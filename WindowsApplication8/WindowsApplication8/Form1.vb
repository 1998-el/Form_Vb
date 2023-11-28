Imports System.Text.RegularExpressions

Public Class Form1

    ' class du formulaire 
    Public Class FormRegister
        Public Property nom As String
        Public Property prenom As String
        Public Property email As String
        Public Property sexe_homme As String
        Public Property sexe_femme As String
        Public Property specialite As String
        Public Property adresse As String
    End Class

    Class FormVAlidate

    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formContent As New FormRegister()
        'affectation  des valeur des differents champ et radioButton aux variables
        formContent.nom = TextBox1.Text
        formContent.prenom = TextBox2.Text
        formContent.email = TextBox3.Text
        formContent.adresse = TextBox4.Text
        formContent.sexe_homme = RadioButton1.Checked
        formContent.sexe_femme = RadioButton2.Checked
        formContent.specialite = ComboBox1.SelectedIndex

        ' expressions reguliere pour validate l'email
        Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"

        'full name
        If String.IsNullOrEmpty(formContent.nom) Or String.IsNullOrEmpty(formContent.prenom) Then
            Label6.Text = "Veillez renseigner votre nom et prenom !"
            Label6.ForeColor = Color.OrangeRed
        ElseIf IsNumeric(formContent.nom) Or IsNumeric(formContent.prenom) Then
            Label6.Text = "seule des lettres sont autorise"
            Label6.ForeColor = Color.OrangeRed
        Else
            Label6.Text = "Good!!"
            Label6.ForeColor = Color.Green
        End If

        'input field email
        If String.IsNullOrEmpty(formContent.email) Then
            Label7.Text = "Veillez renseigner votre email!"
            Label7.ForeColor = Color.OrangeRed
        ElseIf Regex.IsMatch(formContent.email, pattern) Then
            Label7.Text = "Good!!"
            Label7.ForeColor = Color.Green
        Else
            Label7.Text = "Rassurez-vous que l'email respecte ce format 'exemple9@XXX.com'"
            Label7.ForeColor = Color.OrangeRed
        End If

        'input fiel speciality
        If ComboBox1.SelectedIndex <> -1 Then
            Label9.Text = "Good!!"
            Label9.ForeColor = Color.Green
        Else
            Label9.Text = "Veillez selectionner votre specialite!"
            Label9.ForeColor = Color.OrangeRed
        End If

        'Genre
        If RadioButton1.Checked Or RadioButton2.Checked Then
            Label8.Text = "Good!!"
            Label8.ForeColor = Color.Green
        Else
            Label8.Text = "Veillez cocher votre Genre!"
            Label8.ForeColor = Color.OrangeRed
        End If

        'address
        If String.IsNullOrEmpty(formContent.adresse) Then
            Label10.Text = "Veillez remplir une adresse!"
            Label10.ForeColor = Color.OrangeRed
        ElseIf IsNumeric(formContent.adresse) Then
            Label10.Text = "seul les lettres sont autorise!"
            Label10.ForeColor = Color.OrangeRed
        Else
            Label10.Text = "Good!!"
            Label10.ForeColor = Color.Green
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
