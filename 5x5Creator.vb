Public Class PuzzleCreator
    Dim Preview As New Bitmap(10, 10)
    Dim Xvalue As Integer
    Dim Yvalue As Integer
    Private Sub Box_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click
        Select Case sender.Name
            Case "Button1", "Button2", "Button3", "Button4", "Button5"
                Yvalue = 0
            Case "Button6", "Button7", "Button8", "Button9", "Button10"
                Yvalue = 2
            Case "Button11", "Button12", "Button13", "Button14", "Button15"
                Yvalue = 4
            Case "Button16", "Button17", "Button18", "Button19", "Button20"
                Yvalue = 6
            Case "Button21", "Button22", "Button23", "Button24", "Button25"
                Yvalue = 8
        End Select
        Select Case sender.Name
            Case "Button1", "Button6", "Button11", "Button16", "Button21"
                Xvalue = 0
            Case "Button2", "Button7", "Button12", "Button17", "Button22"
                Xvalue = 2
            Case "Button3", "Button8", "Button13", "Button18", "Button23"
                Xvalue = 4
            Case "Button4", "Button9", "Button14", "Button19", "Button24"
                Xvalue = 6
            Case "Button5", "Button10", "Button15", "Button20", "Button25"
                Xvalue = 8
        End Select
        If sender.BackColor.ToKnownColor = KnownColor.Black Then
            sender.BackColor = Color.White
            sender.Tag = "."
            Preview.SetPixel(Xvalue, Yvalue, Color.White)
            Preview.SetPixel(Xvalue, Yvalue + 1, Color.White)
            Preview.SetPixel(Xvalue + 1, Yvalue, Color.White)
            Preview.SetPixel(Xvalue + 1, Yvalue + 1, Color.White)
        Else
            sender.BackColor = Color.Black
            sender.Tag = "O"
            Preview.SetPixel(Xvalue, Yvalue, Color.Black)
            Preview.SetPixel(Xvalue, Yvalue + 1, Color.Black)
            Preview.SetPixel(Xvalue + 1, Yvalue, Color.Black)
            Preview.SetPixel(Xvalue + 1, Yvalue + 1, Color.Black)
        End If
        PictureBox1.Image = Preview
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles ParseButton.Click
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName <> "" Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(SaveFileDialog1.FileName & ".lua", False)
            file.WriteLine("leveldata.gridsize = 5")
            file.WriteLine("leveldata.gamemode = """ & GMText.Text & """")
            file.WriteLine("leveldata.number = """ & NumberText.Text & """")
            file.WriteLine("leveldata.letter = """ & LetterText.Text & """")
            file.WriteLine("")
            file.WriteLine("irow1 = {""" & Button1.Tag & """, """ & Button2.Tag & """, """ & Button3.Tag & """, """ & Button4.Tag & """, """ & Button5.Tag & """}")
            file.WriteLine("irow2 = {""" & Button6.Tag & """, """ & Button7.Tag & """, """ & Button8.Tag & """, """ & Button9.Tag & """, """ & Button10.Tag & """}")
            file.WriteLine("irow3 = {""" & Button11.Tag & """, """ & Button12.Tag & """, """ & Button13.Tag & """, """ & Button14.Tag & """, """ & Button15.Tag & """}")
            file.WriteLine("irow4 = {""" & Button16.Tag & """, """ & Button17.Tag & """, """ & Button18.Tag & """, """ & Button19.Tag & """, """ & Button20.Tag & """}")
            file.WriteLine("irow5 = {""" & Button21.Tag & """, """ & Button22.Tag & """, """ & Button23.Tag & """, """ & Button24.Tag & """, """ & Button25.Tag & """}")
            file.Close()
            Preview.Save(SaveFileDialog1.FileName & ".png", Imaging.ImageFormat.Png)
            MsgBox("Level successfully saved!")
        Else
            MsgBox("Level not saved!")
        End If
    End Sub

    Private Sub PuzzleCreator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Xvalue = 0 To 9
            For Yvalue = 0 To 9
                Preview.SetPixel(Xvalue, Yvalue, Color.White)
                Preview.SetPixel(Xvalue + 1, Yvalue, Color.White)
                Preview.SetPixel(Xvalue, Yvalue + 1, Color.White)
                Preview.SetPixel(Xvalue + 1, Yvalue + 1, Color.White)
                Yvalue = Yvalue + 1
            Next
            Xvalue = Xvalue + 1
        Next
        PictureBox1.Image = Preview
    End Sub
End Class