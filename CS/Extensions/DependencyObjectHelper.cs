using System.Windows;

namespace DXGridSample.Extensions {
    public class DependencyObjectHelper {
        public static object GetDataContext(DependencyObject obj) {
            return obj.GetValue(DataContextProperty);
        }
        public static void SetDataContext(DependencyObject obj, object value) {
            obj.SetValue(DataContextProperty, value);
        }
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.RegisterAttached("DataContext", typeof(object), typeof(DependencyObjectHelper), new PropertyMetadata(null));
    }
}