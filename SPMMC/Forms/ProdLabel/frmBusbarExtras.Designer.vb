<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusbarExtras
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
        Me.tcExtras = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblItemCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.partnumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.descr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblLotCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.lot_number = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.txtField = New System.Windows.Forms.TextBox()
        Me.lblerr = New System.Windows.Forms.Label()
        Me.efficiency = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tcExtras.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcExtras
        '
        Me.tcExtras.Controls.Add(Me.TabPage1)
        Me.tcExtras.Controls.Add(Me.TabPage2)
        Me.tcExtras.Location = New System.Drawing.Point(12, 77)
        Me.tcExtras.Name = "tcExtras"
        Me.tcExtras.SelectedIndex = 0
        Me.tcExtras.Size = New System.Drawing.Size(514, 237)
        Me.tcExtras.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblItemCount)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(506, 206)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = "ITEMS"
        Me.TabPage1.Text = "Cell Part Number"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblItemCount
        '
        Me.lblItemCount.Location = New System.Drawing.Point(398, 178)
        Me.lblItemCount.Name = "lblItemCount"
        Me.lblItemCount.Size = New System.Drawing.Size(98, 25)
        Me.lblItemCount.TabIndex = 5
        Me.lblItemCount.Text = "-"
        Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(316, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Total Items"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.partnumber, Me.descr, Me.efficiency})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(6, 6)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(494, 169)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'partnumber
        '
        Me.partnumber.Text = "Part Number"
        Me.partnumber.Width = 137
        '
        'descr
        '
        Me.descr.Text = "Description"
        Me.descr.Width = 324
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblLotCount)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.ListView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(506, 206)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Tag = "LOTS"
        Me.TabPage2.Text = "Cell Lot"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblLotCount
        '
        Me.lblLotCount.Location = New System.Drawing.Point(397, 161)
        Me.lblLotCount.Name = "lblLotCount"
        Me.lblLotCount.Size = New System.Drawing.Size(98, 25)
        Me.lblLotCount.TabIndex = 8
        Me.lblLotCount.Text = "-"
        Me.lblLotCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(315, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Total Lots"
        '
        'ListView2
        '
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lot_number})
        Me.ListView2.FullRowSelect = True
        Me.ListView2.Location = New System.Drawing.Point(6, 6)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(494, 148)
        Me.ListView2.TabIndex = 6
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'lot_number
        '
        Me.lot_number.Text = "Lot Number"
        Me.lot_number.Width = 137
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(448, 320)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 27)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(364, 320)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 27)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 18)
        Me.Label2.TabIndex = 9
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(19, 21)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(114, 18)
        Me.lblCaption.TabIndex = 10
        Me.lblCaption.Text = "Cell Part Number"
        '
        'txtField
        '
        Me.txtField.Location = New System.Drawing.Point(159, 18)
        Me.txtField.Name = "txtField"
        Me.txtField.Size = New System.Drawing.Size(357, 26)
        Me.txtField.TabIndex = 11
        '
        'lblerr
        '
        Me.lblerr.AutoSize = True
        Me.lblerr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblerr.ForeColor = System.Drawing.Color.Red
        Me.lblerr.Location = New System.Drawing.Point(158, 47)
        Me.lblerr.Name = "lblerr"
        Me.lblerr.Size = New System.Drawing.Size(0, 14)
        Me.lblerr.TabIndex = 12
        '
        'efficiency
        '
        Me.efficiency.Text = "Efficiency"
        Me.efficiency.Width = 106
        '
        'frmBusbarExtras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(538, 359)
        Me.Controls.Add(Me.lblerr)
        Me.Controls.Add(Me.txtField)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tcExtras)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBusbarExtras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Additional Information"
        Me.tcExtras.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tcExtras As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents lblItemCount As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents partnumber As ColumnHeader
    Friend WithEvents descr As ColumnHeader
    Friend WithEvents lblLotCount As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ListView2 As ListView
    Friend WithEvents lot_number As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents lblCaption As Label
    Friend WithEvents txtField As TextBox
    Friend WithEvents lblerr As Label
    Friend WithEvents efficiency As ColumnHeader
End Class
