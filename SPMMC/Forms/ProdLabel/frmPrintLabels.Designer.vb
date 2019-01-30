<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.cboCell = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlCellType = New System.Windows.Forms.Panel()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.txtTop = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboModel = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtProdDate = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCellType.SuspendLayout()
        Me.pnlCellCount.SuspendLayout()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlProdType.SuspendLayout()
        Me.pnlSerial.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtProdDate)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cboModel)
        Me.GroupBox1.Controls.Add(Me.cboCell)
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
        Me.GroupBox1.Size = New System.Drawing.Size(448, 282)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameter Input"
        '
        'cboCell
        '
        Me.cboCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCell.Enabled = False
        Me.cboCell.FormattingEnabled = True
        Me.cboCell.Location = New System.Drawing.Point(370, 146)
        Me.cboCell.Name = "cboCell"
        Me.cboCell.Size = New System.Drawing.Size(62, 26)
        Me.cboCell.TabIndex = 4
        Me.cboCell.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 18)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Quantity"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 18)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Cell Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 18)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Number of Cells"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 18)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Production Line"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Customer"
        '
        'pnlCellType
        '
        Me.pnlCellType.Controls.Add(Me.RadioButton5)
        Me.pnlCellType.Controls.Add(Me.RadioButton4)
        Me.pnlCellType.Controls.Add(Me.RadioButton3)
        Me.pnlCellType.Enabled = False
        Me.pnlCellType.Location = New System.Drawing.Point(148, 210)
        Me.pnlCellType.Name = "pnlCellType"
        Me.pnlCellType.Size = New System.Drawing.Size(284, 30)
        Me.pnlCellType.TabIndex = 6
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(154, 4)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(96, 22)
        Me.RadioButton5.TabIndex = 7
        Me.RadioButton5.Tag = "E"
        Me.RadioButton5.Text = "Mono PERC"
        Me.RadioButton5.UseVisualStyleBackColor = True
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
        Me.RadioButton4.Tag = "M"
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
        Me.RadioButton3.Tag = "P"
        Me.RadioButton3.Text = "Poly"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'pnlCellCount
        '
        Me.pnlCellCount.Controls.Add(Me.RadioButton1)
        Me.pnlCellCount.Controls.Add(Me.RadioButton2)
        Me.pnlCellCount.Enabled = False
        Me.pnlCellCount.Location = New System.Drawing.Point(148, 178)
        Me.pnlCellCount.Name = "pnlCellCount"
        Me.pnlCellCount.Size = New System.Drawing.Size(159, 30)
        Me.pnlCellCount.TabIndex = 5
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
        Me.Label1.Location = New System.Drawing.Point(20, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Type of Label"
        '
        'numQty
        '
        Me.numQty.Location = New System.Drawing.Point(148, 246)
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
        Me.cboProdLine.Location = New System.Drawing.Point(148, 82)
        Me.cboProdLine.Name = "cboProdLine"
        Me.cboProdLine.Size = New System.Drawing.Size(216, 26)
        Me.cboProdLine.TabIndex = 1
        '
        'cboCust
        '
        Me.cboCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCust.Enabled = False
        Me.cboCust.FormattingEnabled = True
        Me.cboCust.Items.AddRange(New Object() {"Runergy", "Own-Tongwei"})
        Me.cboCust.Location = New System.Drawing.Point(148, 146)
        Me.cboCust.Name = "cboCust"
        Me.cboCust.Size = New System.Drawing.Size(216, 26)
        Me.cboCust.TabIndex = 3
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Busbar Label", "Frame Label"})
        Me.cboType.Location = New System.Drawing.Point(148, 50)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(216, 26)
        Me.cboType.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.tscboPrinters, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(884, 39)
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
        Me.GroupBox2.Location = New System.Drawing.Point(466, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 383)
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtLeft)
        Me.GroupBox3.Controls.Add(Me.txtTop)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 330)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(448, 95)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Adjust Margins"
        '
        'txtLeft
        '
        Me.txtLeft.Location = New System.Drawing.Point(147, 57)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(100, 26)
        Me.txtLeft.TabIndex = 19
        Me.txtLeft.Tag = "2"
        Me.txtLeft.Text = "0.00"
        '
        'txtTop
        '
        Me.txtTop.Location = New System.Drawing.Point(147, 25)
        Me.txtTop.Name = "txtTop"
        Me.txtTop.Size = New System.Drawing.Size(100, 26)
        Me.txtTop.TabIndex = 18
        Me.txtTop.Tag = "2"
        Me.txtTop.Text = "0.00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 18)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Left"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 18)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Top"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 18)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Model"
        '
        'cboModel
        '
        Me.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModel.FormattingEnabled = True
        Me.cboModel.Items.AddRange(New Object() {"Runergy", "Own-Tongwei"})
        Me.cboModel.Location = New System.Drawing.Point(148, 114)
        Me.cboModel.Name = "cboModel"
        Me.cboModel.Size = New System.Drawing.Size(216, 26)
        Me.cboModel.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 18)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Production Date"
        '
        'txtProdDate
        '
        Me.txtProdDate.Location = New System.Drawing.Point(148, 18)
        Me.txtProdDate.Name = "txtProdDate"
        Me.txtProdDate.ReadOnly = True
        Me.txtProdDate.Size = New System.Drawing.Size(216, 26)
        Me.txtProdDate.TabIndex = 20
        '
        'frmPrintLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(884, 437)
        Me.Controls.Add(Me.GroupBox3)
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
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtLeft As TextBox
    Friend WithEvents txtTop As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cboCell As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cboModel As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtProdDate As TextBox
End Class
