Imports System.Data.SqlClient

Public Class TipoComprobante
    Private _id_tipoComprobante As Integer
    Private _comprobante_AFIP As String
    Private _id_claseFiscal As String
    Private _signoProveedor As Char
    Private _signoCliente As Char
    Private _discriminaIVA As Boolean
    Private _esRemito As Boolean


    Public Sub New()
        MyBase.New()
        Constructor()
    End Sub

    Public Sub New(ByVal id_tipoComprobante As Integer)
        MyBase.New()
        Constructor()
        Info_Tipo_Comprobante(id_tipoComprobante)
    End Sub

    Private Sub Constructor()
        _id_tipoComprobante = "-1"
        _comprobante_AFIP = ""
        _id_claseFiscal = ""
        _signoProveedor = ""
        _signoCliente = ""
        _discriminaIVA = False
        _esRemito = False
    End Sub

    Public ReadOnly Property id_tipoComprobante As Integer
        Get
            Return _id_tipoComprobante
        End Get
    End Property

    Public ReadOnly Property comprobante_AFIP As String
        Get
            Return _comprobante_AFIP
        End Get
    End Property

    Public ReadOnly Property id_claseFiscal As String
        Get
            Return _id_claseFiscal
        End Get
    End Property

    Public ReadOnly Property signoProveedor As Char
        Get
            Return _signoProveedor
        End Get
    End Property

    Public ReadOnly Property signoCliente As Char
        Get
            Return _signoCliente
        End Get
    End Property

    Public ReadOnly Property discriminaIVA As Boolean
        Get
            Return _discriminaIVA
        End Get
    End Property

    Public ReadOnly Property esRemito As Boolean
        Get
            Return _esRemito
        End Get
    End Property



    Private Sub Info_Tipo_Comprobante(ByVal id_tipoComprobante As String)
        Dim sqlstr As String

        sqlstr = "SELECT tc.id_tipoComprobante, tc.comprobante_AFIP, tc.id_claseFiscal, tc.signoProveedor, tc.signoCliente, tc.discriminaIVA, tc.esRemito " &
                    "FROM tipos_comprobantes AS tc " &
                    "WHERE tc.id_tipoComprobante = '" + id_tipoComprobante + "'"

        Try
            'Crea y abre una nueva conexión
            abrirdb(serversql, basedb, usuariodb, passdb)

            'Propiedades del SqlCommand
            Dim comando As New SqlCommand
            With comando
                .CommandType = CommandType.Text
                .CommandText = sqlstr
                .Connection = CN
            End With

            Dim da As New SqlDataAdapter 'Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet 'Crear nuevo dataset

            da.SelectCommand = comando

            'llenar el dataset
            da.Fill(dataset, "Tabla")
            _id_tipoComprobante = dataset.Tables("tabla").Rows(0).Item(0).ToString
            _comprobante_AFIP = dataset.Tables("tabla").Rows(0).Item(1).ToString
            _id_claseFiscal = dataset.Tables("tabla").Rows(0).Item(2).ToString
            _signoProveedor = dataset.Tables("tabla").Rows(0).Item(3).ToString
            _signoCliente = dataset.Tables("tabla").Rows(0).Item(4).ToString
            _discriminaIVA = dataset.Tables("tabla").Rows(0).Item(5).ToString
            _esRemito = dataset.Tables("tabla").Rows(0).Item(6).ToString
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            _id_tipoComprobante = -1
        Finally
            cerrardb()
        End Try
    End Sub

End Class
