<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.chkPrimAD = New System.Windows.Forms.CheckBox()
    Me.chkPrimNotAD = New System.Windows.Forms.CheckBox()
    Me.chkSecondary = New System.Windows.Forms.CheckBox()
    Me.lstZones = New System.Windows.Forms.ListBox()
    Me.lblFound = New System.Windows.Forms.Label()
    Me.btnBoot = New System.Windows.Forms.Button()
    Me.btnAD = New System.Windows.Forms.Button()
    Me.btnExit = New System.Windows.Forms.Button()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.lnkSource = New System.Windows.Forms.LinkLabel()
    Me.SuspendLayout()
    '
    'chkPrimAD
    '
    Me.chkPrimAD.AutoSize = True
    Me.chkPrimAD.Checked = True
    Me.chkPrimAD.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkPrimAD.Location = New System.Drawing.Point(15, 36)
    Me.chkPrimAD.Name = "chkPrimAD"
    Me.chkPrimAD.Size = New System.Drawing.Size(220, 17)
    Me.chkPrimAD.TabIndex = 0
    Me.chkPrimAD.Text = "Primary zones - Stored in Active Directory"
    Me.chkPrimAD.UseVisualStyleBackColor = True
    '
    'chkPrimNotAD
    '
    Me.chkPrimNotAD.AutoSize = True
    Me.chkPrimNotAD.Checked = True
    Me.chkPrimNotAD.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkPrimNotAD.Location = New System.Drawing.Point(15, 59)
    Me.chkPrimNotAD.Name = "chkPrimNotAD"
    Me.chkPrimNotAD.Size = New System.Drawing.Size(238, 17)
    Me.chkPrimNotAD.TabIndex = 1
    Me.chkPrimNotAD.Text = "Primary zones - Not stored in Active Directory"
    Me.chkPrimNotAD.UseVisualStyleBackColor = True
    '
    'chkSecondary
    '
    Me.chkSecondary.AutoSize = True
    Me.chkSecondary.Checked = True
    Me.chkSecondary.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkSecondary.Location = New System.Drawing.Point(15, 82)
    Me.chkSecondary.Name = "chkSecondary"
    Me.chkSecondary.Size = New System.Drawing.Size(108, 17)
    Me.chkSecondary.TabIndex = 2
    Me.chkSecondary.Text = "Secondary zones"
    Me.chkSecondary.UseVisualStyleBackColor = True
    '
    'lstZones
    '
    Me.lstZones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lstZones.FormattingEnabled = True
    Me.lstZones.IntegralHeight = False
    Me.lstZones.Location = New System.Drawing.Point(12, 135)
    Me.lstZones.Name = "lstZones"
    Me.lstZones.SelectionMode = System.Windows.Forms.SelectionMode.None
    Me.lstZones.Size = New System.Drawing.Size(540, 194)
    Me.lstZones.TabIndex = 3
    '
    'lblFound
    '
    Me.lblFound.AutoSize = True
    Me.lblFound.Location = New System.Drawing.Point(12, 119)
    Me.lblFound.Name = "lblFound"
    Me.lblFound.Size = New System.Drawing.Size(10, 13)
    Me.lblFound.TabIndex = 4
    Me.lblFound.Text = "-"
    '
    'btnBoot
    '
    Me.btnBoot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.btnBoot.Enabled = False
    Me.btnBoot.Location = New System.Drawing.Point(12, 335)
    Me.btnBoot.Name = "btnBoot"
    Me.btnBoot.Size = New System.Drawing.Size(123, 23)
    Me.btnBoot.TabIndex = 5
    Me.btnBoot.Text = "Export Boot file"
    Me.btnBoot.UseVisualStyleBackColor = True
    '
    'btnAD
    '
    Me.btnAD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.btnAD.Enabled = False
    Me.btnAD.Location = New System.Drawing.Point(141, 335)
    Me.btnAD.Name = "btnAD"
    Me.btnAD.Size = New System.Drawing.Size(225, 23)
    Me.btnAD.TabIndex = 6
    Me.btnAD.Text = "Export zones stored in Active Directory"
    Me.btnAD.UseVisualStyleBackColor = True
    '
    'btnExit
    '
    Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnExit.Location = New System.Drawing.Point(477, 335)
    Me.btnExit.Name = "btnExit"
    Me.btnExit.Size = New System.Drawing.Size(75, 23)
    Me.btnExit.TabIndex = 7
    Me.btnExit.Text = "Exit"
    Me.btnExit.UseVisualStyleBackColor = True
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.CheckFileExists = False
    Me.OpenFileDialog1.Filter = "dnscmd.exe|dnscmd.exe"
    Me.OpenFileDialog1.Title = "Specify location of dnscmd.exe"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(94, 13)
    Me.Label1.TabIndex = 8
    Me.Label1.Text = "Select zone types:"
    '
    'lnkSource
    '
    Me.lnkSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lnkSource.AutoSize = True
    Me.lnkSource.LinkArea = New System.Windows.Forms.LinkArea(67, 41)
    Me.lnkSource.Location = New System.Drawing.Point(12, 374)
    Me.lnkSource.Name = "lnkSource"
    Me.lnkSource.Size = New System.Drawing.Size(540, 17)
    Me.lnkSource.TabIndex = 9
    Me.lnkSource.TabStop = True
    Me.lnkSource.Text = "Information and source code for this freeware tool is available at https://github" &
    ".com/jhsoftware/msdnsexport"
    Me.lnkSource.UseCompatibleTextRendering = True
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(564, 396)
    Me.Controls.Add(Me.lnkSource)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.btnExit)
    Me.Controls.Add(Me.btnAD)
    Me.Controls.Add(Me.btnBoot)
    Me.Controls.Add(Me.lstZones)
    Me.Controls.Add(Me.lblFound)
    Me.Controls.Add(Me.chkSecondary)
    Me.Controls.Add(Me.chkPrimNotAD)
    Me.Controls.Add(Me.chkPrimAD)
    Me.MinimumSize = New System.Drawing.Size(580, 400)
    Me.Name = "Form1"
    Me.ShowIcon = False
    Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
    Me.Text = "Export Boot file / Active Directory zones from Microsoft DNS server"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents chkPrimAD As CheckBox
  Friend WithEvents chkPrimNotAD As CheckBox
  Friend WithEvents chkSecondary As CheckBox
  Friend WithEvents lstZones As ListBox
  Friend WithEvents lblFound As Label
  Friend WithEvents btnBoot As Button
  Friend WithEvents btnAD As Button
  Friend WithEvents btnExit As Button
  Friend WithEvents OpenFileDialog1 As OpenFileDialog
  Friend WithEvents Label1 As Label
  Friend WithEvents lnkSource As LinkLabel
End Class
