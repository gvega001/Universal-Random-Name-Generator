Imports System.ComponentModel
Imports System.IO
Public Class Namelist
    Dim IfChange As Boolean = False
    Public titleofD As String = ""
    Private totalN As Integer = 0
    Private Sub Namelist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim ENameReader As StreamReader = New StreamReader("C:\RNG\Database\" & titleofD & "\NameElist.txt", System.Text.Encoding.Default)
        Dim CNameReader As StreamReader = New StreamReader("C:\RNG\Database\" & titleofD & "\NameClist.txt", System.Text.Encoding.Default)
        Using ENameReader
            Using CNameReader
                With ENameReader
                    totalN = .ReadLine
                    For i As Integer = 0 To totalN - 1
                        Dim additem As ListViewItem = ListView1.Items.Add(.ReadLine)
                        additem.SubItems.Add(CNameReader.ReadLine)
                    Next
                End With
            End Using
        End Using
        Label1.Text = "Total number: " & totalN
        Form2.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next
        If ListView1.SelectedIndices.Count > 0 Then
            Dim EnglishN As String = InputBox("Please type the student's English name.")
            If EnglishN = "" Then Exit Sub
            Dim ChineseN As String = InputBox("Please type the student's Chinese name.")
            If ChineseN = "" Then Exit Sub
            Dim selecteditem As ListViewItem = ListView1.Items.Insert(ListView1.SelectedIndices.Item(0) + 1, EnglishN)
            selecteditem.SubItems.Add(ChineseN)
            totalN += 1
            Label1.Text = "Total number: " & totalN
            IfChange = True
        Else
            Dim EnglishN As String = InputBox("Please type the student's English name.")
            If EnglishN = "" Then Exit Sub
            Dim ChineseN As String = InputBox("Please type the student's Chinese name.")
            If ChineseN = "" Then Exit Sub
            Dim additem As ListViewItem = ListView1.Items.Add(EnglishN)
            additem.SubItems.Add(ChineseN)
            totalN += 1
            Label1.Text = "Total number: " & totalN
            IfChange = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error Resume Next
        If ListView1.SelectedIndices.Count > 0 Then
            Dim selectedindex As Int16 = ListView1.SelectedIndices.Item(0)
            Dim textE As String = ListView1.SelectedItems.Item(0).Text
            Dim textC As String = ListView1.SelectedItems.Item(0).SubItems(1).Text
            Dim newitem As ListViewItem = ListView1.Items.Insert(selectedindex + 1, InputBox("Please type the student's English name.",, textE))
            ListView1.Items.Item(selectedindex).Remove()
            newitem.SubItems.Add(InputBox("Please type the student's Chinese name.",, textC))
            IfChange = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        On Error Resume Next
        If ListView1.SelectedIndices.Count > 0 Then
            ListView1.Items.Item(ListView1.SelectedIndices.Item(0)).Remove()
            totalN = totalN - 1
            Label1.Text = "Total number: " & totalN
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        On Error Resume Next
        Dim ENameWriter As StreamWriter = New StreamWriter("C:\RNG\Database\" & titleofD & "\NameElist.txt", False, System.Text.Encoding.Default)
        Using ENameWriter
            With ENameWriter
                .Write("")
                .WriteLine(ListView1.Items.Count)
                For i As Integer = 0 To ListView1.Items.Count - 1
                    .WriteLine(ListView1.Items.Item(i).Text)
                Next
            End With
        End Using
        Dim CNameWriter As StreamWriter = New StreamWriter("C:\RNG\Database\" & titleofD & "\NameClist.txt", False, System.Text.Encoding.Default)
        Using CNameWriter
            With CNameWriter
                .Write("")
                For i As Integer = 0 To ListView1.Items.Count - 1
                    .WriteLine(ListView1.Items.Item(i).SubItems(1).Text)
                Next
            End With
        End Using
        Form2.Show()
        Me.Dispose()
    End Sub

    Private Sub Namelist_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If IfChange = True Then
            If MsgBox("Save changes to the name list?", vbOKCancel) = MsgBoxResult.Ok Then
                Button4.PerformClick()
            End If
        End If
        Form2.Show()
    End Sub

    Private Sub ChangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeToolStripMenuItem.Click
        Button2.PerformClick()
    End Sub

    Private Sub 插入ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 插入ToolStripMenuItem.Click
        Button1.PerformClick()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Button3.PerformClick()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedIndices.Count > 0 Then
            Button1.Text = "Insert"
            Button2.Enabled = True
            Button3.Enabled = True
        Else
            Button1.Text = "New"
            Button2.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Button4.Enabled = True
    End Sub
End Class