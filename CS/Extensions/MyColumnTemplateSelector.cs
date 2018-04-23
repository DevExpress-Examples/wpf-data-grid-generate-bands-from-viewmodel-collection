using DXGridSample.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DXGridSample.Extensions {
    public class MyColumnTemplateSelector : DataTemplateSelector {
        public DataTemplate template1 { get; set; }
        public DataTemplate template2 { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            ColumnViewModel ci = item as ColumnViewModel;
            if (ci != null) {
                if (ci.ColumnFieldName == "Name") return template2;
                return template1;
            }        
            return base.SelectTemplate(item, container);
        }
    }
}