'Name: Whitney Kugel
'Date: 02/17/2021
'Purpose: Track bugs and issues for projects in an organization. 

Option Strict On
Option Explicit On


Public Class Employee
    Private mintEmployeeID As Integer
    Private mstrFirstName As String
    Private mstrLastName As String
    Private mstrEmail As String
    Private mstrPassword As String
    Private mimgEmployeePic As Image
    Private mstrAdmin As String
    Private mdteHiredDate As Date

    Public Property EmployeeID As Integer
        Get
            Return mintEmployeeID
        End Get
        Set(intValue As Integer)
            mintEmployeeID = intValue
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return mstrFirstName
        End Get
        Set(strValue As String)
            mstrFirstName = strValue
        End Set
    End Property

    Public Property LastName As String
        Get
            Return mstrLastName
        End Get
        Set(strValue As String)
            mstrLastName = strValue
        End Set
    End Property

    Public Property Email As String
        Get
            Return mstrEmail
        End Get
        Set(strValue As String)
            mstrEmail = strValue
        End Set
    End Property

    Public Property Password As String
        Get
            Return mstrPassword
        End Get
        Set(strValue As String)
            mstrPassword = strValue
        End Set
    End Property

    Public Property EmployeePic As Image
        Get
            Return mimgEmployeePic
        End Get
        Set(imgValue As Image)
            mimgEmployeePic = imgValue
        End Set
    End Property

    Public Property Admin As String
        Get
            Return mstrAdmin
        End Get
        Set(strValue As String)
            mstrAdmin = strValue
        End Set
    End Property

    Public Property HiredDate As Date
        Get
            Return mdteHiredDate
        End Get
        Set(dteValue As Date)
            mdteHiredDate = dteValue
        End Set
    End Property

    Public Sub New()
        mstrFirstName = String.Empty
        mstrLastName = String.Empty
        mstrEmail = String.Empty
        mstrPassword = String.Empty
        mimgEmployeePic = Nothing
        mstrAdmin = String.Empty
        mdteHiredDate = Now
    End Sub

    Public Sub New(toString As String)
        mstrFirstName = String.Empty
        mstrLastName = String.Empty
        mstrEmail = String.Empty
        mstrPassword = String.Empty
        mimgEmployeePic = Nothing
        mstrAdmin = String.Empty
        mdteHiredDate = Now
    End Sub

End Class
