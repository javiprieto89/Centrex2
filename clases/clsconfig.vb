'Imports System
Imports System.IO
Imports System.Text
'Imports System.Collections

Public Class configInit
    Private path As String
    Private db As String
    Private srvSQL As String
    Private usrDB As String
    Private pswDB As String
    Private bckupDir As String
    Private bckupFile As String
    Private sepdec As String
    Private itPerPage As Integer

    Sub New()
        path = Application.StartupPath + "\initConfig.jav"
    End Sub

    Public Property nameDB As String
        Get
            Return db
        End Get
        Set(value As String)
            Me.db = value
            basedb = value
        End Set
    End Property


    Public Property serverDB As String
        Get
            Return srvSQL.ToString
        End Get
        Set(value As String)
            Me.srvSQL = value
            serversql = value
        End Set
    End Property

    Public Property userDB As String
        Get
            Return usrDB
        End Get
        Set(value As String)
            Me.usrDB = value
            usuariodb = value
        End Set
    End Property

    Public Property passwordDB As String
        Get
            Return pswDB
        End Get
        Set(value As String)
            Me.pswDB = value
            passdb = value
        End Set
    End Property

    Public Property backupPath As String
        Get
            Return bckupDir
        End Get
        Set(value As String)
            Me.bckupDir = value
            rutaBackup = value
        End Set
    End Property

    Public Property backupFile As String
        Get
            Return bckupFile
        End Get
        Set(value As String)
            Me.bckupFile = value
            archivoBackup = value
        End Set
    End Property

    Public Property sep_Decimal As String
        Get
            Return sepdec
        End Get
        Set(value As String)
            Me.sepdec = value
            sepDecimal = value
        End Set
    End Property

    Public Property itemsPorPagina As String
        Get
            Return itPerPage
        End Get
        Set(value As String)
            Me.itPerPage = value
        End Set
    End Property


    Public Sub guardarConfig()
        Dim strEncrypt As New Encriptar
        Dim fs As FileStream = File.Create(path)
        Dim str As Byte()

        str = New UTF8Encoding(True).GetBytes("basedb = " & db & vbCrLf &
                "serversql = " & srvSQL & vbCrLf &
                "usuariodb = " & strEncrypt.Encriptar(usrDB) & vbCrLf &
                "passdb = " & strEncrypt.Encriptar(pswDB) & vbCrLf &
                "rutaBackup = " & bckupDir & vbCrLf &
                "nombreBackup = " & bckupFile & vbCrLf &
                "sepDecimal = " & sepdec & vbCrLf &
                "itPerPage = " & itPerPage)

        fs.Write(str, 0, str.Length)
        fs.Close()
    End Sub

    Public Sub leerConfig()
        Dim strDesc As New Encriptar
        Dim objReader As New StreamReader(path)
        Dim str As String = ""
        Dim arrSTR As New ArrayList
        Dim c As Integer = 0

        Do
            c = c + 1
            str = objReader.ReadLine()
            If c = 1 Then
                basedb = obtieneValorConfig(str)
                db = basedb
            ElseIf c = 2 Then
                serversql = obtieneValorConfig(str)
                srvSQL = serversql
            ElseIf c = 3 Then
                usuariodb = strDesc.Desencriptar(obtieneValorConfig(str))
                usrDB = usuariodb
            ElseIf c = 4 Then
                passdb = strDesc.Desencriptar(obtieneValorConfig(str))
                pswDB = passdb
            ElseIf c = 5 Then
                rutaBackup = obtieneValorConfig(str)
                bckupDir = rutaBackup
            ElseIf c = 6 Then
                archivoBackup = obtieneValorConfig(str)
                bckupFile = archivoBackup
            ElseIf c = 7 Then
                sepDecimal = obtieneValorConfig(str)
                sepdec = sepDecimal
            ElseIf c = 8 Then
                itXPage = obtieneValorConfig(str)
                itPerPage = itXPage
            End If
        Loop Until str Is Nothing
        objReader.Close()
    End Sub
End Class
