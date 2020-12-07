Public Class add_impuesto
    Private esRetencion As Boolean
    Private esPercepcion As Boolean
    Public id_impuesto As Integer
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal _esRetencion As Boolean, ByVal _esPercepcion As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        esRetencion = _esRetencion
        esPercepcion = _esPercepcion
    End Sub
    Private Sub cmd_ok_Click(sender As Object, e As EventArgs) Handles cmd_ok.Click
        If txt_nombre.Text = "" Then
            MsgBox("El campo 'Impuesto (%)' es obligatorio y está vacio")
            Exit Sub
        ElseIf txt_porcentaje.Text = "" Then
            MsgBox("El campo 'Porcentaje' es obligatorio y está vacio")
            Exit Sub
        End If

        Dim tmp As New impuesto

        tmp.nombre = txt_nombre.Text
        tmp.porcentaje = txt_porcentaje.Text
        tmp.esRetencion = chk_esRetencion.Checked
        tmp.esPercepcion = chk_esPercepcion.Checked
        tmp.activo = chk_activo.Checked

        If edicion = True Then
            tmp.id_impuesto = edita_impuesto.id_impuesto
            If updateImpuesto(tmp) = False Then
                MsgBox("Hubo un problema al actualizar el impuesto, consulte con su programdor", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If
        Else
            id_impuesto = addImpuesto(tmp)
            If id_impuesto = -1 Then
                MsgBox("Hubo un problema al dar de alta el impuesto, consulte con su programdor", vbExclamation + vbOKOnly, "Centrex")
                closeandupdate(Me)
            End If
        End If

        If chk_secuencia.Checked = True Then
            txt_nombre.Text = ""
            txt_porcentaje.Text = ""
            chk_activo.Checked = True
        Else
            closeandupdate(Me)
        End If
    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        closeandupdate(Me)
    End Sub

    Private Sub add_marcai_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        closeandupdate(Me)
    End Sub

    Private Sub add_descuento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_activo.Checked = True
        If edicion = True Or borrado = True Then
            chk_secuencia.Enabled = False
            txt_nombre.Text = edita_impuesto.nombre
            txt_porcentaje.Text = edita_impuesto.porcentaje
            chk_esPercepcion.Checked = edita_impuesto.esPercepcion
            chk_esRetencion.Checked = edita_impuesto.esRetencion
            chk_activo.Checked = edita_impuesto.activo
        End If

        If borrado = True Then
            txt_nombre.Enabled = False
            txt_porcentaje.Enabled = False
            chk_esRetencion.Enabled = False
            chk_esPercepcion.Enabled = False
            chk_activo.Enabled = False
            cmd_ok.Visible = False
            cmd_exit.Visible = False
            Me.Show()
            If MsgBox("¿Está seguro que desea borrar este impuesto?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                If (borrarImpuesto(edita_impuesto)) = False Then
                    If (MsgBox("Ocurrió un error al realizar el borrado del impuesto, ¿desea intectar desactivarlo para que no aparezca en la búsqueda?" _
                     , MsgBoxStyle.Question + MsgBoxStyle.YesNo)) = vbYes Then
                        'Realizo un borrado lógico
                        If updateImpuesto(edita_impuesto, True) = True Then
                            MsgBox("Se ha podido realizar un borrado lógico, pero el impuesto no se borró definitivamente." + Chr(13) +
                                "Esto posiblemente se deba a que el impuesto, tiene operaciones realizadas y por lo tanto no podrá borrarse", vbInformation)
                        Else
                            MsgBox("No se ha podido borrar el impuesto, consulte con el programador")
                        End If
                    End If
                End If
            End If
            closeandupdate(Me)
        End If

        If esRetencion Then
            chk_esRetencion.Checked = True
            chk_esRetencion.Enabled = False
            chk_esPercepcion.Enabled = False
            chk_secuencia.Enabled = False
            txt_porcentaje.Text = "0"
        ElseIf esPercepcion Then
            chk_esPercepcion.Checked = True
            chk_esPercepcion.Enabled = False
            chk_esRetencion.Enabled = False
            chk_secuencia.Enabled = False
            txt_porcentaje.Text = "0"
        End If
    End Sub
End Class