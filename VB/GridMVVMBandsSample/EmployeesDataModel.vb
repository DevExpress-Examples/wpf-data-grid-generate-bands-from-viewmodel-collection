Imports System
Imports System.Collections.Generic

Namespace GridMVVMBandsSample
	Public Class Employee
		Public Property FirstName() As String
		Public Property LastName() As String
		Public Property Country() As String
		Public Property City() As String
		Public Property JobTitle() As String
		Public Property BirthDate() As DateTime
	End Class
	Public Class EmployeesDataModel
		Public Shared Function GetEmployees() As List(Of Employee)
			Dim list As New List(Of Employee) From {
				New Employee() With {
					.FirstName = "Elizabeth",
					.LastName = "Lincoln",
					.Country = "Canada",
					.City = "Tsawassen",
					.JobTitle = "Accounting Manager",
					.BirthDate = New DateTime(1988, 12, 8)
				},
				New Employee() With {
					.FirstName = "Maria",
					.LastName = "Anders",
					.Country = "Germany",
					.City = "Berlin",
					.JobTitle = "Sales Representative",
					.BirthDate = New DateTime(1975, 2, 19)
				},
				New Employee() With {
					.FirstName = "Ana",
					.LastName = "Trujillo",
					.Country = "Mexico",
					.City = "México D.F.",
					.JobTitle = "Owner",
					.BirthDate = New DateTime(1965, 3, 4)
				},
				New Employee() With {
					.FirstName = "Antonio",
					.LastName = "Moreno",
					.Country = "Mexico",
					.City = "México D.F.",
					.JobTitle = "Owner",
					.BirthDate = New DateTime(1983, 9, 19)
				},
				New Employee() With {
					.FirstName = "Thomas",
					.LastName = "Hardy",
					.Country = "UK",
					.City = "London",
					.JobTitle = "Sales Representative",
					.BirthDate = New DateTime(1995, 8, 30)
				},
				New Employee() With {
					.FirstName = "Christina",
					.LastName = "Berglund",
					.Country = "Sweden",
					.City = "Luleå",
					.JobTitle = "Order Administrator",
					.BirthDate = New DateTime(1991, 7, 2)
				},
				New Employee() With {
					.FirstName = "Hanna",
					.LastName = "Moos",
					.Country = "Germany",
					.City = "Mannheim",
					.JobTitle = "Sales Representative",
					.BirthDate = New DateTime(1990, 1, 27)
				},
				New Employee() With {
					.FirstName = "Frédérique",
					.LastName = "Citeaux",
					.Country = "France",
					.City = "Strasbourg",
					.JobTitle = "Marketing Manager",
					.BirthDate = New DateTime(1995, 1, 9)
				},
				New Employee() With {
					.FirstName = "Martín",
					.LastName = "Sommer",
					.Country = "Spain",
					.City = "Madrid",
					.JobTitle = "Owner",
					.BirthDate = New DateTime(1970, 5, 29)
				}
			}
			Return list
		End Function
	End Class
End Namespace
