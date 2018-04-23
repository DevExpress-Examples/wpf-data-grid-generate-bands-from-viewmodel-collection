Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace DXGridSample
	Public Class Person
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateBool As Boolean
		Public Property Bool() As Boolean
			Get
				Return privateBool
			End Get
			Set(ByVal value As Boolean)
				privateBool = value
			End Set
		End Property
	End Class

	Public Class BandItem
		Private privateBandHeader As String
		Public Property BandHeader() As String
			Get
				Return privateBandHeader
			End Get
			Set(ByVal value As String)
				privateBandHeader = value
			End Set
		End Property
		Private privateColumns As List(Of ColumnItem)
		Public Property Columns() As List(Of ColumnItem)
			Get
				Return privateColumns
			End Get
			Set(ByVal value As List(Of ColumnItem))
				privateColumns = value
			End Set
		End Property
	End Class
	Public Class ColumnItem
		Private privateColumnFieldName As String
		Public Property ColumnFieldName() As String
			Get
				Return privateColumnFieldName
			End Get
			Set(ByVal value As String)
				privateColumnFieldName = value
			End Set
		End Property
	End Class
End Namespace
