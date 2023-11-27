Imports System.Windows
Imports System.Collections
Imports System.Windows.Controls
Imports DevExpress.Xpf.Grid
Imports DXGridSample.Extensions
Imports System.Collections.Specialized

Namespace DXGridSample.Controls

    Public Class MyGridControl
        Inherits GridControl

        Public Shared ReadOnly BandTemplateProperty As DependencyProperty = DependencyProperty.Register("BandTemplate", GetType(DataTemplate), GetType(MyGridControl), New PropertyMetadata(CType(Nothing, PropertyChangedCallback)))

        Public Property BandTemplate As DataTemplate
            Get
                Return CType(GetValue(BandTemplateProperty), DataTemplate)
            End Get

            Set(ByVal value As DataTemplate)
                SetValue(BandTemplateProperty, value)
            End Set
        End Property

        Public Shared ReadOnly BandsSourceProperty As DependencyProperty = DependencyProperty.Register("BandsSource", GetType(IList), GetType(MyGridControl), New PropertyMetadata(Nothing, AddressOf DXGridSample.Controls.MyGridControl.OnBandedSourcePropertyChanged))

        Public Property BandsSource As IList
            Get
                Return CType(GetValue(BandsSourceProperty), IList)
            End Get

            Set(ByVal value As IList)
                SetValue(BandsSourceProperty, value)
            End Set
        End Property

        Private Shared Sub OnBandedSourcePropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            CType(d, MyGridControl).PopulateBands()
            Dim myDelegate As NotifyCollectionChangedEventHandler = Sub(ByVal sender, ByVal par) CType(d, MyGridControl).PopulateBands()
            If e.OldValue IsNot Nothing AndAlso TypeOf e.OldValue Is INotifyCollectionChanged Then
                RemoveHandler CType(e.NewValue, INotifyCollectionChanged).CollectionChanged, myDelegate
            End If

            If e.NewValue IsNot Nothing AndAlso TypeOf e.NewValue Is INotifyCollectionChanged Then
                AddHandler CType(e.NewValue, INotifyCollectionChanged).CollectionChanged, myDelegate
            End If
        End Sub

        Private Sub PopulateBands()
            Bands.Clear()
            For Each b In BandsSource
                Dim cc As ContentControl = TryCast(BandTemplate.LoadContent(), ContentControl)
                If cc Is Nothing Then Continue For
                Dim band As GridControlBand = TryCast(cc.Content, GridControlBand)
                cc.Content = Nothing
                If band Is Nothing Then Continue For
                band.DataContext = b
                DependencyObjectHelper.SetDataContext(band, band.DataContext)
                Bands.Add(band)
            Next
        End Sub
    End Class
End Namespace
