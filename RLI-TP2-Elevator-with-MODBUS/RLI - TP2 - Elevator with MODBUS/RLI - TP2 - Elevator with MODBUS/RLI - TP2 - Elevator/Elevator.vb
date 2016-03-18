Imports System.Text
Imports RLI___TP2___Elevator.AsyncSocket.AsynchronousSocket
Imports RLI___TP2___Elevator.AsyncSocket.ClientSocket
Imports RLI___TP2___Elevator.AsyncSocket.ServerSocket

Public Class Elevator
    Public Shared ServerName As String = "localhost"

    Private serverIsRunning As Boolean = False
    Private clientIsRunning As Boolean = False
    Public Enum Floor
        zero = 485
        one = 335
        two = 185
        three = 35
    End Enum
    Dim msg_send As Byte() = New Byte(0 To 11) {}
    Dim msg_receive As Byte() = New Byte(0 To 11) {}
    Public floor_asked As New List(Of Floor)(New Floor() {Floor.zero})
    Public last_floor As New Floor
    Private Sub ConnectToServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectToServer.Click
        If Not clientIsRunning Then
            Me.clientIsRunning = True
            Dim serverNameForm As AsyncSocket.ServerNameForm = New AsyncSocket.ServerNameForm
            serverNameForm.ShowDialog()
            Me.ConnectToServer.ForeColor = System.Drawing.Color.Green
            Me.ConnectToServer.Text = "Disconnect From the Server"

            Try
                Me._socket = New AsynchronousClient()
                _socket.AttachReceiveCallBack(AddressOf ReceivedDataFromServer)
                TryCast(_socket, AsynchronousClient).ConnectToServer(ServerName)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Me.clientIsRunning = False
                Me.ConnectToServer.ForeColor = System.Drawing.Color.Red
                Me.ConnectToServer.Text = "Connect To the Server"
            End Try
        Else
            If _socket IsNot Nothing Then
                _socket.Close()
            End If
            Me.clientIsRunning = False
            Me.ConnectToServer.ForeColor = System.Drawing.Color.Red
            Me.ConnectToServer.Text = "Connect To the Server"
        End If
    End Sub

    Private Sub LauchServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LauchServer.Click
        If Not serverIsRunning Then
            Me._socket = New AsynchronousServer()
            Me._socket.AttachReceiveCallBack(AddressOf ReceivedDataFromClient)
            TryCast(_socket, AsynchronousServer).RunServer()

            Me.serverIsRunning = True
            Me.LauchServer.ForeColor = System.Drawing.Color.Green
            Me.LauchServer.Text = "Stop the Server"
        Else
            If _socket IsNot Nothing Then
                _socket.Close()
            End If
            Me.serverIsRunning = False
            Me.LauchServer.ForeColor = System.Drawing.Color.Red
            Me.LauchServer.Text = "Launch the Server"
        End If
    End Sub

    Public Sub New()
        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        My.Computer.Audio.Play(My.Resources.elevatormusic, _
       AudioPlayMode.Background)
    End Sub

    Private Sub Ascenseur_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If _socket IsNot Nothing Then
            _socket.Close()
        End If
    End Sub

    Public Sub SendMessageToClient(ByVal msg As Byte())
        If _socket IsNot Nothing Then
            If TryCast(_socket, AsynchronousServer) IsNot Nothing Then
                Me._socket.SendMessage(msg)
            End If
        End If
    End Sub

    Public Sub SendMessageToServer(ByVal msg As Byte())
        If _socket IsNot Nothing Then
            If TryCast(_socket, AsynchronousClient) IsNot Nothing Then
                Me._socket.SendMessage(msg)
            End If
        End If
    End Sub

    ' This delegate enables asynchronous calls for setting
    ' the property on a Checkbox control.
    Delegate Sub SetCoilUPCallback(ByVal [val] As Boolean)
    Public Sub SetCoilUP(ByVal [val] As Boolean)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.CoilUP.InvokeRequired Then
            Dim d As New SetCoilUPCallback(AddressOf SetCoilUP)
            Me.Invoke(d, New Object() {[val]})
        Else
            Me.CoilUP.Checked = [val]
        End If
    End Sub

    ' This delegate enables asynchronous calls for setting
    ' the property on a Checkbox control.
    Delegate Sub SetCoilDownCallback(ByVal [val] As Boolean)
    Public Sub SetCoilDown(ByVal [val] As Boolean)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.CoilDown.InvokeRequired Then
            Dim d As New SetCoilDownCallback(AddressOf SetCoilDown)
            Me.Invoke(d, New Object() {[val]})
        Else
            Me.CoilDown.Checked = [val]
        End If
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' YOUR JOB START HERE. You don't have to modify another file!
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'CLIENT SIDE
    Private Sub ReceivedDataFromServer(ByVal sender As Object, ByVal e As AsyncEventArgs)
        'Add some stuff to interpret messages (and remove the next line!)
        'Bytes are in e.ReceivedBytes and you can encore the bytes to string using Encoding.ASCII.GetString(e.ReceivedBytes)
        ' MessageBox.Show("Server says :" + Encoding.ASCII.GetString(e.ReceivedBytes), "I am Client")
        'MessageBox.Show(Encoding.ASCII.GetString(e.ReceivedBytes), "I am Server")
        Select Case GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 16)
            'FC5
            Case "5"
                ' FC5(Encoding.ASCII.GetString(e.ReceivedBytes))
                If GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 21) = "F" Then
                    SetCoilUP(True)
                End If
                If GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 21) = "0" Then
                    SetCoilUP(False)
                End If
                If GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 22) = "F" Then
                    SetCoilDown(True)
                End If
                If GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 22) = "0" Then
                    SetCoilDown(False)
                End If
                'FC1
            Case "1"
                FC1(Encoding.ASCII.GetString(e.ReceivedBytes))
                'FC2
            Case "2"
                'En fonction du bit recu indic quel sensor est allumé
                'FC15
            Case "F"
                FC15(Encoding.ASCII.GetString(e.ReceivedBytes))

            Case Else
                Me.LedSensor0.BackColor = Color.Black
        End Select


        'BE CAREFUL!! 
        'If you want to change the properties of CoilUP/CoilDown/LedSensor... here, you must use safe functions. 
        'Functions for CoilUP and CoilDown are given (see SetCoilDown and SetCoilUP)
    End Sub

    'SERVER SIDE
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
                'FC15
            Case "F"
                FC15(Encoding.ASCII.GetString(e.ReceivedBytes))

            Case Else
                Me.LedSensor0.BackColor = Color.Black


        End Select
        'BE CAREFUL!! 
        'If you want to change the properties of CoilUP/CoilDown/LedSensor... here, you must use safe functions. 
        'Functions for CoilUP and CoilDown are given (see SetCoilDown and SetCoilUP)
    End Sub



    'Private Sub ButtonCallFloor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCallFloor2.Click'
    '  If serverIsRunning Then'
    ' Me.SendMessageToClient(Encoding.ASCII.GetBytes("Coucou client !"))'
    '  End If'
    ' If clientIsRunning Then'
    '     Me.SendMessageToServer(Encoding.ASCII.GetBytes("Coucou server !"))'
    '  End If'
    '  End Sub'

    'Read coils
    Private Sub FC1(ByVal msg As String)
        Me.SendMessageToClient(Encoding.ASCII.GetBytes("000000000006010200000005"))
    End Sub

    'Read discret input in the slave
    Private Sub FC2()
        Dim msg_tosend As String
        msg_tosend = "000000000006010201"
        If (Me.LedSensor0.BackColor = Color.LawnGreen) Then
            msg_tosend = "000000000006010201" + "01"
        End If
        If (Me.LedSensor1.BackColor = Color.LawnGreen) Then
            msg_tosend = "000000000006010201" + "02"
        End If
        If (Me.LedSensor2.BackColor = Color.LawnGreen) Then
            msg_tosend = "000000000006010201" + "04"
        End If
        If (Me.LedSensor3.BackColor = Color.LawnGreen) Then
            msg_tosend = "000000000006010201" + "08"
        End If
        If (Me.LedSensor4.BackColor = Color.LawnGreen) Then
            msg_tosend = "000000000006010201" + "10"
        End If
        SendMessageToServer(Encoding.ASCII.GetBytes(msg_tosend))

    End Sub

    'Write coil
    Private Sub FC5(ByVal msg As String)
        ' msg_send = Encoding.ASCII.GetBytes("00000000000601050001FF00")
        SendMessageToClient(Encoding.ASCII.GetBytes(msg))

    End Sub

    'Force multiple coils
    Private Sub FC15(ByVal msg As String)

    End Sub

    Private Sub Move_Elevator(ByVal floor As List(Of Floor))
        If floor.Count Then
            'Si l'ascenseur est en dessous de l'étage demandé alors il monte '
            If Me.ElevatorPhys.Location.Y > floor.Item(0) Then
                Me.ElevatorPhys.Location = New Point(Me.ElevatorPhys.Location.X, Me.ElevatorPhys.Location.Y - 1)
                SetCoilUP(True)
                SetCoilDown(False)
                'Si l'ascenseur est au dessus de l'étage demandé alors il descend '
            ElseIf Me.ElevatorPhys.Location.Y < floor.Item(0) Then
                Me.ElevatorPhys.Location = New Point(Me.ElevatorPhys.Location.X, Me.ElevatorPhys.Location.Y + 1)
                SetCoilUP(False)
                SetCoilDown(True)
                'Arrivé à l'étage demandé'
            ElseIf Me.ElevatorPhys.Location.Y = floor.Item(0) Then
                'On éteint le bouton appelé
                Change_bouton_color(floor.Item(0))
                'On enlève l'étage demandé de la list d'attente
                floor_asked.RemoveAt(0)
                SetCoilUP(False)
                SetCoilDown(False)
                'Stop le temps que les passagers descendent'
                System.Threading.Thread.Sleep(1000)

            End If
        End If
        'Sensors
        Select Case Me.ElevatorPhys.Location.Y
            'Si ascenseur dans la zone du sensor 0'
            Case Me.PositionSensor0.Location.Y - Me.ElevatorPhys.Size.Height
                Me.LedSensor0.BackColor = Color.LawnGreen
                'Si ascenseur dans la zone du sensor 1'
            Case Me.PositionSensor1.Location.Y - Me.ElevatorPhys.Size.Height + 5 To Me.PositionSensor1.Location.Y
                Me.LedSensor1.BackColor = Color.LawnGreen
                'Si ascenseur dans la zone du sensor 2'
            Case Me.PositionSensor2.Location.Y - Me.ElevatorPhys.Size.Height + 5 To Me.PositionSensor2.Location.Y
                Me.LedSensor2.BackColor = Color.LawnGreen
                'Si ascenseur dans la zone du sensor 3'
            Case Me.PositionSensor3.Location.Y - Me.ElevatorPhys.Size.Height + 5 To Me.PositionSensor3.Location.Y
                Me.LedSensor3.BackColor = Color.LawnGreen
                'Si ascenseur dans la zone du sensor 4'
                'Case Me.PositionSensor4.Location.Y + Me.PositionSensor4.Size.Height 
            Case 35
                Me.LedSensor4.BackColor = Color.LawnGreen

            Case Else
                Me.LedSensor0.BackColor = Color.Transparent
                Me.LedSensor1.BackColor = Color.Transparent
                Me.LedSensor2.BackColor = Color.Transparent
                Me.LedSensor3.BackColor = Color.Transparent
                Me.LedSensor4.BackColor = Color.Transparent
        End Select

    End Sub
    Dim last_sensor As Integer = 0
    Private Function Sensor() As Integer
        'Sensors
        Dim actual_sensor As Integer
        Select Case Me.ElevatorPhys.Location.Y
            'Si ascenseur dans la zone du sensor 0'
            Case Me.PositionSensor0.Location.Y - Me.ElevatorPhys.Size.Height
                Me.LedSensor0.BackColor = Color.LawnGreen
                actual_sensor = 0
                'Si ascenseur dans la zone du sensor 1'
            Case Me.PositionSensor1.Location.Y - Me.ElevatorPhys.Size.Height + 5 To Me.PositionSensor1.Location.Y
                Me.LedSensor1.BackColor = Color.LawnGreen
                actual_sensor = 1
                'Si ascenseur dans la zone du sensor 2'
            Case Me.PositionSensor2.Location.Y - Me.ElevatorPhys.Size.Height + 5 To Me.PositionSensor2.Location.Y
                Me.LedSensor2.BackColor = Color.LawnGreen
                actual_sensor = 2
                'Si ascenseur dans la zone du sensor 3'
            Case Me.PositionSensor3.Location.Y - Me.ElevatorPhys.Size.Height + 5 To Me.PositionSensor3.Location.Y
                Me.LedSensor3.BackColor = Color.LawnGreen
                actual_sensor = 3
                'Si ascenseur dans la zone du sensor 4'
                'Case Me.PositionSensor4.Location.Y + Me.PositionSensor4.Size.Height 
            Case 35
                Me.LedSensor4.BackColor = Color.LawnGreen
                actual_sensor = 4

            Case Else
                Me.LedSensor0.BackColor = Color.Transparent
                Me.LedSensor1.BackColor = Color.Transparent
                Me.LedSensor2.BackColor = Color.Transparent
                Me.LedSensor3.BackColor = Color.Transparent
                Me.LedSensor4.BackColor = Color.Transparent
                actual_sensor = last_sensor
        End Select
        Return actual_sensor
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        '<> different
        If (Sensor() <> last_sensor) Then
            FC2()
        End If

        If (Me.CoilUP.Checked) Then
            Me.ElevatorPhys.Location = New Point(Me.ElevatorPhys.Location.X, Me.ElevatorPhys.Location.Y - 1)
        End If
        If (Me.CoilDown.Checked) Then
            Me.ElevatorPhys.Location = New Point(Me.ElevatorPhys.Location.X, Me.ElevatorPhys.Location.Y + 1)
        End If
        If ((Not (Me.CoilUP.Checked)) And (Not (Me.CoilDown.Checked))) Then
            Me.ElevatorPhys.Location = Me.ElevatorPhys.Location
        End If

        'Move_Elevator(floor_asked)
    End Sub

    Private Sub ButtonCallFloor0_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor0.Click
        Me.ButtonCallFloor0.Image = My.Resources.buttonpush
        floor_asked.Add(Floor.zero)
    End Sub

    Private Sub ButtonCallFloor1_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor1.Click
        Me.ButtonCallFloor1.Image = My.Resources.buttonpush
        floor_asked.Add(Floor.one)
       
    End Sub

    Private Sub ButtonCallFloor2_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor2.Click
        'Me.ButtonCallFloor2.Image = My.Resources.buttonpush
        'floor_asked.Add(Floor.two)
        Dim floor_asked As New List(Of Floor)(New Floor() {Floor.zero})
        FC5("00000000000601050001F000")
    End Sub

    Private Sub ButtonCallFloor3_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor3.Click
        Me.ButtonCallFloor3.Image = My.Resources.buttonpush
        floor_asked.Add(Floor.three)

    End Sub

    Private Sub Change_bouton_color(ByVal floor As Floor)

        Select Case floor
            'Si ascenseur dans la zone du sensor 0'
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