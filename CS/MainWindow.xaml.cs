using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Collections;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core;
using System.Windows.Controls;

namespace DXGridSample
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons
        {
            get;
            set;
        }
        public List<BandItem> Bands
        {
            get;
            set;
        }
        public MainWindow()
        {
            InitializeComponent();
            Persons = new ObservableCollection<Person>();
            for (int i = 0; i < 100; i++)
                Persons.Add(new Person { Id = i, Name = "Name" + i, Bool = i % 2 == 0 });

            Bands = new List<BandItem>();
            BandItem band1 = new BandItem() { BandHeader = "Band1" };
            band1.Columns = new List<ColumnItem>();
            band1.Columns.Add(new ColumnItem() { ColumnFieldName = "Id" });
            band1.Columns.Add(new ColumnItem() { ColumnFieldName = "Name" });

            BandItem band2 = new BandItem() { BandHeader = "Band2" };
            band2.Columns = new List<ColumnItem>();
            band2.Columns.Add(new ColumnItem() { ColumnFieldName = "Bool" });

            Bands.Add(band1);
            Bands.Add(band2);

            this.DataContext = this;
        }
    }

    public class MyGridControl : GridControl
    {
        public static readonly DependencyProperty BandsSourceProperty =
            DependencyProperty.Register("BandsSource", typeof(IList), typeof(MyGridControl), new PropertyMetadata(null, OnBandedSourcePropertyChanged));
        public static readonly DependencyProperty BandTemplateProperty =
            DependencyProperty.Register("BandTemplate", typeof(DataTemplate), typeof(MyGridControl), new PropertyMetadata(null));
        public IList BandsSource
        {
            get { return (IList)GetValue(BandsSourceProperty); }
            set { SetValue(BandsSourceProperty, value); }
        }
        public DataTemplate BandTemplate
        {
            get { return (DataTemplate)GetValue(BandTemplateProperty); }
            set { SetValue(BandTemplateProperty, value); }
        }

        private static void OnBandedSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MyGridControl)d).OnBandedSourceChanged(e);
        }
        private void OnBandedSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            Bands.Clear();
            foreach (var b in BandsSource)
            {
                ContentControl cc = BandTemplate.LoadContent() as ContentControl;
                if (cc == null)
                    continue;
                GridControlBand band = cc.Content as GridControlBand;
                cc.Content = null;
                if (band == null)
                    continue;
                band.DataContext = b;
                Bands.Add(band);
            }
        }
    }
    public class MyGridControlBand : GridControlBand
    {
        public static readonly DependencyProperty ColumnsSourceProperty =
            DependencyProperty.Register("ColumnsSource", typeof(IList), typeof(MyGridControlBand), new PropertyMetadata(null, OnColumnsSourcePropertyChanged));
        public static readonly DependencyProperty ColumnTemplateProperty =
            DependencyProperty.Register("ColumnTemplate", typeof(DataTemplate), typeof(MyGridControlBand), new PropertyMetadata(null));
        public IList ColumnsSource
        {
            get { return (IList)GetValue(ColumnsSourceProperty); }
            set { SetValue(ColumnsSourceProperty, value); }
        }
        public DataTemplate ColumnTemplate
        {
            get { return (DataTemplate)GetValue(ColumnTemplateProperty); }
            set { SetValue(ColumnTemplateProperty, value); }
        }

        private static void OnColumnsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MyGridControlBand)d).OnColumnsSourceChanged(e);
        }
        private void OnColumnsSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            Columns.Clear();
            foreach (var b in ColumnsSource)
            {
                ContentControl cc = ColumnTemplate.LoadContent() as ContentControl;
                if (cc == null)
                    continue;
                GridColumn column = cc.Content as GridColumn;
                cc.Content = null;
                if (column == null)
                    continue;
                column.DataContext = b;
                Columns.Add(column);
            }
        }
    }
}