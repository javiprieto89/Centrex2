Imports System.IO
Imports System.Text
Imports Centrex.Afip
Imports Centrex.Afip.Models


Public Class frm_pruebas_afip
    Private Sub frm_pruebas_afip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar configuración inicial
        CargarConfiguracion()
    End Sub

    Private Sub CargarConfiguracion()
        ' Cargar valores por defecto
        txt_cuit.Text = cuit_emisor_default
        
        ' Cargar opciones de modo
        cmb_mode.Items.Clear()
        cmb_mode.Items.Add("HOMO")
        cmb_mode.Items.Add("PROD")
        cmb_mode.SelectedIndex = 0 ' Por defecto HOMO
        
        ' Cargar certificados disponibles
        CargarCertificados()
    End Sub

    Private Sub CargarCertificados()
        cmb_certificados.Items.Clear()
        Dim certificadosPath As String = Application.StartupPath + "\Certificados\"
        
        If Directory.Exists(certificadosPath) Then
            Dim archivos As String() = Directory.GetFiles(certificadosPath, "*.pfx")
            For Each archivo As String In archivos
                cmb_certificados.Items.Add(Path.GetFileName(archivo))
            Next
        End If
        
        If cmb_certificados.Items.Count > 0 Then
            cmb_certificados.SelectedIndex = 0
        End If
    End Sub

    Private Sub btn_probar_conexion_Click(sender As Object, e As EventArgs) Handles btn_probar_conexion.Click
        Try
            ' Validar datos
            If String.IsNullOrWhiteSpace(txt_cuit.Text) Then
                MsgBox("Debe ingresar el CUIT emisor", vbExclamation, "Centrex")
                Return
            End If

            If cmb_certificados.SelectedItem Is Nothing Then
                MsgBox("Debe seleccionar un certificado", vbExclamation, "Centrex")
                Return
            End If

            If String.IsNullOrWhiteSpace(txt_password.Text) Then
                MsgBox("Debe ingresar la contraseña del certificado", vbExclamation, "Centrex")
                Return
            End If

            ' Configurar valores dinámicos
            Dim certificadoPath As String = Application.StartupPath + "\Certificados\" + cmb_certificados.SelectedItem.ToString()
            AfipConfig.DynamicCertPath = certificadoPath
            AfipConfig.DynamicCertPassword = txt_password.Text
            AfipConfig.DynamicCuitEmisor = CLng(txt_cuit.Text)

            ' Determinar modo
            Dim esTest As Boolean = (cmb_mode.SelectedItem.ToString().ToUpper() = "HOMO")

            ' Probar conexión
            btn_probar_conexion.Enabled = False
            txt_resultado.Text = "Probando conexión..."
            Application.DoEvents()

            'Dim resultado As String = ProbarConexionAFIP(esTest)
            'txt_resultado.Text = resultado

        Catch ex As Exception
            txt_resultado.Text = "ERROR: " & ex.Message & vbCrLf & "Tipo: " & ex.GetType().Name
        Finally
            btn_probar_conexion.Enabled = True
        End Try
    End Sub

    Private Sub btn_probar_ultimo_comprobante_Click(sender As Object, e As EventArgs) Handles btn_probar_ultimo_comprobante.Click
        Try
            ' Validar datos
            If String.IsNullOrWhiteSpace(txt_punto_venta.Text) Then
                MsgBox("Debe ingresar el punto de venta", vbExclamation, "Centrex")
                Return
            End If

            If String.IsNullOrWhiteSpace(txt_tipo_comprobante.Text) Then
                MsgBox("Debe ingresar el tipo de comprobante", vbExclamation, "Centrex")
                Return
            End If

            ' Configurar valores dinámicos (usar los mismos del botón anterior)
            If String.IsNullOrWhiteSpace(AfipConfig.DynamicCertPath) Then
                MsgBox("Primero debe probar la conexión básica", vbExclamation, "Centrex")
                Return
            End If

            ' Determinar modo
            Dim esTest As Boolean = (cmb_mode.SelectedItem.ToString().ToUpper() = "HOMO")

            ' Probar último comprobante
            btn_probar_ultimo_comprobante.Enabled = False
            txt_resultado.Text = "Consultando último comprobante..."
            Application.DoEvents()

            Dim afipMode = If(esTest, Afip.AfipMode.HOMO, Afip.AfipMode.PROD)
            Dim wsfe = WSFEv1.CreateWithTa(afipMode)
            Dim ultimoCmp = wsfe.FECompUltimoAutorizado(CInt(txt_punto_venta.Text), CInt(txt_tipo_comprobante.Text))

            txt_resultado.Text = "ÉXITO: Último comprobante autorizado: " & ultimoCmp.ToString() & vbCrLf &
                               "Punto de venta: " & txt_punto_venta.Text & vbCrLf &
                               "Tipo de comprobante: " & txt_tipo_comprobante.Text

        Catch ex As Exception
            txt_resultado.Text = "ERROR: " & ex.Message & vbCrLf & "Tipo: " & ex.GetType().Name
        Finally
            btn_probar_ultimo_comprobante.Enabled = True
        End Try
    End Sub

    Private Sub btn_probar_parametros_Click(sender As Object, e As EventArgs) Handles btn_probar_parametros.Click
        Try
            ' Configurar valores dinámicos (usar los mismos del botón anterior)
            If String.IsNullOrWhiteSpace(AfipConfig.DynamicCertPath) Then
                MsgBox("Primero debe probar la conexión básica", vbExclamation, "Centrex")
                Return
            End If

            ' Determinar modo
            Dim esTest As Boolean = (cmb_mode.SelectedItem.ToString().ToUpper() = "HOMO")

            ' Probar parámetros
            btn_probar_parametros.Enabled = False
            txt_resultado.Text = "Consultando parámetros AFIP..."
            Application.DoEvents()

            Dim afipMode = If(esTest, Afip.AfipMode.HOMO, Afip.AfipMode.PROD)
            Dim wsfe = WSFEv1.CreateWithTa(afipMode)

            Dim resultado As New StringBuilder()
            resultado.AppendLine("PARÁMETROS AFIP:")
            resultado.AppendLine("=================")

            ' Probar diferentes parámetros
            Try
                Dim tiposIva = wsfe.FEParamGetTiposIva()
                resultado.AppendLine("✓ Tipos de IVA: OK")
            Catch ex As Exception
                resultado.AppendLine("✗ Tipos de IVA: " & ex.Message)
            End Try

            Try
                Dim tiposTributos = wsfe.FEParamGetTiposTributos()
                resultado.AppendLine("✓ Tipos de Tributos: OK")
            Catch ex As Exception
                resultado.AppendLine("✗ Tipos de Tributos: " & ex.Message)
            End Try

            Try
                Dim monedas = wsfe.FEParamGetTiposMonedas()
                resultado.AppendLine("✓ Monedas: OK")
            Catch ex As Exception
                resultado.AppendLine("✗ Monedas: " & ex.Message)
            End Try

            Try
                Dim ptosVenta = wsfe.FEParamGetPtosVenta()
                resultado.AppendLine("✓ Puntos de Venta: OK")
            Catch ex As Exception
                resultado.AppendLine("✗ Puntos de Venta: " & ex.Message)
            End Try

            Try
                Dim opcionales = wsfe.FEParamGetTiposOpcional()
                resultado.AppendLine("✓ Tipos Opcionales: OK")
            Catch ex As Exception
                resultado.AppendLine("✗ Tipos Opcionales: " & ex.Message)
            End Try

            txt_resultado.Text = resultado.ToString()

        Catch ex As Exception
            txt_resultado.Text = "ERROR: " & ex.Message & vbCrLf & "Tipo: " & ex.GetType().Name
        Finally
            btn_probar_parametros.Enabled = True
        End Try
    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        txt_resultado.Text = ""
    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Me.Close()
    End Sub

    Private Sub Btn_obtener_puntos_de_venta_Click(sender As Object, e As EventArgs) Handles btn_obtener_puntos_de_venta.Click
        Dim resultado As New StringBuilder()

        Try
            ' Validar que ya se haya probado la conexión
            If String.IsNullOrWhiteSpace(AfipConfig.DynamicCertPath) Then
                MsgBox("Primero debe probar la conexión básica", vbExclamation, "Centrex")
                Return
            End If

            ' Determinar modo (HOMO o PROD)
            Dim esTest As Boolean = (cmb_mode.SelectedItem.ToString().ToUpper() = "HOMO")

            ' Mostrar estado
            btn_probar_parametros.Enabled = False
            txt_resultado.Text = "Consultando puntos de venta AFIP..."
            Application.DoEvents()

            ' Crear cliente WSFEv1 con el TA actual
            Dim afipMode = If(esTest, Afip.AfipMode.HOMO, Afip.AfipMode.PROD)
            Dim wsfe = WSFEv1.CreateWithTa(afipMode)

            ' --- Llamada al servicio ---
            Try
                Dim ptosVenta As List(Of PtoVentaInfo) = wsfe.FEParamGetPtosVenta()

                If ptosVenta Is Nothing OrElse ptosVenta.Count = 0 Then
                    resultado.AppendLine("✗ No se encontraron puntos de venta habilitados.")
                Else
                    resultado.AppendLine("✓ Puntos de venta habilitados:")

                    For Each pto In ptosVenta
                        resultado.AppendLine($"  • Nro: {pto.Nro} | Tipo: {pto.EmisionTipo} | Bloqueado: {pto.Bloqueado} | Baja: {pto.FchBaja}")
                    Next

                    resultado.AppendLine()
                    resultado.AppendLine($"Total: {ptosVenta.Count} puntos de venta encontrados.")
                End If

            Catch ex As Exception
                resultado.AppendLine("✗ Error al consultar puntos de venta:")
                resultado.AppendLine(ex.Message)
            End Try

        Catch ex As Exception
            resultado.AppendLine("✗ Error general:")
            resultado.AppendLine(ex.Message)
        Finally
            ' Mostrar el resultado en el TextBox
            txt_resultado.Text = resultado.ToString()
            btn_probar_parametros.Enabled = True
        End Try
    End Sub


End Class
