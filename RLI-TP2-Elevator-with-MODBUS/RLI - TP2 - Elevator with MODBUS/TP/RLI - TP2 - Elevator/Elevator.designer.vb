﻿' Epuration et amélioration du code grâce au travail de 
' CHASSINAT Adrien
' ING4 SE en 2013-2014

Imports RLI___TP2___Elevator.AsyncSocket
Imports RLI___TP2___Elevator.AsyncSocket.ClientSocket
Imports RLI___TP2___Elevator.AsyncSocket.ServerSocket

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Elevator
    Inherits System.Windows.Forms.Form

    Private _socket As AsynchronousSocket

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Elevator))
        Me.ConnectToServer = New System.Windows.Forms.Button()
        Me.LauchServer = New System.Windows.Forms.Button()
        Me.PanelConnexion = New System.Windows.Forms.Panel()
        Me.LabelConnexion = New System.Windows.Forms.Label()
        Me.PositionSensor3 = New System.Windows.Forms.Label()
        Me.PositionSensor2 = New System.Windows.Forms.Label()
        Me.PositionSensor1 = New System.Windows.Forms.Label()
        Me.PositionSensor0 = New System.Windows.Forms.Label()
        Me.PanelSensors = New System.Windows.Forms.Panel()
        Me.LabelLedSensor4 = New System.Windows.Forms.Label()
        Me.LedSensor4 = New System.Windows.Forms.Panel()
        Me.LabelLedSensor3 = New System.Windows.Forms.Label()
        Me.LabelLedSensor2 = New System.Windows.Forms.Label()
        Me.LabelLedSensor1 = New System.Windows.Forms.Label()
        Me.LabelLedSensor0 = New System.Windows.Forms.Label()
        Me.LedSensor3 = New System.Windows.Forms.Panel()
        Me.LedSensor2 = New System.Windows.Forms.Panel()
        Me.LedSensor1 = New System.Windows.Forms.Panel()
        Me.LedSensor0 = New System.Windows.Forms.Panel()
        Me.LabelSensors = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CoilDown = New System.Windows.Forms.CheckBox()
        Me.CoilUP = New System.Windows.Forms.CheckBox()
        Me.LabelCoils = New System.Windows.Forms.Label()
        Me.PositionSensor4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ElevatorPhys = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelConnexion.SuspendLayout()
        Me.PanelSensors.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElevatorPhys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ConnectToServer
        '
        Me.ConnectToServer.ForeColor = System.Drawing.Color.DimGray
        Me.ConnectToServer.Location = New System.Drawing.Point(39, 37)
        Me.ConnectToServer.Name = "ConnectToServer"
        Me.ConnectToServer.Size = New System.Drawing.Size(77, 37)
        Me.ConnectToServer.TabIndex = 0
        Me.ConnectToServer.Text = "Connect to the Server"
        Me.ConnectToServer.UseVisualStyleBackColor = True
        '
        'LauchServer
        '
        Me.LauchServer.ForeColor = System.Drawing.Color.DimGray
        Me.LauchServer.Location = New System.Drawing.Point(39, 80)
        Me.LauchServer.Name = "LauchServer"
        Me.LauchServer.Size = New System.Drawing.Size(77, 38)
        Me.LauchServer.TabIndex = 1
        Me.LauchServer.Text = "Launch the Server"
        Me.LauchServer.UseVisualStyleBackColor = True
        '
        'PanelConnexion
        '
        Me.PanelConnexion.BackColor = System.Drawing.Color.Firebrick
        Me.PanelConnexion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelConnexion.Controls.Add(Me.LabelConnexion)
        Me.PanelConnexion.Controls.Add(Me.LauchServer)
        Me.PanelConnexion.Controls.Add(Me.ConnectToServer)
        Me.PanelConnexion.Location = New System.Drawing.Point(641, 12)
        Me.PanelConnexion.Name = "PanelConnexion"
        Me.PanelConnexion.Size = New System.Drawing.Size(132, 134)
        Me.PanelConnexion.TabIndex = 2
        '
        'LabelConnexion
        '
        Me.LabelConnexion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelConnexion.AutoSize = True
        Me.LabelConnexion.Font = New System.Drawing.Font("Elephant", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConnexion.Location = New System.Drawing.Point(1, 0)
        Me.LabelConnexion.Name = "LabelConnexion"
        Me.LabelConnexion.Size = New System.Drawing.Size(129, 25)
        Me.LabelConnexion.TabIndex = 2
        Me.LabelConnexion.Text = "Connection"
        '
        'PositionSensor3
        '
        Me.PositionSensor3.AutoSize = True
        Me.PositionSensor3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PositionSensor3.Location = New System.Drawing.Point(250, 174)
        Me.PositionSensor3.Name = "PositionSensor3"
        Me.PositionSensor3.Size = New System.Drawing.Size(92, 13)
        Me.PositionSensor3.TabIndex = 11
        Me.PositionSensor3.Text = "Sensor/Input 3"
        '
        'PositionSensor2
        '
        Me.PositionSensor2.AutoSize = True
        Me.PositionSensor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PositionSensor2.Location = New System.Drawing.Point(250, 325)
        Me.PositionSensor2.Name = "PositionSensor2"
        Me.PositionSensor2.Size = New System.Drawing.Size(92, 13)
        Me.PositionSensor2.TabIndex = 12
        Me.PositionSensor2.Text = "Sensor/Input 2"
        '
        'PositionSensor1
        '
        Me.PositionSensor1.AutoSize = True
        Me.PositionSensor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PositionSensor1.Location = New System.Drawing.Point(250, 475)
        Me.PositionSensor1.Name = "PositionSensor1"
        Me.PositionSensor1.Size = New System.Drawing.Size(92, 13)
        Me.PositionSensor1.TabIndex = 13
        Me.PositionSensor1.Text = "Sensor/Input 1"
        '
        'PositionSensor0
        '
        Me.PositionSensor0.AutoSize = True
        Me.PositionSensor0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PositionSensor0.Location = New System.Drawing.Point(250, 625)
        Me.PositionSensor0.Name = "PositionSensor0"
        Me.PositionSensor0.Size = New System.Drawing.Size(92, 13)
        Me.PositionSensor0.TabIndex = 14
        Me.PositionSensor0.Text = "Sensor/Input 0"
        '
        'PanelSensors
        '
        Me.PanelSensors.BackColor = System.Drawing.Color.Firebrick
        Me.PanelSensors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelSensors.Controls.Add(Me.LabelLedSensor4)
        Me.PanelSensors.Controls.Add(Me.LedSensor4)
        Me.PanelSensors.Controls.Add(Me.LabelLedSensor3)
        Me.PanelSensors.Controls.Add(Me.LabelLedSensor2)
        Me.PanelSensors.Controls.Add(Me.LabelLedSensor1)
        Me.PanelSensors.Controls.Add(Me.LabelLedSensor0)
        Me.PanelSensors.Controls.Add(Me.LedSensor3)
        Me.PanelSensors.Controls.Add(Me.LedSensor2)
        Me.PanelSensors.Controls.Add(Me.LedSensor1)
        Me.PanelSensors.Controls.Add(Me.LedSensor0)
        Me.PanelSensors.Controls.Add(Me.LabelSensors)
        Me.PanelSensors.Location = New System.Drawing.Point(26, 277)
        Me.PanelSensors.Name = "PanelSensors"
        Me.PanelSensors.Size = New System.Drawing.Size(155, 77)
        Me.PanelSensors.TabIndex = 19
        '
        'LabelLedSensor4
        '
        Me.LabelLedSensor4.AutoSize = True
        Me.LabelLedSensor4.Location = New System.Drawing.Point(121, 33)
        Me.LabelLedSensor4.Name = "LabelLedSensor4"
        Me.LabelLedSensor4.Size = New System.Drawing.Size(13, 13)
        Me.LabelLedSensor4.TabIndex = 13
        Me.LabelLedSensor4.Text = "4"
        '
        'LedSensor4
        '
        Me.LedSensor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LedSensor4.Location = New System.Drawing.Point(118, 49)
        Me.LedSensor4.Name = "LedSensor4"
        Me.LedSensor4.Size = New System.Drawing.Size(20, 20)
        Me.LedSensor4.TabIndex = 12
        '
        'LabelLedSensor3
        '
        Me.LabelLedSensor3.AutoSize = True
        Me.LabelLedSensor3.Location = New System.Drawing.Point(96, 33)
        Me.LabelLedSensor3.Name = "LabelLedSensor3"
        Me.LabelLedSensor3.Size = New System.Drawing.Size(13, 13)
        Me.LabelLedSensor3.TabIndex = 11
        Me.LabelLedSensor3.Text = "3"
        '
        'LabelLedSensor2
        '
        Me.LabelLedSensor2.AutoSize = True
        Me.LabelLedSensor2.Location = New System.Drawing.Point(70, 33)
        Me.LabelLedSensor2.Name = "LabelLedSensor2"
        Me.LabelLedSensor2.Size = New System.Drawing.Size(13, 13)
        Me.LabelLedSensor2.TabIndex = 10
        Me.LabelLedSensor2.Text = "2"
        '
        'LabelLedSensor1
        '
        Me.LabelLedSensor1.AutoSize = True
        Me.LabelLedSensor1.Location = New System.Drawing.Point(44, 33)
        Me.LabelLedSensor1.Name = "LabelLedSensor1"
        Me.LabelLedSensor1.Size = New System.Drawing.Size(13, 13)
        Me.LabelLedSensor1.TabIndex = 9
        Me.LabelLedSensor1.Text = "1"
        '
        'LabelLedSensor0
        '
        Me.LabelLedSensor0.AutoSize = True
        Me.LabelLedSensor0.Location = New System.Drawing.Point(18, 33)
        Me.LabelLedSensor0.Name = "LabelLedSensor0"
        Me.LabelLedSensor0.Size = New System.Drawing.Size(13, 13)
        Me.LabelLedSensor0.TabIndex = 8
        Me.LabelLedSensor0.Text = "0"
        '
        'LedSensor3
        '
        Me.LedSensor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LedSensor3.Location = New System.Drawing.Point(93, 49)
        Me.LedSensor3.Name = "LedSensor3"
        Me.LedSensor3.Size = New System.Drawing.Size(20, 20)
        Me.LedSensor3.TabIndex = 7
        '
        'LedSensor2
        '
        Me.LedSensor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LedSensor2.Location = New System.Drawing.Point(67, 49)
        Me.LedSensor2.Name = "LedSensor2"
        Me.LedSensor2.Size = New System.Drawing.Size(20, 20)
        Me.LedSensor2.TabIndex = 6
        '
        'LedSensor1
        '
        Me.LedSensor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LedSensor1.Location = New System.Drawing.Point(41, 49)
        Me.LedSensor1.Name = "LedSensor1"
        Me.LedSensor1.Size = New System.Drawing.Size(20, 20)
        Me.LedSensor1.TabIndex = 5
        '
        'LedSensor0
        '
        Me.LedSensor0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LedSensor0.Location = New System.Drawing.Point(15, 49)
        Me.LedSensor0.Name = "LedSensor0"
        Me.LedSensor0.Size = New System.Drawing.Size(20, 20)
        Me.LedSensor0.TabIndex = 4
        '
        'LabelSensors
        '
        Me.LabelSensors.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelSensors.AutoSize = True
        Me.LabelSensors.Font = New System.Drawing.Font("Elephant", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSensors.Location = New System.Drawing.Point(3, 0)
        Me.LabelSensors.Name = "LabelSensors"
        Me.LabelSensors.Size = New System.Drawing.Size(145, 21)
        Me.LabelSensors.TabIndex = 3
        Me.LabelSensors.Text = "Sensors/Inputs"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Firebrick
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.CoilDown)
        Me.Panel1.Controls.Add(Me.CoilUP)
        Me.Panel1.Controls.Add(Me.LabelCoils)
        Me.Panel1.Location = New System.Drawing.Point(26, 385)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(155, 77)
        Me.Panel1.TabIndex = 20
        '
        'CoilDown
        '
        Me.CoilDown.AutoSize = True
        Me.CoilDown.Location = New System.Drawing.Point(49, 48)
        Me.CoilDown.Name = "CoilDown"
        Me.CoilDown.Size = New System.Drawing.Size(54, 17)
        Me.CoilDown.TabIndex = 5
        Me.CoilDown.Text = "Down"
        Me.CoilDown.UseVisualStyleBackColor = True
        '
        'CoilUP
        '
        Me.CoilUP.AutoSize = True
        Me.CoilUP.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.CoilUP.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.CoilUP.Location = New System.Drawing.Point(49, 24)
        Me.CoilUP.Name = "CoilUP"
        Me.CoilUP.Size = New System.Drawing.Size(40, 17)
        Me.CoilUP.TabIndex = 4
        Me.CoilUP.Text = "Up"
        Me.CoilUP.UseVisualStyleBackColor = True
        '
        'LabelCoils
        '
        Me.LabelCoils.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelCoils.AutoSize = True
        Me.LabelCoils.Font = New System.Drawing.Font("Elephant", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCoils.Location = New System.Drawing.Point(8, 0)
        Me.LabelCoils.Name = "LabelCoils"
        Me.LabelCoils.Size = New System.Drawing.Size(134, 21)
        Me.LabelCoils.TabIndex = 3
        Me.LabelCoils.Text = "Coils/Outputs"
        '
        'PositionSensor4
        '
        Me.PositionSensor4.AutoSize = True
        Me.PositionSensor4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PositionSensor4.Location = New System.Drawing.Point(251, 26)
        Me.PositionSensor4.Name = "PositionSensor4"
        Me.PositionSensor4.Size = New System.Drawing.Size(92, 13)
        Me.PositionSensor4.TabIndex = 22
        Me.PositionSensor4.Text = "Sensor/Input 4"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel2.Location = New System.Drawing.Point(344, 14)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(162, 629)
        Me.Panel2.TabIndex = 23
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.three
        Me.PictureBox5.Location = New System.Drawing.Point(512, 82)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 31
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.two
        Me.PictureBox4.Location = New System.Drawing.Point(512, 231)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 30
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.zero
        Me.PictureBox3.Location = New System.Drawing.Point(512, 540)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 29
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.one
        Me.PictureBox2.Location = New System.Drawing.Point(512, 376)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 28
        Me.PictureBox2.TabStop = False
        '
        'ElevatorPhys
        '
        Me.ElevatorPhys.BackColor = System.Drawing.Color.DarkRed
        Me.ElevatorPhys.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.elevator
        Me.ElevatorPhys.InitialImage = Nothing
        Me.ElevatorPhys.Location = New System.Drawing.Point(355, 490)
        Me.ElevatorPhys.Name = "ElevatorPhys"
        Me.ElevatorPhys.Size = New System.Drawing.Size(140, 140)
        Me.ElevatorPhys.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ElevatorPhys.TabIndex = 21
        Me.ElevatorPhys.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(233, 222)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Elevator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkRed
        Me.ClientSize = New System.Drawing.Size(787, 655)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PositionSensor4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ElevatorPhys)
        Me.Controls.Add(Me.PanelSensors)
        Me.Controls.Add(Me.PositionSensor0)
        Me.Controls.Add(Me.PositionSensor1)
        Me.Controls.Add(Me.PositionSensor2)
        Me.Controls.Add(Me.PositionSensor3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PanelConnexion)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Elevator"
        Me.Text = "Elevator - RLI - TP3"
        Me.PanelConnexion.ResumeLayout(False)
        Me.PanelConnexion.PerformLayout()
        Me.PanelSensors.ResumeLayout(False)
        Me.PanelSensors.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElevatorPhys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ConnectToServer As System.Windows.Forms.Button
    Friend WithEvents LauchServer As System.Windows.Forms.Button
    Friend WithEvents PanelConnexion As System.Windows.Forms.Panel
    Friend WithEvents LabelConnexion As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PositionSensor3 As System.Windows.Forms.Label
    Friend WithEvents PositionSensor2 As System.Windows.Forms.Label
    Friend WithEvents PositionSensor1 As System.Windows.Forms.Label
    Friend WithEvents PositionSensor0 As System.Windows.Forms.Label
    Friend WithEvents PanelSensors As System.Windows.Forms.Panel
    Friend WithEvents LabelSensors As System.Windows.Forms.Label
    Friend WithEvents ElevatorPhys As System.Windows.Forms.PictureBox
    Friend WithEvents LedSensor0 As System.Windows.Forms.Panel
    Friend WithEvents LedSensor1 As System.Windows.Forms.Panel
    Friend WithEvents LabelLedSensor3 As System.Windows.Forms.Label
    Friend WithEvents LabelLedSensor2 As System.Windows.Forms.Label
    Friend WithEvents LabelLedSensor1 As System.Windows.Forms.Label
    Friend WithEvents LabelLedSensor0 As System.Windows.Forms.Label
    Friend WithEvents LedSensor3 As System.Windows.Forms.Panel
    Friend WithEvents LedSensor2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelCoils As System.Windows.Forms.Label
    Friend WithEvents LabelLedSensor4 As System.Windows.Forms.Label
    Friend WithEvents LedSensor4 As System.Windows.Forms.Panel
    Friend WithEvents PositionSensor4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents CoilDown As System.Windows.Forms.CheckBox
    Friend WithEvents CoilUP As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox

End Class