﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintLabels
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintLabels))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlCellType = New System.Windows.Forms.Panel()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.pnlCellCount = New System.Windows.Forms.Panel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numQty = New System.Windows.Forms.NumericUpDown()
        Me.cboProdLine = New System.Windows.Forms.ComboBox()
        Me.cboCust = New System.Windows.Forms.ComboBox()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tscboPrinters = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pnlProdType = New System.Windows.Forms.Panel()
        Me.txtProdType = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlSerial = New System.Windows.Forms.Panel()
        Me.txtSerialEnd = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSerialStart = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCellType.SuspendLayout()
        Me.pnlCellCount.SuspendLayout()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlProdType.SuspendLayout()
        Me.pnlSerial.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.pnlCellType)
        Me.GroupBox1.Controls.Add(Me.pnlCellCount)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.numQty)
        Me.GroupBox1.Controls.Add(Me.cboProdLine)
        Me.GroupBox1.Controls.Add(Me.cboCust)
        Me.GroupBox1.Controls.Add(Me.cboType)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 254)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameter Input"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 18)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Quantity"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 18)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Cell Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 18)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Number of Cells"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 18)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Production Line"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Customer"
        '
        'pnlCellType
        '
        Me.pnlCellType.Controls.Add(Me.RadioButton4)
        Me.pnlCellType.Controls.Add(Me.RadioButton3)
        Me.pnlCellType.Location = New System.Drawing.Point(148, 166)
        Me.pnlCellType.Name = "pnlCellType"
        Me.pnlCellType.Size = New System.Drawing.Size(159, 30)
        Me.pnlCellType.TabIndex = 10
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(8, 4)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(62, 22)
        Me.RadioButton4.TabIndex = 5
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Mono"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(83, 4)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(53, 22)
        Me.RadioButton3.TabIndex = 6
        Me.RadioButton3.Text = "Poly"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'pnlCellCount
        '
        Me.pnlCellCount.Controls.Add(Me.RadioButton1)
        Me.pnlCellCount.Controls.Add(Me.RadioButton2)
        Me.pnlCellCount.Location = New System.Drawing.Point(148, 134)
        Me.pnlCellCount.Name = "pnlCellCount"
        Me.pnlCellCount.Size = New System.Drawing.Size(159, 30)
        Me.pnlCellCount.TabIndex = 9
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(8, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(69, 22)
        Me.RadioButton1.TabIndex = 3
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "60-Cell"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(83, 4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(69, 22)
        Me.RadioButton2.TabIndex = 4
        Me.RadioButton2.Text = "72-Cell"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Type of Label"
        '
        'numQty
        '
        Me.numQty.Location = New System.Drawing.Point(148, 202)
        Me.numQty.Name = "numQty"
        Me.numQty.Size = New System.Drawing.Size(216, 26)
        Me.numQty.TabIndex = 7
        Me.numQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboProdLine
        '
        Me.cboProdLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProdLine.FormattingEnabled = True
        Me.cboProdLine.Items.AddRange(New Object() {"Line 1"})
        Me.cboProdLine.Location = New System.Drawing.Point(148, 102)
        Me.cboProdLine.Name = "cboProdLine"
        Me.cboProdLine.Size = New System.Drawing.Size(216, 26)
        Me.cboProdLine.TabIndex = 2
        '
        'cboCust
        '
        Me.cboCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCust.FormattingEnabled = True
        Me.cboCust.Items.AddRange(New Object() {"Runergy"})
        Me.cboCust.Location = New System.Drawing.Point(148, 70)
        Me.cboCust.Name = "cboCust"
        Me.cboCust.Size = New System.Drawing.Size(216, 26)
        Me.cboCust.TabIndex = 1
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Busbar Label", "Frame Label"})
        Me.cboType.Location = New System.Drawing.Point(148, 38)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(216, 26)
        Me.cboType.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.tscboPrinters, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(825, 39)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(104, 36)
        Me.ToolStripButton1.Text = "Print Labels"
        '
        'tscboPrinters
        '
        Me.tscboPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tscboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscboPrinters.Name = "tscboPrinters"
        Me.tscboPrinters.Size = New System.Drawing.Size(300, 39)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(76, 36)
        Me.ToolStripLabel1.Text = "Select Printer"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pnlProdType)
        Me.GroupBox2.Controls.Add(Me.pnlSerial)
        Me.GroupBox2.Location = New System.Drawing.Point(407, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 344)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Module Information"
        '
        'pnlProdType
        '
        Me.pnlProdType.Controls.Add(Me.txtProdType)
        Me.pnlProdType.Controls.Add(Me.Label10)
        Me.pnlProdType.Location = New System.Drawing.Point(6, 134)
        Me.pnlProdType.Name = "pnlProdType"
        Me.pnlProdType.Size = New System.Drawing.Size(394, 58)
        Me.pnlProdType.TabIndex = 20
        '
        'txtProdType
        '
        Me.txtProdType.Location = New System.Drawing.Point(165, 15)
        Me.txtProdType.Name = "txtProdType"
        Me.txtProdType.ReadOnly = True
        Me.txtProdType.Size = New System.Drawing.Size(216, 26)
        Me.txtProdType.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 18)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Product Type"
        '
        'pnlSerial
        '
        Me.pnlSerial.Controls.Add(Me.txtSerialEnd)
        Me.pnlSerial.Controls.Add(Me.Label8)
        Me.pnlSerial.Controls.Add(Me.txtSerialStart)
        Me.pnlSerial.Controls.Add(Me.Label7)
        Me.pnlSerial.Location = New System.Drawing.Point(6, 23)
        Me.pnlSerial.Name = "pnlSerial"
        Me.pnlSerial.Size = New System.Drawing.Size(394, 91)
        Me.pnlSerial.TabIndex = 19
        '
        'txtSerialEnd
        '
        Me.txtSerialEnd.Location = New System.Drawing.Point(165, 47)
        Me.txtSerialEnd.Name = "txtSerialEnd"
        Me.txtSerialEnd.ReadOnly = True
        Me.txtSerialEnd.Size = New System.Drawing.Size(216, 26)
        Me.txtSerialEnd.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 18)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "End Serial"
        '
        'txtSerialStart
        '
        Me.txtSerialStart.Location = New System.Drawing.Point(165, 15)
        Me.txtSerialStart.Name = "txtSerialStart"
        Me.txtSerialStart.ReadOnly = True
        Me.txtSerialStart.Size = New System.Drawing.Size(216, 26)
        Me.txtSerialStart.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 18)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Start Serial"
        '
        'frmPrintLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(825, 399)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPrintLabels"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Labels"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlCellType.ResumeLayout(False)
        Me.pnlCellType.PerformLayout()
        Me.pnlCellCount.ResumeLayout(False)
        Me.pnlCellCount.PerformLayout()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlProdType.ResumeLayout(False)
        Me.pnlProdType.PerformLayout()
        Me.pnlSerial.ResumeLayout(False)
        Me.pnlSerial.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents cboProdLine As ComboBox
    Friend WithEvents cboCust As ComboBox
    Friend WithEvents cboType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlCellType As Panel
    Friend WithEvents pnlCellCount As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSerialEnd As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSerialStart As TextBox
    Friend WithEvents pnlProdType As Panel
    Friend WithEvents txtProdType As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents pnlSerial As Panel
    Friend WithEvents tscboPrinters As ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
End Class