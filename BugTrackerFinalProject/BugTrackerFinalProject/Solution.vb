'Name: Whitney Kugel
'Date: 02/17/2021
'Purpose: Track bugs and issues for projects in an organization. 

Option Strict On
Option Explicit On


Public Class Solution
    Private mintSolutionID As Integer
    Private mintIssueID As Integer
    Private mstrUpdatedByName As String
    Private mdteUpdatedOnDate As Date
    Private mstrUpdatedDescription As String

    Public Property SolutionID As Integer
        Get
            Return mintSolutionID
        End Get
        Set(intValue As Integer)
            mintSolutionID = intValue
        End Set
    End Property

    Public Property IssueID As Integer
        Get
            Return mintIssueID
        End Get
        Set(intValue As Integer)
            mintIssueID = intValue
        End Set
    End Property

    Public Property UpdatedByName As String
        Get
            Return mstrUpdatedByName
        End Get
        Set(strValue As String)
            mstrUpdatedByName = strValue
        End Set
    End Property

    Public Property UpdatedOnDate As Date
        Get
            Return mdteUpdatedOnDate
        End Get
        Set(dteValue As Date)
            mdteUpdatedOnDate = dteValue
        End Set
    End Property

    Public Property UpdatedDescription As String
        Get
            Return mstrUpdatedDescription
        End Get
        Set(strValue As String)
            mstrUpdatedDescription = strValue
        End Set
    End Property



    Public Sub New()
        mintSolutionID = 0
        mintIssueID = 0
        mstrUpdatedByName = String.Empty
        mdteUpdatedOnDate = Date.Now
        mstrUpdatedDescription = String.Empty
    End Sub

    Public Sub New(toString As String)
        mintSolutionID = 0
        mintIssueID = 0
        mstrUpdatedByName = String.Empty
        mdteUpdatedOnDate = Date.Now
        mstrUpdatedDescription = String.Empty
    End Sub

End Class
