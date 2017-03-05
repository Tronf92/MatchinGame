Public Class MatchingGame

    Private random As New Random


    Private icons =
        New List(Of String) From {"!", "!", "C", "C", "{", "{", ":", ":", "R", "R", "O", "O", "A", "A", "@", "@"}

    Private Sub AssignIconsToSquare()
        For Each control In TableLayoutPanel1.Controls
            Dim iconLabel = TryCast(control, Label)
            iconLabel.ForeColor = iconLabel.BackColor
            If iconLabel IsNot Nothing Then
                Dim randomNumber = random.Next(icons.Count)
                iconLabel.Text = icons(randomNumber)
                icons.removeAt(randomNumber)
            End If
        Next
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AssignIconsToSquare()

    End Sub


    Private Sub Label_Click(sender As Object, e As EventArgs) Handles Label9.Click, Label8.Click, Label7.Click, Label6.Click, Label5.Click, Label4.Click, Label3.Click, Label2.Click, Label16.Click, Label15.Click, Label14.Click, Label13.Click, Label12.Click, Label11.Click, Label10.Click, Label1.Click
        If Timer1.Enabled Then Exit Sub
        Dim clickedLabel = TryCast(sender, Label)

        If clickedLabel IsNot Nothing Then

            ' If the clicked label is black, the player clicked  
            ' an icon that's already been revealed --  
            ' ignore the click 
            If clickedLabel.ForeColor = Color.Black Then Exit Sub

            ' If firstClicked is Nothing, this is the first icon  
            ' in the pair that the player clicked,  
            ' so set firstClicked to the label that the player 
            ' clicked, change its color to black, and return 
            If firstClicked Is Nothing Then
                firstClicked = clickedLabel
                firstClicked.ForeColor = Color.Black
                Exit Sub
            End If
            secondClicked = clickedLabel
            secondClicked.ForeColor = Color.Black
            CheckForWinner()
            If (firstClicked.Text = secondClicked.Text) Then
                firstClicked = Nothing
                secondClicked = Nothing
                Exit Sub
            End If
            Timer1.Start()
        End If
    End Sub

    Private firstClicked As Label = Nothing
    Private secondClicked As Label = Nothing

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        firstClicked.ForeColor = firstClicked.BackColor
        secondClicked.ForeColor = secondClicked.BackColor
        firstClicked = Nothing
        secondClicked = Nothing

    End Sub

    Private Sub CheckForWinner()
        For Each Control In TableLayoutPanel1.Controls
            Dim iconLabel = TryCast(Control, Label)
            If iconLabel IsNot Nothing AndAlso
                iconLabel.ForeColor = iconLabel.BackColor Then Exit Sub
        Next
        MessageBox.Show("You matched all the icons!", "Congrats")



    End Sub

    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
        AssignIconsToSquare2()
    End Sub

    Private second As New Random
    Private iconz =
        New List(Of String) From {"C", "C", "!", "!", "A", "A", "W", "W", "N", "N", "U", "U", "G", "G", "*", "*"}

    Private Sub AssignIconsToSquare2()
        For Each Control In TableLayoutPanel1.Controls
            Dim iconLabel = TryCast(Control, Label)
            iconLabel.ForeColor = iconLabel.BackColor
            If iconLabel IsNot Nothing Then
                Dim randomNumber = random.Next(iconz.Count)
                iconLabel.Text = iconz(randomNumber)
                iconz.removeAt(randomNumber)
            End If
        Next
    End Sub
    Public Sub NewGame()
        InitializeComponent()
        AssignIconsToSquare2()
        
    End Sub
End Class
