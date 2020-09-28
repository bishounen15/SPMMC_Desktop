<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLot
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CommandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lot1 = New System.Windows.Forms.TextBox()
        Me.lot2 = New System.Windows.Forms.TextBox()
        Me.lot3 = New System.Windows.Forms.TextBox()
        Me.lot4 = New System.Windows.Forms.TextBox()
        Me.lot5 = New System.Windows.Forms.TextBox()
        Me.caption1 = New System.Windows.Forms.Label()
        Me.caption2 = New System.Windows.Forms.Label()
        Me.caption3 = New System.Windows.Forms.Label()
        Me.caption4 = New System.Windows.Forms.Label()
        Me.caption5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CommandsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(402, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'CommandsToolStripMenuItem
        '
        Me.CommandsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.CancelToolStripMenuItem})
        Me.CommandsToolStripMenuItem.Name = "CommandsToolStripMenuItem"
        Me.CommandsToolStripMenuItem.Size = New System.Drawing.Size(81, 19)
        Me.CommandsToolStripMenuItem.Text = "Commands"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.caption5)
        Me.GroupBox1.Controls.Add(Me.caption4)
        Me.GroupBox1.Controls.Add(Me.caption3)
        Me.GroupBox1.Controls.Add(Me.caption2)
        Me.GroupBox1.Controls.Add(Me.caption1)
        Me.GroupBox1.Controls.Add(Me.lot5)
        Me.GroupBox1.Controls.Add(Me.lot4)
        Me.GroupBox1.Controls.Add(Me.lot3)
        Me.GroupBox1.Controls.Add(Me.lot2)
        Me.GroupBox1.Controls.Add(Me.lot1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 200)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Scan / Enter Lot Number"
        '
        'lot1
        '
        Me.lot1.Location = New System.Drawing.Point(135, 33)
        Me.lot1.Name = "lot1"
        Me.lot1.Size = New System.Drawing.Size(214, 24)
        Me.lot1.TabIndex = 0
        '
        'lot2
        '
        Me.lot2.Location = New System.Drawing.Point(135, 63)
        Me.lot2.Name = "lot2"
        Me.lot2.Size = New System.Drawing.Size(214, 24)
        Me.lot2.TabIndex = 1
        '
        'lot3
        '
        Me.lot3.Location = New System.Drawing.Point(135, 93)
        Me.lot3.Name = "lot3"
        Me.lot3.Size = New System.Drawing.Size(214, 24)
        Me.lot3.TabIndex = 2
        '
        'lot4
        '
        Me.lot4.Location = New System.Drawing.Point(135, 123)
        Me.lot4.Name = "lot4"
        Me.lot4.Size = New System.Drawing.Size(214, 24)
        Me.lot4.TabIndex = 3
        '
        'lot5
        '
        Me.lot5.Location = New System.Drawing.Point(135, 153)
        Me.lot5.Name = "lot5"
        Me.lot5.Size = New System.Drawing.Size(214, 24)
        Me.lot5.TabIndex = 4
        '
        'caption1
        '
        Me.caption1.AutoSize = True
        Me.caption1.Location = New System.Drawing.Point(19, 36)
        Me.caption1.Name = "caption1"
        Me.caption1.Size = New System.Drawing.Size(88, 18)
        Me.caption1.TabIndex = 1
        Me.caption1.Tag = "FRAMING"
        Me.caption1.Text = "Long Frame"
        '
        'caption2
        '
        Me.caption2.AutoSize = True
        Me.caption2.Location = New System.Drawing.Point(19, 66)
        Me.caption2.Name = "caption2"
        Me.caption2.Size = New System.Drawing.Size(91, 18)
        Me.caption2.TabIndex = 2
        Me.caption2.Tag = "FRAMING"
        Me.caption2.Text = "Short Frame"
        '
        'caption3
        '
        Me.caption3.AutoSize = True
        Me.caption3.Location = New System.Drawing.Point(19, 96)
        Me.caption3.Name = "caption3"
        Me.caption3.Size = New System.Drawing.Size(104, 18)
        Me.caption3.TabIndex = 3
        Me.caption3.Tag = "FRAMING"
        Me.caption3.Text = "Frame Sealant"
        '
        'caption4
        '
        Me.caption4.AutoSize = True
        Me.caption4.Location = New System.Drawing.Point(19, 126)
        Me.caption4.Name = "caption4"
        Me.caption4.Size = New System.Drawing.Size(55, 18)
        Me.caption4.TabIndex = 3
        Me.caption4.Tag = "JBOX"
        Me.caption4.Text = "Pottant"
        '
        'caption5
        '
        Me.caption5.AutoSize = True
        Me.caption5.Location = New System.Drawing.Point(19, 156)
        Me.caption5.Name = "caption5"
        Me.caption5.Size = New System.Drawing.Size(48, 18)
        Me.caption5.TabIndex = 3
        Me.caption5.Tag = "JBOX"
        Me.caption5.Text = "JBOX"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(12, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(378, 30)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Press [F1] to Continue"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(12, 245)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(378, 30)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Press [F8] to Cancel"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmLot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(402, 284)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Record Material Lot"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CommandsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents caption5 As Label
    Friend WithEvents caption4 As Label
    Friend WithEvents caption3 As Label
    Friend WithEvents caption2 As Label
    Friend WithEvents caption1 As Label
    Friend WithEvents lot5 As TextBox
    Friend WithEvents lot4 As TextBox
    Friend WithEvents lot3 As TextBox
    Friend WithEvents lot2 As TextBox
    Friend WithEvents lot1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
