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

        ' Ajoutez l'instance du formulaire au tableau
        If formulaires Is Nothing Then
            ReDim formulaires(0)
        Else
            ReDim Preserve formulaires(formulaires.Length)
        End If
        formulaires(formulaires.Length - 1) = formContent

        ' Ouvrez le Form2 et passez les données
        Dim form2 As New Form2(formulaires)
        form2.Show()
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
        ' Configurez le DataGridView pour afficher les données
        DataGridView1.AutoGenerateColumns = True ' Génère automatiquement les colonnes à partir des propriétés de la classe FormRegister
    End Sub
End Class
