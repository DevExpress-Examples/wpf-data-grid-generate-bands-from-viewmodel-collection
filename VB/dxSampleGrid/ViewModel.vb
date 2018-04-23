Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls

Namespace dxSampleGrid
    Public Class ViewModel
        ' Returns a list of employees so that they can be bound to the grid control.  
        Private privateSource As List(Of Employee)
        Public Property Source() As List(Of Employee)
            Get
                Return privateSource
            End Get
            Private Set(ByVal value As List(Of Employee))
                privateSource = value
            End Set
        End Property
        ' The collection of grid columns.  
        Private privateBands As ObservableCollection(Of Band)
        Public Property Bands() As ObservableCollection(Of Band)
            Get
                Return privateBands
            End Get
            Private Set(ByVal value As ObservableCollection(Of Band))
                privateBands = value
            End Set
        End Property
        Public Sub New()
            Source = EmployeeData.DataSource
            Bands = New ObservableCollection(Of Band)() _
                From { _
                    New Band() With { _
                        .Header = "Personal Info", _
                        .ChildColumns = New ObservableCollection(Of Column)() From { _
                            New Column() With {.FieldName = "FirstName"}, _
                            New Column() With {.FieldName = "LastName"}, _
                            New Column() With {.FieldName = "BirthDate"} _
                        } _
                    }, _
                    New Band() With { _
                        .Header = "Location", _
                        .ChildColumns = New ObservableCollection(Of Column)() From { _
                            New Column() With {.FieldName = "City"}, _
                            New Column() With {.FieldName = "Address"} _
                        } _
                    }, _
                    New Band() With { _
                        .Header = "Position", _
                        .ChildColumns = New ObservableCollection(Of Column)() From { _
                            New Column() With {.FieldName = "JobTitle"} _
                        } _
                        _
                    } _
                }
        End Sub
    End Class
    ' The data item.  
    Public Class Employee
        Public Property FirstName() As String
        Public Property LastName() As String
        Public Property City() As String
        Public Property Address() As String
        Public Property JobTitle() As String
        Public Property BirthDate() As Date
    End Class
    Public Class EmployeeData
        Inherits List(Of Employee)

        Public Shared ReadOnly Property DataSource() As List(Of Employee)
            Get
                Dim list As New List(Of Employee)()
                list.Add(New Employee() With { _
                    .FirstName = "Nathan", _
                    .LastName = "White", _
                    .City = "NY", _
                    .Address = "90 7th Street", _
                    .JobTitle = "Sales Manager", _
                    .BirthDate = New Date(1970, 1, 10) _
                })
                list.Add(New Employee() With { _
                    .FirstName = "Sandra", _
                    .LastName = "Oldman", _
                    .City = "LA", _
                    .Address = "3687 Mohawk Street", _
                    .JobTitle = "Marketing Manager", _
                    .BirthDate = New Date(1970, 7, 22) _
                })
                Return list
            End Get
        End Property
    End Class
    Public Class Column
        ' Specifies the name of a data source field to which the column is bound.  
        Public Property FieldName() As String
    End Class
    ' Corresponds to a band column.  
    Public Class Band
        ' Specifies the band header. 
        Public Property Header() As String
        Public Property ChildColumns() As ObservableCollection(Of Column)
    End Class

    Public Class BandTemplateSelector
        Inherits DataTemplateSelector

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim band As Band = DirectCast(item, Band)
            If band.ChildColumns.Count = 1 Then
                Return DirectCast(CType(container, Control).FindResource("SingleColumnBandTemplate"), DataTemplate)
            End If
            Return DirectCast(CType(container, Control).FindResource("MultiColumnBandTemplate"), DataTemplate)
        End Function
    End Class
End Namespace
