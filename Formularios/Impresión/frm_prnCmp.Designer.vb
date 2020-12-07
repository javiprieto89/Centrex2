<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_prnCmp
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DbCentrexDataSet = New Centrex.dbCentrexDataSet()
        Me.Factura_cabeceraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Factura_cabeceraTableAdapter = New Centrex.dbCentrexDataSetTableAdapters.factura_cabeceraTableAdapter()
        Me.TableAdapterManager = New Centrex.dbCentrexDataSetTableAdapters.TableAdapterManager()
        Me.Factura_detalleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Factura_detalleTableAdapter = New Centrex.dbCentrexDataSetTableAdapters.factura_detalleTableAdapter()
        Me.Datos_empresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Datos_empresaTableAdapter = New Centrex.dbCentrexDataSetTableAdapters.datos_empresaTableAdapter()
        CType(Me.DbCentrexDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Factura_cabeceraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Factura_detalleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(930, 733)
        Me.ReportViewer1.TabIndex = 0
        '
        'DbCentrexDataSet
        '
        Me.DbCentrexDataSet.DataSetName = "dbCentrexDataSet"
        Me.DbCentrexDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Factura_cabeceraBindingSource
        '
        Me.Factura_cabeceraBindingSource.DataMember = "factura_cabecera"
        Me.Factura_cabeceraBindingSource.DataSource = Me.DbCentrexDataSet
        '
        'Factura_cabeceraTableAdapter
        '
        Me.Factura_cabeceraTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = Centrex.dbCentrexDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Factura_detalleBindingSource
        '
        Me.Factura_detalleBindingSource.DataMember = "factura_detalle"
        Me.Factura_detalleBindingSource.DataSource = Me.DbCentrexDataSet
        '
        'Factura_detalleTableAdapter
        '
        Me.Factura_detalleTableAdapter.ClearBeforeFill = True
        '
        'Datos_empresaBindingSource
        '
        Me.Datos_empresaBindingSource.DataMember = "datos_empresa"
        Me.Datos_empresaBindingSource.DataSource = Me.DbCentrexDataSet
        '
        'Datos_empresaTableAdapter
        '
        Me.Datos_empresaTableAdapter.ClearBeforeFill = True
        '
        'frm_prnCmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 733)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frm_prnCmp"
        Me.Text = "Impresión"
        CType(Me.DbCentrexDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Factura_cabeceraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Factura_detalleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DbCentrexDataSet As Centrex.dbCentrexDataSet
    Friend WithEvents Factura_cabeceraBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Factura_cabeceraTableAdapter As Centrex.dbCentrexDataSetTableAdapters.factura_cabeceraTableAdapter
    Friend WithEvents TableAdapterManager As Centrex.dbCentrexDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Factura_detalleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Factura_detalleTableAdapter As Centrex.dbCentrexDataSetTableAdapters.factura_detalleTableAdapter
    Friend WithEvents Datos_empresaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Datos_empresaTableAdapter As Centrex.dbCentrexDataSetTableAdapters.datos_empresaTableAdapter
End Class
