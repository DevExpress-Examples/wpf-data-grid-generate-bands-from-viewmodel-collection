Imports DXGridSample.ViewModels
Imports System.Windows
Imports System.Windows.Controls

Namespace DXGridSample.Extensions
    Public Class MyColumnTemplateSelector
        Inherits DataTemplateSelector

        Public Property template1() As DataTemplate
        Public Property template2() As DataTemplate
        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim ci As ColumnViewModel = TryCast(item, ColumnViewModel)
            If ci IsNot Nothing Then
                If ci.ColumnFieldName = "Name" Then
                    Return template2
                End If
                Return template1
            End If
            Return MyBase.SelectTemplate(item, container)
        End Function
    End Class
End Namespace