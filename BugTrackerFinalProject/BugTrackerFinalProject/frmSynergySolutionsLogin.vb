'Name: Whitney Kugel
'Date: 02/17/2021
'Purpose: Track bugs and issues for projects in an organization. 


Option Strict On
Option Explicit On

Imports System.Data.SqlClient
Imports System.IO

Public Class frmSynergySolutionsLogin


    'Module level Object
    Dim objEmployee As New Employee()

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ValidateLogin()

    End Sub

    'Connect to Database
    Private Function OpenDBConnection() As SqlConnection
        'Create a connection String
        'This give the full path into the bin/debug folder
        Dim strPath As String = Application.StartupPath
        Dim intPathLength As Integer = strPath.Length
        'This strips off the bin/debug folder to point into your project folder.
        strPath = strPath.Substring(0, intPathLength - 9)

        Dim strconnection As String = "Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=" + strPath + "SynergySolutionsDB.mdf"

        'Create a Connection object
        Dim dbConnection As New SqlConnection(strconnection)

        Try
            'Open Database
            dbConnection.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message) 'Delete/modify messagebox upon release
        End Try

        Return dbConnection
    End Function

    Private Sub ValidateLogin()
        Dim dbConnection As SqlConnection = OpenDBConnection()

        'Create a command object
        Dim cmdSelect As New SqlCommand("Select * from Employees_Tbl;", dbConnection)

        'Execute Command into a Datareader
        Dim rdrEmployee As SqlDataReader = cmdSelect.ExecuteReader

        If rdrEmployee.HasRows Then
            While rdrEmployee.Read
                Dim objValidateEmployee As New Employee(rdrEmployee.Item("EmployeeID").ToString)
                objValidateEmployee.EmployeeID = CInt(rdrEmployee.Item("EmployeeID"))
                objValidateEmployee.FirstName = rdrEmployee.Item("FirstName").ToString
                objValidateEmployee.LastName = rdrEmployee.Item("LastName").ToString
                objValidateEmployee.Email = rdrEmployee.Item("Email").ToString
                objValidateEmployee.Password = rdrEmployee.Item("Password").ToString
                objValidateEmployee.Admin = rdrEmployee.Item("Admin").ToString

                'Verify Image is stored
                If IsDBNull(rdrEmployee.Item("EmployeePic")) = False Then
                    objValidateEmployee.EmployeePic = byteArrayToImage(CType(rdrEmployee.Item("EmployeePic"), Byte()))
                End If

                If txtEmail.Text.ToLower = objValidateEmployee.Email.ToLower And txtPassword.Text = objValidateEmployee.Password Then
                    frmSynergySolutionsMain.lblActiveName.Text = objValidateEmployee.FirstName & " " & objValidateEmployee.LastName
                    frmSynergySolutionsMain.lblEmployeeIDDisplay.Text = objValidateEmployee.EmployeeID.ToString
                    frmSynergySolutionsMain.pbxEmployeePic.Image = (objValidateEmployee.EmployeePic)

                    'Check for admin level credentials
                    If objValidateEmployee.Admin.ToUpper = "TRUE" Then
                        frmSynergySolutionsMain.lblHome.Visible = True
                        frmSynergySolutionsMain.btnDeleteIssue.Visible = True
                        frmSynergySolutionsMain.btnDeleteUpdate.Visible = True
                        frmSynergySolutionsMain.btnRestore.Visible = True
                    Else
                        frmSynergySolutionsMain.lblHome.Visible = False
                        frmSynergySolutionsMain.btnDeleteIssue.Visible = False
                        frmSynergySolutionsMain.btnDeleteUpdate.Visible = False
                        frmSynergySolutionsMain.btnRestore.Visible = False
                    End If


                    frmSynergySolutionsMain.Show()
                    Me.Hide()

                Else
                    lblLoginErrorDisplay.Visible = True
                End If

            End While
        End If
        dbConnection.Close()
        dbConnection.Dispose()
    End Sub


    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            ValidateLogin()
        End If
    End Sub

    Private Sub txtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            ValidateLogin()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Me.Close()
    End Sub

    Public Function byteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Using mStream As New MemoryStream(byteArrayIn)
            Return Image.FromStream(mStream)
        End Using
    End Function
End Class
