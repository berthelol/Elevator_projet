Imports System.Text
Imports RLI___TP2___Elevator.AsyncSocket.AsynchronousSocket
Imports RLI___TP2___Elevator.AsyncSocket.ClientSocket
Imports RLI___TP2___Elevator.AsyncSocket.ServerSocket

Public Class Elevator
    Public Shared ServerName As String = "localhost"

    Private serverIsRunning As Boolean = False
    Private clientIsRunning As Boolean = False
   
    Dim msg_send As Byte() = New Byte(0 To 11) {}
    Dim msg_receive As Byte() = New Byte(0 To 11) {}
    Dim test As Boolean = False

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

        Me.LauchServer.ForeColor = System.Drawing.Color.Red
        Me.LauchServer.Text = "Launch the Server"
        If Not serverIsRunning Then
            Dim server As Server
            server = New Server
            server.Show()
            'Dim serveur As AsyncSocket.Serveur = New AsyncSocket.Serveur
            ' serveur.Show()
            serverIsRunning = True
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
        ' MessageBox.Show(Encoding.ASCII.GetString(e.ReceivedBytes), "I am Server")
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
                If (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 21) = "0") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 22) = "0") Then
                    SetCoilDown(False)
                    SetCoilUP(False)
                End If
                FC5()
                'FC1
            Case "1"
                FC1()
                'FC2
            Case "2"
                'On demande toujours l'état de tout les sensors
                '<> different
                Dim test As Integer = Sensor()
                If (test <> last_sensor) And test Then
                    FC2()
                    test = False
                End If
                'FC15
            Case "F"
                FC15(Encoding.ASCII.GetString(e.ReceivedBytes))

            Case Else
                ' Me.LedSensor0.BackColor = Color.Black
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
        If msg_tosend.Length = 20 Then
            Me.SendMessageToServer(Encoding.ASCII.GetBytes(msg_tosend))
        End If
    End Sub

    Private Sub FC1()
         Dim msg As String = "00000000000601050001"
        If CoilUP.Checked Then
            msg += "F"
        Else
            msg += "0"
        End If
        If CoilDown.Checked Then
            msg += "F"
        Else
            msg += "0"
        End If
        msg += "00"
        'SendMessageToServer(Encoding.ASCII.GetBytes(msg))

    End Sub
    'Force multiple coils
    Private Sub FC15(ByVal msg As String)
        ' SendMessageToServer(Encoding.ASCII.GetBytes("000000000009010F00000010"))
    End Sub
    'write coils
    Private Sub FC5()
        Dim msg As String = "00000000000601050001"
        If CoilUP.Checked Then
            msg += "F"
        Else
            msg += "0"
        End If
        If CoilDown.Checked Then
            msg += "F"
        Else
            msg += "0"
        End If
        msg += "00"
        'SendMessageToServer(Encoding.ASCII.GetBytes(msg))

    End Sub

    Dim last_sensor As Integer = 0
    Private Function Sensor() As Integer
        'Sensors
        Dim actual_sensor As Integer
        Select Case Me.ElevatorPhys.Location.Y
            'Si ascenseur dans la zone du sensor 0'
            Case Me.PositionSensor0.Location.Y - Me.ElevatorPhys.Size.Height
                Me.LedSensor0.BackColor = Color.LawnGreen
                actual_sensor = 5
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
                test = True
        End Select
        Return actual_sensor
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If (Me.CoilUP.Checked) Then
            Me.ElevatorPhys.Location = New Point(Me.ElevatorPhys.Location.X, Me.ElevatorPhys.Location.Y - 1)
        End If
        If (Me.CoilDown.Checked) Then
            Me.ElevatorPhys.Location = New Point(Me.ElevatorPhys.Location.X, Me.ElevatorPhys.Location.Y + 1)
        End If
        If ((Not (Me.CoilUP.Checked)) And (Not (Me.CoilDown.Checked))) Then
            Me.ElevatorPhys.Location = Me.ElevatorPhys.Location
        End If
        If Me.ElevatorPhys.Location.Y > 630 Then
            Me.ElevatorPhys.Location = New Point(Me.ElevatorPhys.Location.X, Me.ElevatorPhys.Location.Y - 1)
        End If

    End Sub


End Class