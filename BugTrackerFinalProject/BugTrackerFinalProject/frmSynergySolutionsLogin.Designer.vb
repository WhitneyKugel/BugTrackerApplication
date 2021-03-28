<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynergySolutionsLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSynergySolutionsLogin))
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblDectect = New System.Windows.Forms.Label()
        Me.lblDocument = New System.Windows.Forms.Label()
        Me.lblDebug = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblLoginErrorDisplay = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblCompanyName
        '
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.BackColor = System.Drawing.Color.Transparent
        Me.lblCompanyName.Font = New System.Drawing.Font("Cambria", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblCompanyName.Location = New System.Drawing.Point(24, 17)
        Me.lblCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(642, 86)
        Me.lblCompanyName.TabIndex = 0
        Me.lblCompanyName.Text = "Synergy Solutions"
        '
        'lblDectect
        '
        Me.lblDectect.AutoSize = True
        Me.lblDectect.BackColor = System.Drawing.Color.Transparent
        Me.lblDectect.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDectect.ForeColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblDectect.Location = New System.Drawing.Point(96, 100)
        Me.lblDectect.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDectect.Name = "lblDectect"
        Me.lblDectect.Size = New System.Drawing.Size(120, 37)
        Me.lblDectect.TabIndex = 1
        Me.lblDectect.Text = "Dectect"
        '
        'lblDocument
        '
        Me.lblDocument.AutoSize = True
        Me.lblDocument.BackColor = System.Drawing.Color.Transparent
        Me.lblDocument.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocument.ForeColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblDocument.Location = New System.Drawing.Point(136, 137)
        Me.lblDocument.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDocument.Name = "lblDocument"
        Me.lblDocument.Size = New System.Drawing.Size(159, 37)
        Me.lblDocument.TabIndex = 2
        Me.lblDocument.Text = "Document"
        '
        'lblDebug
        '
        Me.lblDebug.AutoSize = True
        Me.lblDebug.BackColor = System.Drawing.Color.Transparent
        Me.lblDebug.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebug.ForeColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblDebug.Location = New System.Drawing.Point(182, 173)
        Me.lblDebug.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.Size = New System.Drawing.Size(106, 37)
        Me.lblDebug.TabIndex = 3
        Me.lblDebug.Text = "Debug"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.BackColor = System.Drawing.Color.Transparent
        Me.lblEmail.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblEmail.Location = New System.Drawing.Point(252, 319)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(216, 49)
        Me.lblEmail.TabIndex = 4
        Me.lblEmail.Text = "Username"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblPassword.Location = New System.Drawing.Point(254, 404)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(207, 49)
        Me.lblPassword.TabIndex = 5
        Me.lblPassword.Text = "Password"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(504, 329)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(308, 31)
        Me.txtEmail.TabIndex = 6
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(504, 404)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPassword.Size = New System.Drawing.Size(308, 31)
        Me.txtPassword.TabIndex = 7
        '
        'btnLogin
        '
        Me.btnLogin.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(504, 494)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(134, 44)
        Me.btnLogin.TabIndex = 8
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(682, 494)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(134, 44)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblLoginErrorDisplay
        '
        Me.lblLoginErrorDisplay.AutoSize = True
        Me.lblLoginErrorDisplay.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginErrorDisplay.ForeColor = System.Drawing.Color.Red
        Me.lblLoginErrorDisplay.Location = New System.Drawing.Point(376, 562)
        Me.lblLoginErrorDisplay.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblLoginErrorDisplay.Name = "lblLoginErrorDisplay"
        Me.lblLoginErrorDisplay.Size = New System.Drawing.Size(561, 36)
        Me.lblLoginErrorDisplay.TabIndex = 10
        Me.lblLoginErrorDisplay.Text = "Username and/or Password are invalid."
        Me.lblLoginErrorDisplay.Visible = False
        '
        'frmSynergySolutionsLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BugTrackerFinalProject.My.Resources.Resources.SynergyBackground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1168, 752)
        Me.Controls.Add(Me.lblLoginErrorDisplay)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblDebug)
        Me.Controls.Add(Me.lblDocument)
        Me.Controls.Add(Me.lblDectect)
        Me.Controls.Add(Me.lblCompanyName)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "frmSynergySolutionsLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Synergy Solutions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCompanyName As Label
    Friend WithEvents lblDectect As Label
    Friend WithEvents lblDocument As Label
    Friend WithEvents lblDebug As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lblLoginErrorDisplay As Label
End Class
