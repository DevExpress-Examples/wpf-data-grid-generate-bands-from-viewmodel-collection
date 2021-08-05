using System.Windows;
using System.Windows.Controls;

namespace GridMVVMBandsSample {
    public class BandTemplateSelector : DataTemplateSelector {

        public DataTemplate SingleColumnBandTemplate { get; set; }
        public DataTemplate MultiColumnBandTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            Band band = item as Band;
            if(band == null) return null;
            if(band.Header == "Position") {
                return SingleColumnBandTemplate;
            }
            return MultiColumnBandTemplate;
        }
    }
}
