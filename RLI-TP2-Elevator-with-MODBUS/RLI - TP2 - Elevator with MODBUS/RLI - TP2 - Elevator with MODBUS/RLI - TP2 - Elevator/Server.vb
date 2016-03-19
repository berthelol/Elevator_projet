Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text
Imports RLI___TP2___Elevator.AsyncSocket.AsynchronousSocket
Imports RLI___TP2___Elevator.AsyncSocket.ClientSocket
Imports RLI___TP2___Elevator.AsyncSocket.ServerSocket

Public Class Server

    Private _socket As RLI___TP2___Elevator.AsyncSocket.AsynchronousSocket
    Private serverIsRunning As Boolean = False
    Private clientIsRunning As Boolean = False
    Public Enum Coil
        up
        down
        null
    End Enum
    Public Enum Sensor
        zero = 0
        one = 1
        two = 2
        three = 3
        four = 4
    End Enum
    Public Enum Floor
        zero = 0
        one = 1
        two = 2
        three = 3
    End Enum
    Public start As Boolean
    Public floor_asked As New List(Of Floor)(New Floor())
    Public last_sensor As New Sensor()
    Public last_coil As New Coil()
    Public change As Boolean
    Public Sub New()
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        Me._socket = New AsynchronousServer()
        Me._socket.AttachReceiveCallBack(AddressOf ReceivedDataFromClient)
        TryCast(_socket, AsynchronousServer).RunServer()
        Me.serverIsRunning = True
        last_sensor = Sensor.zero
        last_coil = Coil.up
        ' floor_asked.Add(Floor.zero)
        start = False
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
                'FC5(Encoding.ASCII.GetString(e.ReceivedBytes))
                'FC1
            Case "1"
                ' FC1(Encoding.ASCII.GetString(e.ReceivedBytes))
                'FC2 read sensors
            Case "2"

                'sensor0
                Dim prev_sensor As Sensor = last_sensor
                If ((GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 19) = "0") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 20) = "1")) Then

                    last_sensor = Sensor.zero
                End If
                'sensor1
                If ((GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 19) = "0") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 20) = "2")) Then

                    last_sensor = Sensor.one
                End If
                'sensor2
                If ((GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 19) = "0") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 20) = "4")) Then

                    last_sensor = Sensor.two
                End If
                'sensor3
                If ((GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 19) = "0") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 20) = "8")) Then

                    last_sensor = Sensor.three
                End If
                'sensor4
                If ((GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 19) = "1") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 20) = "0")) Then

                    last_sensor = Sensor.four
                End If

                If last_sensor <> prev_sensor Then
                    change = True
                    ' Move_Elevator()

                Else
                    change = False

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
    Private Sub FC5(ByVal coil As Coil)

            Select coil
            'FC5
            Case coil.up
                SendMessageToClient(Encoding.ASCII.GetBytes("00000000000601050001F000"))
            Case coil.down
                SendMessageToClient(Encoding.ASCII.GetBytes("000000000006010500010F00"))
            Case coil.null
                SendMessageToClient(Encoding.ASCII.GetBytes("000000000006010500010000"))
        End Select
    End Sub


    Private Sub ButtonCallFloor0_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor0.Click
        Me.ButtonCallFloor0.Image = My.Resources.buttonpush
        floor_asked.Add(Floor.zero)
        '  Me.TextBox2.Text = "0 " + Me.TextBox2.Text
        start = True
        change = True
        Move_Elevator()
    End Sub

    Private Sub ButtonCallFloor1_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor1.Click
        Me.ButtonCallFloor1.Image = My.Resources.buttonpush
        floor_asked.Add(Floor.one)
        ' Me.TextBox2.Text = "1 " + Me.TextBox2.Text
        start = True
        change = True
        Move_Elevator()
    End Sub

    Private Sub ButtonCallFloor2_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor2.Click
        Me.ButtonCallFloor2.Image = My.Resources.buttonpush
        floor_asked.Add(Floor.two)
        ' Me.TextBox2.Text = "2 " + Me.TextBox2.Text
        start = True
        change = True
        Move_Elevator()
    End Sub

    Private Sub ButtonCallFloor3_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor3.Click
        Me.ButtonCallFloor3.Image = My.Resources.buttonpush
        floor_asked.Add(Floor.three)
        ' Me.TextBox2.Text = "3 " + Me.TextBox2.Text
        start = True
        change = True
        Move_Elevator()
    End Sub
    Private Sub STOP_Click(sender As Object, e As EventArgs) Handles Stop_button.Click
        FC5(Coil.null)

        'floor_asked.RemoveAt(0)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Move_Elevator()
        ' TextBox1.Text = last_sensor

        If floor_asked.Count Then
            TextBox2.Text = floor_asked.Item(0).ToString
            TextBox1.Text = change.ToString
        End If
        Move_Elevator()

    End Sub

    Private Sub Move_Elevator()

        If floor_asked.Count And start Then
            If floor_asked.Count And change Then
                If last_sensor = Sensor.four And floor_asked.Item(0) = Floor.three Then
                    ' MessageBox.Show("bam", "Server")
                    last_coil = Coil.null
                    FC5(last_coil)
                    'On éteint le bouton appelé
                    Change_bouton_color(Floor.three)
                    'On enlève l'étage demandé de la liste d'attente
                    floor_asked.RemoveAt(0)
                    change = False
                End If
            End If
            If floor_asked.Count And change Then
                If ((last_sensor = Sensor.two) And floor_asked.Item(0) = Floor.two And last_coil = Coil.down) Then
                    last_coil = Coil.null
                    FC5(last_coil)
                    'On éteint le bouton appelé
                    Change_bouton_color(Floor.two)
                    'On enlève l'étage demandé de la liste d'attente
                    floor_asked.RemoveAt(0)
                    change = False
                End If
            End If
            If floor_asked.Count And change Then
                If ((last_sensor = Sensor.three) And floor_asked.Item(0) = Floor.two And last_coil = Coil.up) Then
                    '  MessageBox.Show("BAM", "I am Server")
                    last_coil = Coil.null
                    FC5(last_coil)
                    'On éteint le bouton appelé
                    Change_bouton_color(Floor.two)
                    'On enlève l'étage demandé de la liste d'attente
                    floor_asked.RemoveAt(0)
                    change = False
                End If
            End If
        End If
        If floor_asked.Count And change Then

            If ((last_sensor = Sensor.two) And floor_asked.Item(0) = Floor.one And last_coil = Coil.up) Then
                'MessageBox.Show("BAM", "I am Server")
                last_coil = Coil.null
                FC5(last_coil)
                'On éteint le bouton appelé
                Change_bouton_color(Floor.one)
                'On enlève l'étage demandé de la liste d'attente
                floor_asked.RemoveAt(0)
                change = False
            End If
        End If
        If floor_asked.Count And change Then
            If ((last_sensor = Sensor.one) And floor_asked.Item(0) = Floor.one And last_coil = Coil.down) Then
                'MessageBox.Show("BAM", "I am Server")
                last_coil = Coil.null
                FC5(last_coil)
                'On éteint le bouton appelé
                Change_bouton_color(Floor.one)
                'On enlève l'étage demandé de la liste d'attente
                floor_asked.RemoveAt(0)
                change = False
            End If
        End If

        If floor_asked.Count And change Then
            If ((last_sensor = Sensor.one) And floor_asked.Item(0) = Floor.zero) Then
                ' MessageBox.Show("BAM", "I am Server")
                last_coil = Coil.null
                FC5(last_coil)
                'On éteint le bouton appelé
                Change_bouton_color(Floor.zero)
                'On enlève l'étage demandé de la liste d'attente
                floor_asked.RemoveAt(0)
                change = False
            End If
        End If
        If floor_asked.Count And change Then
            'Si l'ascenseur est en dessous de l'étage demandé alors il monte '
            If (last_sensor < floor_asked.Item(0) And floor_asked.Count) Then
                'set coil up
                last_coil = Coil.up
                FC5(last_coil)
                'Si l'ascenseur est au dessus de l'étage demandé alors il descend '
            End If
            If last_sensor > floor_asked.Item(0) And floor_asked.Count Then
                ' MessageBox.Show(last_sensor + 1, "I am Server")
                last_coil = Coil.down
                FC5(last_coil)
                'Arrivé à l'étage demandé'
            End If
            'Else

            'Stop le temps que les passagers descendent'
            'System.Threading.Thread.Sleep(1000)
        End If


        'change = False

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


   
End Class

