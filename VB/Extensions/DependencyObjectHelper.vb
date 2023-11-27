Imports System.Windows

Namespace DXGridSample.Extensions

    Public Class DependencyObjectHelper

        Public Shared Function GetDataContext(ByVal obj As DependencyObject) As Object
            Return obj.GetValue(DataContextProperty)
        End Function

        Public Shared Sub SetDataContext(ByVal obj As DependencyObject, ByVal value As Object)
            obj.SetValue(DataContextProperty, value)
        End Sub

        Public Shared ReadOnly DataContextProperty As DependencyProperty = DependencyProperty.RegisterAttached("DataContext", GetType(Object), GetType(DependencyObjectHelper), New PropertyMetadata(CType(Nothing, PropertyChangedCallback)))
    End Class
End Namespace
