Imports System.Windows
Imports System.Windows.Controls

Namespace GridMVVMBandsSample
	Public Class BandTemplateSelector
		Inherits DataTemplateSelector

		Public Property SingleColumnBandTemplate() As DataTemplate

		Public Property MultiColumnBandTemplate() As DataTemplate

		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
			Dim band As Band = TryCast(item, Band)
			If band Is Nothing Then
				Return Nothing
			End If
			If band.ChildColumns.Count = 1 Then
				Return SingleColumnBandTemplate
			End If
			Return MultiColumnBandTemplate
		End Function
	End Class
End Namespace
