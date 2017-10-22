<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Namelist
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Namelist))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.EName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.插入ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.EName, Me.CName})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.LabelEdit = True
        Me.ListView1.Location = New System.Drawing.Point(15, 19)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(400, 458)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'EName
        '
        Me.EName.Text = "English name"
        Me.EName.Width = 135
        '
        'CName
        '
        Me.CName.Text = "Chinese name"
        Me.CName.Width = 135
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.插入ToolStripMenuItem, Me.ChangeToolStripMenuItem, Me.RemoveToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(139, 76)
        '
        '插入ToolStripMenuItem
        '
        Me.插入ToolStripMenuItem.Name = "插入ToolStripMenuItem"
        Me.插入ToolStripMenuItem.Size = New System.Drawing.Size(138, 24)
        Me.插入ToolStripMenuItem.Text = "Insert"
        '
        'ChangeToolStripMenuItem
        '
        Me.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem"
        Me.ChangeToolStripMenuItem.Size = New System.Drawing.Size(138, 24)
        Me.ChangeToolStripMenuItem.Text = "Change"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(138, 24)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 524)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 37)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "New"
        Me.ToolTip1.SetToolTip(Me.Button1, "If a item is selected, a new item will be added after it. Otherwise it a new item" &
        " will be added after the last item. ")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(102, 524)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 37)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Change"
        Me.ToolTip1.SetToolTip(Me.Button2, "Change the text of a selected item")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(200, 524)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(89, 37)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Remove"
        Me.ToolTip1.SetToolTip(Me.Button3, "Remove a selected item.")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(316, 524)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(99, 37)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Save"
        Me.ToolTip1.SetToolTip(Me.Button4, "Save your changes.")
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 482)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 29)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Total number:"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 3000
        '
        'Namelist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(432, 575)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "Namelist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Name list Editor"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents EName As ColumnHeader
    Friend WithEvents CName As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 插入ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Timer1 As Timer
End Class
