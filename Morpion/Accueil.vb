Imports Windows.Win32.System

Public Class Accueil
    Dim Joueur, Joueur2, Fin, Gagner, Ordi As Boolean 'Création des booléens Joueur, Joueur2, Fin, Gagner afin de faire les conditions de tour et de fin de partie
    Dim compteur, OrdiGagne As Int16 'Création d'une variable compteur et OrdiGagne afin de compter les coups pour l'un et vérifier si l'ordi a gagner pour l'autre
    Dim StrJ As String 'Définition d'une variable StrJ afin de vérifier le texte de la ligne gagnante
    Dim Tresult = New Integer() {0, 0, 0, 0, 0, 0, 0, 0} 'Création d'un tableau Tresult où on stocke les chiffres permettant à l'ordi ou le joueur de gagner

    Private Sub Accueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Procédure qui charge l'Accueil
        Joueur = True 'Par défaut on a Joueur et Joueur2 qui sont vrai pour une partie joueur contre joueur
        Joueur2 = True
        compteur = 0 'Le compteur à 0 car aucun coup n'a été joué
        Fin = False 'La partie n'est pas finie
        Gagner = False 'Pas de vainqueur pour le moment
    End Sub

    Private Sub Reset()
        Joueur = True 'On laisse joueur actif
        compteur = 0
        FinTextBox.Visible = False 'La boite qui affiche le message de fin de partie est cachée
        FinTextBox.Text = "" 'Son texte est vide
        Tresult = {0, 0, 0, 0, 0, 0, 0, 0} 'On reset le tableau
        Fin = False
        Gagner = False
    End Sub
    Private Sub OrdiButton_Click(sender As Object, e As EventArgs) Handles OrdiButton.Click 'S'active lorsque l'on souhaite faire une partie contre l'ordinateur
        For Each ctrl As Control In Me.Controls 'On remet tout à 0 sauf les boutons permettant de quitter, rejouer et jouer contre l'ordinateur
            If TypeOf ctrl Is Button AndAlso ctrl.Name <> "QuitButton" AndAlso ctrl.Name <> "RejouerButton" AndAlso ctrl.Name <> "OrdiButton" Then
                CType(ctrl, Button).Enabled = True 'On active les boutons de la partie
                CType(ctrl, Button).Text = "" 'On efface leur contenu
            End If
        Next
        Joueur2 = False 'On enlève le joueur2
        Ordi = True 'On "active" l'ordinateur
        StrJ = "" 'Pas de ligne gagnante dès le début
        Reset()
    End Sub

    Private Sub RejouerButton_Click(sender As Object, e As EventArgs) Handles RejouerButton.Click 'S'active lorsque l'on décide de rejouer contre un joueur
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.Name <> "QuitButton" AndAlso ctrl.Name <> "RejouerButton" AndAlso ctrl.Name <> "OrdiButton" Then
                CType(ctrl, Button).Enabled = True
                CType(ctrl, Button).Text = ""
            End If
        Next
        Joueur2 = True
        Ordi = False
        Reset()
    End Sub

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click 'Quitte le jeu
        Application.Exit()
    End Sub

    Private Sub DesactiveButton() 'S'active lorsqu'il y a un vainqueur ou qu'il y a match nul, les boutons de jeu sont désactivés
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.Name <> "QuitButton" AndAlso ctrl.Name <> "RejouerButton" AndAlso ctrl.Name <> "OrdiButton" Then
                CType(ctrl, Button).Enabled = False
            End If
        Next
    End Sub

    Private Sub CompteCoup() 'Compte les coups
        compteur += 1
        If compteur = 9 Then 'En cas de match nul 
            Fin = True 'Partie fini
            FinTextBoxVisible() 'Affichage de la boite de message de fin
        End If
    End Sub

    Private Sub FinTextBoxVisible()
        If Fin = True Then
            FinTextBox.Visible = True
            DesactiveButton()
            If Ordi = True Then 'Dans le cas d'une partie contre l'ordinateur
                If StrJ = "O" Then 'L'ordinateur à aligné 3 rond
                    FinTextBox.Text = "Fin de partie, l'ordinateur a gagné"
                ElseIf StrJ = "X" Then 'Le joueur à aligné 3 croix
                    FinTextBox.Text = "Fin de partie, le joueur a gagné"
                Else
                    FinTextBox.Text = "Match nul"
                End If
            ElseIf Gagner = True Then 'Dans le cas du joueur contre joueur
                If Joueur Then 'La variable joueur fonctionne comme du tour par tour, quand le joueur 1 joue, joueur devient false puis j2 joue et joueur redevient true
                    FinTextBox.Text = "Fin de partie, le joueur 2 a gagné"
                Else
                    FinTextBox.Text = "Fin de partie, le joueur 1 a gagné"
                End If
            ElseIf (compteur = 9) And (Gagner = False) Then 'Match nul
                FinTextBox.Text = "Fin de la partie, match nul"
            End If
        End If
    End Sub

    Public Function TourOrdi() 'S'active quand la procédure OrdiJoue() est appelée donc c'est le tour de l'ordinateur
        For i = 0 To 7 Step 1
            If Tresult(i) = 10 Then 'On vérifie d'abord si il y a un coup vainqueur
                Return i 'On récupère la ligne ou il y a un coup à jouer et on quitte la fonction
                Exit Function
            End If
        Next
        For j = 0 To 7 Step 1
            If Tresult(j) = 6 Then 'Puis on vérifie si il y a un coup à contrer
                Return j
                Exit Function
            End If
        Next
        For k = 0 To 7 Step 1 'Ensuite on vérifie si il y a un coup qui permet d'avancer vers la victoire
            If Tresult(k) = 5 Then
                Return k
                Exit Function
            End If
        Next
        Return 99 'Enfin dans le cas ou il n'y a aucun des coups ci-dessus à jouer
    End Function

    Private Sub OrdiJoue()
        Dim placer As Integer = TourOrdi() 'On récupère la ligne ou l'ordinateur doit jouer
        Select Case placer 'On utilise un switch pour les 10 cas différents
            Case 99 'Le cas ou on place au hasard
                Dim nomBoutons As String() = {"GHButton", "MHButton", "DHButton", "GMButton", "MMButton", "DMButton", "GBButton", "MBButton", "DBButton"}
                Dim rnd As New Random() 'Ci-dessus la liste des boutons où jouer, rnd est un nombre aléatoire pour l'endroit où jouer
                Dim premiercoup = False 'Le premier coup de l'ordinateur n'as pas encore été joué.
                While premiercoup = False 'Tant qu'il n'a pas jouer mais surtout pour pas qu'il essaie de placer un coup où le joueur à jouer
                    Dim boutonAlea As Integer = rnd.Next(0, 9)
                    Dim nomtab = nomBoutons(boutonAlea) 'On récupère le nom du boutons où jouer
                    If Fin = False Then 'Au cas où on est en fin de partie et qu'il n'y a plus de case où placer
                        Select Case nomtab
                            Case "GHButton" 'Le nom du boutons
                                If GHButton.Text = "" AndAlso GHButton.Enabled = True Then 'On vérifie qu'il peut bien le placer et que c'est un bouton vierge
                                    GHButton.Text = "O" 'Place sont coup
                                    CompteCoup() 'Incrémente le compteur
                                    Tresult(0) += 5 'On rajoute les différentes dans les différentes lignes le coup où l'ordinateur à jouer
                                    Tresult(3) += 5
                                    Tresult(6) += 5
                                    GHButton.Enabled = False 'Désactive le bouton
                                    premiercoup = True 'L'ordi à jouer
                                    Exit While 'On quitte la boucle
                                End If
                            Case "MHButton"
                                If MHButton.Text = "" AndAlso MHButton.Enabled = True Then
                                    MHButton.Text = "O"
                                    CompteCoup()
                                    Tresult(1) += 5
                                    Tresult(3) += 5
                                    MHButton.Enabled = False
                                    premiercoup = True
                                    Exit While
                                End If
                            Case "DHButton"
                                If DHButton.Text = "" AndAlso DHButton.Enabled = True Then
                                    DHButton.Text = "O"
                                    CompteCoup()
                                    Tresult(2) += 5
                                    Tresult(3) += 5
                                    Tresult(7) += 5
                                    DHButton.Enabled = False
                                    premiercoup = True
                                    Exit While
                                End If
                            Case "GMButton"
                                If GMButton.Text = "" AndAlso GMButton.Enabled = True Then
                                    GMButton.Text = "O"
                                    CompteCoup()
                                    Tresult(4) += 5
                                    Tresult(0) += 5
                                    GMButton.Enabled = False
                                    premiercoup = True
                                    Exit While
                                End If
                            Case "MMButton"
                                If MMButton.Text = "" AndAlso MMButton.Enabled = True Then
                                    MMButton.Text = "O"
                                    CompteCoup()
                                    Tresult(1) += 5
                                    Tresult(4) += 5
                                    Tresult(6) += 5
                                    Tresult(7) += 5
                                    MMButton.Enabled = False
                                    premiercoup = True
                                    Exit While
                                End If
                            Case "DMButton"
                                If DMButton.Text = "" AndAlso DMButton.Enabled = True Then
                                    DMButton.Text = "O"
                                    CompteCoup()
                                    Tresult(2) += 5
                                    Tresult(4) += 5
                                    DMButton.Enabled = False
                                    premiercoup = True
                                    Exit While
                                End If
                            Case "GBButton"
                                If GBButton.Text = "" AndAlso GBButton.Enabled = True Then
                                    GBButton.Text = "O"
                                    GBButton.Enabled = False
                                    CompteCoup()
                                    Tresult(0) += 5
                                    Tresult(5) += 5
                                    Tresult(7) += 5
                                    premiercoup = True
                                    Exit While
                                End If
                            Case "MBButton"
                                If MBButton.Text = "" AndAlso MBButton.Enabled = True Then
                                    MBButton.Text = "O"
                                    MBButton.Enabled = False
                                    CompteCoup()
                                    Tresult(1) += 5
                                    Tresult(5) += 5
                                    premiercoup = True
                                    Exit While
                                End If
                            Case "DBButton"
                                If DBButton.Text = "" AndAlso DBButton.Enabled = True Then
                                    DBButton.Text = "O"
                                    DBButton.Enabled = False
                                    CompteCoup()
                                    Tresult(2) += 5
                                    Tresult(5) += 5
                                    Tresult(6) += 5
                                    premiercoup = True
                                    Exit While
                                End If
                        End Select
                    Else
                        premiercoup = True 'Au cas où l'ordi a essayer de placer le coup à un endroit où le joueur a joué on reste dans la boucle
                    End If
                End While
            Case 0 'Dans le cas de la ligne verticale à gauche
                If GHButton.Text = "" Then 'L'ordi vérifie si il peut jouer
                    GHButton.Text = "O"
                    GHButton.Enabled = False
                    Tresult(0) += 5
                    Tresult(3) += 5
                    Tresult(6) += 5
                ElseIf GMButton.Text = "" Then 'Sinon il vérifie ici
                    GMButton.Text = "O"
                    Tresult(0) += 5
                    Tresult(4) += 5
                    GMButton.Enabled = False
                ElseIf GBButton.Text = "" Then 'Et enfin ici
                    GBButton.Text = "O"
                    Tresult(0) += 5
                    Tresult(6) += 5
                    Tresult(7) += 5
                    GBButton.Enabled = False
                End If
                CompteCoup()
            Case 1
                If MHButton.Text = "" Then
                    MHButton.Text = "O"
                    MHButton.Enabled = False
                    Tresult(1) += 5
                    Tresult(3) += 5
                ElseIf MMButton.Text = "" Then
                    MMButton.Text = "O"
                    Tresult(1) += 5
                    Tresult(4) += 5
                    Tresult(6) += 5
                    Tresult(7) += 5
                    MMButton.Enabled = False
                ElseIf MBButton.Text = "" Then
                    MBButton.Text = "O"
                    MBButton.Enabled = False
                    Tresult(1) += 5
                    Tresult(5) += 5
                End If
                CompteCoup()
            Case 2
                If DHButton.Text = "" Then
                    DHButton.Text = "O"
                    Tresult(2) += 5
                    Tresult(3) += 5
                    Tresult(7) += 5
                    DHButton.Enabled = False
                ElseIf DMButton.Text = "" Then
                    DMButton.Text = "O"
                    Tresult(2) += 5
                    Tresult(4) += 5
                    DMButton.Enabled = False
                ElseIf DBButton.Text = "" Then
                    DBButton.Text = "O"
                    Tresult(2) += 5
                    Tresult(5) += 5
                    Tresult(6) += 5
                    DBButton.Enabled = False
                End If
                CompteCoup()
            Case 3
                If GHButton.Text = "" Then
                    GHButton.Text = "O"
                    Tresult(3) += 5
                    Tresult(2) += 5
                    Tresult(7) += 5
                    GHButton.Enabled = False
                ElseIf MHButton.Text = "" Then
                    MHButton.Text = "O"
                    Tresult(3) += 5
                    Tresult(1) += 5
                    MHButton.Enabled = False
                ElseIf DHButton.Text = "" Then
                    DHButton.Text = "O"
                    Tresult(3) += 5
                    Tresult(0) += 5
                    DHButton.Enabled = False
                End If
                CompteCoup()
            Case 4
                If GMButton.Text = "" Then
                    GMButton.Text = "O"
                    Tresult(4) += 5
                    Tresult(0) += 5
                    GMButton.Enabled = False
                ElseIf MMButton.Text = "" Then
                    MMButton.Text = "O"
                    Tresult(4) += 5
                    Tresult(1) += 5
                    Tresult(6) += 5
                    Tresult(7) += 5
                    MMButton.Enabled = False
                ElseIf DMButton.Text = "" Then
                    DMButton.Text = "O"
                    Tresult(4) += 5
                    Tresult(2) += 5
                    DMButton.Enabled = False
                End If
                CompteCoup()
            Case 5
                If GBButton.Text = "" Then
                    GBButton.Text = "O"
                    Tresult(5) += 5
                    Tresult(0) += 5
                    Tresult(7) += 5
                    GBButton.Enabled = False
                ElseIf MBButton.Text = "" Then
                    MBButton.Text = "O"
                    Tresult(5) += 5
                    Tresult(1) += 5
                    MBButton.Enabled = False
                ElseIf DBButton.Text = "" Then
                    DBButton.Text = "O"
                    Tresult(5) += 5
                    Tresult(2) += 5
                    Tresult(6) += 5
                    DBButton.Enabled = False
                End If
                CompteCoup()
            Case 6
                If GHButton.Text = "" Then
                    GHButton.Text = "O"
                    Tresult(6) += 5
                    Tresult(0) += 5
                    Tresult(3) += 5
                    GHButton.Enabled = False
                ElseIf MMButton.Text = "" Then
                    MMButton.Text = "O"
                    Tresult(6) += 5
                    Tresult(1) += 5
                    Tresult(4) += 5
                    Tresult(7) += 5
                    MMButton.Enabled = False
                ElseIf DBButton.Text = "" Then
                    DBButton.Text = "O"
                    Tresult(6) += 5
                    Tresult(2) += 5
                    Tresult(5) += 5
                    DBButton.Enabled = False
                End If
                CompteCoup()
            Case 7
                If GBButton.Text = "" Then
                    GBButton.Text = "O"
                    Tresult(7) += 5
                    Tresult(0) += 5
                    Tresult(5) += 5
                    GBButton.Enabled = False
                ElseIf MMButton.Text = "" Then
                    MMButton.Text = "O"
                    Tresult(7) += 5
                    Tresult(1) += 5
                    Tresult(4) += 5
                    Tresult(6) += 5
                    MMButton.Enabled = False
                ElseIf DHButton.Text = "" Then
                    DHButton.Text = "O"
                    Tresult(7) += 5
                    Tresult(2) += 5
                    Tresult(3) += 5
                    DHButton.Enabled = False
                End If
                CompteCoup()
        End Select
        For OrdiGagne = 0 To 7 Step 1 'On vérifie le tableau pour voir si l'ordi a gagné
            If Tresult(OrdiGagne) = 15 Then
                Fin = True 'La partie est finie
                Gagner = True 'Il y a un vainqueur
                StrJ = "O" 'Le symbole du vainqueur
                FinTextBoxVisible() 'Affichage du message de fin
            End If
        Next
    End Sub

    Private Sub GHButton_Click(sender As Object, e As EventArgs) Handles GHButton.Click 'S'active lorsqu'un joueur clic sur la case en haut à gauche
        If Joueur Then 'Si c'est au tour du joueur 1
            If Ordi Then 'S'il est contre l'ordinateur
                Tresult(0) += 3
                Tresult(3) += 3
                Tresult(6) += 3
                GHButton.Text = "X"
                If GHButton.Text = MHButton.Text And GHButton.Text = DHButton.Text _ 'On vérifie les conditions de victoire du joueur
                    Or GHButton.Text = MMButton.Text And GHButton.Text = DBButton.Text _
                    Or GHButton.Text = GMButton.Text And GHButton.Text = GBButton.Text Then
                    Fin = True
                    Gagner = True
                    StrJ = "X"
                    FinTextBoxVisible()
                    Exit Sub
                End If
                If Fin = False Then 'Sinon on incrémente le compteur et c'est au tour de l'ordi
                    CompteCoup()
                    OrdiJoue()
                End If
            End If
            GHButton.Text = "X" 'Le joueur 1 place son symbole
            If Joueur2 Then 'Au prochain tour c'est au joueur 2
                Joueur = False
                CompteCoup()
            End If
        Else
            GHButton.Text = "O" 'Dans le cas du tour du joueur 2
            Joueur = True 'Au prochain tour c'est au joueur 1
        End If
        If GHButton.Text = MHButton.Text And GHButton.Text = DHButton.Text _
            Or GHButton.Text = MMButton.Text And GHButton.Text = DBButton.Text _
            Or GHButton.Text = GMButton.Text And GHButton.Text = GBButton.Text Then
            Fin = True
            Gagner = True
            StrJ = "X"
            FinTextBoxVisible()
            Exit Sub
        End If
        GHButton.Enabled = False
    End Sub

    Private Sub MHButton_Click(sender As Object, e As EventArgs) Handles MHButton.Click
        If Joueur Then
            If Ordi Then
                Tresult(1) += 3
                Tresult(3) += 3
                MHButton.Text = "X"
                If MHButton.Text = GHButton.Text And MHButton.Text = DHButton.Text _
                    Or MHButton.Text = MMButton.Text And MHButton.Text = MBButton.Text Then
                    Fin = True
                    Gagner = True
                    StrJ = "X"
                    FinTextBoxVisible()
                End If
                If Fin = False Then
                    CompteCoup()
                    OrdiJoue()
                End If
            End If
            MHButton.Text = "X"
            If Joueur2 Then
                Joueur = False
                CompteCoup()
            End If
        Else
            MHButton.Text = "O"
            Joueur = True
        End If
        If MHButton.Text = GHButton.Text And MHButton.Text = DHButton.Text _
            Or MHButton.Text = MMButton.Text And MHButton.Text = MBButton.Text Then
            Fin = True
            Gagner = True
            StrJ = "X"
            FinTextBoxVisible()
        End If
        MHButton.Enabled = False
    End Sub

    Private Sub DHButton_Click(sender As Object, e As EventArgs) Handles DHButton.Click
        If Joueur Then
            If Ordi Then
                Tresult(3) += 3
                Tresult(7) += 3
                Tresult(2) += 3
                DHButton.Text = "X"
                If DHButton.Text = MHButton.Text And DHButton.Text = GHButton.Text _
                    Or DHButton.Text = MMButton.Text And DHButton.Text = GBButton.Text _
                    Or DHButton.Text = DMButton.Text And DHButton.Text = DBButton.Text Then
                    Fin = True
                    Gagner = True
                    StrJ = "X"
                    FinTextBoxVisible()
                    Exit Sub
                End If
                If Fin = False Then
                    CompteCoup()
                    OrdiJoue()
                End If
            End If
            DHButton.Text = "X"
            If Joueur2 Then
                Joueur = False
                CompteCoup()
            End If
        Else
            DHButton.Text = "O"
            Joueur = True
        End If
        If DHButton.Text = MHButton.Text And DHButton.Text = GHButton.Text _
            Or DHButton.Text = MMButton.Text And DHButton.Text = GBButton.Text _
            Or DHButton.Text = DMButton.Text And DHButton.Text = DBButton.Text Then
            Fin = True
            Gagner = True
            StrJ = "X"
            FinTextBoxVisible()
        End If
        DHButton.Enabled = False
    End Sub

    Private Sub GMButton_Click(sender As Object, e As EventArgs) Handles GMButton.Click
        If Joueur Then
            If Ordi Then
                Tresult(0) += 3
                Tresult(4) += 3
                GMButton.Text = "X"
                If GMButton.Text = MMButton.Text And GMButton.Text = DMButton.Text _
                    Or GMButton.Text = GHButton.Text And GMButton.Text = GBButton.Text Then
                    Fin = True
                    Gagner = True
                    StrJ = "X"
                    FinTextBoxVisible()
                    Exit Sub
                End If
                If Fin = False Then
                    CompteCoup()
                    OrdiJoue()
                End If
            End If
            GMButton.Text = "X"
            If Joueur2 Then
                Joueur = False
                CompteCoup()
            End If
        Else
            GMButton.Text = "O"
            Joueur = True
        End If
        If GMButton.Text = MMButton.Text And GMButton.Text = DMButton.Text _
            Or GMButton.Text = GHButton.Text And GMButton.Text = GBButton.Text Then
            Fin = True
            Gagner = True
            StrJ = "X"
            FinTextBoxVisible()
        End If
        GMButton.Enabled = False
    End Sub

    Private Sub MMButton_Click(sender As Object, e As EventArgs) Handles MMButton.Click
        If Joueur Then
            If Ordi Then
                Tresult(1) += 3
                Tresult(4) += 3
                Tresult(6) += 3
                Tresult(7) += 3
                MMButton.Text = "X"
                If MMButton.Text = GMButton.Text And MMButton.Text = DMButton.Text _
                    Or MMButton.Text = MHButton.Text And MMButton.Text = MBButton.Text _
                    Or MMButton.Text = GHButton.Text And MMButton.Text = DBButton.Text _
                    Or MMButton.Text = GBButton.Text And MMButton.Text = DHButton.Text Then
                    Fin = True
                    Gagner = True
                    StrJ = "X"
                    FinTextBoxVisible()
                    Exit Sub
                End If
                If Fin = False Then
                    CompteCoup()
                    OrdiJoue()
                End If
            End If
            MMButton.Text = "X"
            If Joueur2 Then
                Joueur = False
                CompteCoup()
            End If
        Else
            MMButton.Text = "O"
            Joueur = True
        End If
        If MMButton.Text = GMButton.Text And MMButton.Text = DMButton.Text _
            Or MMButton.Text = MHButton.Text And MMButton.Text = MBButton.Text _
            Or MMButton.Text = GHButton.Text And MMButton.Text = DBButton.Text _
            Or MMButton.Text = GBButton.Text And MMButton.Text = DHButton.Text Then
            Fin = True
            Gagner = True
            StrJ = "X"
            FinTextBoxVisible()
        End If
        MMButton.Enabled = False
    End Sub

    Private Sub DMButton_Click(sender As Object, e As EventArgs) Handles DMButton.Click
        If Joueur Then
            If Ordi Then
                Tresult(2) += 3
                Tresult(4) += 3
                DMButton.Text = "X"
                If DMButton.Text = MMButton.Text And DMButton.Text = GMButton.Text _
                    Or DMButton.Text = DHButton.Text And DMButton.Text = DBButton.Text Then
                    Fin = True
                    Gagner = True
                    StrJ = "X"
                    FinTextBoxVisible()
                End If
                If Fin = False Then
                    CompteCoup()
                    OrdiJoue()
                End If
            End If
            DMButton.Text = "X"
            If Joueur2 Then
                Joueur = False
                CompteCoup()
            End If
        Else
            DMButton.Text = "O"
            Joueur = True
        End If
        If DMButton.Text = MMButton.Text And DMButton.Text = GMButton.Text _
            Or DMButton.Text = DHButton.Text And DMButton.Text = DBButton.Text Then
            Fin = True
            Gagner = True
            StrJ = "X"
            FinTextBoxVisible()
        End If
        DMButton.Enabled = False
    End Sub

    Private Sub GBButton_Click(sender As Object, e As EventArgs) Handles GBButton.Click
        If Joueur Then
            If Ordi Then
                Tresult(0) += 3
                Tresult(7) += 3
                Tresult(5) += 3
                GBButton.Text = "X"
                If GBButton.Text = MBButton.Text And GBButton.Text = DBButton.Text _
                    Or GBButton.Text = GMButton.Text And GBButton.Text = GHButton.Text _
                    Or GBButton.Text = MMButton.Text And GBButton.Text = DHButton.Text Then
                    Fin = True
                    Gagner = True
                    StrJ = "X"
                    FinTextBoxVisible()
                    Exit Sub
                End If
                If Fin = False Then
                    CompteCoup()
                    OrdiJoue()
                End If
            End If
            GBButton.Text = "X"
            If Joueur2 Then
                Joueur = False
                CompteCoup()
            End If
        Else
            GBButton.Text = "O"
            Joueur = True
        End If
        If GBButton.Text = MBButton.Text And GBButton.Text = DBButton.Text _
            Or GBButton.Text = GMButton.Text And GBButton.Text = GHButton.Text _
            Or GBButton.Text = MMButton.Text And GBButton.Text = DHButton.Text Then
            Fin = True
            Gagner = True
            StrJ = "X"
            FinTextBoxVisible()
        End If
        GBButton.Enabled = False
    End Sub

    Private Sub MBButton_Click(sender As Object, e As EventArgs) Handles MBButton.Click
        If Joueur Then
            If Ordi Then
                Tresult(1) += 3
                Tresult(5) += 3
                MBButton.Text = "X"
                If MBButton.Text = DBButton.Text And MBButton.Text = GBButton.Text _
                    Or MBButton.Text = MMButton.Text And MBButton.Text = MHButton.Text Then
                    Fin = True
                    Gagner = True
                    FinTextBoxVisible()
                    Exit Sub
                End If
                If Fin = False Then
                    CompteCoup()
                    OrdiJoue()
                End If
            End If
            MBButton.Text = "X"
            If Joueur2 Then
                Joueur = False
                CompteCoup()
            End If
        Else
            MBButton.Text = "O"
            Joueur = True
        End If
        If MBButton.Text = DBButton.Text And MBButton.Text = GBButton.Text _
            Or MBButton.Text = MMButton.Text And MBButton.Text = MHButton.Text Then
            Fin = True
            Gagner = True
            FinTextBoxVisible()
        End If
        MBButton.Enabled = False
    End Sub

    Private Sub DBButton_Click(sender As Object, e As EventArgs) Handles DBButton.Click
        If Joueur Then
            If Ordi Then
                Tresult(2) += 3
                Tresult(5) += 3
                Tresult(6) += 3
                DBButton.Text = "X"
                If DBButton.Text = MMButton.Text And DBButton.Text = GHButton.Text _
                   Or DBButton.Text = DMButton.Text And DBButton.Text = DHButton.Text _
                    Or DBButton.Text = MBButton.Text And DBButton.Text = GBButton.Text Then
                    Fin = True
                    Gagner = True
                    FinTextBoxVisible()
                    Exit Sub
                End If
                If Fin = False Then
                    CompteCoup()
                    OrdiJoue()
                End If
            End If
            DBButton.Text = "X"
            If Joueur2 Then
                Joueur = False
                CompteCoup()
            End If
        Else
            DBButton.Text = "O"
            Joueur = True
        End If
        If DBButton.Text = MMButton.Text And DBButton.Text = GHButton.Text _
            Or DBButton.Text = DMButton.Text And DBButton.Text = DHButton.Text _
            Or DBButton.Text = MBButton.Text And DBButton.Text = GBButton.Text Then
            Fin = True
            Gagner = True
            FinTextBoxVisible()
        End If
        DBButton.Enabled = False
    End Sub

End Class