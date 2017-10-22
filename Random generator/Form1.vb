Imports System.Math
Imports System.IO
Imports System.ComponentModel

Public Class Form1
    Public NameE(65535) As String
    Public NameC(65535) As String
    Public KickTimer As Integer = 0
    Public appendindex As Integer = 0
    Public GroupN As Integer = 0
    Public GroupC As Integer = 0
    Public TotalN As Integer = 0
    Public existgroupmembernumber As Integer = 0
    Public existgroupnumber As Integer = 0
    Public DatabaseloaderName As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Form2.Show()
    End Sub
    Public Sub Nameloader(ByVal databasetitle As String)
        ' load the name list of the given database title 
        Dim ENameReader As StreamReader = New StreamReader("C:\RNG\Database\" & databasetitle & "\NameElist.txt", System.Text.Encoding.Default)
        Using ENameReader
            With ENameReader
                TotalN = .ReadLine
                For i As Integer = 0 To TotalN - 1
                    NameE.SetValue(.ReadLine, i)
                Next
            End With
        End Using
        Dim CNameReader As StreamReader = New StreamReader("C:\RNG\Database\" & databasetitle & "\NameClist.txt", System.Text.Encoding.Default)
        Using CNameReader
            With CNameReader
                For i As Integer = 0 To TotalN - 1
                    NameC(i) = .ReadLine
                Next
            End With
        End Using
        DatabaseloaderName = databasetitle
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RichTextBox1.Text = "" Then appendindex = 0
        If CheckBox1.CheckState = CheckState.Checked Then
            If CheckBox2.CheckState = CheckState.Unchecked Then
                ' kick mode
c:
                Randomize()
                Dim x As Integer = Int(Rnd() * TotalN)
                If NameC(x) = "" Then GoTo c
                Label1.Text = NameE(x) & Chr(13) + Chr(10) & NameC(x)
                KickTimer += 1
                appendindex += 1
                RichTextBox1.AppendText(appendindex & "、" & NameE(x) & " " & NameC(x) & Chr(13) + Chr(10))
                NameC(x) = ""
                Label1.Left = (RichTextBox1.Left - Label1.Width) / 2
                If KickTimer = TotalN Then
                    MsgBox("All students have been chosen!")
                    CheckBox1.CheckState = CheckState.Unchecked
                End If
            Else
                'Group mode
                ' Checking if there are already existed groups
                If existgroupnumber = 0 And existgroupmembernumber = 0 Then RichTextBox1.AppendText("Group1" & Chr(13) + Chr(10))
                If existgroupmembernumber > 0 Then
                    existgroupnumber += 1
                    RichTextBox1.AppendText("--------------" & Chr(13) + Chr(10) & "Group" & existgroupnumber + 1 & Chr(13) + Chr(10))
                End If
                Do
f:
                    Randomize()
                    Dim x As Integer = Int(Rnd() * TotalN)
                    If NameC(x) = "" Then GoTo f
                    Label1.Text = NameE(x) & Chr(13) + Chr(10) & NameC(x)
                    KickTimer += 1
                    GroupC += 1
                    appendindex += 1
                    If GroupC = GroupN And KickTimer < TotalN - 1 Then
                        GroupC = 0
                        existgroupnumber += 1
                        RichTextBox1.AppendText(appendindex & "、" & NameE(x) & " " & NameC(x) & Chr(13) + Chr(10) & "--------------" & Chr(13) + Chr(10) & "Group" & existgroupnumber + 1 & Chr(13) + Chr(10))
                    Else
                        RichTextBox1.AppendText(appendindex & "、" & NameE(x) & " " & NameC(x) & Chr(13) + Chr(10))
                    End If
                    NameC(x) = ""
                Loop Until KickTimer = TotalN
                KickTimer = 0
                appendindex = 0
                CheckBox2.CheckState = CheckState.Unchecked
                CheckBox1.CheckState = CheckState.Unchecked
                Label1.Left = (RichTextBox1.Left - Label1.Width) / 2
                MsgBox("Complete!", vbInformation)
            End If
        Else
            ' totally random mode (all checkboxes unchecked)
            Randomize()
            Dim x As Integer = Int(Rnd() * TotalN)
            Label1.Text = NameE(x) & Chr(13) + Chr(10) & NameC(x)
            appendindex += 1
            RichTextBox1.AppendText(appendindex & "、" & NameE(x) & " " & NameC(x) & Chr(13) + Chr(10))
            Label1.Left = (RichTextBox1.Left - Label1.Width) / 2
        End If
        Label1.Left = (RichTextBox1.Left - Label1.Width) / 2
        Exit Sub
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        existgroupnumber = 0
        existgroupmembernumber = 0
        KickTimer = 0
        If CheckBox1.CheckState = CheckState.Checked Then
            KickTimer = 0
        Else
            'Reload the name list in order to assign name to the previously cleared variable in kick mode or group mode
            Dim CNameReader As StreamReader = New StreamReader("C:\RNG\Database\" & DatabaseloaderName & "\NameClist.txt", System.Text.Encoding.Default)
            Using CNameReader
                With CNameReader
                    For i As Integer = 0 To TotalN - 1
                        NameC(i) = .ReadLine
                    Next
                End With
            End Using
            CheckBox2.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
r:
        On Error GoTo e
        KickTimer = 0
        GroupN = 0
        GroupC = 0
        existgroupmembernumber = 0
        appendindex = 0
        existgroupnumber = 0
        If CheckBox2.CheckState = CheckState.Checked Then
            CheckBox1.CheckState = CheckState.Checked
            GroupN = InputBox("Please enter the number of people in a group.(Greater than 1 And no more than " & TotalN & "）")
            If GroupN > TotalN Or GroupN < 2 Then
                MsgBox("Outranged!", MsgBoxStyle.Exclamation)
                GoTo r
            End If
            Button2.Visible = True
        Else
            GroupN = 0
            Button2.Visible = False
            CheckBox1.CheckState = False
        End If
        Exit Sub
e:      MsgBox("Error! Please check your input.", MsgBoxStyle.Critical)
        CheckBox1.CheckState = CheckState.Unchecked
        CheckBox2.CheckState = CheckState.Unchecked
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error GoTo e
        Dim ifexact As Boolean = False
        Dim name As String = InputBox("Please enter the group members' name, either Chinese or English. The spelling must be exact.")
        'Check spelling and extract full name from the name list
        For x As Integer = 0 To TotalN - 1 Step 1
            If NameC(x) = name Or NameE(x) = name And name IsNot "" And NameC(x) <> "" Then
                If existgroupmembernumber = 0 And existgroupnumber = 0 Then RichTextBox1.AppendText("Group1" & Chr(13) + Chr(10))
                appendindex += 1
                RichTextBox1.AppendText(appendindex & "、" & NameE(x) & " " & NameC(x) & Chr(13) + Chr(10))
                NameC(x) = ""
                ifexact = True
                existgroupmembernumber += 1
                KickTimer += 1
                ' Creating new group if previous group was at full strength
                If existgroupmembernumber = GroupN Then
                    existgroupmembernumber = 0
                    existgroupnumber += 1
                    RichTextBox1.AppendText("--------------" & Chr(13) + Chr(10) & "Group" & 1 + existgroupnumber & Chr(13) + Chr(10))
                End If
            End If
        Next
        If ifexact = False Then
            MsgBox("Spelling is incorrect or that person is already in your group list!", vbExclamation)
        End If
        Exit Sub
e:
        MsgBox("Error! Please check your input!", vbCritical)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Namelist.Show()
        Me.Hide()
    End Sub

    Private Sub LToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LToolStripMenuItem.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        Namelist.Text = "Edit the name list '" & DatabaseloaderName & "'"
        Namelist.titleofD = DatabaseloaderName
        Namelist.Show()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        Clipboard.SetText(RichTextBox1.SelectedText)
        RichTextBox1.SelectedText = ""
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Clipboard.SetText(RichTextBox1.SelectedText)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        RichTextBox1.Text = ""
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
        Dim path As String = SaveFileDialog1.FileName
        MsgBox(path)
        Dim listsaver As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.Default)

        Using listsaver
            For i As Int64 = 0 To RichTextBox1.Lines.Length - 1
                listsaver.WriteLine(RichTextBox1.Lines.GetValue(i))
            Next
        End Using
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        MsgBox("Random Name Generator, version 1.2.0, produced by Tom Zhou.", vbInformation)
    End Sub
End Class
