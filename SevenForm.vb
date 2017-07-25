Public Class SevenForm
    ''By Jamie Edwards, this program calculates the cost of chartering a yacht.
    ''show the about box

    ''setting variables
    Dim RunningPrice As Decimal
    Dim Price As Decimal
    Dim HoursIn As Decimal
    Dim OkToPrint As Boolean
    Dim NumChart As Integer
    Dim AvgHours As Decimal
    Dim RunningHours As Decimal


    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    ''close the program
    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As System.Object, e As System.EventArgs) Handles ClearButton.Click
        ''this does the same thing as the menu item, so I'll use that
        ClearToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        ''clear the info for next user
        SizeListBox.SelectedIndex = -1
        RespInText.Clear()
        HoursInText.Clear()
        YachtTypeCombo.SelectedIndex = -1
        PriceOutLabel.Text = ""
        Price = 0
        HoursIn = 0
        OkButton.Enabled = True
    End Sub

    Private Sub OkButton_Click(sender As System.Object, e As System.EventArgs) Handles OkButton.Click
        ''checking for correct input, and setting OkToPrint
        OkToPrint = True
        Try
            HoursIn = Decimal.Parse(HoursInText.Text)
        Catch ex As Exception
            OkToPrint = False
            MessageBox.Show("Please enter how many hours you want a yacht.", "Data entry error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        If YachtTypeCombo.SelectedIndex = -1 Then
            OkToPrint = False
            MessageBox.Show("Please select a Yacht.", "Data entry error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        If SizeListBox.SelectedIndex = -1 Then
            OkToPrint = False
            MessageBox.Show("Please select the size of the yacht.", "Data entry error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        If RespInText.Text = "" Then
            OkToPrint = False
            MessageBox.Show("Please enter the name of the responsible party.", "Data entry error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        ''calculate price
        If SizeListBox.SelectedIndex = 0 And OkToPrint = True Then
            Price = HoursIn * 95
        ElseIf SizeListBox.SelectedIndex = 1 And OkToPrint = True Then
            Price = HoursIn * 137
        ElseIf SizeListBox.SelectedIndex = 2 And OkToPrint = True Then
            Price = HoursIn * 160
        ElseIf SizeListBox.SelectedIndex = 3 And OkToPrint = True Then
            Price = HoursIn * 192
        ElseIf SizeListBox.SelectedIndex = 4 And OkToPrint = True Then
            Price = HoursIn * 250
        ElseIf SizeListBox.SelectedIndex = 5 And OkToPrint = True Then
            Price = HoursIn * 400
        ElseIf SizeListBox.SelectedIndex = 6 And OkToPrint = True Then
            Price = HoursIn * 550
        End If

        ''output price
        If OkToPrint = True Then
            PriceOutLabel.Text = Price.ToString("C")

            ''prevent click spam
            OkButton.Enabled = False

            ''adding info to summary
            NumChart += 1
            RunningHours += HoursIn
            RunningPrice += Price
        End If

    End Sub

    Private Sub PrintSummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintSummaryToolStripMenuItem.Click
        ''check OkToPrint, then setup printing for summary
        If OkToPrint = True Then
            PrintPreviewDialog1.Document = PrintSummary
            PrintPreviewDialog1.ShowDialog()
        End If
    End Sub

    Private Sub PrintSummary_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintSummary.PrintPage
        ''calculate, format and print avghours, numchart, runningprice and header

        ''set variables
        Dim PrintFont As New Font("Cambria", "12")
        Dim LineHeight As Single = PrintFont.GetHeight + 3
        Dim Horiz As Single = e.MarginBounds.Left
        Dim Vert As Single = e.MarginBounds.Top
        Dim StringToPrint As String
        Dim HeadingFont As Font
        HeadingFont = New System.Drawing.Font("Cambria", 16, FontStyle.Bold) ''it yelled at me when I tried it the same as PrintFont, so I did it this way

        ''create a heading, and print my name
        Using HeadingFont
            e.Graphics.DrawString("Summary Information", HeadingFont, Brushes.Black, Horiz, Vert)
            e.Graphics.DrawString("By Jamie Edwards", HeadingFont, Brushes.Black, Horiz + 350, Vert)
        End Using

        ''print number of charters
        StringToPrint = "You had: " & NumChart.ToString() & " charters."
        e.Graphics.DrawString(StringToPrint, PrintFont, Brushes.Black, Horiz, Vert + (LineHeight * 2))

        ''print and calculate average hours
        AvgHours = RunningHours / NumChart
        StringToPrint = "You had: " & AvgHours.ToString() & " average hours per charter."
        e.Graphics.DrawString(StringToPrint, PrintFont, Brushes.Black, Horiz, Vert + (LineHeight * 4))

        ''print total revenue
        StringToPrint = "You made: " & RunningPrice.ToString("c") & "."
        e.Graphics.DrawString(StringToPrint, PrintFont, Brushes.Black, Horiz, Vert + (LineHeight * 6))

        ''see I told you it could be much prettier if I did it this way from the start

    End Sub

    Private Sub PrintYachtsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintYachtsToolStripMenuItem.Click
        ''setup printing for the list of yachts, and my header
        PrintPreviewDialog1.Document = PrintYachts
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintYachts_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintYachts.PrintPage
        ''print and format the list of yachts
        ''set variables
        Dim PrintFont As New Font("Cambria", "12")
        Dim LineHeight As Single = PrintFont.GetHeight + 3
        Dim Horiz As Single = e.MarginBounds.Left
        Dim Vert As Single = e.MarginBounds.Top
        Dim StringToPrint As String
        Dim HeadingFont As Font
        HeadingFont = New System.Drawing.Font("Cambria", 16, FontStyle.Bold) ''it yelled at me when I tried it the same as PrintFont, so I did it this way

        ''create a heading, and print my name
        Using HeadingFont
            e.Graphics.DrawString("Yacht Information", HeadingFont, Brushes.Black, Horiz, Vert)
            e.Graphics.DrawString("By Jamie Edwards", HeadingFont, Brushes.Black, Horiz + 350, Vert)
        End Using

        ''show what's printing
        StringToPrint = "List of yachts: "
        Vert += Vert
        e.Graphics.DrawString(StringToPrint, PrintFont, Brushes.Black, Horiz, Vert)

        For IndexInt As Integer = 0 To YachtTypeCombo.Items.Count - 1
            ''keep from overlapping
            Vert += LineHeight * 2

            ''set stringtoprint to the current yacht
            StringToPrint = YachtTypeCombo.Items(IndexInt).ToString()
            e.Graphics.DrawString(StringToPrint, PrintFont, Brushes.Black, Horiz, Vert)

        Next IndexInt


    End Sub

    Private Sub RemoveYachtToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoveYachtToolStripMenuItem.Click
        ''remove a yacht from the list
        With YachtTypeCombo
            ''make sure it's a valid selection
            If .SelectedIndex <> -1 Then
                .Items.RemoveAt(.SelectedIndex)
            Else
                MessageBox.Show("Pick a yacht to remove.", "No yacht selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End With
    End Sub

    Private Sub AddYachtToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddYachtToolStripMenuItem.Click
        ''add a yacht to the list
        With YachtTypeCombo
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
                    MessageBox.Show("Duplicate yacht", "Adding yacht Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    ''add the item
                    .Items.Add(.Text)
                    .Text = ""
                End If
                .Focus()
            End If
        End With
    End Sub

    Private Sub CountYachtsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CountYachtsToolStripMenuItem.Click
        MessageBox.Show("There are " & YachtTypeCombo.Items.Count.ToString & " types of yacht.", "Number of yachts", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
