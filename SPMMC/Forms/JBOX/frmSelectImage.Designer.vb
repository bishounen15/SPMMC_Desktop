<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectImage
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
        Me.lstImage = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnUse = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstImage
        '
        Me.lstImage.FormattingEnabled = True
        Me.lstImage.ItemHeight = 18
        Me.lstImage.Location = New System.Drawing.Point(12, 37)
        Me.lstImage.Name = "lstImage"
        Me.lstImage.Size = New System.Drawing.Size(251, 310)
        Me.lstImage.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Captured Image List"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 359)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Total Images:"
        '
        'lblCount
        '
        Me.lblCount.Location = New System.Drawing.Point(150, 359)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(113, 18)
        Me.lblCount.TabIndex = 3
        Me.lblCount.Text = "-"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picPreview
        '
        Me.picPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPreview.BackColor = System.Drawing.Color.Black
        Me.picPreview.Location = New System.Drawing.Point(270, 37)
        Me.picPreview.Margin = New System.Windows.Forms.Padding(4)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(464, 310)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPreview.TabIndex = 4
        Me.picPreview.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(267, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Image Preview"
        '
        'btnUse
        '
        Me.btnUse.Location = New System.Drawing.Point(500, 354)
        Me.btnUse.Name = "btnUse"
        Me.btnUse.Size = New System.Drawing.Size(114, 31)
        Me.btnUse.TabIndex = 6
        Me.btnUse.Text = "Use Selected"
        Me.btnUse.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(620, 354)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(114, 31)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmSelectImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(747, 393)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUse)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.picPreview)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstImage)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmSelectImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Image"
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstImage As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents picPreview As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnUse As Button
    Friend WithEvents btnCancel As Button
End Class
