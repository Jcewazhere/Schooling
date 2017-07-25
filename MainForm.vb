''By Jamie Edwards, this program keeps track of movie catagories. With the option to save or load.
Imports System.IO

Public Class MainForm
    ''keep track of if changes were made
    Dim DirtyBool As Boolean = False
    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        ''close the program
        If DirtyBool = True Then
            ''get user input about saving changes
            Dim YesNo As DialogResult
            YesNo = MessageBox.Show("Did you want to close without saving changes?", "Save Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If YesNo = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            Else
                SaveFileDialog1.ShowDialog()
            End If
        Else
            Me.Close()
        End If

    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        ''start the print process
        PrintPreviewDialog1.Document = PrintCatalogs
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub AddCatalogMenu_Click(sender As System.Object, e As System.EventArgs) Handles AddCatalogMenu.Click
        With CatalogsCombo
            ''test for input
            If .Text <> "" Then
                ''prevent duplicates
                Dim ItemFound As Boolean = False
                Dim IndexInt As Integer
                Do Until ItemFound Or IndexInt = .Items.Count
                    If .Text = .Items(IndexInt).ToString() Then
                        ItemFound = True
                        Exit Do
                    Else
                        IndexInt += 1
                    End If
                Loop
                ''if it's a duplicate warn them
                If ItemFound = True Then
                    MessageBox.Show("Duplicate catagory", "Adding catagory Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    ''add the item
                    .Items.Add(.Text)
                    .Text = ""
                End If
                .Focus()
            End If
        End With
        DirtyBool = True
    End Sub

    Private Sub RemoveCatalogToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoveCatalogToolStripMenuItem.Click
        With CatalogsCombo
            ''make sure it's a valid selection
            If .SelectedIndex <> -1 Then
                .Items.RemoveAt(.SelectedIndex)
            Else
                MessageBox.Show("Pick a catagory to remove.", "No catagory selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End With
        DirtyBool = True
    End Sub

    Private Sub CountCatalogsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CountCatalogsToolStripMenuItem.Click
        ''display a message box with the number of catagorys
        MessageBox.Show("There are " & CatalogsCombo.Items.Count.ToString & " different catagories of movies.", "Number of catagories", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearAllToolStripMenuItem.Click
        ''clear everything from the catagory
        Dim YesNo As DialogResult
        ''get user input
        YesNo = MessageBox.Show("Are you sure you want to clear all catagories from the list?", "Clear All", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If YesNo = vbYes Then
            CatalogsCombo.Items.Clear()
            DirtyBool = True
        End If
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResetToolStripMenuItem.Click
        ''reset the catagory to default, more useful than clearing all imo
        Dim CatalogDefault() As String = New String() {"Comedy", "Drama", "Action", "Sci-Fi", "Horror"}
        Dim YesNo As DialogResult
        ''get user input
        YesNo = MessageBox.Show("Are you sure you want to reset the list to default?", "Reset List", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If YesNo = vbYes Then
            CatalogsCombo.Items.Clear()
            CatalogsCombo.Items.AddRange(CatalogDefault)
            DirtyBool = True
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        ''show the about box
        AboutBox1.Show()
    End Sub

    

    Private Sub MainForm_Load(sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CatagoryString As String
        Dim YesNo
        Try
            'open the file
            Dim CatStreamReader As StreamReader = New StreamReader("Catagories.txt")
            Do Until CatStreamReader.Peek = -1
                CatagoryString = CatStreamReader.ReadLine()
                CatalogsCombo.Items.Add(CatagoryString)
            Loop
            'close file
            CatStreamReader.Close()
        Catch ex As Exception
            'file missing
            YesNo = MessageBox.Show("Create a new file?", "File Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If YesNo = vbNo Then
                'exit
                Me.Close()
            End If
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim NumItems As Integer
        ''open file
        Dim CatStreamWriter As StreamWriter = New StreamWriter("Catagories.txt", False)
        'save into file
        NumItems = CatalogsCombo.Items.Count - 1
        For Index As Integer = 0 To NumItems
            CatStreamWriter.WriteLine(CatalogsCombo.Items(Index))
        Next Index
        ''close stream
        CatStreamWriter.Close()
        DirtyBool = False
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ''save file if it was changed
        Dim YesNo As DialogResult
        Dim TempString As String = "File has changed, save changes?"
        If DirtyBool = True Then
            YesNo = MessageBox.Show(TempString, "Catagory List Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If YesNo = Windows.Forms.DialogResult.Yes Then
                SaveToolStripMenuItem_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub PrintCatalogs_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintCatalogs.PrintPage
        ''print and format the list of catalogs

        ''set variables
        Dim PrintFont As New Font("Cambria", "12")
        Dim LineHeight As Single = PrintFont.GetHeight + 3
        Dim Horiz As Single = e.MarginBounds.Left
        Dim Vert As Single = e.MarginBounds.Top
        Dim StringToPrint As String
        Dim HeadingFont As Font
        HeadingFont = New System.Drawing.Font("Cambria", 16, FontStyle.Bold)

        ''create a heading, and print my name
        Using HeadingFont
            e.Graphics.DrawString("Catagories list", HeadingFont, Brushes.Black, Horiz, Vert)
            e.Graphics.DrawString("By Jamie Edwards", HeadingFont, Brushes.Black, Horiz + 350, Vert)
        End Using

        ''show what's printing
        StringToPrint = "List of catagories: "
        Vert += Vert
        e.Graphics.DrawString(StringToPrint, PrintFont, Brushes.Black, Horiz, Vert)

        For IndexInt As Integer = 0 To CatalogsCombo.Items.Count - 1
            ''keep from overlapping
            Vert += LineHeight * 2

            ''set stringtoprint to the current catagory
            StringToPrint = CatalogsCombo.Items(IndexInt).ToString()
            e.Graphics.DrawString(StringToPrint, PrintFont, Brushes.Black, Horiz, Vert)

        Next IndexInt
    End Sub
End Class
