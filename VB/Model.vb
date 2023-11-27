Imports System.Collections.Generic

Namespace DXGridSample

    Public Class Person

        Public Property Id As Integer

        Public Property Name As String

        Public Property Bool As Boolean
    End Class

    Public Class BandItem

        Public Property BandHeader As String

        Public Property Columns As List(Of ColumnItem)
    End Class

    Public Class ColumnItem

        Public Property ColumnFieldName As String
    End Class
End Namespace
