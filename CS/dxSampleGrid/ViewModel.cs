using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace dxSampleGrid {
    public class ViewModel {
        // Returns a list of employees so that they can be bound to the grid control.  
        public List<Employee> Source { get; private set; }
        // The collection of grid columns.  
        public ObservableCollection<Band> Bands { get; private set; }
        public ViewModel()
        {
            Source = EmployeeData.DataSource;
            Bands = new ObservableCollection<Band>() {
                new Band() {
                    Header = "Personal Info",
                    ChildColumns = new ObservableCollection<Column>() {
                        new Column() { FieldName = "FirstName" },
                        new Column() { FieldName = "LastName" },
                        new Column() { FieldName = "BirthDate" }
                    }
                },
                new Band() {
                    Header = "Location",
                    ChildColumns = new ObservableCollection<Column>() {
                        new Column() { FieldName = "City" },
                        new Column() { FieldName = "Address" }
                    }
                },
                new Band() {
                    Header = "Position",
                    ChildColumns = new ObservableCollection<Column>() {
                        new Column() { FieldName = "JobTitle" },
                    }
                }
            };
        }
    }
    // The data item.  
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public class EmployeeData : List<Employee>
    {
        public static List<Employee> DataSource
        {
            get
            {
                List<Employee> list = new List<Employee>();
                list.Add(new Employee() {
                    FirstName = "Nathan",
                    LastName = "White",
                    City = "NY",
                    Address = "90 7th Street",
                    JobTitle = "Sales Manager",
                    BirthDate = new DateTime(1970, 1, 10)
                });
                list.Add(new Employee() {
                    FirstName = "Sandra",
                    LastName = "Oldman",
                    City = "LA",
                    Address = "3687 Mohawk Street",
                    JobTitle = "Marketing Manager",
                    BirthDate = new DateTime(1970, 7, 22)
                });
                return list;
            }
        }
    }
    public class Column
    {
        // Specifies the name of a data source field to which the column is bound.  
        public string FieldName { get; set; }
    }
    // Corresponds to a band column.  
    public class Band
    {
        // Specifies the band header. 
        public string Header { get; set; }
        public ObservableCollection<Column> ChildColumns { get; set; }
    }

    public class BandTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Band band = (Band)item;
            if (band.ChildColumns.Count == 1)
            {
                return (DataTemplate)((Control)container).FindResource("SingleColumnBandTemplate");
            }
            return (DataTemplate)((Control)container).FindResource("MultiColumnBandTemplate");
        }
    }
}
