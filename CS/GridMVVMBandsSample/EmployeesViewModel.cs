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
                    new ObservableCollection<Column>(),
                    new ObservableCollection<Band>() {
                        new Band (
                            "Name",
                            new ObservableCollection<Column>() {
                                new Column(nameof(Employee.FirstName)),
                                new Column(nameof(Employee.LastName))
                            },
                            new ObservableCollection<Band>()
                        ),
                        new Band (
                            "Birthday",
                            new ObservableCollection<Column>() {
                                new Column(nameof(Employee.BirthDate))
                            },
                            new ObservableCollection<Band>()
                        )
                    }
                ),
                new Band(
                    "Location",
                    new ObservableCollection<Column>() {
                        new Column(nameof(Employee.Country)),
                        new Column(nameof(Employee.City))
                    },
                    new ObservableCollection<Band>()
                ),
                new Band(
                    "Position",
                    new ObservableCollection<Column>() {
                        new Column(nameof(Employee.JobTitle))
                    },
                    new ObservableCollection<Band>()
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
        public Band(string header, ObservableCollection<Column> childcolumns, ObservableCollection<Band> childbands) {
            Header = header;
            ChildColumns = childcolumns;
            ChildBands = childbands;
        }
        public string Header { get; }
        public ObservableCollection<Column> ChildColumns { get; }
        public ObservableCollection<Band> ChildBands { get; }
    }
}
