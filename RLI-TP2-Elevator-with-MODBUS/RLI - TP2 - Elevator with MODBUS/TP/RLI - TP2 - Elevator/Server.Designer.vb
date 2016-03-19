<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Server
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Textbox_floor = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Textboxcoil = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Stop_button = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.ButtonCallFloor3 = New System.Windows.Forms.PictureBox()
        Me.ButtonCallFloor2 = New System.Windows.Forms.PictureBox()
        Me.ButtonCallFloor1 = New System.Windows.Forms.PictureBox()
        Me.ButtonCallFloor0 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Stop_button, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonCallFloor3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonCallFloor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonCallFloor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonCallFloor0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Textbox_floor
        '
        Me.Textbox_floor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Textbox_floor.Location = New System.Drawing.Point(12, 185)
        Me.Textbox_floor.Name = "Textbox_floor"
        Me.Textbox_floor.Size = New System.Drawing.Size(175, 20)
        Me.Textbox_floor.TabIndex = 9
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30
        '
        'Textboxcoil
        '
        Me.Textboxcoil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Textboxcoil.Location = New System.Drawing.Point(12, 229)
        Me.Textboxcoil.Name = "Textboxcoil"
        Me.Textboxcoil.Size = New System.Drawing.Size(175, 20)
        Me.Textboxcoil.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Floors called"
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Location = New System.Drawing.Point(13, 213)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(50, 13)
        Me.label.TabIndex = 12
        Me.label.Text = "Coil state"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.RLI___TP2___Elevator.My.Resources.Resources._stop
        Me.PictureBox1.Location = New System.Drawing.Point(208, 229)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 48)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Stop_button
        '
        Me.Stop_button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Stop_button.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.caution
        Me.Stop_button.Location = New System.Drawing.Point(208, 185)
        Me.Stop_button.Name = "Stop_button"
        Me.Stop_button.Size = New System.Drawing.Size(64, 64)
        Me.Stop_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Stop_button.TabIndex = 8
        Me.Stop_button.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.three
        Me.PictureBox8.Location = New System.Drawing.Point(240, 117)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox8.TabIndex = 7
        Me.PictureBox8.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.two
        Me.PictureBox7.Location = New System.Drawing.Point(167, 117)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox7.TabIndex = 6
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.one
        Me.PictureBox6.Location = New System.Drawing.Point(98, 117)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox6.TabIndex = 5
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.zero
        Me.PictureBox5.Location = New System.Drawing.Point(25, 117)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 4
        Me.PictureBox5.TabStop = False
        '
        'ButtonCallFloor3
        '
        Me.ButtonCallFloor3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCallFloor3.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
        Me.ButtonCallFloor3.Location = New System.Drawing.Point(222, 47)
        Me.ButtonCallFloor3.Name = "ButtonCallFloor3"
        Me.ButtonCallFloor3.Size = New System.Drawing.Size(64, 64)
        Me.ButtonCallFloor3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ButtonCallFloor3.TabIndex = 3
        Me.ButtonCallFloor3.TabStop = False
        '
        'ButtonCallFloor2
        '
        Me.ButtonCallFloor2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCallFloor2.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
        Me.ButtonCallFloor2.Location = New System.Drawing.Point(152, 47)
        Me.ButtonCallFloor2.Name = "ButtonCallFloor2"
        Me.ButtonCallFloor2.Size = New System.Drawing.Size(64, 64)
        Me.ButtonCallFloor2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ButtonCallFloor2.TabIndex = 2
        Me.ButtonCallFloor2.TabStop = False
        '
        'ButtonCallFloor1
        '
        Me.ButtonCallFloor1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCallFloor1.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
        Me.ButtonCallFloor1.Location = New System.Drawing.Point(82, 47)
        Me.ButtonCallFloor1.Name = "ButtonCallFloor1"
        Me.ButtonCallFloor1.Size = New System.Drawing.Size(64, 64)
        Me.ButtonCallFloor1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ButtonCallFloor1.TabIndex = 1
        Me.ButtonCallFloor1.TabStop = False
        '
        'ButtonCallFloor0
        '
        Me.ButtonCallFloor0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCallFloor0.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
        Me.ButtonCallFloor0.Location = New System.Drawing.Point(12, 47)
        Me.ButtonCallFloor0.Name = "ButtonCallFloor0"
        Me.ButtonCallFloor0.Size = New System.Drawing.Size(64, 64)
        Me.ButtonCallFloor0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ButtonCallFloor0.TabIndex = 0
        Me.ButtonCallFloor0.TabStop = False
        '
        'Server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkRed
        Me.ClientSize = New System.Drawing.Size(284, 272)
        Me.Controls.Add(Me.label)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Textboxcoil)
        Me.Controls.Add(Me.Textbox_floor)
        Me.Controls.Add(Me.Stop_button)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.ButtonCallFloor3)
        Me.Controls.Add(Me.ButtonCallFloor2)
        Me.Controls.Add(Me.ButtonCallFloor1)
        Me.Controls.Add(Me.ButtonCallFloor0)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Server"
        Me.Text = "Server"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Stop_button, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonCallFloor3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonCallFloor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonCallFloor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonCallFloor0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonCallFloor0 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonCallFloor1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonCallFloor2 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonCallFloor3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents Stop_button As System.Windows.Forms.PictureBox
    Friend WithEvents Textbox_floor As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Textboxcoil As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents label As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
