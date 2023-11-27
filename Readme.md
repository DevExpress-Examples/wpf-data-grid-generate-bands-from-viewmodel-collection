<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128650570/20.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5217)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - Generate Bands from a ViewModel Collection

This example demonstrates how to define bands in a ViewModel collection and generate GridControl bands based on this collection.

![](/Images/wpf_grid_mvvm_bandcolumns125100.png)

## Files to Review

* [MainWindow.xaml](./CS/GridMVVMBandsSample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/GridMVVMBandsSample/MainWindow.xaml))
* [EmployeesViewModel.cs](./CS/GridMVVMBandsSample/EmployeesViewModel.cs) (VB: [EmployeesViewModel.vb](./VB/GridMVVMBandsSample/EmployeesViewModel.vb))
* [EmployeesDataModel.cs](./CS/GridMVVMBandsSample/EmployeesDataModel.cs) (VB: [EmployeesDataModel.vb](./VB/GridMVVMBandsSample/EmployeesDataModel.vb))
* [BandTemplateSelector.cs](./CS/GridMVVMBandsSample/BandTemplateSelector.cs) (VB: [BandTemplateSelector.vb](./VB/GridMVVMBandsSample/BandTemplateSelector.vb))

## Documentation

* [Bands](https://docs.devexpress.com/WPF/15660/controls-and-libraries/data-grid/grid-view-data-layout/bands)
* [How to: Bind the Grid to Bands Specified in ViewModel](http://docs.devexpress.com/WPF/117249/controls-and-libraries/data-grid/mvvm-enhancements/binding-to-a-collection-of-bands)
* [BandsSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.BandsSource)
* [BandGeneratorTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.BandGeneratorTemplate)
* [BandGeneratorTemplateSelector](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.BandGeneratorTemplateSelector)

## More Examples

* [WPF Data Grid - Create a Banded View](https://github.com/DevExpress-Examples/wpf-data-grid-create-a-banded-view)
* [WPF Data Grid - Generate Columns from a ViewModel Collection](https://github.com/DevExpress-Examples/wpf-data-grid-bind-columns-to-viewmodel-collection)
* [WPF Data Grid - Generate Total and Group Summaries from a ViewModel Collection](https://github.com/DevExpress-Examples/wpf-mvvm-how-to-bind-the-gridcontrol-to-total-and-group-summaries-specified-in-viewmodel)
