Module autoajuste
    Dim ctrlwidth_viejo As Double() 'ancho viejo control
    Dim ctrlheight_viejo As Double() 'largo viejo control

    Dim ctrlwidth_actual As Double() 'ancho actual control
    Dim ctrlheight_actual As Double() 'largo actual control

    Public ctrlwidth_nuevo As Double() 'ancho nuevo control
    Public ctrlheight_nuevo As Double() 'largo nuevo control

    Dim frmwidth_viejo As Double 'ancho viejo formulario
    Dim frmheight_viejo As Double 'largo viejo formulario

    Dim frmwidth_actual As Double 'ancho actual formulario
    Dim frmheight_actual As Double 'largo actual formulario

    Dim frmwidth_nuevo As Double 'ancho nuevo formulario
    Dim frmheight_nuevo As Double 'largo nuevo formulario

    Dim ctrlx_viejo As Double() 'distancia vertical vieja control
    Dim ctrly_viejo As Double() 'distancia horizontal vieja control

    Dim ctrlx_actual As Double() 'distancia vertical actual control
    Dim ctrly_actual As Double() 'distancia horizontal actual control

    Public ctrlx_nuevo As Double() 'distancia vertical nueva control
    Public ctrly_nuevo As Double() 'distancia horizontal nueva control

    Dim frmx_viejo As Double 'distancia vertical vieja formulario
    Dim frmy_viejo As Double 'distancia horizontal vieja formulario

    Dim frmx_actual As Double 'distancia vertical actual formulario
    Dim frmy_actual As Double 'distancia horizontal actual formulario

    Dim frmx_nuevo As Double 'distancia vertical nueva formulario
    Dim frmy_nuevo As Double 'distancia horizontal nueva formulario

    Dim cctrl As Integer 'cantidad de controles en el formulario

    Public Sub ajustarcontrol(frm As Form, toma As Boolean)
        If toma Then
            tomarvalores(frm)
        Else
            setearvalores(frm)
        End If
    End Sub

    Private Sub tomarvalores(frm As Form)

        'obtengo la cantidad de controles del formulario
        cctrl = frm.Controls.Count - 1

        ReDim ctrlwidth_viejo(cctrl) 'ancho viejo control
        ReDim ctrlheight_viejo(cctrl) 'largo viejo control

        ReDim ctrlwidth_actual(cctrl) 'ancho actual control
        ReDim ctrlheight_actual(cctrl) 'largo actual control

        ReDim ctrlwidth_nuevo(cctrl) 'ancho nuevo control
        ReDim ctrlheight_nuevo(cctrl) 'largo nuevo control

        ReDim ctrlx_viejo(cctrl) 'distancia vertical vieja control
        ReDim ctrly_viejo(cctrl) 'distancia horizontal vieja control

        ReDim ctrlx_actual(cctrl) 'distancia vertical actual control
        ReDim ctrly_actual(cctrl) 'distancia horizontal actual control

        ReDim ctrlx_nuevo(cctrl) 'distancia vertical nueva control
        ReDim ctrly_nuevo(cctrl) 'distancia horizontal nueva control

        'tomo el tamaño actual del formulario
        frmwidth_actual = frm.Width
        frmheight_actual = frm.Height

        'tomo la posición actual del formulario
        frmx_actual = frm.Location.X
        frmy_actual = frm.Location.Y
        If frmx_actual = 0 Then frmx_actual = 1
        If frmy_actual = 0 Then frmy_actual = 1

        For i As Integer = 0 To cctrl
            'tomo el tamaño actual del control
            ctrlwidth_actual(i) = frm.Controls.Item(i).Width
            ctrlheight_actual(i) = frm.Controls.Item(i).Height

            'tomo la posición actual del control
            ctrlx_actual(i) = frm.Controls.Item(i).Location.X
            ctrly_actual(i) = frm.Controls.Item(i).Location.Y
        Next
    End Sub

    Private Sub setearvalores(frm As Form)
        Dim i As Integer
        Dim x, y As Double

        'tomo el nuevo tamaño del formulario
        frmwidth_nuevo = frm.Width
        frmheight_nuevo = frm.Height

        'tomo la nueva posición del formulario
        frmx_nuevo = frm.Location.X
        frmy_nuevo = frm.Location.Y
        If frmx_nuevo = 0 Then frmx_nuevo = 1
        If frmy_nuevo = 0 Then frmy_nuevo = 1

        'los valores actuales pasan a ser viejos, me van a quedar los viejos siendo los originales

        frmwidth_viejo = frmwidth_actual
        frmheight_viejo = frmheight_actual

        frmx_viejo = frmx_actual
        frmy_viejo = frmy_actual
        'If frmwidth_viejo = frmwidth_nuevo And frmheight_viejo = frmheight_nuevo Then Exit Sub

        For i = 0 To cctrl
            ctrlwidth_viejo(i) = ctrlwidth_actual(i)
            ctrlheight_viejo(i) = ctrlheight_actual(i)

            ctrlx_viejo(i) = ctrlx_actual(i)
            ctrly_viejo(i) = ctrly_actual(i)
        Next

        'calculo el nuevo tamaño del control
        For i = 0 To cctrl
            'ancho
            ctrlwidth_nuevo(i) = (frmwidth_nuevo * ctrlwidth_viejo(i)) / frmwidth_viejo
            'alto
            ctrlheight_nuevo(i) = (frmheight_nuevo * ctrlheight_viejo(i)) / frmheight_viejo

            'calculo la nueva posición del control

            x = ((ctrlx_viejo(i) * 100) / frmwidth_viejo) / 100
            y = ((ctrly_viejo(i) * 100) / frmheight_viejo) / 100
            ctrlx_nuevo(i) = frmwidth_nuevo * x
            ctrly_nuevo(i) = frmheight_nuevo * y

            'ctrlx_nuevo = (frmx_nuevo * ctrlx_viejo) / frmx_viejo
            'ctrly_nuevo = (frmy_nuevo * ctrly_viejo) / frmy_viejo

            'asigno los valores
            'tamaño
            'frm.Controls.Item(i).Width = ctrlwidth_nuevo(i)
            'frm.Controls.Item(i).Height = ctrlheight_nuevo(i)

            'posición
            'frm.Controls.Item(i).Left = ctrlx_nuevo(i)
            'frm.Controls.Item(i).Top = ctrly_nuevo(i)
        Next
    End Sub
End Module
