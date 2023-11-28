Public Class Form2
    Private formulaires() As Form1.FormRegister

    Public Sub New(formulaires() As Form1.FormRegister)
        InitializeComponent()
        Me.formulaires = formulaires
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurez le DataGridView pour afficher les données
        DataGridView1.AutoGenerateColumns = True ' Génère automatiquement les colonnes à partir des propriétés de la classe FormRegister
        ' Configurez le DataGridView pour afficher les données
        DataGridView1.AutoGenerateColumns = True ' Génère automatiquement les colonnes à partir des propriétés de la classe FormRegister
        DataGridView1.DataSource = formulaires ' Définissez le tableau comme source de données du DataGridView
    End Sub
End Class
