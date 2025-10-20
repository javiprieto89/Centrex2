Imports System.Text.RegularExpressions

''' <summary>
''' Enum para tipos de validación
''' </summary>
Public Enum ValidationType
    Text
    LettersOnly
    NumbersOnly
    PhoneNumber
    Email
    DecimalNumber
    LicensePlate
    CUIT
    DNI
End Enum

''' <summary>
''' Módulo helper para validaciones comunes
''' Centraliza todas las validaciones de entrada de datos
''' </summary>
Module ValidationHelper
    
    ''' <summary>
    ''' Valida caracteres de entrada según el tipo especificado
    ''' </summary>
    Public Function ValidateInput(input As String, validationType As ValidationType) As Boolean
        Select Case validationType
            Case ValidationType.Text
                Return Not String.IsNullOrWhiteSpace(input)
            Case ValidationType.LettersOnly
                Return System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            Case ValidationType.NumbersOnly
                Return System.Text.RegularExpressions.Regex.IsMatch(input, "^\d+$")
            Case ValidationType.PhoneNumber
                Return System.Text.RegularExpressions.Regex.IsMatch(input, "^[\d\-\(\)\s]+$")
            Case ValidationType.Email
                Return System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            Case ValidationType.DecimalNumber
                Return System.Text.RegularExpressions.Regex.IsMatch(input, "^[\d.,\-]+$")
            Case ValidationType.LicensePlate
                Return System.Text.RegularExpressions.Regex.IsMatch(input, "^[A-Z]{3}\d{3}$")
            Case ValidationType.CUIT
                Return System.Text.RegularExpressions.Regex.IsMatch(input, "^\d{2}-\d{8}-\d{1}$")
            Case Else
                Return True
        End Select
    End Function
    
    ''' <summary>
    ''' Valida si un campo está vacío o solo contiene espacios
    ''' </summary>
    Public Function IsEmptyOrWhitespace(value As String) As Boolean
        Return String.IsNullOrWhiteSpace(value)
    End Function
    
    ''' <summary>
    ''' Valida si un valor está dentro de un rango numérico
    ''' </summary>
    Public Function IsInRange(value As Decimal, minValue As Decimal, maxValue As Decimal) As Boolean
        Return value >= minValue AndAlso value <= maxValue
    End Function
    
    ''' <summary>
    ''' Valida si una fecha está dentro de un rango válido
    ''' </summary>
    Public Function IsValidDateRange(dateValue As Date, minDate As Date, maxDate As Date) As Boolean
        Return dateValue >= minDate AndAlso dateValue <= maxDate
    End Function
    
    ''' <summary>
    ''' Valida si un CUIT es válido según el algoritmo de AFIP
    ''' </summary>
    Public Function IsValidCUIT(cuit As String) As Boolean
        If Not System.Text.RegularExpressions.Regex.IsMatch(cuit, "^\d{11}$") Then Return False
        
        Dim multipliers As Integer() = {5, 4, 3, 2, 7, 6, 5, 4, 3, 2}
        Dim sum As Integer = 0
        
        For i As Integer = 0 To 9
            sum += CInt(cuit.Substring(i, 1)) * multipliers(i)
        Next
        
        Dim remainder As Integer = sum Mod 11
        Dim checkDigit As Integer = If(remainder < 2, remainder, 11 - remainder)
        
        Return checkDigit = CInt(cuit.Substring(10, 1))
    End Function
    
    ''' <summary>
    ''' Valida si un DNI es válido (8 dígitos)
    ''' </summary>
    Public Function IsValidDNI(dni As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(dni, "^\d{8}$")
    End Function
    
    ''' <summary>
    ''' Valida si un email tiene formato válido
    ''' </summary>
    Public Function IsValidEmail(email As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
    End Function
    
    ''' <summary>
    ''' Valida si un teléfono tiene formato válido
    ''' </summary>
    Public Function IsValidPhone(phone As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(phone, "^[\d\-\(\)\s]+$")
    End Function
    
    ''' <summary>
    ''' Valida si un precio es válido (positivo y con formato correcto)
    ''' </summary>
    Public Function IsValidPrice(price As String) As Boolean
        If Not Decimal.TryParse(price.Replace(sepDecimal, "."), Nothing) Then Return False
        Dim decimalPrice As Decimal = CDec(price.Replace(sepDecimal, "."))
        Return decimalPrice >= 0
    End Function
    
    ''' <summary>
    ''' Valida si una cantidad es válida (positiva)
    ''' </summary>
    Public Function IsValidQuantity(quantity As String) As Boolean
        If Not Decimal.TryParse(quantity.Replace(sepDecimal, "."), Nothing) Then Return False
        Dim decimalQuantity As Decimal = CDec(quantity.Replace(sepDecimal, "."))
        Return decimalQuantity > 0
    End Function
    
    ''' <summary>
    ''' Valida si un porcentaje es válido (entre 0 y 100)
    ''' </summary>
    Public Function IsValidPercentage(percentage As String) As Boolean
        If Not Decimal.TryParse(percentage.Replace(sepDecimal, "."), Nothing) Then Return False
        Dim decimalPercentage As Decimal = CDec(percentage.Replace(sepDecimal, "."))
        Return decimalPercentage >= 0 AndAlso decimalPercentage <= 100
    End Function
    
End Module
