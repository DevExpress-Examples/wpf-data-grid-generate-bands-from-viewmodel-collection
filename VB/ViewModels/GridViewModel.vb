Imports System
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports DevExpress.Mvvm.POCO
Imports System.Linq

Namespace DXGridSample.ViewModels
    <POCOViewModel> _
    Public Class GridViewModel
        Public Overridable Property Persons() As ObservableCollection(Of PersonViewModel)
        Public Overridable Property Bands() As ObservableCollection(Of BandViewModel)
        Public Overridable Property Names() As ObservableCollection(Of String)
        Public Sub New()
            Persons = New ObservableCollection(Of PersonViewModel)()
            For i As Integer = 0 To 99
                Persons.Add(ViewModelSource.Create(Function() New PersonViewModel With {.Id = i, .Name = "Name" & i, .Bool = i Mod 2 = 0}))
            Next i

            Bands = New ObservableCollection(Of BandViewModel)()
            Dim band1 As BandViewModel = ViewModelSource.Create(Function() New BandViewModel() With {.BandHeader = "Band1"})
            band1.Columns = New ObservableCollection(Of ColumnViewModel)()
            band1.Columns.Add(ViewModelSource.Create(Function() New ColumnViewModel() With {.ColumnFieldName = "Id", .ColumnHeader = "Identifier"}))
            band1.Columns.Add(ViewModelSource.Create(Function() New ColumnViewModel() With {.ColumnFieldName = "Name", .ColumnHeader = "FullName"}))

            Dim band2 As BandViewModel = ViewModelSource.Create(Function() New BandViewModel() With {.BandHeader = "Band2"})
            band2.Columns = New ObservableCollection(Of ColumnViewModel)()
            band2.Columns.Add(ViewModelSource.Create(Function() New ColumnViewModel() With {.ColumnFieldName = "Bool", .ColumnHeader = "Boolean"}))

            Bands.Add(band1)
            Bands.Add(band2)

            Names = New ObservableCollection(Of String)()
            For i As Integer = 0 To 2
                Names.Add("Name" & i)
            Next i
        End Sub

        Public Sub AddBand()
            Dim band As BandViewModel = ViewModelSource.Create(Function() New BandViewModel() With {.BandHeader = String.Format("Band{0}", Bands.Count + 1), .Columns = New ObservableCollection(Of ColumnViewModel)()})
            Bands.Add(band)
        End Sub

        Public Sub AddColumn()
            Dim column As ColumnViewModel = ViewModelSource.Create(Function() New ColumnViewModel() With {.ColumnFieldName = String.Empty, .ColumnHeader = "Empty"})
            Bands.LastOrDefault().Columns.Add(column)
        End Sub
    End Class
    Public Class PersonViewModel
        Public Overridable Property Id() As Integer
        Public Overridable Property Name() As String
        Public Overridable Property Bool() As Boolean
    End Class

    Public Class BandViewModel
        Public Overridable Property BandHeader() As String
        Public Overridable Property Columns() As ObservableCollection(Of ColumnViewModel)
    End Class
    Public Class ColumnViewModel
        Public Overridable Property ColumnHeader() As String
        Public Overridable Property ColumnFieldName() As String
    End Class
End Namespace
