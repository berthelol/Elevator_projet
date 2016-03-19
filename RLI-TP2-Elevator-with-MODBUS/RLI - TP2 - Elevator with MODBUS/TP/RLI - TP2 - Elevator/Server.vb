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
        all
    End Enum
    Public start As Boolean
    Public floor_asked As New List(Of Floor)(New Floor())
    Public last_sensor As New Sensor()
    Public last_coil As New Coil()
    Public change As Boolean
    Public Sub New()
        InitializeComponent()
        Me._socket = New AsynchronousServer()
        Me._socket.AttachReceiveCallBack(AddressOf ReceivedDataFromClient)
        TryCast(_socket, AsynchronousServer).RunServer()
        Me.serverIsRunning = True
        last_sensor = Sensor.zero
        last_coil = Coil.up
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

        Select Case GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 16)
            'FC5
            Case "5"
                If ((GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 21) = "F") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 22) = "0")) Then
                    'Textboxcoil.Text = "up"
                End If
                If ((GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 21) = "0") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 22) = "F")) Then
                    ' Textboxcoil.Text = "down"
                End If
                If ((GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 21) = "0") And (GetChar(Encoding.ASCII.GetString(e.ReceivedBytes), 22) = "0")) Then
                    ' Textboxcoil.Text = "null"
                End If
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
                Else
                    change = False
                End If
                'FC15
            Case "F"
                FC15()

            Case Else
        End Select
        'BE CAREFUL!! 
        'If you want to change the properties of CoilUP/CoilDown/LedSensor... here, you must use safe functions. 
        'Functions for CoilUP and CoilDown are given (see SetCoilDown and SetCoilUP)
    End Sub

    'Read coils
    Private Sub FC1(ByVal msg As String)
        'Me.SendMessageToClient(Encoding.ASCII.GetBytes("000000000006010100000008"))
    End Sub
    'Read sensors
    Private Sub FC2()
        Me.SendMessageToClient(Encoding.ASCII.GetBytes("000000000006010200000008"))
    End Sub

    'Write coil
    Private Sub FC5(ByVal coil As Coil)
        Select Case coil
            'FC5
            Case coil.up
                SendMessageToClient(Encoding.ASCII.GetBytes("00000000000601050001F000"))
            Case coil.down
                SendMessageToClient(Encoding.ASCII.GetBytes("000000000006010500010F00"))
            Case coil.null
                SendMessageToClient(Encoding.ASCII.GetBytes("000000000006010500010000"))
        End Select
    End Sub
    'Frce multiple coils
    Private Sub FC15()
        'Me.SendMessageToClient(Encoding.ASCII.GetBytes("000000000009010F0000001002A5F0"))
    End Sub
    Private Sub ButtonCallFloor0_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor0.Click
        Me.ButtonCallFloor0.Image = My.Resources.buttonpush
        If floor_asked.Count Then
            If (floor_asked.Item(0) <> Floor.zero) Then
                floor_asked.Add(Floor.zero)
            End If
        Else
            floor_asked.Add(Floor.zero)
        End If
        start = True
        change = True
        Move_Elevator()
    End Sub

    Private Sub ButtonCallFloor1_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor1.Click
        Me.ButtonCallFloor1.Image = My.Resources.buttonpush
        If floor_asked.Count Then
            If (floor_asked.Item(0) <> Floor.one) Then
                floor_asked.Add(Floor.one)
            End If
        Else
            floor_asked.Add(Floor.one)
        End If
        start = True
        change = True
        Move_Elevator()
    End Sub

    Private Sub ButtonCallFloor2_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor2.Click
        Me.ButtonCallFloor2.Image = My.Resources.buttonpush
        If floor_asked.Count Then
            If (floor_asked.Item(0) <> Floor.two) Then
                floor_asked.Add(Floor.two)
            End If
        Else
            floor_asked.Add(Floor.two)
        End If
        start = True
        change = True
        Move_Elevator()
    End Sub

    Private Sub ButtonCallFloor3_Click(sender As Object, e As EventArgs) Handles ButtonCallFloor3.Click
        Me.ButtonCallFloor3.Image = My.Resources.buttonpush
        If floor_asked.Count Then
            If (floor_asked.Item(0) <> Floor.three) Then
                floor_asked.Add(Floor.three)
            End If
        Else
            floor_asked.Add(Floor.three)
        End If
        start = True
        change = True
        Move_Elevator()
    End Sub
    Private Sub STOP_Click(sender As Object, e As EventArgs) Handles Stop_button.Click
        FC5(Coil.null)
        If floor_asked.Count Then
            floor_asked.RemoveAt(0)
            Change_bouton_color(Floor.all)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'ask sensors
        FC2()
        Move_Elevator()
        If floor_asked.Count Then
            Textboxcoil.Text = last_coil.ToString
            Textbox_floor.Text = ""
            For Each element In floor_asked
                Textbox_floor.Text = Textbox_floor.Text + "->" + element.ToString
            Next
        End If
    End Sub

    Private Sub Move_Elevator()
        If floor_asked.Count And start Then
            If floor_asked.Count And change Then
                If last_sensor = Sensor.four And floor_asked.Item(0) = Floor.three Then
                    last_coil = Coil.null
                    FC5(last_coil)
                    'On éteint le bouton appelé
                    Change_bouton_color(Floor.three)
                    'On enlève l'étage demandé de la liste d'attente
                    floor_asked.RemoveAt(0)
                    change = False
                    'Stop le temps que les passagers descendent'
                    System.Threading.Thread.Sleep(1000)
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
                    'Stop le temps que les passagers descendent'
                    System.Threading.Thread.Sleep(1000)
                End If
            End If
            If floor_asked.Count And change Then
                If ((last_sensor = Sensor.three) And floor_asked.Item(0) = Floor.two And last_coil = Coil.up) Then
                    last_coil = Coil.null
                    FC5(last_coil)
                    'On éteint le bouton appelé
                    Change_bouton_color(Floor.two)
                    'On enlève l'étage demandé de la liste d'attente
                    floor_asked.RemoveAt(0)
                    change = False
                    'Stop le temps que les passagers descendent'
                    System.Threading.Thread.Sleep(1000)
                End If
            End If
        End If
        If floor_asked.Count And change Then
            If ((last_sensor = Sensor.two) And floor_asked.Item(0) = Floor.one And last_coil = Coil.up) Then
                last_coil = Coil.null
                FC5(last_coil)
                'On éteint le bouton appelé
                Change_bouton_color(Floor.one)
                'On enlève l'étage demandé de la liste d'attente
                floor_asked.RemoveAt(0)
                change = False
                'Stop le temps que les passagers descendent'
                System.Threading.Thread.Sleep(1000)
            End If
        End If
        If floor_asked.Count And change Then
            If ((last_sensor = Sensor.one) And floor_asked.Item(0) = Floor.one And last_coil = Coil.down) Then
                last_coil = Coil.null
                FC5(last_coil)
                'On éteint le bouton appelé
                Change_bouton_color(Floor.one)
                'On enlève l'étage demandé de la liste d'attente
                floor_asked.RemoveAt(0)
                change = False
                'Stop le temps que les passagers descendent'
                System.Threading.Thread.Sleep(1000)
            End If
        End If

        If floor_asked.Count Then
            If ((last_sensor = Sensor.zero) And floor_asked.Item(0) = Floor.zero And last_coil = Coil.down) Then
                last_coil = Coil.null
                FC5(last_coil)
                'On éteint le bouton appelé
                Change_bouton_color(Floor.zero)
                'On enlève l'étage demandé de la liste d'attente
                floor_asked.RemoveAt(0)
                change = False
                'Stop le temps que les passagers descendent'
                System.Threading.Thread.Sleep(1000)
            End If
        End If
        If floor_asked.Count Then
            'Si l'ascenseur est en dessous de l'étage demandé alors il monte '
            If (last_sensor < floor_asked.Item(0) And floor_asked.Count) Then
                'set coil up
                last_coil = Coil.up
                FC5(Coil.up)
            End If
            'Si l'ascenseur est au dessus de l'étage demandé alors il descend '
            If last_sensor > floor_asked.Item(0) And floor_asked.Count Then
                'set coil down
                last_coil = Coil.down
                FC5(Coil.down)
            End If
        End If
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
            Case floor.all
                Me.ButtonCallFloor0.Image = My.Resources.buttons
                Me.ButtonCallFloor1.Image = My.Resources.buttons
                Me.ButtonCallFloor2.Image = My.Resources.buttons
                Me.ButtonCallFloor3.Image = My.Resources.buttons
        End Select
    End Sub
End Class

