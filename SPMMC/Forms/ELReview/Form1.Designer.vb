<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQAReview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQAReview))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPalletNo = New System.Windows.Forms.TextBox()
        Me.tcData = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvFTD = New System.Windows.Forms.DataGridView()
        Me.colSNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIsc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colShunt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lnkView1 = New System.Windows.Forms.LinkLabel()
        Me.btnRemarks1 = New System.Windows.Forms.Button()
        Me.btnShow1 = New System.Windows.Forms.Button()
        Me.txtRemarks1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbEL1 = New System.Windows.Forms.PictureBox()
        Me.lvEL1 = New System.Windows.Forms.ListView()
        Me.EL1Serial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EL1Path = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rbEL2 = New System.Windows.Forms.RadioButton()
        Me.lnkView2 = New System.Windows.Forms.LinkLabel()
        Me.btnRemarks2 = New System.Windows.Forms.Button()
        Me.btnShow2 = New System.Windows.Forms.Button()
        Me.txtRemarks2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbEL2 = New System.Windows.Forms.PictureBox()
        Me.lvEL2 = New System.Windows.Forms.ListView()
        Me.EL2Serial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EL2Path = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvJBOX = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PassedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FailedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tcData.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFTD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.pbEL1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.pbEL2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Scan Pallet Number"
        '
        'txtPalletNo
        '
        Me.txtPalletNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPalletNo.Location = New System.Drawing.Point(195, 45)
        Me.txtPalletNo.Name = "txtPalletNo"
        Me.txtPalletNo.Size = New System.Drawing.Size(628, 26)
        Me.txtPalletNo.TabIndex = 1
        '
        'tcData
        '
        Me.tcData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcData.Controls.Add(Me.TabPage1)
        Me.tcData.Controls.Add(Me.TabPage2)
        Me.tcData.Controls.Add(Me.TabPage3)
        Me.tcData.Location = New System.Drawing.Point(12, 88)
        Me.tcData.Name = "tcData"
        Me.tcData.SelectedIndex = 0
        Me.tcData.Size = New System.Drawing.Size(815, 258)
        Me.tcData.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblCount)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dgvFTD)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(807, 227)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Flash Test Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Location = New System.Drawing.Point(677, 197)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(121, 18)
        Me.lblCount.TabIndex = 2
        Me.lblCount.Text = "-"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(579, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Modules"
        '
        'dgvFTD
        '
        Me.dgvFTD.AllowUserToAddRows = False
        Me.dgvFTD.AllowUserToDeleteRows = False
        Me.dgvFTD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFTD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFTD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSNO, Me.colDate, Me.colBin, Me.colModel, Me.colPartNo, Me.colIsc, Me.colUoc, Me.colImp, Me.colUmp, Me.colPmp, Me.colShunt, Me.colFF})
        Me.dgvFTD.Location = New System.Drawing.Point(6, 6)
        Me.dgvFTD.Name = "dgvFTD"
        Me.dgvFTD.ReadOnly = True
        Me.dgvFTD.RowHeadersVisible = False
        Me.dgvFTD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFTD.Size = New System.Drawing.Size(795, 178)
        Me.dgvFTD.TabIndex = 0
        '
        'colSNO
        '
        Me.colSNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSNO.DataPropertyName = "SERIALNO"
        Me.colSNO.FillWeight = 14.0!
        Me.colSNO.HeaderText = "Serial No"
        Me.colSNO.Name = "colSNO"
        Me.colSNO.ReadOnly = True
        '
        'colDate
        '
        Me.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDate.DataPropertyName = "INSPECTIONTIME"
        Me.colDate.FillWeight = 12.0!
        Me.colDate.HeaderText = "Flash Test Date"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        '
        'colBin
        '
        Me.colBin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colBin.DataPropertyName = "BIN"
        Me.colBin.FillWeight = 5.0!
        Me.colBin.HeaderText = "Bin"
        Me.colBin.Name = "colBin"
        Me.colBin.ReadOnly = True
        '
        'colModel
        '
        Me.colModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colModel.DataPropertyName = "MODELNAME"
        Me.colModel.FillWeight = 10.0!
        Me.colModel.HeaderText = "Model Name"
        Me.colModel.Name = "colModel"
        Me.colModel.ReadOnly = True
        '
        'colPartNo
        '
        Me.colPartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPartNo.DataPropertyName = "PARTNO"
        Me.colPartNo.FillWeight = 10.0!
        Me.colPartNo.HeaderText = "Part Number"
        Me.colPartNo.Name = "colPartNo"
        Me.colPartNo.ReadOnly = True
        '
        'colIsc
        '
        Me.colIsc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colIsc.DataPropertyName = "ISC"
        Me.colIsc.FillWeight = 7.0!
        Me.colIsc.HeaderText = "Isc"
        Me.colIsc.Name = "colIsc"
        Me.colIsc.ReadOnly = True
        '
        'colUoc
        '
        Me.colUoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colUoc.DataPropertyName = "UOC"
        Me.colUoc.FillWeight = 7.0!
        Me.colUoc.HeaderText = "Uoc"
        Me.colUoc.Name = "colUoc"
        Me.colUoc.ReadOnly = True
        '
        'colImp
        '
        Me.colImp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colImp.DataPropertyName = "IMPP"
        Me.colImp.FillWeight = 7.0!
        Me.colImp.HeaderText = "Impp"
        Me.colImp.Name = "colImp"
        Me.colImp.ReadOnly = True
        '
        'colUmp
        '
        Me.colUmp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colUmp.DataPropertyName = "UMPP"
        Me.colUmp.FillWeight = 7.0!
        Me.colUmp.HeaderText = "Umpp"
        Me.colUmp.Name = "colUmp"
        Me.colUmp.ReadOnly = True
        '
        'colPmp
        '
        Me.colPmp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPmp.DataPropertyName = "PMPP"
        Me.colPmp.FillWeight = 7.0!
        Me.colPmp.HeaderText = "Pmpp"
        Me.colPmp.Name = "colPmp"
        Me.colPmp.ReadOnly = True
        '
        'colShunt
        '
        Me.colShunt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colShunt.DataPropertyName = "SHUNTRESISTANCE"
        Me.colShunt.FillWeight = 7.0!
        Me.colShunt.HeaderText = "Shunt Resistance"
        Me.colShunt.Name = "colShunt"
        Me.colShunt.ReadOnly = True
        '
        'colFF
        '
        Me.colFF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFF.DataPropertyName = "FF"
        Me.colFF.FillWeight = 7.0!
        Me.colFF.HeaderText = "FF"
        Me.colFF.Name = "colFF"
        Me.colFF.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lnkView1)
        Me.TabPage2.Controls.Add(Me.btnRemarks1)
        Me.TabPage2.Controls.Add(Me.btnShow1)
        Me.TabPage2.Controls.Add(Me.txtRemarks1)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.pbEL1)
        Me.TabPage2.Controls.Add(Me.lvEL1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(807, 227)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "EL1 Images"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lnkView1
        '
        Me.lnkView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkView1.AutoSize = True
        Me.lnkView1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkView1.Location = New System.Drawing.Point(479, 156)
        Me.lnkView1.Name = "lnkView1"
        Me.lnkView1.Size = New System.Drawing.Size(102, 14)
        Me.lnkView1.TabIndex = 13
        Me.lnkView1.TabStop = True
        Me.lnkView1.Text = "View All Remarks"
        '
        'btnRemarks1
        '
        Me.btnRemarks1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemarks1.Image = CType(resources.GetObject("btnRemarks1.Image"), System.Drawing.Image)
        Me.btnRemarks1.Location = New System.Drawing.Point(592, 173)
        Me.btnRemarks1.Name = "btnRemarks1"
        Me.btnRemarks1.Size = New System.Drawing.Size(50, 48)
        Me.btnRemarks1.TabIndex = 10
        Me.btnRemarks1.UseVisualStyleBackColor = True
        '
        'btnShow1
        '
        Me.btnShow1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShow1.Location = New System.Drawing.Point(676, 173)
        Me.btnShow1.Name = "btnShow1"
        Me.btnShow1.Size = New System.Drawing.Size(125, 27)
        Me.btnShow1.TabIndex = 9
        Me.btnShow1.Text = "Show Full Image"
        Me.btnShow1.UseVisualStyleBackColor = True
        '
        'txtRemarks1
        '
        Me.txtRemarks1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks1.Location = New System.Drawing.Point(419, 173)
        Me.txtRemarks1.Multiline = True
        Me.txtRemarks1.Name = "txtRemarks1"
        Me.txtRemarks1.Size = New System.Drawing.Size(167, 48)
        Me.txtRemarks1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(419, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Remarks"
        '
        'pbEL1
        '
        Me.pbEL1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbEL1.BackColor = System.Drawing.Color.Black
        Me.pbEL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbEL1.Location = New System.Drawing.Point(419, 6)
        Me.pbEL1.Name = "pbEL1"
        Me.pbEL1.Size = New System.Drawing.Size(382, 147)
        Me.pbEL1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEL1.TabIndex = 1
        Me.pbEL1.TabStop = False
        '
        'lvEL1
        '
        Me.lvEL1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvEL1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.EL1Serial, Me.EL1Path})
        Me.lvEL1.FullRowSelect = True
        Me.lvEL1.HideSelection = False
        Me.lvEL1.Location = New System.Drawing.Point(6, 6)
        Me.lvEL1.MultiSelect = False
        Me.lvEL1.Name = "lvEL1"
        Me.lvEL1.Size = New System.Drawing.Size(407, 215)
        Me.lvEL1.TabIndex = 0
        Me.lvEL1.UseCompatibleStateImageBehavior = False
        Me.lvEL1.View = System.Windows.Forms.View.Details
        '
        'EL1Serial
        '
        Me.EL1Serial.Text = "Serial Number"
        Me.EL1Serial.Width = 150
        '
        'EL1Path
        '
        Me.EL1Path.Text = "File Path"
        Me.EL1Path.Width = 225
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.RadioButton1)
        Me.TabPage3.Controls.Add(Me.rbEL2)
        Me.TabPage3.Controls.Add(Me.lnkView2)
        Me.TabPage3.Controls.Add(Me.btnRemarks2)
        Me.TabPage3.Controls.Add(Me.btnShow2)
        Me.TabPage3.Controls.Add(Me.txtRemarks2)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.pbEL2)
        Me.TabPage3.Controls.Add(Me.lvEL2)
        Me.TabPage3.Controls.Add(Me.lvJBOX)
        Me.TabPage3.Location = New System.Drawing.Point(4, 27)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(807, 227)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "EL2 Images"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(107, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(104, 22)
        Me.RadioButton1.TabIndex = 15
        Me.RadioButton1.Text = "JBOX Images"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rbEL2
        '
        Me.rbEL2.AutoSize = True
        Me.rbEL2.Checked = True
        Me.rbEL2.Location = New System.Drawing.Point(8, 6)
        Me.rbEL2.Name = "rbEL2"
        Me.rbEL2.Size = New System.Drawing.Size(93, 22)
        Me.rbEL2.TabIndex = 14
        Me.rbEL2.TabStop = True
        Me.rbEL2.Text = "EL2 Images"
        Me.rbEL2.UseVisualStyleBackColor = True
        '
        'lnkView2
        '
        Me.lnkView2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkView2.AutoSize = True
        Me.lnkView2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkView2.Location = New System.Drawing.Point(479, 156)
        Me.lnkView2.Name = "lnkView2"
        Me.lnkView2.Size = New System.Drawing.Size(102, 14)
        Me.lnkView2.TabIndex = 12
        Me.lnkView2.TabStop = True
        Me.lnkView2.Text = "View All Remarks"
        '
        'btnRemarks2
        '
        Me.btnRemarks2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemarks2.Image = CType(resources.GetObject("btnRemarks2.Image"), System.Drawing.Image)
        Me.btnRemarks2.Location = New System.Drawing.Point(592, 173)
        Me.btnRemarks2.Name = "btnRemarks2"
        Me.btnRemarks2.Size = New System.Drawing.Size(50, 48)
        Me.btnRemarks2.TabIndex = 11
        Me.btnRemarks2.UseVisualStyleBackColor = True
        '
        'btnShow2
        '
        Me.btnShow2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShow2.Location = New System.Drawing.Point(676, 173)
        Me.btnShow2.Name = "btnShow2"
        Me.btnShow2.Size = New System.Drawing.Size(125, 27)
        Me.btnShow2.TabIndex = 6
        Me.btnShow2.Text = "Show Full Image"
        Me.btnShow2.UseVisualStyleBackColor = True
        '
        'txtRemarks2
        '
        Me.txtRemarks2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks2.Location = New System.Drawing.Point(419, 173)
        Me.txtRemarks2.Multiline = True
        Me.txtRemarks2.Name = "txtRemarks2"
        Me.txtRemarks2.Size = New System.Drawing.Size(167, 48)
        Me.txtRemarks2.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(419, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Remarks"
        '
        'pbEL2
        '
        Me.pbEL2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbEL2.BackColor = System.Drawing.Color.Black
        Me.pbEL2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbEL2.Location = New System.Drawing.Point(419, 6)
        Me.pbEL2.Name = "pbEL2"
        Me.pbEL2.Size = New System.Drawing.Size(382, 147)
        Me.pbEL2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbEL2.TabIndex = 3
        Me.pbEL2.TabStop = False
        '
        'lvEL2
        '
        Me.lvEL2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvEL2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.EL2Serial, Me.EL2Path})
        Me.lvEL2.FullRowSelect = True
        Me.lvEL2.HideSelection = False
        Me.lvEL2.Location = New System.Drawing.Point(6, 32)
        Me.lvEL2.MultiSelect = False
        Me.lvEL2.Name = "lvEL2"
        Me.lvEL2.Size = New System.Drawing.Size(407, 189)
        Me.lvEL2.TabIndex = 2
        Me.lvEL2.UseCompatibleStateImageBehavior = False
        Me.lvEL2.View = System.Windows.Forms.View.Details
        '
        'EL2Serial
        '
        Me.EL2Serial.Text = "Serial Number"
        Me.EL2Serial.Width = 150
        '
        'EL2Path
        '
        Me.EL2Path.Text = "File Path"
        Me.EL2Path.Width = 225
        '
        'lvJBOX
        '
        Me.lvJBOX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvJBOX.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvJBOX.FullRowSelect = True
        Me.lvJBOX.HideSelection = False
        Me.lvJBOX.Location = New System.Drawing.Point(6, 32)
        Me.lvJBOX.MultiSelect = False
        Me.lvJBOX.Name = "lvJBOX"
        Me.lvJBOX.Size = New System.Drawing.Size(407, 189)
        Me.lvJBOX.TabIndex = 13
        Me.lvJBOX.UseCompatibleStateImageBehavior = False
        Me.lvJBOX.View = System.Windows.Forms.View.Details
        Me.lvJBOX.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Serial Number"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "File Path"
        Me.ColumnHeader2.Width = 225
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 348)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(815, 13)
        Me.ProgressBar1.TabIndex = 3
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(13, 364)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(36, 13)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "Ready"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Enabled = False
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(839, 39)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(79, 36)
        Me.ToolStripButton2.Text = "Cancel"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PassedToolStripMenuItem, Me.FailedToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(92, 36)
        Me.ToolStripDropDownButton1.Text = "Actions"
        '
        'PassedToolStripMenuItem
        '
        Me.PassedToolStripMenuItem.Image = CType(resources.GetObject("PassedToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PassedToolStripMenuItem.Name = "PassedToolStripMenuItem"
        Me.PassedToolStripMenuItem.Size = New System.Drawing.Size(126, 38)
        Me.PassedToolStripMenuItem.Text = "Passed"
        '
        'FailedToolStripMenuItem
        '
        Me.FailedToolStripMenuItem.Image = CType(resources.GetObject("FailedToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FailedToolStripMenuItem.Name = "FailedToolStripMenuItem"
        Me.FailedToolStripMenuItem.Size = New System.Drawing.Size(126, 38)
        Me.FailedToolStripMenuItem.Text = "Failed"
        '
        'frmQAReview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(839, 383)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.tcData)
        Me.Controls.Add(Me.txtPalletNo)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmQAReview"
        Me.Text = "EL Image Review"
        Me.tcData.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvFTD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.pbEL1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.pbEL2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPalletNo As TextBox
    Friend WithEvents tcData As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvFTD As DataGridView
    Friend WithEvents lblCount As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pbEL1 As PictureBox
    Friend WithEvents lvEL1 As ListView
    Friend WithEvents pbEL2 As PictureBox
    Friend WithEvents lvEL2 As ListView
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblStatus As Label
    Friend WithEvents EL1Serial As ColumnHeader
    Friend WithEvents EL1Path As ColumnHeader
    Friend WithEvents EL2Serial As ColumnHeader
    Friend WithEvents EL2Path As ColumnHeader
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents txtRemarks2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnShow2 As Button
    Friend WithEvents btnShow1 As Button
    Friend WithEvents txtRemarks1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnRemarks1 As Button
    Friend WithEvents btnRemarks2 As Button
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents PassedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FailedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lnkView1 As LinkLabel
    Friend WithEvents lnkView2 As LinkLabel
    Friend WithEvents colSNO As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colBin As DataGridViewTextBoxColumn
    Friend WithEvents colModel As DataGridViewTextBoxColumn
    Friend WithEvents colPartNo As DataGridViewTextBoxColumn
    Friend WithEvents colIsc As DataGridViewTextBoxColumn
    Friend WithEvents colUoc As DataGridViewTextBoxColumn
    Friend WithEvents colImp As DataGridViewTextBoxColumn
    Friend WithEvents colUmp As DataGridViewTextBoxColumn
    Friend WithEvents colPmp As DataGridViewTextBoxColumn
    Friend WithEvents colShunt As DataGridViewTextBoxColumn
    Friend WithEvents colFF As DataGridViewTextBoxColumn
    Friend WithEvents lvJBOX As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents rbEL2 As RadioButton
End Class
