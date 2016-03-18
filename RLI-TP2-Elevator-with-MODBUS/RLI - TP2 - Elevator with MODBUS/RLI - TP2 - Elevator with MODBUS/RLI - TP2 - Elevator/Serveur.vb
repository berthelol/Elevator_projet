Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text
Imports RLI___TP2___Elevator.AsyncSocket.AsynchronousSocket
Imports RLI___TP2___Elevator.AsyncSocket.ClientSocket
Imports RLI___TP2___Elevator.AsyncSocket.ServerSocket

Namespace AsyncSocket
    Public Class Serveur
        Inherits Form
        Private _socket As AsynchronousSocket
        Private serverIsRunning As Boolean = False
        Private clientIsRunning As Boolean = False

Public Enum Floor
        zero = 485
        one = 335
        two = 185
        three = 35
    End Enum

        Public Sub New()
            ' Cet appel est requis par le Concepteur Windows Form.
             InitializeComponent()
            Me._socket = New AsynchronousServer()
            Me._socket.AttachReceiveCallBack(AddressOf ReceivedDataFromClient)
            TryCast(_socket, AsynchronousServer).RunServer()

            Me.serverIsRunning = True
        End Sub

        Public Sub SendMessageToClient(ByVal msg As Byte())
            If _socket IsNot Nothing Then
                If TryCast(_socket, AsynchronousServer) IsNot Nothing Then
                    Me._socket.SendMessage(msg)
                End If
            End If
        End Sub

        Private Sub ReceivedDataFromClient(ByVal sender As Object, ByVal e As AsyncEventArgs)
            'Add some stuff to interpret messages (and remove the next line!)
            'Bytes are in e.ReceivedBytes and you can encore the bytes to string using Encoding.ASCII.GetString(e.ReceivedBytes)
            'MessageBox.Show("Client says :" + Encoding.ASCII.GetString(e.ReceivedBytes), "I am Server")
            Select Case GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 16)
                'FC5
                Case "5"
                    FC5(Encoding.ASCII.GetString(e.ReceivedBytes))
                    'FC1
                Case "1"
                    FC1(Encoding.ASCII.GetString(e.ReceivedBytes))
                    'FC2
                Case "2"
                    'MessageBox.Show(Encoding.ASCII.GetString(e.ReceivedBytes), "I am Server")
                    If ((GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 19) = "0") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 20) = "8")) Then
                        FC5("000000000006010500010000")
                    End If

                    If GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 19) = "1" Then
                        FC5("000000000006010500010000")
                    End If
                    'FC15
                Case "F"
                    'FC15(Encoding.ASCII.GetString(e.ReceivedBytes))

                Case Else



            End Select
            'BE CAREFUL!! 
            'If you want to change the properties of CoilUP/CoilDown/LedSensor... here, you must use safe functions. 
            'Functions for CoilUP and CoilDown are given (see SetCoilDown and SetCoilUP)
        End Sub

        'Read coils
        Private Sub FC1(ByVal msg As String)
            Me.SendMessageToClient(Encoding.ASCII.GetBytes("000000000006010200000005"))
        End Sub

        'Write coil
        Private Sub FC5(ByVal msg As String)
            ' msg_send = Encoding.ASCII.GetBytes("00000000000601050001FF00")
            SendMessageToClient(Encoding.ASCII.GetBytes(msg))

        End Sub

        Private Sub ButtonCallFloor0_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor0.Click
            Me.ButtonCallFloor0.Image = My.Resources.buttonpush
            ' floor_asked.Add(Floor.zero)
        End Sub

        Private Sub ButtonCallFloor1_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor1.Click
            Me.ButtonCallFloor1.Image = My.Resources.buttonpush
            'floor_asked.Add(Floor.one)

        End Sub

        Private Sub ButtonCallFloor2_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor2.Click
            Me.ButtonCallFloor2.Image = My.Resources.buttonpush
            'floor_asked.Add(Floor.two)
            'Dim floor_asked As New List(Of Floor)(New Floor() {Floor.zero})
            FC5("00000000000601050001F000")
        End Sub

        Private Sub ButtonCallFloor3_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor3.Click
            Me.ButtonCallFloor3.Image = My.Resources.buttonpush
            'floor_asked.Add(Floor.three)

        End Sub


    Private Sub Change_bouton_color(ByVal floor As Floor)

        Select Case floor
           
            Case floor.zero
                Me.ButtonCallFloor0.Image = My.Resources.buttons
            Case floor.one
                Me.ButtonCallFloor1.Image = My.Resources.buttons
            Case floor.two
                Me.ButtonCallFloor2.Image = My.Resources.buttons
            Case floor.three
                Me.ButtonCallFloor3.Image = My.Resources.buttons
            Case Else

        End Select
    End Sub

        Private Sub InitializeComponent()
            Me.ButtonCallFloor0 = New System.Windows.Forms.PictureBox()
            Me.PictureBox7 = New System.Windows.Forms.PictureBox()
            Me.ButtonCallFloor1 = New System.Windows.Forms.PictureBox()
            Me.ButtonCallFloor2 = New System.Windows.Forms.PictureBox()
            Me.ButtonCallFloor3 = New System.Windows.Forms.PictureBox()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.PictureBox2 = New System.Windows.Forms.PictureBox()
            Me.PictureBox6 = New System.Windows.Forms.PictureBox()
            CType(Me.ButtonCallFloor0, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ButtonCallFloor1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ButtonCallFloor2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ButtonCallFloor3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonCallFloor0
            '
            Me.ButtonCallFloor0.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
            Me.ButtonCallFloor0.Location = New System.Drawing.Point(12, 70)
            Me.ButtonCallFloor0.Name = "ButtonCallFloor0"
            Me.ButtonCallFloor0.Size = New System.Drawing.Size(64, 64)
            Me.ButtonCallFloor0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.ButtonCallFloor0.TabIndex = 4
            Me.ButtonCallFloor0.TabStop = False
            '
            'PictureBox7
            '
            Me.PictureBox7.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.one
            Me.PictureBox7.Location = New System.Drawing.Point(130, 140)
            Me.PictureBox7.Name = "PictureBox7"
            Me.PictureBox7.Size = New System.Drawing.Size(32, 32)
            Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.PictureBox7.TabIndex = 6
            Me.PictureBox7.TabStop = False
            '
            'ButtonCallFloor1
            '
            Me.ButtonCallFloor1.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
            Me.ButtonCallFloor1.Location = New System.Drawing.Point(115, 70)
            Me.ButtonCallFloor1.Name = "ButtonCallFloor1"
            Me.ButtonCallFloor1.Size = New System.Drawing.Size(64, 64)
            Me.ButtonCallFloor1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.ButtonCallFloor1.TabIndex = 8
            Me.ButtonCallFloor1.TabStop = False
            '
            'ButtonCallFloor2
            '
            Me.ButtonCallFloor2.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
            Me.ButtonCallFloor2.Location = New System.Drawing.Point(206, 70)
            Me.ButtonCallFloor2.Name = "ButtonCallFloor2"
            Me.ButtonCallFloor2.Size = New System.Drawing.Size(64, 64)
            Me.ButtonCallFloor2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.ButtonCallFloor2.TabIndex = 9
            Me.ButtonCallFloor2.TabStop = False
            '
            'ButtonCallFloor3
            '
            Me.ButtonCallFloor3.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.buttons
            Me.ButtonCallFloor3.Location = New System.Drawing.Point(301, 70)
            Me.ButtonCallFloor3.Name = "ButtonCallFloor3"
            Me.ButtonCallFloor3.Size = New System.Drawing.Size(64, 64)
            Me.ButtonCallFloor3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.ButtonCallFloor3.TabIndex = 10
            Me.ButtonCallFloor3.TabStop = False
            '
            'PictureBox1
            '
            Me.PictureBox1.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.two
            Me.PictureBox1.Location = New System.Drawing.Point(220, 140)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
            Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.PictureBox1.TabIndex = 11
            Me.PictureBox1.TabStop = False
            '
            'PictureBox2
            '
            Me.PictureBox2.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.three
            Me.PictureBox2.Location = New System.Drawing.Point(315, 140)
            Me.PictureBox2.Name = "PictureBox2"
            Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
            Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.PictureBox2.TabIndex = 12
            Me.PictureBox2.TabStop = False
            '
            'PictureBox6
            '
            Me.PictureBox6.Image = Global.RLI___TP2___Elevator.My.Resources.Resources.zero
            Me.PictureBox6.Location = New System.Drawing.Point(28, 140)
            Me.PictureBox6.Name = "PictureBox6"
            Me.PictureBox6.Size = New System.Drawing.Size(32, 32)
            Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.PictureBox6.TabIndex = 13
            Me.PictureBox6.TabStop = False
            '
            'Serveur
            '
            Me.ClientSize = New System.Drawing.Size(402, 357)
            Me.Controls.Add(Me.PictureBox6)
            Me.Controls.Add(Me.PictureBox2)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.ButtonCallFloor3)
            Me.Controls.Add(Me.ButtonCallFloor2)
            Me.Controls.Add(Me.ButtonCallFloor1)
            Me.Controls.Add(Me.PictureBox7)
            Me.Controls.Add(Me.ButtonCallFloor0)
            Me.Name = "Serveur"
            CType(Me.ButtonCallFloor0, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ButtonCallFloor1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ButtonCallFloor2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ButtonCallFloor3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ButtonCallFloor0 As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
        Friend WithEvents ButtonCallFloor1 As System.Windows.Forms.PictureBox
        Friend WithEvents ButtonCallFloor2 As System.Windows.Forms.PictureBox
        Friend WithEvents ButtonCallFloor3 As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

        Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        End Sub
        Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    End Class
End Namespace