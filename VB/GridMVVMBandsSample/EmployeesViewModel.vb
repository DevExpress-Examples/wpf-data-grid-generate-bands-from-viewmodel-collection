Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Namespace GridMVVMBandsSample
	Public Class ViewModel
		Inherits ViewModelBase

		Public Sub New()
			Source = EmployeesDataModel.GetEmployees()
			Bands = New ObservableCollection(Of Band)() _
				From {
					New Band("Personal Info", New ObservableCollection(Of Column)(), New ObservableCollection(Of Band)() _
						From {
							New Band("Name", New ObservableCollection(Of Column)() From {
								New Column(NameOf(Employee.FirstName)),
								New Column(NameOf(Employee.LastName))
							}, New ObservableCollection(Of Band)()),
							New Band("Birthday", New ObservableCollection(Of Column)() From {New Column(NameOf(Employee.BirthDate))}, New ObservableCollection(Of Band)())
						}),
					New Band("Location", New ObservableCollection(Of Column)() From {
						New Column(NameOf(Employee.Country)),
						New Column(NameOf(Employee.City))
					}, New ObservableCollection(Of Band)()),
					New Band("Position", New ObservableCollection(Of Column)() From {New Column(NameOf(Employee.JobTitle))}, New ObservableCollection(Of Band)())
				}
		End Sub
		Public ReadOnly Property Source() As List(Of Employee)
		Public ReadOnly Property Bands() As ObservableCollection(Of Band)
	End Class
	Public Class Column
		Inherits BindableBase

		Public Sub New(ByVal fieldname As String)
			Me.FieldName = fieldname
		End Sub
		Public ReadOnly Property FieldName() As String
	End Class
	Public Class Band
		Inherits BindableBase

		Public Sub New(ByVal header As String, ByVal childcolumns As ObservableCollection(Of Column), ByVal childbands As ObservableCollection(Of Band))
			Me.Header = header
			Me.ChildColumns = childcolumns
			Me.ChildBands = childbands
		End Sub
		Public ReadOnly Property Header() As String
		Public ReadOnly Property ChildColumns() As ObservableCollection(Of Column)
		Public ReadOnly Property ChildBands() As ObservableCollection(Of Band)
	End Class
End Namespace
