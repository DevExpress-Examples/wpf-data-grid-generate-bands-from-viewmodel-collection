Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Windows.Data
Imports System.Windows.Markup
Imports System.Collections
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Core
Imports System.Windows.Controls

Namespace DXGridSample
    Partial Public Class MainWindow
        Inherits Window
        Private Persons As ObservableCollection(Of Person)
        Public Sub New()
            InitializeComponent()
            Persons = New ObservableCollection(Of Person)()
            For i As Integer = 0 To 99
                Persons.Add(New Person With {.Id = i, .Name = "Name" & i, .Bool = i Mod 2 = 0})
            Next i
            grid.ItemsSource = Persons


            Dim bands As New List(Of BandItem)()
            Dim band1 As New BandItem() With {.BandHeader = "Band1"}
            band1.Columns = New List(Of ColumnItem)()
            band1.Columns.Add(New ColumnItem() With {.ColumnFieldName = "Id"})
            band1.Columns.Add(New ColumnItem() With {.ColumnFieldName = "Name"})

            Dim band2 As New BandItem() With {.BandHeader = "Band2"}
            band2.Columns = New List(Of ColumnItem)()
            band2.Columns.Add(New ColumnItem() With {.ColumnFieldName = "Bool"})

            bands.Add(band1)
            bands.Add(band2)
            grid.BandsSource = bands
        End Sub
    End Class

    Public Class MyGridControl
        Inherits GridControl
        Public Shared ReadOnly BandsSourceProperty As DependencyProperty = DependencyProperty.Register("BandsSource", GetType(IList), GetType(MyGridControl), New PropertyMetadata(Nothing, AddressOf OnBandedSourcePropertyChanged))
        Public Shared ReadOnly BandTemplateProperty As DependencyProperty = DependencyProperty.Register("BandTemplate", GetType(DataTemplate), GetType(MyGridControl), New PropertyMetadata(Nothing))
        Public Property BandsSource() As IList
            Get
                Return CType(GetValue(BandsSourceProperty), IList)
            End Get
            Set(ByVal value As IList)
                SetValue(BandsSourceProperty, value)
            End Set
        End Property
        Public Property BandTemplate() As DataTemplate
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
                If cc Is Nothing Then
                    Continue For
                End If
                Dim band As GridControlBand = TryCast(cc.Content, GridControlBand)
                cc.Content = Nothing
                If band Is Nothing Then
                    Continue For
                End If
                band.DataContext = b
                Bands.Add(band)
            Next b
        End Sub
    End Class
    Public Class MyGridControlBand
        Inherits GridControlBand
        Public Shared ReadOnly ColumnsSourceProperty As DependencyProperty = DependencyProperty.Register("ColumnsSource", GetType(IList), GetType(MyGridControlBand), New PropertyMetadata(Nothing, AddressOf OnColumnsSourcePropertyChanged))
        Public Shared ReadOnly ColumnTemplateProperty As DependencyProperty = DependencyProperty.Register("ColumnTemplate", GetType(DataTemplate), GetType(MyGridControlBand), New PropertyMetadata(Nothing))
        Public Property ColumnsSource() As IList
            Get
                Return CType(GetValue(ColumnsSourceProperty), IList)
            End Get
            Set(ByVal value As IList)
                SetValue(ColumnsSourceProperty, value)
            End Set
        End Property
        Public Property ColumnTemplate() As DataTemplate
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
                If cc Is Nothing Then
                    Continue For
                End If
                Dim column As GridColumn = TryCast(cc.Content, GridColumn)
                cc.Content = Nothing
                If column Is Nothing Then
                    Continue For
                End If
                column.DataContext = b
                Columns.Add(column)
            Next b
        End Sub
    End Class
End Namespace