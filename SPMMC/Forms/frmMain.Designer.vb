﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ApplicationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductionLabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateLabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReprintLabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ELReviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ELImageReviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerOEMOBAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplicationsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 40)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ApplicationsToolStripMenuItem
        '
        Me.ApplicationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductionLabelsToolStripMenuItem, Me.ELReviewToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.ApplicationsToolStripMenuItem.Image = CType(resources.GetObject("ApplicationsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ApplicationsToolStripMenuItem.Name = "ApplicationsToolStripMenuItem"
        Me.ApplicationsToolStripMenuItem.Size = New System.Drawing.Size(117, 36)
        Me.ApplicationsToolStripMenuItem.Text = "Applications"
        '
        'ProductionLabelsToolStripMenuItem
        '
        Me.ProductionLabelsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateLabelsToolStripMenuItem, Me.ReprintLabelsToolStripMenuItem})
        Me.ProductionLabelsToolStripMenuItem.Image = CType(resources.GetObject("ProductionLabelsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProductionLabelsToolStripMenuItem.Name = "ProductionLabelsToolStripMenuItem"
        Me.ProductionLabelsToolStripMenuItem.Size = New System.Drawing.Size(185, 38)
        Me.ProductionLabelsToolStripMenuItem.Tag = "PRODLABEL"
        Me.ProductionLabelsToolStripMenuItem.Text = "Production Labels"
        '
        'GenerateLabelsToolStripMenuItem
        '
        Me.GenerateLabelsToolStripMenuItem.Image = CType(resources.GetObject("GenerateLabelsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GenerateLabelsToolStripMenuItem.Name = "GenerateLabelsToolStripMenuItem"
        Me.GenerateLabelsToolStripMenuItem.Size = New System.Drawing.Size(168, 38)
        Me.GenerateLabelsToolStripMenuItem.Text = "Print Labels"
        '
        'ReprintLabelsToolStripMenuItem
        '
        Me.ReprintLabelsToolStripMenuItem.Image = CType(resources.GetObject("ReprintLabelsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReprintLabelsToolStripMenuItem.Name = "ReprintLabelsToolStripMenuItem"
        Me.ReprintLabelsToolStripMenuItem.Size = New System.Drawing.Size(168, 38)
        Me.ReprintLabelsToolStripMenuItem.Text = "Reprint Labels"
        '
        'ELReviewToolStripMenuItem
        '
        Me.ELReviewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ELImageReviewToolStripMenuItem, Me.CustomerOEMOBAToolStripMenuItem})
        Me.ELReviewToolStripMenuItem.Image = CType(resources.GetObject("ELReviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ELReviewToolStripMenuItem.Name = "ELReviewToolStripMenuItem"
        Me.ELReviewToolStripMenuItem.Size = New System.Drawing.Size(185, 38)
        Me.ELReviewToolStripMenuItem.Tag = "ELREVIEW"
        Me.ELReviewToolStripMenuItem.Text = "EL Review"
        '
        'ELImageReviewToolStripMenuItem
        '
        Me.ELImageReviewToolStripMenuItem.Name = "ELImageReviewToolStripMenuItem"
        Me.ELImageReviewToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ELImageReviewToolStripMenuItem.Text = "EL Image Review"
        '
        'CustomerOEMOBAToolStripMenuItem
        '
        Me.CustomerOEMOBAToolStripMenuItem.Name = "CustomerOEMOBAToolStripMenuItem"
        Me.CustomerOEMOBAToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.CustomerOEMOBAToolStripMenuItem.Text = "Customer OEM - OBA"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(182, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(185, 38)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 239)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(284, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslStatus
        '
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(39, 17)
        Me.tslStatus.Text = "Ready"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solar Philippines Module Manufacturing Corporation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ApplicationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductionLabelsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateLabelsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReprintLabelsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ELReviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ELImageReviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerOEMOBAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tslStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
End Class
