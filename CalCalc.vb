''By Jamie Edwards
''3.1, create a project that calculates the total calories for an item and keeps a running total of items

Public Class CalCalc

    ''user entered variables:
    ''GoF= grams of fat entered into text box
    ''GoC= grams of carbs entered into text box
    ''GoP= grams of protein entered into text box

    ''Calculated variables:
    ''TC= total calories for single entry
    ''INum= number of times calc button was pressed/number of items entered
    ''RTC= running total of all calories entered

    ''constants
    ''FC=9, calories per gram of fat
    ''PCC=4, Protein or carbs have 4 calories per gram

    Const FC As Integer = 9
    Const PCC As Integer = 4
    Private TC, INum, RTC As Integer

    Private Sub CalcButton_Click(sender As System.Object, e As System.EventArgs) Handles CalcButton.Click
        ''prevents spamming the button
        CalcButton.Enabled = False

        ''declaring user entered variables:
        Dim GoF, GoC, GoP, TC As Decimal

        ''changing from char to decimal and assigning values
        Try
            GoF = Decimal.Parse(FatIn.Text)
            GoC = Decimal.Parse(CarbsIn.Text)
            GoP = Decimal.Parse(ProtIn.Text)

        Catch ex As Exception
            MessageBox.Show("Please enter only whole number amounts of calories.", "Data entry error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        ''getting total calories for single entry
        TC = (GoF * FC) + ((GoC + GoP) * PCC)

        ''outputting TC as string
        TotalCalOut.Text = TC.ToString

        ''adding 1 to the item count
        INum += 1

        ''outputting INum as string
        ItemNumOut.Text = INum.ToString

        ''calculating and outputting RTC as string
        RTC = RTC + TC
        RunTotalCalOut.Text = RTC.ToString

    End Sub

    Private Sub ClearButton_Click(sender As System.Object, e As System.EventArgs) Handles ClearButton.Click
        ''enables calculating the next items
        CalcButton.Enabled = True
        ''clears text boxes so more can be input
        FatIn.Clear()
        CarbsIn.Clear()
        ProtIn.Clear()

    End Sub

    Private Sub CloseButton_Click(sender As System.Object, e As System.EventArgs) Handles CloseButton.Click
        ''closes the program
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ''prints the page
        PrintForm1.Print()

    End Sub

End Class
