Public Class Form1
  Private Ready As Boolean
  Private DnsPath As String = Environment.SystemDirectory & "\dns"
  Private UsedFileNames As Dictionary(Of String, Object)

  Private Sub x_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrimAD.CheckedChanged, chkPrimNotAD.CheckedChanged, chkSecondary.CheckedChanged
    RefreshList()
  End Sub

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
    Ready = True
    RefreshList()
  End Sub

  Private Sub RefreshList()
    If Not Ready Then Exit Sub
    lstZones.Items.Clear()
    UsedFileNames = New Dictionary(Of String, Object)
    Dim kn = "SOFTWARE\Microsoft\Windows NT\CurrentVersion\DNS Server\Zones"
    Dim k = My.Computer.Registry.LocalMachine.OpenSubKey(kn)
    If k Is Nothing Then
      MessageBox.Show("Could not open registry key for Microsoft DNS server zones" & vbCrLf &
                      "(HKLM\" & kn & ")." & vbCrLf & vbCrLf &
                      "Is Microsoft DNS server installed on this computer?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End
    End If
    Dim skn = k.GetSubKeyNames()
    Dim zk As Microsoft.Win32.RegistryKey
    Dim z As Zone
    Dim AdCt = 0
    For Each zn In k.GetSubKeyNames()
      zk = k.OpenSubKey(zn)
      z = New Zone
      z.Name = zn
      Select Case CInt(zk.GetValue("Type"))
        Case 1 'primary
          z.Secondary = False
          Dim obj = zk.GetValue("DsIntegrated")
          If obj IsNot Nothing AndAlso CInt(obj) <> 0 Then
            If Not chkPrimAD.Checked Then zk.Close() : Continue For
            z.AD = True
            AdCt += 1
          Else
            If Not chkPrimNotAD.Checked Then zk.Close() : Continue For
            z.AD = False
            z.File = CStr(zk.GetValue("DatabaseFile"))
          End If
        Case 2 'secondary
          If Not chkSecondary.Checked Then zk.Close() : Continue For
          z.Secondary = True
          z.File = CStr(zk.GetValue("DatabaseFile"))
          Dim obj = zk.GetValue("MasterServers")
          If obj Is Nothing Then zk.Close() : Continue For
          If TypeOf obj Is String() Then
            Dim x = CType(obj, String())
            If x.Length = 0 Then zk.Close() : Continue For 'No masters? Skip 
            z.Master = x(0)
          Else
            Dim x = CStr(obj)
            If x.Length = 0 Then zk.Close() : Continue For
            z.Master = x.Substring(0, (x & " ").IndexOf(" "))
          End If
        Case Else
          REM skip it
          zk.Close()
          Continue For
      End Select
      zk.Close()
      lstZones.Items.Add(z)
      If z.File IsNot Nothing AndAlso Not UsedFileNames.ContainsKey(z.File) Then UsedFileNames.Add(z.File, Nothing)
    Next
    k.Close()
    lblFound.Text = "Found " & If(lstZones.Items.Count = 0, "no", lstZones.Items.Count.ToString) & " matching zones:"
    btnBoot.Enabled = lstZones.Items.Count > 0
    btnAD.Enabled = AdCt > 0
  End Sub

  Class Zone
    Friend Name As String
    Friend File As String
    Friend Secondary As Boolean
    Friend AD As Boolean
    Friend Master As String

    Public Overrides Function ToString() As String
      Dim rv = Name & " ["
      If Secondary Then
        rv &= "Secondary - " & Master
      Else
        rv &= "Primary"

        If AD Then
          rv &= " AD"
        Else
          rv &= " Non-AD"
        End If
      End If
      rv &= "]"
      Return rv
    End Function
  End Class

  Private Sub btnBoot_Click(sender As Object, e As EventArgs) Handles btnBoot.Click
    Dim fn = DnsPath & "\boot"
    Dim f = My.Computer.FileSystem.OpenTextFileWriter(fn, False, System.Text.Encoding.ASCII)
    For Each itm As Zone In lstZones.Items
      If itm.Secondary Then
        f.WriteLine("Secondary" & vbTab & itm.Name & vbTab & itm.Master & vbTab & itm.File)
      Else
        f.WriteLine("Primary  " & vbTab & itm.Name & vbTab & itm.File)
      End If
    Next
    f.Close()
    MessageBox.Show("Boot file saved as '" & fn & "'", "Save boot file", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
    Me.Close()
  End Sub

  Private Sub btnAD_Click(sender As Object, e As EventArgs) Handles btnAD.Click
    Dim cp = Environment.SystemDirectory & "\dnscmd.exe"
    If Not My.Computer.FileSystem.FileExists(cp) Then
      cp = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) & "\Support Tools\dnscmd.exe"
      If Not My.Computer.FileSystem.FileExists(cp) Then
        If OpenFileDialog1.ShowDialog <> DialogResult.OK Then Exit Sub
        cp = OpenFileDialog1.FileName
      End If
    End If

    Dim p As Process, os As String
    Dim ct = 0
    For Each z As Zone In lstZones.Items
      If Not z.AD Then Continue For
      If z.File Is Nothing Then
        z.File = MakeUpFileName(z.Name)
        UsedFileNames.Add(z.File, Nothing)
      End If
      Try
        My.Computer.FileSystem.DeleteFile(DnsPath & "\" & z.File)
      Catch
      End Try
      p = New Process()
      p.StartInfo.CreateNoWindow = True
      p.StartInfo.UseShellExecute = False
      p.StartInfo.RedirectStandardOutput = True
      p.StartInfo.FileName = cp
      p.StartInfo.Arguments = "/ZoneExport " & z.Name & " " & z.File
      p.Start()
      os = p.StandardOutput.ReadToEnd()
      p.WaitForExit()
      If p.ExitCode <> 0 Then
        MessageBox.Show("Could not export zone '" & z.Name & "'." & vbCrLf & vbCrLf &
          "dnscmd.exe returned exit code " & p.ExitCode & " and this output:" & vbCrLf & vbCrLf &
          os, "Export failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If
      ct += 1
    Next
    MessageBox.Show(ct & " zone" & If(ct > 1, "s", "") & " exported to" & vbCrLf & "'" & DnsPath & "'", "Export successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Private Function MakeUpFileName(ByVal zName As String) As String
    Dim BaseFName As String
    Dim i As Integer
    If zName = "." Or zName = "" Then
      BaseFName = "_root"
    Else
      Dim b() As Char = zName.ToLower.ToCharArray
      For i = 0 To b.Length - 1
        If "abcdefghijlkmnopqrstuvwxyz1234567890._-".IndexOf(b(i)) < 0 Then b(i) = "_"c
      Next
      BaseFName = b
    End If
    If BaseFName.Chars(0) = "."c Then BaseFName = "_" & BaseFName.Substring(1)

    If BadFileName(BaseFName & ".dns") Then BaseFName = "_" & BaseFName

    If UsedFileNames.ContainsKey(BaseFName & ".dns") Then
      i = 2
      While UsedFileNames.ContainsKey(BaseFName & "_" & i & ".dns")
        i += 1
      End While
      BaseFName &= "_" & i
    End If
    BaseFName &= ".dns"
    Return BaseFName
  End Function

  Private Function BadFileName(ByVal s As String) As Boolean
    If s.Length < 4 Then Return False
    Dim x = s.Substring(0, 4)
    If x = "con." Or x = "prn." Or x = "aux." Or x = "nul." Then Return True
    If s.Length < 5 Then Return False
    x = s.Substring(0, 3)
    If (x = "com" Or x = "lpt") AndAlso s(3) >= "0"c AndAlso s(3) <= "9"c AndAlso s(4) = "."c Then Return True
    Return False
  End Function

  Private Sub lnkSource_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSource.LinkClicked
    Dim url = lnkSource.Text.Substring(lnkSource.Links(0).Start, lnkSource.Links(0).Length)
    Try
      System.Diagnostics.Process.Start(url)
    Catch ex As Exception
      MessageBox.Show("Could not open your browser :-(", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub
End Class
