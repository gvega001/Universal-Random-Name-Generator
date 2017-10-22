Imports System.ComponentModel
Imports System.IO
Public Class Form2
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedIndices.Count > 0 Then
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
        End If
    End Sub
    Public Sub ItemsLoading()
        ListView1.Items.Clear()
        Dim TitlesReader As StreamReader = New StreamReader("C:\RNG\Database\Databases Titles.txt", System.Text.Encoding.Default)
        Using TitlesReader
            With TitlesReader
                Dim a As Integer = .ReadLine
                For i As Integer = 0 To a - 1
                    Dim titleread As String = .ReadLine
                    Dim Title As ListViewItem = ListView1.Items.Add(titleread)
                    Dim ENameReader As StreamReader = New StreamReader("C:\RNG\Database\" & titleread & "\NameElist.txt", System.Text.Encoding.Default)
                    Using ENameReader
                        Dim numbers As String = ENameReader.ReadLine
                        If numbers = "" Then
                            Title.SubItems.Add("0")
                        Else
                            Title.SubItems.Add(numbers)
                        End If
                    End Using
                Next
            End With
        End Using
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Dispose()
        If File.Exists("C:\RNG\Database\Databases Titles.txt") = True Then
            Dim TitlesReader As StreamReader = New StreamReader("C:\RNG\Database\Databases Titles.txt", System.Text.Encoding.Default)
            Using TitlesReader
                With TitlesReader
                    Dim b As String = .ReadLine
                    If b = "" Then
                        .Close()
                        MsgBox("Please create the name list since this is the first time you use this software on your computer.")
                        Button4.PerformClick()
                    Else
                        Dim a As Integer = b
                        For i As Integer = 0 To a - 1
                            Dim titleread As String = .ReadLine
                            Dim Title As ListViewItem = ListView1.Items.Add(titleread)
                            Dim ENameReader As StreamReader = New StreamReader("C:\RNG\Database\" & titleread & "\NameElist.txt", System.Text.Encoding.Default)
                            Using ENameReader
                                Dim numbers As String = ENameReader.ReadLine
                                If numbers = "" Then
                                    Title.SubItems.Add("0")
                                Else
                                    Title.SubItems.Add(numbers)
                                End If
                            End Using
                        Next
                    End If
                End With
            End Using
        Else
            MsgBox("Please create the name list since this is the first time you use this software on your computer.")
            Button4.PerformClick()
        End If
    End Sub
    '写文件保存文字列表
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Newtitle As String = InputBox("Please type the title of your new name list.")
        Dim ifrepeat As Boolean = False
        For checkcycle As Integer = 0 To ListView1.Items.Count - 1
            If Newtitle = ListView1.Items.Item(checkcycle).Text Then ifrepeat = True
        Next
        If Newtitle <> "" And ifrepeat = False Then
            Directory.CreateDirectory("C:\RNG\Database\" & Newtitle)
            File.Create("C:\RNG\Database\" & Newtitle & "\NameClist.txt")
            File.Create("C:\RNG\Database\" & Newtitle & "\NameElist.txt")
            Namelist.Text = "Edit the name list '" & Newtitle & "'"
            Namelist.titleofD = Newtitle
            Dim TitlesWriter As StreamWriter = New StreamWriter("C:\RNG\Database\Databases Titles.txt", False, System.Text.Encoding.Default)
            Using TitlesWriter
                With TitlesWriter
                    Dim a As Integer = ListView1.Items.Count + 1
                    .WriteLine(a)
                    .WriteLine(Newtitle)
                    For i As Integer = 0 To a - 2
                        .WriteLine(ListView1.Items.Item(i).Text)
                    Next
                End With
            End Using
            Namelist.Show()
        Else
            MsgBox("The " & Newtitle & " already exists!")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Form1.Nameloader(ListView1.SelectedItems.Item(0).Text)
        Form1.Show()
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Are you sure you want to delete the selected name list? This action is irreversible", vbOKCancel) = MsgBoxResult.Ok Then
            File.Delete("C:\RNG\Database\" & ListView1.SelectedItems.Item(0).Text & "\NameClist.txt")
            File.Delete("C:\RNG\Database\" & ListView1.SelectedItems.Item(0).Text & "\NameElist.txt")
            Directory.Delete("C:\RNG\Database\" & ListView1.SelectedItems.Item(0).Text)
            ListView1.Items.RemoveAt(ListView1.SelectedIndices.Item(0))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim title As String = ListView1.SelectedItems.Item(0).Text
        Namelist.Text = "Edit the name list '" & title & "'"
        Namelist.titleofD = title
        Namelist.Show()
    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub
End Class