Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls

Namespace dxSampleGrid

    Public Class ViewModel

        ' Returns a list of employees so that they can be bound to the grid control.  
        ' The collection of grid columns.  
        Private _Source As List(Of dxSampleGrid.Employee), _Bands As ObservableCollection(Of dxSampleGrid.Band)

        Public Property Source As List(Of Employee)
            Get
                Return _Source
            End Get

            Private Set(ByVal value As List(Of Employee))
                _Source = value
            End Set
        End Property

        Public Property Bands As ObservableCollection(Of Band)
            Get
                Return _Bands
            End Get

            Private Set(ByVal value As ObservableCollection(Of Band))
                _Bands = value
            End Set
        End Property

        Public Sub New()
            Source = EmployeeData.DataSource
            Bands = New ObservableCollection(Of Band)() From {New Band() With {.Header = "Personal Info", .ChildColumns = New ObservableCollection(Of Column)() From {New Column() With {.FieldName = "FirstName"}, New Column() With {.FieldName = "LastName"}, New Column() With {.FieldName = "BirthDate"}}}, New Band() With {.Header = "Location", .ChildColumns = New ObservableCollection(Of Column)() From {New Column() With {.FieldName = "City"}, New Column() With {.FieldName = "Address"}}}, New Band() With {.Header = "Position", .ChildColumns = New ObservableCollection(Of Column)() From {New Column() With {.FieldName = "JobTitle"}}}}
        End Sub
    End Class

    ' The data item.  
    Public Class Employee

        Public Property FirstName As String

        Public Property LastName As String

        Public Property City As String

        Public Property Address As String

        Public Property JobTitle As String

        Public Property BirthDate As Date
    End Class

    Public Class EmployeeData
        Inherits List(Of Employee)

        Public Shared ReadOnly Property DataSource As List(Of Employee)
            Get
                Dim list As List(Of Employee) = New List(Of Employee)()
                list.Add(New Employee() With {.FirstName = "Nathan", .LastName = "White", .City = "NY", .Address = "90 7th Street", .JobTitle = "Sales Manager", .BirthDate = New DateTime(1970, 1, 10)})
                list.Add(New Employee() With {.FirstName = "Sandra", .LastName = "Oldman", .City = "LA", .Address = "3687 Mohawk Street", .JobTitle = "Marketing Manager", .BirthDate = New DateTime(1970, 7, 22)})
                Return list
            End Get
        End Property
    End Class

    Public Class Column

        ' Specifies the name of a data source field to which the column is bound.  
        Public Property FieldName As String
    End Class

    ' Corresponds to a band column.  
    Public Class Band

        ' Specifies the band header. 
        Public Property Header As String

        Public Property ChildColumns As ObservableCollection(Of Column)
    End Class

    Public Class BandTemplateSelector
        Inherits DataTemplateSelector

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim band As Band = CType(item, Band)
            If band.ChildColumns.Count = 1 Then
                Return CType(CType(container, Control).FindResource("SingleColumnBandTemplate"), DataTemplate)
            End If

            Return CType(CType(container, Control).FindResource("MultiColumnBandTemplate"), DataTemplate)
        End Function
    End Class
End Namespace
