<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128650570/13.2.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5217)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
* [Model.cs](./CS/Model.cs) (VB: [Model.vb](./VB/Model.vb))
<!-- default file list end -->
# How to generate bands based on a collection in a ViewModel


<p>The following sample demonstrates how to generate bands from a collection in a ViewModel using the MVVM architectural pattern. This is done by using the <a href="https://documentation.devexpress.com/WPF/DevExpressXpfGridDataControlBase_BandsSourcetopic.aspx">BandsSource</a> and <a href="https://documentation.devexpress.com/WPF/DevExpressXpfGridDataControlBase_BandGeneratorTemplatetopic.aspx">BandGeneratorTemplate</a> properties. To learn more, see <a href="https://documentation.devexpress.com/WPF/CustomDocument117249.aspx">Binding to a Collection of Bands</a>.</p>


<h3>Description</h3>

This is done by creating a custom attached behavior with the <strong>BandsSource</strong> property. Bind this property to a collection of simple objects and specify the <strong>BandTemplate</strong> property that is used to visualize a band from an object. In a similar manner, you can use the <strong>ColumnsSource</strong>,&nbsp;<strong>ColumnTemplate</strong> and <strong>ColumnTemplateSelector</strong> properties to create columns in a band.

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-generate-bands-from-viewmodel-collection&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-generate-bands-from-viewmodel-collection&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
