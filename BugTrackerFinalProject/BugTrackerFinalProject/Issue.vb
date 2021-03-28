'Name: Whitney Kugel
'Date: 02/17/2021
'Purpose: Track bugs and issues for projects in an organization. 

Option Strict On
Option Explicit On


Public Class Issue
    Private mstrIssueID As String
    Private mstrOpenedByName As String
    Private mdteOpenedOnDate As Date
    Private mstrOpenedDescription As String
    Private mimgOpenedImage As Image
    Private mstrOpenedImageName As String
    Private mstrOpenedProjectName As String
    Private mstrOpenedProjectUrgency As String
    Private mstrUpdatedByName As String
    Private mdteUpdatedOnDate As Date
    Private mstrUpdatedDescription As String
    Private mstrClosedByName As String
    Private mdteClosedOnDate As Date
    Private mstrClosedDescription As String


    Public Property IssueID As String
        Get
            Return mstrIssueID
        End Get
        Set(strValue As String)
            mstrIssueID = strValue
        End Set
    End Property

    Public Property OpenedByName As String
        Get
            Return mstrOpenedByName
        End Get
        Set(strValue As String)
            mstrOpenedByName = strValue
        End Set
    End Property

    Public Property OpenedOnDate As Date
        Get
            Return mdteOpenedOnDate
        End Get
        Set(strValue As Date)
            mdteOpenedOnDate = strValue
        End Set
    End Property

    Public Property OpenedDescription As String
        Get
            Return mstrOpenedDescription
        End Get
        Set(strValue As String)
            mstrOpenedDescription = strValue
        End Set
    End Property

    Public Property OpenedImage As Image
        Get
            Return mimgOpenedImage
        End Get
        Set(imgValue As Image)
            mimgOpenedImage = imgValue
        End Set
    End Property

    Public Property OpenedImageName As String
        Get
            Return mstrOpenedImageName
        End Get
        Set(strValue As String)
            mstrOpenedImageName = strValue
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


    Public Property ClosedByName As String
        Get
            Return mstrClosedByName
        End Get
        Set(strValue As String)
            mstrClosedByName = strValue
        End Set
    End Property

    Public Property ClosedOnDate As Date
        Get
            Return mdteClosedOnDate
        End Get
        Set(dteValue As Date)
            mdteClosedOnDate = dteValue
        End Set
    End Property

    Public Property ClosedDescription As String
        Get
            Return mstrClosedDescription
        End Get
        Set(strValue As String)
            mstrClosedDescription = strValue
        End Set
    End Property

    Public Property OpenedProjectName As String
        Get
            Return mstrOpenedProjectName
        End Get
        Set(strValue As String)
            mstrOpenedProjectName = strValue
        End Set
    End Property


    Public Property OpenedProjectUrgency As String
        Get
            Return mstrOpenedProjectUrgency
        End Get
        Set(strValue As String)
            mstrOpenedProjectUrgency = strValue
        End Set
    End Property


    Public Sub New()
        mstrIssueID = String.Empty
        mstrOpenedByName = String.Empty
        mdteOpenedOnDate = Nothing
        mstrOpenedDescription = String.Empty
        mimgOpenedImage = Nothing
        mstrOpenedImageName = String.Empty
        mstrUpdatedByName = String.Empty
        mdteUpdatedOnDate = Date.Now
        mstrUpdatedDescription = String.Empty
        mstrClosedByName = String.Empty
        mdteClosedOnDate = Date.Now
        mstrClosedDescription = String.Empty
        mstrOpenedProjectName = String.Empty
        mstrOpenedProjectUrgency = String.Empty
    End Sub

    Public Sub New(toString As String)
        mstrIssueID = String.Empty
        mstrOpenedByName = String.Empty
        mdteOpenedOnDate = Date.Now
        mstrOpenedDescription = String.Empty
        mimgOpenedImage = Nothing
        mstrOpenedImageName = String.Empty
        mstrUpdatedByName = String.Empty
        mdteUpdatedOnDate = Date.Now
        mstrUpdatedDescription = String.Empty
        mstrClosedByName = String.Empty
        mdteClosedOnDate = Date.Now
        mstrClosedDescription = String.Empty
        mstrOpenedProjectName = String.Empty
        mstrOpenedProjectUrgency = String.Empty
    End Sub

End Class
