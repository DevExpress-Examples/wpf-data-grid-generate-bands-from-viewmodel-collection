using System.Windows;
using System.Collections;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;
using DXGridSample.Extensions;
using System.Collections.Specialized;
using System;

namespace DXGridSample.Controls {
    public class MyGridControl : GridControl {
        public static readonly DependencyProperty BandTemplateProperty =
            DependencyProperty.Register("BandTemplate", typeof(DataTemplate), typeof(MyGridControl), new PropertyMetadata(null));
        public DataTemplate BandTemplate {
            get { return (DataTemplate)GetValue(BandTemplateProperty); }
            set { SetValue(BandTemplateProperty, value); }
        }
        public static readonly DependencyProperty BandsSourceProperty =
            DependencyProperty.Register("BandsSource", typeof(IList), typeof(MyGridControl), new PropertyMetadata(null, OnBandedSourcePropertyChanged));
        public IList BandsSource {
            get { return (IList)GetValue(BandsSourceProperty); }
            set { SetValue(BandsSourceProperty, value); }
        }
        private static void OnBandedSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((MyGridControl)d).PopulateBands();

            NotifyCollectionChangedEventHandler myDelegate = delegate (object sender, NotifyCollectionChangedEventArgs par) { ((MyGridControl)d).PopulateBands(); };

            if (e.OldValue != null && e.OldValue is INotifyCollectionChanged) {
                ((INotifyCollectionChanged)e.NewValue).CollectionChanged -= myDelegate;
            }

            if (e.NewValue != null && e.NewValue is INotifyCollectionChanged) {
                ((INotifyCollectionChanged)e.NewValue).CollectionChanged += myDelegate;
            }

        }

        private void PopulateBands() {
            Bands.Clear();
            foreach (var b in BandsSource) {
                ContentControl cc = BandTemplate.LoadContent() as ContentControl;
                if (cc == null)
                    continue;
                GridControlBand band = cc.Content as GridControlBand;
                cc.Content = null;
                if (band == null)
                    continue;
                band.DataContext = b;
                DependencyObjectHelper.SetDataContext(band, band.DataContext);                
                Bands.Add(band);
            }
        }
    }
}