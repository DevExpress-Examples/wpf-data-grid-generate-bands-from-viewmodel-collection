using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using DevExpress.Mvvm.POCO;
using System.Linq;

namespace DXGridSample.ViewModels {
    [POCOViewModel]
    public class GridViewModel {
        public virtual ObservableCollection<PersonViewModel> Persons { get; set; }
        public virtual ObservableCollection<BandViewModel> Bands { get; set; }
        public virtual ObservableCollection<string> Names { get; set; }
        public GridViewModel() {
            Persons = new ObservableCollection<PersonViewModel>();
            for (int i = 0; i < 100; i++)
                Persons.Add(ViewModelSource.Create(()=> new PersonViewModel { Id = i, Name = "Name" + i, Bool = i % 2 == 0 }));

            Bands = new ObservableCollection<BandViewModel>();
            BandViewModel band1 = ViewModelSource.Create(()=> new BandViewModel() { BandHeader = "Band1" });
            band1.Columns = new ObservableCollection<ColumnViewModel>();
            band1.Columns.Add(ViewModelSource.Create(()=> new ColumnViewModel() { ColumnFieldName = "Id", ColumnHeader = "Identifier" }));
            band1.Columns.Add(ViewModelSource.Create(() => new ColumnViewModel() { ColumnFieldName = "Name", ColumnHeader = "FullName" }));

            BandViewModel band2 = ViewModelSource.Create(() => new BandViewModel() { BandHeader = "Band2" });
            band2.Columns = new ObservableCollection<ColumnViewModel>();
            band2.Columns.Add(ViewModelSource.Create(() => new ColumnViewModel() { ColumnFieldName = "Bool", ColumnHeader = "Boolean" }));

            Bands.Add(band1);
            Bands.Add(band2);

            Names = new ObservableCollection<string>();
            for (int i = 0; i < 3; i++)
                Names.Add("Name" + i);            
        }

        public void AddBand() {
            BandViewModel band = ViewModelSource.Create(() => new BandViewModel() { BandHeader = string.Format("Band{0}", Bands.Count + 1), Columns = new ObservableCollection<ColumnViewModel>() });
            Bands.Add(band);
        }

        public void AddColumn() {
            ColumnViewModel column = ViewModelSource.Create(() => new ColumnViewModel() { ColumnFieldName = String.Empty, ColumnHeader = "Empty" });
            Bands.LastOrDefault().Columns.Add(column);
        }
    }
    public class PersonViewModel {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Bool { get; set; }
    }

    public class BandViewModel {
        public virtual string BandHeader { get; set; }
        public virtual ObservableCollection<ColumnViewModel> Columns { get; set; }
    }
    public class ColumnViewModel {
        public virtual string ColumnHeader { get; set; }
        public virtual string ColumnFieldName { get; set; }
    }
}
