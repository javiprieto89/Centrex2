Imports System.Windows.Forms
Imports System.Drawing

''' <summary>
''' Módulo helper para operaciones comunes de formularios
''' Centraliza funciones repetitivas de UI
''' </summary>
Module FormHelper
    
    ''' <summary>
    ''' Limpia todos los controles de un formulario
    ''' </summary>
    Public Sub ClearForm(form As Form)
        For Each control As Control In form.Controls
            ClearControl(control)
        Next
    End Sub
    
    ''' <summary>
    ''' Limpia un control específico según su tipo
    ''' </summary>
    Private Sub ClearControl(control As Control)
        Select Case control.GetType()
            Case GetType(TextBox)
                CType(control, TextBox).Text = ""
            Case GetType(ComboBox)
                CType(control, ComboBox).SelectedIndex = -1
                CType(control, ComboBox).Text = ""
            Case GetType(CheckBox)
                CType(control, CheckBox).Checked = False
            Case GetType(RadioButton)
                CType(control, RadioButton).Checked = False
            Case GetType(DateTimePicker)
                CType(control, DateTimePicker).Value = DateTime.Now
            Case GetType(NumericUpDown)
                CType(control, NumericUpDown).Value = 0
            Case GetType(DataGridView)
                CType(control, DataGridView).DataSource = Nothing
        End Select
        
        ' Limpiar controles anidados
        For Each childControl As Control In control.Controls
            ClearControl(childControl)
        Next
    End Sub
    
    ''' <summary>
    ''' Habilita o deshabilita todos los controles de un formulario
    ''' </summary>
    Public Sub SetFormEnabled(form As Form, enabled As Boolean)
        For Each control As Control In form.Controls
            SetControlEnabled(control, enabled)
        Next
    End Sub
    
    ''' <summary>
    ''' Habilita o deshabilita un control específico
    ''' </summary>
    Private Sub SetControlEnabled(control As Control, enabled As Boolean)
        control.Enabled = enabled
        
        ' Aplicar a controles anidados
        For Each childControl As Control In control.Controls
            SetControlEnabled(childControl, enabled)
        Next
    End Sub
    
    ''' <summary>
    ''' Centra un formulario en la pantalla
    ''' </summary>
    Public Sub CenterForm(form As Form)
        form.StartPosition = FormStartPosition.CenterScreen
    End Sub
    
    ''' <summary>
    ''' Centra un formulario respecto a otro formulario padre
    ''' </summary>
    Public Sub CenterFormToParent(form As Form, parentForm As Form)
        form.StartPosition = FormStartPosition.CenterParent
        form.Owner = parentForm
    End Sub
    
    ''' <summary>
    ''' Configura un DataGridView con propiedades comunes
    ''' </summary>
    Public Sub ConfigureDataGrid(grid As DataGridView, Optional allowEdit As Boolean = False)
        grid.AllowUserToAddRows = False
        grid.AllowUserToDeleteRows = False
        grid.ReadOnly = Not allowEdit
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grid.MultiSelect = False
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grid.BackgroundColor = Color.White
        grid.BorderStyle = BorderStyle.Fixed3D
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
        grid.ColumnHeadersDefaultCellStyle.Font = New Font(grid.Font, FontStyle.Bold)
        grid.EnableHeadersVisualStyles = False
    End Sub
    
    ''' <summary>
    ''' Configura un ComboBox con propiedades comunes
    ''' </summary>
    Public Sub ConfigureComboBox(combo As ComboBox, Optional defaultText As String = "Seleccione...")
        combo.DropDownStyle = ComboBoxStyle.DropDownList
        combo.Text = defaultText
    End Sub
    
    ''' <summary>
    ''' Configura un TextBox para solo números
    ''' </summary>
    Public Sub ConfigureNumericTextBox(textBox As TextBox, Optional allowDecimals As Boolean = True)
        AddHandler textBox.KeyPress, Sub(sender, e)
                                        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
                                            If allowDecimals AndAlso e.KeyChar = sepDecimal AndAlso Not textBox.Text.Contains(sepDecimal) Then
                                                ' Permitir separador decimal
                                            Else
                                                e.Handled = True
                                            End If
                                        End If
                                    End Sub
    End Sub
    
    ''' <summary>
    ''' Configura un TextBox para solo letras
    ''' </summary>
    Public Sub ConfigureLetterTextBox(textBox As TextBox)
        AddHandler textBox.KeyPress, Sub(sender, e)
                                        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> " "c Then
                                            e.Handled = True
                                        End If
                                    End Sub
    End Sub
    
    ''' <summary>
    ''' Muestra un mensaje de error con formato estándar
    ''' </summary>
    Public Sub ShowError(message As String, Optional title As String = "Error")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    
    ''' <summary>
    ''' Muestra un mensaje de información con formato estándar
    ''' </summary>
    Public Sub ShowInfo(message As String, Optional title As String = "Información")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    
    ''' <summary>
    ''' Muestra un mensaje de advertencia con formato estándar
    ''' </summary>
    Public Sub ShowWarning(message As String, Optional title As String = "Advertencia")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    
    ''' <summary>
    ''' Muestra un diálogo de confirmación
    ''' </summary>
    Public Function ShowConfirmation(message As String, Optional title As String = "Confirmar") As Boolean
        Return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function
    
    ''' <summary>
    ''' Valida que todos los campos requeridos estén completos
    ''' </summary>
    Public Function ValidateRequiredFields(form As Form, requiredFields As List(Of Control)) As Boolean
        For Each field As Control In requiredFields
            If IsEmptyOrWhitespace(field.Text) Then
                ShowError($"El campo {field.Name} es requerido", "Validación")
                field.Focus()
                Return False
            End If
        Next
        Return True
    End Function
    
    ''' <summary>
    ''' Formatea un número como precio con símbolo de moneda
    ''' </summary>
    Public Function FormatPrice(price As Decimal) As String
        Return $"$ {price:N2}"
    End Function
    
    ''' <summary>
    ''' Formatea un número como porcentaje
    ''' </summary>
    Public Function FormatPercentage(percentage As Decimal) As String
        Return $"{percentage:N2}%"
    End Function
    
    ''' <summary>
    ''' Formatea una fecha según el formato estándar del sistema
    ''' </summary>
    Public Function FormatDate(dateValue As Date) As String
        Return dateValue.ToString("dd/MM/yyyy")
    End Function
    
    ''' <summary>
    ''' Formatea una fecha y hora según el formato estándar del sistema
    ''' </summary>
    Public Function FormatDateTime(dateValue As Date) As String
        Return dateValue.ToString("dd/MM/yyyy HH:mm")
    End Function
    
    ''' <summary>
    ''' Muestra un mensaje de pregunta con botones Sí/No
    ''' </summary>
    Public Function ShowQuestionMessage(message As String) As DialogResult
        Return MessageBox.Show(message, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Function


    ''' <summary>
    ''' Obtiene la fecha y hora actual
    ''' </summary>
    Public Function Ahora() As DateTime
        Return DateTime.Now
    End Function
    
    Public Function ShowInfoMessage(ByVal message As String, ByVal title As String) As DialogResult
        Try
            Return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Return DialogResult.OK
        End Try
    End Function

    Public Function ShowErrorMessage(ByVal message As String, ByVal title As String) As DialogResult
        Try
            Return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            Return DialogResult.OK
        End Try
    End Function

    Public Function SetupDataGridView(ByVal dataGrid As DataGridView) As Boolean
        Try
            ' Esta función debería configurar un DataGridView
            ' Por ahora retornamos True para evitar errores de compilación
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
