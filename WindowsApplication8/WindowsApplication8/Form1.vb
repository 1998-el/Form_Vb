Imports System.Text.RegularExpressions

Public Class Form1

    ' Classe du formulaire
    Public Class FormRegister
        Public Property Nom As String
        Public Property Prenom As String
        Public Property Email As String
        Public Property SexeHomme As Boolean
        Public Property SexeFemme As Boolean
        Public Property Specialite As Integer
        Public Property Adresse As String
    End Class

    ' Tableau pour stocker les formulaires d'inscription
    Private formulaires() As FormRegister
    Dim DataGridView1 As Object

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Créez une instance de la classe FormRegister
        Dim formContent As New FormRegister()

        ' Affectez les valeurs des différents champs et boutons radio aux propriétés de l'instance
        formContent.Nom = TextBox1.Text
        formContent.Prenom = TextBox2.Text
        formContent.Email = TextBox3.Text
        formContent.Adresse = TextBox4.Text
        formContent.SexeHomme = RadioButton1.Checked
        formContent.SexeFemme = RadioButton2.Checked
        formContent.Specialite = ComboBox1.SelectedIndex

        ' expressions reguliere pour validate l'email
        Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"

        'full name
        If String.IsNullOrEmpty(formContent.Nom) Or String.IsNullOrEmpty(formContent.Prenom) Then
            Label6.Text = "Veillez renseigner votre nom et prenom !"
            Label6.ForeColor = Color.OrangeRed
        ElseIf IsNumeric(formContent.Nom) Or IsNumeric(formContent.Prenom) Then
            Label6.Text = "seule des lettres sont autorise"
            Label6.ForeColor = Color.OrangeRed
        Else
            Label6.Text = "Good!!"
            Label6.ForeColor = Color.Green
        End If

        'input field email
        If String.IsNullOrEmpty(formContent.Email) Then
            Label7.Text = "Veillez renseigner votre email!"
            Label7.ForeColor = Color.OrangeRed
        ElseIf Regex.IsMatch(formContent.Email, pattern) Then
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
        If String.IsNullOrEmpty(formContent.Adresse) Then
            Label10.Text = "Veillez remplir une adresse!"
            Label10.ForeColor = Color.OrangeRed
        ElseIf IsNumeric(formContent.Adresse) Then
            Label10.Text = "seul les lettres sont autorise!"
            Label10.ForeColor = Color.OrangeRed
        Else
            Label10.Text = "Good!!"
            Label10.ForeColor = Color.Green
        End If

    ' Ajoutez l'instance du formulaire au tableau
        If formulaires Is Nothing Then
            ReDim formulaires(0)
        Else
            ReDim Preserve formulaires(formulaires.Length)
        End If
        formulaires(formulaires.Length - 1) = formContent

        ' Ouvrez le Form2 et passez les données

    
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Effacez les valeurs des différents champs
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()

        ' Réinitialisez les boutons radio
        RadioButton1.Checked = False
        RadioButton2.Checked = False

        ' Réinitialisez la sélection de la ComboBox
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim form2 As New Form2(formulaires)
        form2.DataGridView1.DataSource = formulaires
        form2.Show()
    End Sub
End Class
