Public Class _10x10Creator

    Dim Preview As New Bitmap(10, 10)
    Dim Xvalue As Integer
    Dim Yvalue As Integer
    Dim Coord As String
    Dim Irow As Integer = 1
    Dim ButtonRow(10) As Button

    Private Sub GridClick(sender As Object, e As EventArgs)
        Coord = sender.Name
        Coord = Coord.Replace("Button", "")
        Xvalue = Coord.Substring("0,1")
        Yvalue = StrReverse(Coord).Substring("0,1")
        If sender.BackColor.ToKnownColor = KnownColor.Black Then
            sender.BackColor = Color.White
            sender.Tag = "."
            Preview.SetPixel(Xvalue, Yvalue, Color.White)
        Else
            sender.BackColor = Color.Black
            sender.Tag = "O"
            Preview.SetPixel(Xvalue, Yvalue, Color.Black)
        End If
        PictureBox1.Image = Preview
    End Sub

    Private Sub _10x10Creator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each b As Button In Panel1.Controls
            AddHandler b.Click, AddressOf GridClick
        Next
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

    Private Sub ParseButton_Click(sender As Object, e As EventArgs) Handles ParseButton.Click
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName <> "" Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(SaveFileDialog1.FileName & ".lua", False)
            file.WriteLine("leveldata.gridsize = 10")
            file.WriteLine("leveldata.gamemode = """ & GMText.Text & """")
            file.WriteLine("leveldata.number = """ & NumberText.Text & """")
            file.WriteLine("leveldata.letter = """ & LetterText.Text & """")
            file.WriteLine("")
            Irow = 1
            For Irow = 0 To 9
                Dim i As Integer = 0
                Dim ButtonValue
                For i = 0 To 9
                    ButtonValue = CType(Controls("Button" & Irow & i), Button)
                    ButtonRow.SetValue(ButtonValue, i)
                    i = i + 1
                Next
                file.WriteLine("irow" & Irow + 1 & " = {""" & ButtonRow(0).Tag & """, """ & ButtonRow(1).Tag & """, """ & ButtonRow(2).Tag & """, """ & ButtonRow(3).Tag & """, """ & ButtonRow(4).Tag & """, """ & ButtonRow(5).Tag & """, """ & ButtonRow(6).Tag & """, """ & ButtonRow(7).Tag & """, """ & ButtonRow(8).Tag & """, """ & ButtonRow(9).Tag & """}")
                Irow = Irow + 1
            Next
            file.Close()
            Irow = 1
            Preview.Save(SaveFileDialog1.FileName & ".png", Imaging.ImageFormat.Png)
            MsgBox("Level successfully saved!")
        Else
            MsgBox("Level not saved!")
        End If
    End Sub
End Class