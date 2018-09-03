<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOnlineLabel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOnlineLabel))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tscboPrinters = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSerial = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDimension = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtIsc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVoc = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtImpp = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtVmpp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPower = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSerialNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkPreview = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.tscboPrinters, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(884, 39)
        Me.ToolStrip1.TabIndex = 2
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkPreview)
        Me.GroupBox1.Controls.Add(Me.txtSerial)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(448, 90)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameter Input"
        '
        'txtSerial
        '
        Me.txtSerial.Location = New System.Drawing.Point(145, 22)
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.Size = New System.Drawing.Size(273, 26)
        Me.txtSerial.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Scan Serial"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDimension)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtCustomer)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtIsc)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtVoc)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtImpp)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtVmpp)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtPower)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtModel)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtType)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCount)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSerialNo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(466, 43)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 344)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Last Label Printed"
        '
        'txtDimension
        '
        Me.txtDimension.Location = New System.Drawing.Point(127, 309)
        Me.txtDimension.Name = "txtDimension"
        Me.txtDimension.ReadOnly = True
        Me.txtDimension.Size = New System.Drawing.Size(273, 26)
        Me.txtDimension.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 312)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 18)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Dimension"
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(127, 85)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(273, 26)
        Me.txtCustomer.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 88)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 18)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Customer"
        '
        'txtIsc
        '
        Me.txtIsc.Location = New System.Drawing.Point(127, 277)
        Me.txtIsc.Name = "txtIsc"
        Me.txtIsc.ReadOnly = True
        Me.txtIsc.Size = New System.Drawing.Size(111, 26)
        Me.txtIsc.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 280)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 18)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Isc"
        '
        'txtVoc
        '
        Me.txtVoc.Location = New System.Drawing.Point(127, 245)
        Me.txtVoc.Name = "txtVoc"
        Me.txtVoc.ReadOnly = True
        Me.txtVoc.Size = New System.Drawing.Size(111, 26)
        Me.txtVoc.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 18)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Voc"
        '
        'txtImpp
        '
        Me.txtImpp.Location = New System.Drawing.Point(127, 213)
        Me.txtImpp.Name = "txtImpp"
        Me.txtImpp.ReadOnly = True
        Me.txtImpp.Size = New System.Drawing.Size(111, 26)
        Me.txtImpp.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 18)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Impp"
        '
        'txtVmpp
        '
        Me.txtVmpp.Location = New System.Drawing.Point(127, 181)
        Me.txtVmpp.Name = "txtVmpp"
        Me.txtVmpp.ReadOnly = True
        Me.txtVmpp.Size = New System.Drawing.Size(111, 26)
        Me.txtVmpp.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 18)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Vmpp"
        '
        'txtPower
        '
        Me.txtPower.Location = New System.Drawing.Point(127, 149)
        Me.txtPower.Name = "txtPower"
        Me.txtPower.ReadOnly = True
        Me.txtPower.Size = New System.Drawing.Size(111, 26)
        Me.txtPower.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 18)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Power"
        '
        'txtModel
        '
        Me.txtModel.Location = New System.Drawing.Point(127, 117)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.ReadOnly = True
        Me.txtModel.Size = New System.Drawing.Size(273, 26)
        Me.txtModel.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 18)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Model Name"
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(339, 53)
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.Size = New System.Drawing.Size(61, 26)
        Me.txtType.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 18)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Cell Type"
        '
        'txtCount
        '
        Me.txtCount.Location = New System.Drawing.Point(127, 53)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.ReadOnly = True
        Me.txtCount.Size = New System.Drawing.Size(61, 26)
        Me.txtCount.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 18)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Cell Count"
        '
        'txtSerialNo
        '
        Me.txtSerialNo.Location = New System.Drawing.Point(127, 21)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.ReadOnly = True
        Me.txtSerialNo.Size = New System.Drawing.Size(273, 26)
        Me.txtSerialNo.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 18)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Serial Number"
        '
        'chkPreview
        '
        Me.chkPreview.AutoSize = True
        Me.chkPreview.Location = New System.Drawing.Point(145, 56)
        Me.chkPreview.Name = "chkPreview"
        Me.chkPreview.Size = New System.Drawing.Size(114, 22)
        Me.chkPreview.TabIndex = 10
        Me.chkPreview.Text = "Preview Label"
        Me.chkPreview.UseVisualStyleBackColor = True
        '
        'frmOnlineLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(884, 399)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmOnlineLabel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Online Label Printing"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents tscboPrinters As ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSerial As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtIsc As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtVoc As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtImpp As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtVmpp As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPower As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtModel As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtType As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSerialNo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDimension As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkPreview As CheckBox
End Class
