using System.Windows;
using System.Collections;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;
using DXGridSample.Extensions;
using System.Collections.Specialized;
using System;

namespace DXGridSample.Controls {
    public class MyGridControlBand : GridControlBand {

        public static readonly DependencyProperty ColumnTemplateProperty =
            DependencyProperty.Register("ColumnTemplate", typeof(DataTemplate), typeof(MyGridControlBand), new PropertyMetadata(null));

        public DataTemplate ColumnTemplate {
            get { return (DataTemplate)GetValue(ColumnTemplateProperty); }
            set { SetValue(ColumnTemplateProperty, value); }
        }

        public static readonly DependencyProperty ColumnTemplateSelectorProperty =
            DependencyProperty.Register("ColumnTemplateSelector", typeof(MyColumnTemplateSelector), typeof(MyGridControlBand), new PropertyMetadata(null));

        public MyColumnTemplateSelector ColumnTemplateSelector {
            get { return (MyColumnTemplateSelector)GetValue(ColumnTemplateSelectorProperty); }
            set { SetValue(ColumnTemplateSelectorProperty, value); }
        }        


        public static readonly DependencyProperty ColumnsSourceProperty =
            DependencyProperty.Register("ColumnsSource", typeof(IList), typeof(MyGridControlBand), new PropertyMetadata(null, OnColumnsSourcePropertyChanged));

        public IList ColumnsSource {
            get { return (IList)GetValue(ColumnsSourceProperty); }
            set { SetValue(ColumnsSourceProperty, value); }
        }

        private static void OnColumnsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((MyGridControlBand)d).PopulateColumns();

            NotifyCollectionChangedEventHandler myDelegate = delegate (object sender, NotifyCollectionChangedEventArgs par) { ((MyGridControlBand)d).PopulateColumns(); };

            if (e.OldValue != null && e.OldValue is INotifyCollectionChanged) {
                ((INotifyCollectionChanged)e.NewValue).CollectionChanged -= myDelegate;
            }

            if (e.NewValue != null && e.NewValue is INotifyCollectionChanged) {
                ((INotifyCollectionChanged)e.NewValue).CollectionChanged += myDelegate;
            }
        }

        private void PopulateColumns() {
            Columns.Clear();
            foreach (var b in ColumnsSource) {
                DataTemplate custColumnTemplate = null;
                if (ColumnTemplateSelector != null) custColumnTemplate = ColumnTemplateSelector.SelectTemplate(b, null);
                if (ColumnTemplate != null) custColumnTemplate = ColumnTemplate;
                if (custColumnTemplate != null) {
                    ContentControl cc = custColumnTemplate.LoadContent() as ContentControl;
                    if (cc == null) continue;
                    GridColumn column = cc.Content as GridColumn;
                    cc.Content = null;
                    if (column == null) continue; 
                    column.DataContext = b;
                    DependencyObjectHelper.SetDataContext(column, column.DataContext);
                    Columns.Add(column);
                }
            }
        }
    }
}