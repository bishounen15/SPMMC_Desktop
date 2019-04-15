<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmELPath
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDest = New System.Windows.Forms.Button()
        Me.txtDest = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnEL2MC = New System.Windows.Forms.Button()
        Me.btnJBOXDump = New System.Windows.Forms.Button()
        Me.btnEL2Dump = New System.Windows.Forms.Button()
        Me.btnEL1Dump = New System.Windows.Forms.Button()
        Me.txtEL2MC = New System.Windows.Forms.TextBox()
        Me.txtJBOXDump = New System.Windows.Forms.TextBox()
        Me.txtEL2Dump = New System.Windows.Forms.TextBox()
        Me.txtEL1Dump = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtContainerNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtContainerNo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnDest)
        Me.GroupBox1.Controls.Add(Me.txtDest)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnEL2MC)
        Me.GroupBox1.Controls.Add(Me.btnJBOXDump)
        Me.GroupBox1.Controls.Add(Me.btnEL2Dump)
        Me.GroupBox1.Controls.Add(Me.btnEL1Dump)
        Me.GroupBox1.Controls.Add(Me.txtEL2MC)
        Me.GroupBox1.Controls.Add(Me.txtJBOXDump)
        Me.GroupBox1.Controls.Add(Me.txtEL2Dump)
        Me.GroupBox1.Controls.Add(Me.txtEL1Dump)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(453, 249)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Source Path Setup"
        '
        'btnDest
        '
        Me.btnDest.Location = New System.Drawing.Point(414, 186)
        Me.btnDest.Name = "btnDest"
        Me.btnDest.Size = New System.Drawing.Size(30, 23)
        Me.btnDest.TabIndex = 14
        Me.btnDest.Text = "..."
        Me.btnDest.UseVisualStyleBackColor = True
        '
        'txtDest
        '
        Me.txtDest.Location = New System.Drawing.Point(114, 186)
        Me.txtDest.Name = "txtDest"
        Me.txtDest.Size = New System.Drawing.Size(294, 23)
        Me.txtDest.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Destination Path"
        '
        'btnEL2MC
        '
        Me.btnEL2MC.Location = New System.Drawing.Point(414, 120)
        Me.btnEL2MC.Name = "btnEL2MC"
        Me.btnEL2MC.Size = New System.Drawing.Size(30, 23)
        Me.btnEL2MC.TabIndex = 11
        Me.btnEL2MC.Text = "..."
        Me.btnEL2MC.UseVisualStyleBackColor = True
        '
        'btnJBOXDump
        '
        Me.btnJBOXDump.Location = New System.Drawing.Point(414, 91)
        Me.btnJBOXDump.Name = "btnJBOXDump"
        Me.btnJBOXDump.Size = New System.Drawing.Size(30, 23)
        Me.btnJBOXDump.TabIndex = 10
        Me.btnJBOXDump.Text = "..."
        Me.btnJBOXDump.UseVisualStyleBackColor = True
        '
        'btnEL2Dump
        '
        Me.btnEL2Dump.Location = New System.Drawing.Point(414, 62)
        Me.btnEL2Dump.Name = "btnEL2Dump"
        Me.btnEL2Dump.Size = New System.Drawing.Size(30, 23)
        Me.btnEL2Dump.TabIndex = 9
        Me.btnEL2Dump.Text = "..."
        Me.btnEL2Dump.UseVisualStyleBackColor = True
        '
        'btnEL1Dump
        '
        Me.btnEL1Dump.Location = New System.Drawing.Point(414, 33)
        Me.btnEL1Dump.Name = "btnEL1Dump"
        Me.btnEL1Dump.Size = New System.Drawing.Size(30, 23)
        Me.btnEL1Dump.TabIndex = 8
        Me.btnEL1Dump.Text = "..."
        Me.btnEL1Dump.UseVisualStyleBackColor = True
        '
        'txtEL2MC
        '
        Me.txtEL2MC.Location = New System.Drawing.Point(114, 120)
        Me.txtEL2MC.Name = "txtEL2MC"
        Me.txtEL2MC.Size = New System.Drawing.Size(294, 23)
        Me.txtEL2MC.TabIndex = 7
        '
        'txtJBOXDump
        '
        Me.txtJBOXDump.Location = New System.Drawing.Point(114, 91)
        Me.txtJBOXDump.Name = "txtJBOXDump"
        Me.txtJBOXDump.Size = New System.Drawing.Size(294, 23)
        Me.txtJBOXDump.TabIndex = 6
        '
        'txtEL2Dump
        '
        Me.txtEL2Dump.Location = New System.Drawing.Point(114, 62)
        Me.txtEL2Dump.Name = "txtEL2Dump"
        Me.txtEL2Dump.Size = New System.Drawing.Size(294, 23)
        Me.txtEL2Dump.TabIndex = 5
        '
        'txtEL1Dump
        '
        Me.txtEL1Dump.Location = New System.Drawing.Point(114, 33)
        Me.txtEL1Dump.Name = "txtEL1Dump"
        Me.txtEL1Dump.Size = New System.Drawing.Size(294, 23)
        Me.txtEL1Dump.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "EL2 Machine"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "JBOX Dump"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "EL2 Dump"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EL1 Dump"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(390, 267)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(309, 267)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(228, 267)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtContainerNo
        '
        Me.txtContainerNo.Location = New System.Drawing.Point(114, 215)
        Me.txtContainerNo.Name = "txtContainerNo"
        Me.txtContainerNo.Size = New System.Drawing.Size(294, 23)
        Me.txtContainerNo.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Container No."
        '
        'frmELPath
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(477, 302)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmELPath"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Source Path for EL Images"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEL2MC As Button
    Friend WithEvents btnJBOXDump As Button
    Friend WithEvents btnEL2Dump As Button
    Friend WithEvents btnEL1Dump As Button
    Friend WithEvents txtEL2MC As TextBox
    Friend WithEvents txtJBOXDump As TextBox
    Friend WithEvents txtEL2Dump As TextBox
    Friend WithEvents txtEL1Dump As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnApply As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnDest As Button
    Friend WithEvents txtDest As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtContainerNo As TextBox
    Friend WithEvents Label6 As Label
End Class
