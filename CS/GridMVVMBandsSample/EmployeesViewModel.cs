using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GridMVVMBandsSample {
    public class ViewModel : ViewModelBase {
        public ViewModel() {
            Source = EmployeesDataModel.GetEmployees();
            Bands = new ObservableCollection<Band>() {
                new Band(
                    "Personal Info",
                    new ObservableCollection<Column>() {
                        new Column( nameof(Employee.FirstName) ),
                        new Column( nameof(Employee.LastName) ),
                        new Column( nameof(Employee.BirthDate) )
                    }
                ),
                new Band(
                    "Location",
                    new ObservableCollection<Column>() {
                        new Column( nameof(Employee.Country) ),
                        new Column( nameof(Employee.City) )
                    }
                ),
                new Band(
                    "Position",
                    new ObservableCollection<Column>() {
                        new Column( nameof(Employee.JobTitle) )
                    }
                )
            };
        }
        public List<Employee> Source { get; }
        public ObservableCollection<Band> Bands { get; }
    }
    public class Column : BindableBase {
        public Column(string fieldname) {
            FieldName = fieldname;
        }
        public string FieldName { get; }
    }
    public class Band : BindableBase {
        public Band(string header, ObservableCollection<Column> childcolumns) {
            Header = header;
            ChildColumns = childcolumns;
        }
        public string Header { get; }
        public ObservableCollection<Column> ChildColumns { get; }
    }
}
