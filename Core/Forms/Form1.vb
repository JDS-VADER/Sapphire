'You must add a reference to (System.Windows.Forms) and (System.Drawing). Do that by clicking (Project) on the VB menu
'And selecting (Add Reference...). On the Add reference window select the (.Net) tab and selelect these from the list.

Imports System.Windows.Forms
Imports System.Drawing

Namespace Core.Forms
    Public Class Form1
        Inherits Form

        'the custom event use to send the name and password back to the caller form.
        'you can declare them to be whatever type of data you want. They don`t have to be strings
        Public Event LoginInfo(ByVal uName As String, ByVal uPassword As String)

        Friend WithEvents Button1 As Button
        Friend WithEvents TextBox2 As TextBox
        Friend WithEvents TextBox1 As TextBox

        'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
        Public Sub New(ByVal info1 As String) 'i only used on parameter as a string for this example
            InitializeComponent()
            Text = info1
        End Sub

        Private Sub InitializeComponent()
            TextBox1 = New TextBox
            TextBox2 = New TextBox
            Button1 = New Button
            SuspendLayout()
            '
            'TextBox1
            '
            TextBox1.Location = New Point(25, 24)
            TextBox1.Name = "TextBox1"
            TextBox1.Size = New Size(240, 20)
            TextBox1.TabIndex = 0
            '
            'TextBox2
            '
            TextBox2.Location = New Point(25, 59)
            TextBox2.Name = "TextBox2"
            TextBox2.Size = New Size(240, 20)
            TextBox2.TabIndex = 1
            '
            'Button1
            '
            Button1.Location = New Point(107, 104)
            Button1.Name = "Button1"
            Button1.Size = New Size(75, 23)
            Button1.TabIndex = 2
            Button1.Text = "Button1"
            Button1.UseVisualStyleBackColor = True
            '
            'Class1
            '
            ClientSize = New Size(292, 157)
            Controls.Add(Button1)
            Controls.Add(TextBox2)
            Controls.Add(TextBox1)
            Name = "Form1"
            ResumeLayout(False)
            PerformLayout()

        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            If TextBox1.Text.Trim <> "" And TextBox2.Text.Trim <> "" Then
                'do you code to check if the name and password are correct.
                ' then raise the custom LoginInfo event to send the info to the caller form
                RaiseEvent LoginInfo(TextBox1.Text, TextBox2.Text)
            End If
        End Sub
    End Class
End Namespace
