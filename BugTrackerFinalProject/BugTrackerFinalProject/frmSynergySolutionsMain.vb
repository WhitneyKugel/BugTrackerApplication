'Name: Whitney Kugel
'Date: 02/17/2021
'Purpose: Track bugs and issues for projects in an organization. 

Option Strict On
Option Explicit On


Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class frmSynergySolutionsMain

    Dim lstIssues As New BindingList(Of Issue)
    Dim lstEmployee As New BindingList(Of Employee)
    Dim lstSolutions As New BindingList(Of Solution)
    Dim lstClosedIssues As New BindingList(Of Issue)
    Dim lstClosedSolutions As New BindingList(Of Issue)


    'Dim objIssue As New Issue()


    Private Sub frmSynergySolutionsMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Modify Panel Menu Background color
        pnlMenu.BackColor = Color.FromArgb(85, 0, 0, 0)

        'Populate IssuesToView Combobox
        cbxUrgency.Items.Add("Feature Request")
        cbxUrgency.Items.Add("Low")
        cbxUrgency.Items.Add("Medium")
        cbxUrgency.Items.Add("High")
        cbxUrgency.Items.Add("Critical")

        'Populate Employee Clearance Combobox
        cbxClearanceLevel.Items.Add("Admin")
        cbxClearanceLevel.Items.Add("Non-admin")

        'Bind Binding List to listbox for Issue List
        lbxIssueList.DataSource = lstIssues
        lbxIssueList.DisplayMember = "IssueID"

        'Bind Binding List to listbox for Solution List
        lbxEntries.DataSource = lstSolutions
        lbxEntries.DisplayMember = "UpdatedOnDate"

        'Bind Binding List to listbox for Closed Issue List
        lbxIssuesClosed.DataSource = lstClosedIssues
        lbxIssuesClosed.DisplayMember = "IssueID"

        'Bind Binding List to listbox for Closed Solution List
        lbxClosedEntry.DataSource = lstSolutions
        lbxClosedEntry.DisplayMember = "UpdatedOnDate"

        ClearInput()

        'Check if user is an Admin for ability to create new employees


    End Sub


    Private Sub Reload_lbxIssues()
        'Clear Listbox
        lstIssues.Clear()
        lstSolutions.Clear()
        lstClosedIssues.Clear()

        'Open Database
        Dim dbConnection As SqlConnection = OpenDBConnection()

        'Create a Command Object
        Dim cmdSelect As New SqlCommand("Select * from Issues_Tbl;", dbConnection)

        'Execute Command into a DataReader
        Dim rdrIssue As SqlDataReader = cmdSelect.ExecuteReader

        If rdrIssue.HasRows Then
            While rdrIssue.Read
                'Populate data into temporary object
                Dim objStoredIssue As New Issue(rdrIssue.Item("IssueID").ToString)
                objStoredIssue.IssueID = rdrIssue.Item("IssueID").ToString
                objStoredIssue.OpenedByName = rdrIssue.Item("OpenedByName").ToString
                If IsDBNull(rdrIssue.Item("OpenedOnDate")) = False Then
                    objStoredIssue.OpenedOnDate = CDate(rdrIssue.Item("OpenedOnDate"))
                End If
                objStoredIssue.OpenedProjectName = rdrIssue.Item("OpenedProjectName").ToString
                objStoredIssue.OpenedProjectUrgency = rdrIssue.Item("OpenedProjectUrgency").ToString
                objStoredIssue.OpenedDescription = rdrIssue.Item("OpenedDescription").ToString

                If IsDBNull(rdrIssue.Item("OpenedImage")) = False Then

                    objStoredIssue.OpenedImage = byteArrayToImage(CType(rdrIssue.Item("OpenedImage"), Byte()))
                    objStoredIssue.OpenedImageName = rdrIssue.Item("OpenedImageName").ToString
                End If

                If (IsDBNull(rdrIssue.Item("ClosedOnDate")) = False) And (rdrIssue.Item("ClosedOnDate").ToString <> "1/1/1900 12:00:00 AM") Then
                    objStoredIssue.ClosedOnDate = CDate(rdrIssue.Item("ClosedOnDate"))
                    objStoredIssue.ClosedByName = rdrIssue.Item("ClosedByName").ToString
                    objStoredIssue.ClosedDescription = rdrIssue.Item("ClosedDescription").ToString
                    'Add Closed Jobs to list
                    lstClosedIssues.Add(objStoredIssue)

                Else
                    'Add Open Jobs to List
                    lstIssues.Add(objStoredIssue)
                End If

            End While
        End If

        dbConnection.Close()
        dbConnection.Dispose()
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



    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        'Condition for if working on the document process
        If txtProjectName.Text <> String.Empty Then
            If cbxUrgency.SelectedItem IsNot Nothing Then
                If txtDescription.Text <> String.Empty Then

                    'Intantiate a new User
                    Dim objIssue As New Issue()

                    'Assign Issue Properties
                    objIssue.OpenedByName = lblActiveName.Text
                    objIssue.OpenedOnDate = Now
                    objIssue.OpenedProjectName = txtProjectName.Text
                    objIssue.OpenedDescription = txtDescription.Text
                    objIssue.OpenedProjectUrgency = cbxUrgency.SelectedItem.ToString

                    If lblUploadedFileName.Text <> String.Empty Then
                        Dim uldPictureFile = lblFileLocation.Text
                        objIssue.OpenedImage = Image.FromFile(uldPictureFile)
                        objIssue.OpenedImageName = lblUploadedFileName.Text

                    End If

                    lstIssues.Add(objIssue)
                    InsertIssue()
                    Reload_lbxIssues()
                    ClearInput()

                Else
                    MessageBox.Show("Enter a description to continue.")
                End If
            Else
                MessageBox.Show("Select the urgency to continue.")
            End If

            'Else condition for if working on the debug process
        Else
            MessageBox.Show("Enter project name to continue.")
        End If

    End Sub

    Public Sub InsertIssue()
        If lblUploadedFileName.Text = String.Empty Then
            'Open Database
            Dim dbConnection As SqlConnection = OpenDBConnection()

            'Create SQL String9
            Dim strSQL = "Insert into Issues_Tbl (OpenedByName,OpenedOnDate,OpenedDescription,OpenedProjectName,OpenedProjectUrgency) values (@OpenedByName,@OpenedOnDate,@OpenedDescription,@OpenedProjectName,@OpenedProjectUrgency)"

            'Create Command
            Dim cmdInsert As New SqlCommand(strSQL, dbConnection)

            'Populate Parameters of the Insert
            cmdInsert.Parameters.AddWithValue("OpenedByName", lstIssues.Last.OpenedByName)
            cmdInsert.Parameters.AddWithValue("OpenedOnDate", lstIssues.Last.OpenedOnDate)
            cmdInsert.Parameters.AddWithValue("OpenedDescription", lstIssues.Last.OpenedDescription)
            cmdInsert.Parameters.AddWithValue("OpenedProjectName", lstIssues.Last.OpenedProjectName)
            cmdInsert.Parameters.AddWithValue("OpenedProjectUrgency", lstIssues.Last.OpenedProjectUrgency)

            Try
                Dim intRowsAffected = cmdInsert.ExecuteNonQuery()

                If intRowsAffected = 1 Then
                    'MessageBox.Show("Insert Success!")
                Else
                    MessageBox.Show("Insert Failed!")
                End If

            Catch ex As Exception
                MessageBox.Show("Insert did not work!")
            End Try


        Else
            Try
                Dim memstr As New MemoryStream

                lstIssues.Last.OpenedImage.Save(memstr, lstIssues.Last.OpenedImage.RawFormat)
                'Open Database
                Dim dbConnection As SqlConnection = OpenDBConnection()

                'Create SQL String
                Dim strSQL = "Insert into Issues_Tbl (OpenedByName,OpenedOnDate,OpenedDescription,OpenedImage,OpenedImageName,OpenedProjectName,OpenedProjectUrgency) values (@OpenedByName,@OpenedOnDate,@OpenedDescription,@OpenedImage,@OpenedImageName,@OpenedProjectName,@OpenedProjectUrgency)"

                'Create Command
                Dim cmdInsert As New SqlCommand(strSQL, dbConnection)

                'Populate Parameters of the Insert
                cmdInsert.Parameters.AddWithValue("OpenedByName", lstIssues.Last.OpenedByName)
                cmdInsert.Parameters.AddWithValue("OpenedOnDate", lstIssues.Last.OpenedOnDate)
                cmdInsert.Parameters.AddWithValue("OpenedDescription", lstIssues.Last.OpenedDescription)
                cmdInsert.Parameters.AddWithValue("OpenedProjectName", lstIssues.Last.OpenedProjectName)
                cmdInsert.Parameters.AddWithValue("OpenedProjectUrgency", lstIssues.Last.OpenedProjectUrgency)
                cmdInsert.Parameters.Add("@OpenedImage", SqlDbType.Image).Value = memstr.ToArray
                cmdInsert.Parameters.AddWithValue("OpenedImageName", lstIssues.Last.OpenedImageName)

                Try
                    Dim intRowsAffected = cmdInsert.ExecuteNonQuery()

                    If intRowsAffected = 1 Then
                        'MessageBox.Show("Insert image Success!")
                    Else
                        MessageBox.Show("Insert image Failed!")
                    End If

                Catch ex As Exception
                    MessageBox.Show("Insert image did not work!")
                End Try

            Catch
                MessageBox.Show("Image not working")
            End Try

        End If
    End Sub



    Public Sub DeleteIssue()

        'Remove deleted User
        Dim objSelectedIssue = CType(lbxIssueList.SelectedItem, Issue)

        'Open Database
        Dim dbConnection As SqlConnection = OpenDBConnection()

        Dim strSQL = "Delete from Issues_Tbl where IssueID = '" & CInt(objSelectedIssue.IssueID) & "'"

        Dim cmdDelete As New SqlCommand(strSQL, dbConnection)

        Try
            Dim intRowsAffected = cmdDelete.ExecuteNonQuery()

            If intRowsAffected = 1 Then
                'MessageBox.Show("Record " & objSelectedIssue.IssueID & "  was deleted")
                lstIssues.Remove(objSelectedIssue)
                Reload_lbxIssues()
            Else
                MessageBox.Show("Did not update!")
            End If

        Catch ex As Exception
            MessageBox.Show("DB Delete Failed" & ex.Message)
        End Try

        dbConnection.Close()
        dbConnection.Dispose()
    End Sub


    Public Sub DeleteUpdate()

        'Remove deleted User
        Dim objSelectedSolution = CType(lbxEntries.SelectedItem, Solution)

        'Open Database
        Dim dbConnection As SqlConnection = OpenDBConnection()

        Dim strSQL = "Delete from Solutions_Tbl where SolutionID = '" & objSelectedSolution.SolutionID & "'"

        Dim cmdDelete As New SqlCommand(strSQL, dbConnection)

        Try
            Dim intRowsAffected = cmdDelete.ExecuteNonQuery()

            If intRowsAffected = 1 Then
                'MessageBox.Show("Record " & objSelectedSolution.SolutionID & "  was deleted")
                lstSolutions.Remove(objSelectedSolution)
                Reload_lbxEntries()
            Else
                MessageBox.Show("Did not update." + objSelectedSolution.SolutionID.ToString)
            End If

        Catch ex As Exception
            MessageBox.Show("DB Delete Failed" & ex.Message)
        End Try

        dbConnection.Close()
        dbConnection.Dispose()
    End Sub



    Private Sub ClearInput()
        txtProjectName.Text = String.Empty
        cbxUrgency.SelectedIndex = -1
        lblFileAttachmentDisplay.Text = String.Empty
        lblFileLocation.Text = String.Empty
        txtDescription.Text = String.Empty
        lblUploadedFileName.Text = String.Empty
        txtUpdateDescription.Text = String.Empty
        lblIssueIDDisplay.Text = String.Empty
        lblProjectNameDisplay.Text = String.Empty
        lblUrgencyDisplay.Text = String.Empty
        lblOpenedByNameDisplay.Text = String.Empty
        lblOpenedOnDateDisplay.Text = String.Empty
        lblDaySinceOpenedDisplay.Text = String.Empty
        txtIssueDescriptionDisplay.Text = String.Empty
        txtUpdateDescription.Text = String.Empty
        txtUpdateDescriptionClosedDisplay.Text = String.Empty
        lblUpdatedByClosedDisplay.Text = String.Empty
        lblUpdatedOnClosedDisplay.Text = String.Empty
        txtUpdateDescriptionDisplay.Text = String.Empty
        lblUpdatedByDisplay.Text = String.Empty
        lblUpdatedOnDisplay.Text = String.Empty
        txtUpdateDescription.Text = String.Empty
        lstClosedSolutions.Clear()
        btnUpdate.Enabled = False
        btnClose.Enabled = False
        btnDeleteUpdate.Enabled = False
        lstSolutions.Clear()
        lblProjectNameClosedDisplay.Text = String.Empty
        lblOpenedByClosedDisplay.Text = String.Empty
        lblOpenedOnClosedDisplay.Text = String.Empty
        lblUrgencyClosedDisplay.Text = String.Empty
        lblDaysToCompleteDisplay.Text = String.Empty
        lblClosedByDisplay.Text = String.Empty
        lblClosedonDisplay.Text = String.Empty
        pbxIssueImageClosed.Image = Nothing
        txtIssueDescriptionClosedDisplay.Text = String.Empty
        txtUpdateDescriptionClosedDisplay.Text = String.Empty
        lblIssueIDClosedDisplay.Text = String.Empty

    End Sub

    Private Sub lbxIssueList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxIssueList.SelectedIndexChanged
        ClearInput()
        lstSolutions.Clear()
        If lbxIssueList.SelectedIndex >= 0 Then
            btnDeleteIssue.Enabled = True
            btnUpdate.Enabled = True
            btnClose.Enabled = True
            Dim objSelectedIssue As Issue = CType(lbxIssueList.SelectedItem, Issue)

            'Populate fields with selected issue information
            lblIssueIDDisplay.Text = objSelectedIssue.IssueID
            lblProjectNameDisplay.Text = objSelectedIssue.OpenedProjectName
            lblUrgencyDisplay.Text = objSelectedIssue.OpenedProjectUrgency
            lblOpenedByNameDisplay.Text = objSelectedIssue.OpenedByName
            lblOpenedOnDateDisplay.Text = objSelectedIssue.OpenedOnDate.ToString

            lblDaySinceOpenedDisplay.Text = CStr(DateDiff(DateInterval.Day, objSelectedIssue.OpenedOnDate, Now))

            txtIssueDescriptionDisplay.Text = objSelectedIssue.OpenedDescription
            If IsDBNull(lblFileAttachmentDisplay.Text) = False Then
                pbxSavedImage.Image = (objSelectedIssue.OpenedImage)
            End If

            Reload_lbxEntries()

        Else
            btnDeleteIssue.Enabled = False

        End If


    End Sub

    'Covert Saved Array back to Image
    Public Function byteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Using mStream As New MemoryStream(byteArrayIn)
            Return Image.FromStream(mStream)
        End Using
    End Function


    Private Sub btnUploadAttachment_Click(sender As Object, e As EventArgs) Handles btnUploadAttachment.Click

        Dim opnAttachmentFile As New OpenFileDialog
        If opnAttachmentFile.ShowDialog = DialogResult.OK Then

            If opnAttachmentFile.FileName <> String.Empty Then

                lblUploadedFileName.Text = opnAttachmentFile.SafeFileName
                lblFileLocation.Text = opnAttachmentFile.FileName

            End If

        End If

    End Sub

    Private Sub pbxSavedImage_DoubleClick(sender As Object, e As EventArgs) Handles pbxSavedImage.DoubleClick
        frmImageViewer.pbxImageViewer.Image = pbxSavedImage.Image
        frmImageViewer.Show()
    End Sub

    Private Sub btnSaveEmployee_Click(sender As Object, e As EventArgs) Handles btnSaveEmployee.Click

        If txtNewFirstName.Text <> String.Empty Then
            If txtNewLastName.Text <> String.Empty Then
                If cbxClearanceLevel.Text <> String.Empty Then
                    If txtNewPassword.Text <> String.Empty Then
                        If lblEmployeePhotoFileName.Text <> String.Empty Then


                            'Intantiate a new User
                            Dim objEmployee As New Employee()

                            'Assign Issue Properties
                            objEmployee.FirstName = txtNewFirstName.Text
                            objEmployee.LastName = txtNewLastName.Text
                            objEmployee.Email = txtNewFirstName.Text & txtNewLastName.Text & "@SynergySolutions.com"
                            objEmployee.Password = txtNewPassword.Text
                            If cbxClearanceLevel.SelectedIndex = 0 Then
                                objEmployee.Admin = "False"
                            Else
                                objEmployee.Admin = "True"
                            End If

                            If lblEmployeePhotoFileName.Text <> String.Empty Then
                                Dim uldPictureFile = lblEmployeePhotoFileLocation.Text
                                objEmployee.EmployeePic = Image.FromFile(uldPictureFile)

                            End If

                            lstEmployee.Add(objEmployee)
                            InsertEmployee()
                            'Reload_lbxIssues()
                            ClearInput()

                        Else
                            lblLoginErrorDisplay.Visible = True
                        End If
                    Else
                        lblLoginErrorDisplay.Visible = True
                    End If
                Else
                    lblLoginErrorDisplay.Visible = True
                End If
            Else
                lblLoginErrorDisplay.Visible = True
            End If
        Else
            lblLoginErrorDisplay.Visible = True
        End If

    End Sub

    Public Sub InsertEmployee()
        'Create Memory Stream for image conversion
        Dim memstr As New MemoryStream

        lstEmployee.Last.EmployeePic.Save(memstr, lstEmployee.Last.EmployeePic.RawFormat)

        'Open Database
        Dim dbConnection As SqlConnection = OpenDBConnection()

        'Create SQL String9
        Dim strSQL = "Insert into Employees_Tbl (FirstName,LastName,Email,Password,EmployeePic,Admin,HiredDate) values (@FirstName,@LastName,@Email,@Password,@EmployeePic,@Admin,@HiredDate)"

        'Create Command
        Dim cmdInsert As New SqlCommand(strSQL, dbConnection)

        'Populate Parameters of the Insert
        cmdInsert.Parameters.AddWithValue("FirstName", lstEmployee.Last.FirstName)
        cmdInsert.Parameters.AddWithValue("LastName", lstEmployee.Last.LastName)
        cmdInsert.Parameters.AddWithValue("Email", lstEmployee.Last.Email)
        cmdInsert.Parameters.AddWithValue("Password", lstEmployee.Last.Password)
        cmdInsert.Parameters.Add("@EmployeePic", SqlDbType.Image).Value = memstr.ToArray

        cmdInsert.Parameters.AddWithValue("Admin", lstEmployee.Last.Admin)
        cmdInsert.Parameters.AddWithValue("HiredDate", lstEmployee.Last.HiredDate)
        Try
            Dim intRowsAffected = cmdInsert.ExecuteNonQuery()

            If intRowsAffected = 1 Then
                'MessageBox.Show("Insert Success!")
            Else
                MessageBox.Show("Insert Failed!")
            End If

        Catch ex As Exception
            MessageBox.Show("Insert did not work!")
        End Try

    End Sub

    Private Sub btnUploadEmployeePhoto_Click(sender As Object, e As EventArgs) Handles btnUploadEmployeePhoto.Click

        Dim opnAttachmentFile As New OpenFileDialog
        If opnAttachmentFile.ShowDialog = DialogResult.OK Then

            If opnAttachmentFile.FileName <> String.Empty Then

                lblEmployeePhotoFileName.Text = opnAttachmentFile.SafeFileName
                lblEmployeePhotoFileLocation.Text = opnAttachmentFile.FileName

            End If

        End If

    End Sub

    Private Sub lblHome_Click(sender As Object, e As EventArgs) Handles lblHome.Click
        pnlMain.Visible = True
        pnlDocument.Visible = False
        pnlDebug.Visible = False
        pnlClosedTickets.Visible = False
        ClearInput()
    End Sub


    Private Sub lblDocument_Click(sender As Object, e As EventArgs) Handles lblDocument.Click
        pnlMain.Visible = False
        pnlDocument.Visible = True
        pnlDebug.Visible = False
        pnlClosedTickets.Visible = False
        ClearInput()
    End Sub


    Private Sub lblDebug_Click(sender As Object, e As EventArgs) Handles lblDebug.Click
        pnlMain.Visible = False
        pnlDocument.Visible = False
        pnlDebug.Visible = True
        pnlClosedTickets.Visible = False
        Reload_lbxIssues()
        Reload_lbxEntries()
        Reload_lbxClosedEntry()
        lstSolutions.Clear()
        ClearInput()
        lbxIssueList.SelectedIndex = -1
        lstSolutions.Clear()
    End Sub


    Private Sub lblClosed_Click(sender As Object, e As EventArgs) Handles lblClosed.Click
        pnlMain.Visible = False
        pnlDocument.Visible = False
        pnlDebug.Visible = False
        pnlClosedTickets.Visible = True
        Reload_lbxIssues()
        Reload_lbxClosedEntry()
        ClearInput()
        lbxIssuesClosed.SelectedIndex = -1
        lstSolutions.Clear()
    End Sub



    Private Sub lblDebug_MouseEnter(sender As Object, e As EventArgs) Handles lblDebug.MouseEnter
        lblDebug.ForeColor = Color.Red
    End Sub

    Private Sub lblDebug_MouseLeave(sender As Object, e As EventArgs) Handles lblDebug.MouseLeave
        lblDebug.ForeColor = Color.White
    End Sub

    Private Sub lblDocument_MouseEnter(sender As Object, e As EventArgs) Handles lblDocument.MouseEnter
        lblDocument.ForeColor = Color.Red
    End Sub

    Private Sub lblDocument_MouseLeave(sender As Object, e As EventArgs) Handles lblDocument.MouseLeave
        lblDocument.ForeColor = Color.White
    End Sub

    Private Sub lblClosed_MouseEnter(sender As Object, e As EventArgs) Handles lblClosed.MouseEnter
        lblClosed.ForeColor = Color.Red
    End Sub

    Private Sub lblClosed_MouseLeave(sender As Object, e As EventArgs) Handles lblClosed.MouseLeave
        lblClosed.ForeColor = Color.White
    End Sub


    Private Sub lblLogout_MouseLeave(sender As Object, e As EventArgs) Handles lblLogout.MouseLeave
        lblLogout.ForeColor = Color.White
    End Sub

    Private Sub lblLogout_MouseEnter(sender As Object, e As EventArgs) Handles lblLogout.MouseEnter
        lblLogout.ForeColor = Color.Red
    End Sub

    Private Sub lblHome_MouseEnter(sender As Object, e As EventArgs) Handles lblHome.MouseEnter
        lblHome.ForeColor = Color.Red
    End Sub

    Private Sub lblHome_MouseLeave(sender As Object, e As EventArgs) Handles lblHome.MouseLeave
        lblHome.ForeColor = Color.White
    End Sub

    Private Sub lblLogout_Click(sender As Object, e As EventArgs) Handles lblLogout.Click
        Me.Close()

    End Sub

    Private Sub tmrDateTime_Tick(sender As Object, e As EventArgs) Handles tmrDateTime.Tick

        lblCurrentDate.Text = Date.Now.ToString("MM/dd/yyyy") 'Calander Date
        lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt") 'Time in AM/PM

    End Sub

    Public Sub UpdateIssue()
        'Open Database
        Dim dbConnection As SqlConnection = OpenDBConnection()

        Dim strSQL = "Insert into Solutions_Tbl (IssueID,UpdatedByName,UpdatedOnDate,UpdatedDescription) values (@IssueID,@UpdatedByName,@UpdatedOnDate,@UpdatedDescription)"

        'Create Command
        Dim cmdInsert As New SqlCommand(strSQL, dbConnection)

        'Populate Parameters of the Insert
        cmdInsert.Parameters.AddWithValue("IssueID", lstSolutions.Last.IssueID)
        cmdInsert.Parameters.AddWithValue("UpdatedByName", lstSolutions.Last.UpdatedByName)
        cmdInsert.Parameters.AddWithValue("UpdatedOnDate", lstSolutions.Last.UpdatedOnDate)
        cmdInsert.Parameters.AddWithValue("UpdatedDescription", lstSolutions.Last.UpdatedDescription)

        Try
            Dim intRowsAffected = cmdInsert.ExecuteNonQuery()
            If intRowsAffected = 1 Then
                'MessageBox.Show("Updating Issue")
            End If
        Catch ex As Exception
            MessageBox.Show("Updating Issue failed")
        End Try
        Reload_lbxIssues()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If txtUpdateDescription.Text <> String.Empty Then

            'Intantiate a new User
            Dim objSolution As New Solution()

            'Assign Issue Properties
            objSolution.IssueID = CInt(lblIssueIDDisplay.Text)
            objSolution.UpdatedByName = lblActiveName.Text
            objSolution.UpdatedOnDate = Date.Now
            objSolution.UpdatedDescription = txtUpdateDescription.Text


            lstSolutions.Add(objSolution)

            UpdateIssue()
            Reload_lbxIssues()
            Reload_lbxEntries()

            ClearInput()
            lbxIssueList.SelectedIndex = -1
        End If
    End Sub

    Private Sub Reload_lbxEntries()
        'Reloads both lbxEntries and lbxClosedEntry

        'Clear Listbox
        lstSolutions.Clear()

        'Open Database
        Dim dbConnection As SqlConnection = OpenDBConnection()

        'Create a Command Object
        Dim cmdSelect As New SqlCommand("Select * from Solutions_Tbl;", dbConnection)

        'Execute Command into a DataReader
        Dim rdrIssue As SqlDataReader = cmdSelect.ExecuteReader

        If rdrIssue.HasRows Then
            While rdrIssue.Read
                'Populate data into temporary object
                Dim objStoredSolution As New Solution(rdrIssue.Item("IssueID").ToString)
                objStoredSolution.SolutionID = CInt(rdrIssue.Item("SolutionID").ToString)
                objStoredSolution.IssueID = CInt(rdrIssue.Item("IssueID"))
                objStoredSolution.UpdatedByName = rdrIssue.Item("UpdatedByName").ToString
                objStoredSolution.UpdatedOnDate = CDate(rdrIssue.Item("UpdatedOnDate"))
                objStoredSolution.UpdatedDescription = rdrIssue.Item("UpdatedDescription").ToString

                If objStoredSolution.IssueID.ToString = lblIssueIDDisplay.Text Then
                    lstSolutions.Add(objStoredSolution)
                End If


            End While
        End If
        lbxEntries.SelectedIndex = -1
        dbConnection.Close()
        dbConnection.Dispose()
    End Sub

    Private Sub lbxEntries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxEntries.SelectedIndexChanged

        If lbxEntries.SelectedIndex >= 0 Then
            btnDeleteUpdate.Enabled = True
            Dim objSelectedSolution As Solution = CType(lbxEntries.SelectedItem, Solution)

            'Populate fields with selected issue information
            txtUpdateDescriptionDisplay.Text = objSelectedSolution.UpdatedDescription
            lblUpdatedByDisplay.Text = objSelectedSolution.UpdatedByName
            lblUpdatedOnDisplay.Text = objSelectedSolution.UpdatedOnDate.ToString

        End If


    End Sub

    Private Sub lbxIssuesClosed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxIssuesClosed.SelectedIndexChanged
        ClearInput()
        If lbxIssuesClosed.SelectedIndex >= 0 Then

            Dim objSelectedIssue As Issue = CType(lbxIssuesClosed.SelectedItem, Issue)

            'Populate fields with selected issue information
            lblIssueIDClosedDisplay.Text = objSelectedIssue.IssueID
            lblProjectNameClosedDisplay.Text = objSelectedIssue.OpenedProjectName
            lblUrgencyClosedDisplay.Text = objSelectedIssue.OpenedProjectUrgency
            lblOpenedByClosedDisplay.Text = objSelectedIssue.OpenedByName
            lblOpenedOnClosedDisplay.Text = objSelectedIssue.OpenedOnDate.ToString
            lblDaysToCompleteDisplay.Text = CStr(DateDiff(DateInterval.Day, objSelectedIssue.OpenedOnDate, objSelectedIssue.ClosedOnDate))

            lblClosedByDisplay.Text = objSelectedIssue.ClosedByName
            lblClosedonDisplay.Text = objSelectedIssue.ClosedOnDate.ToString
            txtIssueDescriptionClosedDisplay.Text = objSelectedIssue.OpenedDescription

            lblDaySinceOpenedDisplay.Text = CStr(DateDiff(DateInterval.Day, objSelectedIssue.OpenedOnDate, Now))

            If IsDBNull(lblFileAttachmentDisplay.Text) = False Then
                pbxIssueImageClosed.Image = (objSelectedIssue.OpenedImage)
            End If

            Reload_lbxClosedEntry()
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Update and Close


        'Intantiate a new User
        Dim objClosedSolution As New Issue()

        'Assign Issue Properties
        objClosedSolution.IssueID = lblIssueIDDisplay.Text
        objClosedSolution.ClosedByName = lblActiveName.Text
        objClosedSolution.ClosedOnDate = Date.Now
        objClosedSolution.ClosedDescription = txtUpdateDescription.Text


        lstClosedSolutions.Add(objClosedSolution)

        CloseIssue()
        Reload_lbxIssues()
        Reload_lbxEntries()

        ClearInput()
        lbxIssueList.SelectedIndex = -1

    End Sub

    Public Sub CloseIssue()
        'Open Database
        Dim dbConnection As SqlConnection = OpenDBConnection()

        Dim strSQL = "Update Issues_Tbl set ClosedByName ='" & lblActiveName.Text & "',ClosedOnDate ='" & Date.Now & "',ClosedDescription ='" & txtUpdateDescription.Text & "' where IssueID ='" & CInt(lblIssueIDDisplay.Text) & "'"

        Dim cmdUpdate As New SqlCommand(strSQL, dbConnection)

        Try
            Dim intRowsAffected = cmdUpdate.ExecuteNonQuery()
            If intRowsAffected = 1 Then
                'MessageBox.Show("updated")
            Else
                MessageBox.Show("The update failed.")
            End If

        Catch ex As Exception
            MessageBox.Show("DB Update Failed" & ex.Message)
        End Try

        Reload_lbxIssues()
        Reload_lbxEntries()

        ClearInput()
    End Sub

    Private Sub Reload_lbxClosedEntry()
        'Clear Listbox
        lstSolutions.Clear()
        lstClosedSolutions.Clear()


        'Open Database
        Dim dbConnection As SqlConnection = OpenDBConnection()

        'Create a Command Object
        Dim cmdSelect As New SqlCommand("Select * from Solutions_Tbl;", dbConnection)

        'Execute Command into a DataReader
        Dim rdrIssue As SqlDataReader = cmdSelect.ExecuteReader

        If rdrIssue.HasRows Then
            While rdrIssue.Read
                'Populate data into temporary object
                Dim objStoredSolution As New Solution(rdrIssue.Item("IssueID").ToString)
                objStoredSolution.IssueID = CInt(rdrIssue.Item("IssueID"))
                objStoredSolution.UpdatedByName = rdrIssue.Item("UpdatedByName").ToString
                objStoredSolution.UpdatedOnDate = CDate(rdrIssue.Item("UpdatedOnDate"))
                objStoredSolution.UpdatedDescription = rdrIssue.Item("UpdatedDescription").ToString

                If objStoredSolution.IssueID.ToString = lblIssueIDDisplay.Text Or objStoredSolution.IssueID.ToString = lblIssueIDClosedDisplay.Text Then
                    lstSolutions.Add(objStoredSolution)
                End If

            End While
        End If
        lbxClosedEntry.SelectedIndex = -1
        dbConnection.Close()
        dbConnection.Dispose()
    End Sub


    Private Sub lbxClosedEntry_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lbxClosedEntry.SelectedIndexChanged

        If lbxClosedEntry.SelectedIndex >= 0 Then

            Dim objSelectedSolution As Solution = CType(lbxClosedEntry.SelectedItem, Solution)

            'Populate fields with selected issue information
            txtUpdateDescriptionClosedDisplay.Text = objSelectedSolution.UpdatedDescription
            lblUpdatedByClosedDisplay.Text = objSelectedSolution.UpdatedByName
            lblUpdatedOnClosedDisplay.Text = objSelectedSolution.UpdatedOnDate.ToString


        End If

    End Sub


    Private Sub btnDeleteIssue_Click(sender As Object, e As EventArgs) Handles btnDeleteIssue.Click

        DeleteIssue()
        ClearInput()
        lbxIssueList.SelectedIndex = -1

    End Sub


    Private Sub btnDeleteUpdate_Click(sender As Object, e As EventArgs) Handles btnDeleteUpdate.Click
        DeleteUpdate()
        ClearInput()
        lbxIssueList.SelectedIndex = -1
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click

        'Restore a ticket

        'Update in datebase
        'Open Database
        Dim dbConnection As SqlConnection = OpenDBConnection()

        Dim strSQL = "Update Issues_Tbl set ClosedByName ='" & DBNull.Value & "',ClosedOnDate ='" & DBNull.Value & "',ClosedDescription ='" & DBNull.Value & "' where IssueID ='" & CInt(lblIssueIDClosedDisplay.Text) & "'"

        Dim cmdUpdate As New SqlCommand(strSQL, dbConnection)

        Try
            Dim intRowsAffected = cmdUpdate.ExecuteNonQuery()
            If intRowsAffected = 1 Then
                MessageBox.Show("Restored")
            Else
                MessageBox.Show("The restore failed.")
            End If

        Catch ex As Exception
            MessageBox.Show("DB Restore Failed" & ex.Message)
        End Try



        Reload_lbxIssues()
        Reload_lbxEntries()


        ClearInput()
        lbxIssuesClosed.SelectedIndex = -1

    End Sub
End Class