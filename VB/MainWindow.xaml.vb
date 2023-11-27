Imports System.Collections.Generic
Imports System.Windows
Imports System.Collections.ObjectModel
Imports System.Collections
Imports DevExpress.Xpf.Grid
Imports System.Windows.Controls

Namespace DXGridSample

    Public Partial Class MainWindow
        Inherits Window

        Public Property Persons As ObservableCollection(Of Person)

        Public Property Bands As List(Of BandItem)

        Public Sub New()
            Me.InitializeComponent()
            Persons = New ObservableCollection(Of Person)()
            For i As Integer = 0 To 100 - 1
                Persons.Add(New Person With {.Id = i, .Name = "Name" & i, .Bool = i Mod 2 = 0})
            Next

            Bands = New List(Of BandItem)()
            Dim band1 As BandItem = New BandItem() With {.BandHeader = "Band1"}
            band1.Columns = New List(Of ColumnItem)()
            band1.Columns.Add(New ColumnItem() With {.ColumnFieldName = "Id"})
            band1.Columns.Add(New ColumnItem() With {.ColumnFieldName = "Name"})
            Dim band2 As BandItem = New BandItem() With {.BandHeader = "Band2"}
            band2.Columns = New List(Of ColumnItem)()
            band2.Columns.Add(New ColumnItem() With {.ColumnFieldName = "Bool"})
            Bands.Add(band1)
            Bands.Add(band2)
            DataContext = Me
        End Sub
    End Class

    Public Class MyGridControl
        Inherits GridControl

        Public Shared ReadOnly BandsSourceProperty As DependencyProperty = DependencyProperty.Register("BandsSource", GetType(IList), GetType(MyGridControl), New PropertyMetadata(Nothing, AddressOf OnBandedSourcePropertyChanged))

        Public Shared ReadOnly BandTemplateProperty As DependencyProperty = DependencyProperty.Register("BandTemplate", GetType(DataTemplate), GetType(MyGridControl), New PropertyMetadata(CType(Nothing, PropertyChangedCallback)))

        Public Property BandsSource As IList
            Get
                Return CType(GetValue(BandsSourceProperty), IList)
            End Get

            Set(ByVal value As IList)
                SetValue(BandsSourceProperty, value)
            End Set
        End Property

        Public Property BandTemplate As DataTemplate
            Get
                Return CType(GetValue(BandTemplateProperty), DataTemplate)
            End Get

            Set(ByVal value As DataTemplate)
                SetValue(BandTemplateProperty, value)
            End Set
        End Property

        Private Shared Sub OnBandedSourcePropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            CType(d, MyGridControl).OnBandedSourceChanged(e)
        End Sub

        Private Sub OnBandedSourceChanged(ByVal e As DependencyPropertyChangedEventArgs)
            Bands.Clear()
            For Each b In BandsSource
                Dim cc As ContentControl = TryCast(BandTemplate.LoadContent(), ContentControl)
                If cc Is Nothing Then Continue For
                Dim band As GridControlBand = TryCast(cc.Content, GridControlBand)
                cc.Content = Nothing
                If band Is Nothing Then Continue For
                band.DataContext = b
                Bands.Add(band)
            Next
        End Sub
    End Class

    Public Class MyGridControlBand
        Inherits GridControlBand

        Public Shared ReadOnly ColumnsSourceProperty As DependencyProperty = DependencyProperty.Register("ColumnsSource", GetType(IList), GetType(MyGridControlBand), New PropertyMetadata(Nothing, AddressOf OnColumnsSourcePropertyChanged))

        Public Shared ReadOnly ColumnTemplateProperty As DependencyProperty = DependencyProperty.Register("ColumnTemplate", GetType(DataTemplate), GetType(MyGridControlBand), New PropertyMetadata(CType(Nothing, PropertyChangedCallback)))

        Public Property ColumnsSource As IList
            Get
                Return CType(GetValue(ColumnsSourceProperty), IList)
            End Get

            Set(ByVal value As IList)
                SetValue(ColumnsSourceProperty, value)
            End Set
        End Property

        Public Property ColumnTemplate As DataTemplate
            Get
                Return CType(GetValue(ColumnTemplateProperty), DataTemplate)
            End Get

            Set(ByVal value As DataTemplate)
                SetValue(ColumnTemplateProperty, value)
            End Set
        End Property

        Private Shared Sub OnColumnsSourcePropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            CType(d, MyGridControlBand).OnColumnsSourceChanged(e)
        End Sub

        Private Sub OnColumnsSourceChanged(ByVal e As DependencyPropertyChangedEventArgs)
            Columns.Clear()
            For Each b In ColumnsSource
                Dim cc As ContentControl = TryCast(ColumnTemplate.LoadContent(), ContentControl)
                If cc Is Nothing Then Continue For
                Dim column As GridColumn = TryCast(cc.Content, GridColumn)
                cc.Content = Nothing
                If column Is Nothing Then Continue For
                column.DataContext = b
                Columns.Add(column)
            Next
        End Sub
    End Class
End Namespace
