Imports RLI___TP2___Elevator.AsyncSocket
Imports RLI___TP2___Elevator.AsyncSocket.ClientSocket
Imports RLI___TP2___Elevator.AsyncSocket.ServerSocket
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Serveur
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ButtonCallFloor0 = New System.Windows.Forms.PictureBox()
        Me.ButtonCallFloor1 = New System.Windows.Forms.PictureBox()
        Me.ButtonCallFloor2 = New System.Windows.Forms.PictureBox()
        Me.ButtonCallFloor3 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonCallFloor0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonCallFloor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonCallFloor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonCallFloor3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.three
        Me.PictureBox1.Location = New System.Drawing.Point(431, 122)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 41
        Me.PictureBox1.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
        Me.PictureBox6.Location = New System.Drawing.Point(460, 108)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 40
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.three
        Me.PictureBox5.Location = New System.Drawing.Point(96, -116)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 39
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.two
        Me.PictureBox4.Location = New System.Drawing.Point(307, 124)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 38
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.zero
        Me.PictureBox3.Location = New System.Drawing.Point(35, 123)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 37
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.one
        Me.PictureBox2.Location = New System.Drawing.Point(169, 120)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 36
        Me.PictureBox2.TabStop = False
        '
        'ButtonCallFloor0
        '
        Me.ButtonCallFloor0.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
        Me.ButtonCallFloor0.Location = New System.Drawing.Point(64, 108)
        Me.ButtonCallFloor0.Name = "ButtonCallFloor0"
        Me.ButtonCallFloor0.Size = New System.Drawing.Size(64, 64)
        Me.ButtonCallFloor0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ButtonCallFloor0.TabIndex = 35
        Me.ButtonCallFloor0.TabStop = False
        '
        'ButtonCallFloor1
        '
        Me.ButtonCallFloor1.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
        Me.ButtonCallFloor1.Location = New System.Drawing.Point(198, 108)
        Me.ButtonCallFloor1.Name = "ButtonCallFloor1"
        Me.ButtonCallFloor1.Size = New System.Drawing.Size(64, 64)
        Me.ButtonCallFloor1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ButtonCallFloor1.TabIndex = 34
        Me.ButtonCallFloor1.TabStop = False
        '
        'ButtonCallFloor2
        '
        Me.ButtonCallFloor2.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
        Me.ButtonCallFloor2.Location = New System.Drawing.Point(336, 108)
        Me.ButtonCallFloor2.Name = "ButtonCallFloor2"
        Me.ButtonCallFloor2.Size = New System.Drawing.Size(64, 64)
        Me.ButtonCallFloor2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ButtonCallFloor2.TabIndex = 33
        Me.ButtonCallFloor2.TabStop = False
        '
        'ButtonCallFloor3
        '
        Me.ButtonCallFloor3.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
        Me.ButtonCallFloor3.Location = New System.Drawing.Point(125, -130)
        Me.ButtonCallFloor3.Name = "ButtonCallFloor3"
        Me.ButtonCallFloor3.Size = New System.Drawing.Size(64, 64)
        Me.ButtonCallFloor3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ButtonCallFloor3.TabIndex = 32
        Me.ButtonCallFloor3.TabStop = False
        '
        'Serveur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 446)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ButtonCallFloor0)
        Me.Controls.Add(Me.ButtonCallFloor1)
        Me.Controls.Add(Me.ButtonCallFloor2)
        Me.Controls.Add(Me.ButtonCallFloor3)
        Me.Name = "Serveur"
        Me.Text = "Serveur"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonCallFloor0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonCallFloor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonCallFloor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonCallFloor3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonCallFloor0 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonCallFloor1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonCallFloor2 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonCallFloor3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
End Class
