"' Entidad relación Item-Impuesto con clave compuesta (id_item, id_impuesto)
Public Class ItemImpuestoEntity
    ' Clave compuesta
    Public Property IdItem As Integer
    Public Property IdImpuesto As Integer
    Public Property Activo As Boolean

    ' Navegación (opcional)
    Public Overridable Property Item As ItemEntity
    Public Overridable Property Impuesto As ImpuestoEntity
End Class
