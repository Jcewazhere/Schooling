Public Class Form1
    ''by Jamie Edwards, problem 5.3, this takes user input of pay, sales and name, does stuff with it and outputs in text boxes or message boxes
    ''declare variables
    Private YourPay As Decimal
    Private YourCom As Decimal
    Private Commision As Decimal
    Const BasePay As Decimal = 250
    Const Quota As Integer = 1000
    Const ComRate As Decimal = 0.15
    Private YourSales As Decimal
    Friend TotalPay, TotalSale, TotalCom As Decimal

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        ''close the program
        Me.Close()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        ''print
        PrintForm1.Print()
    End Sub

    Private Sub PayToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PayToolStripMenuItem.Click
        Try
            YourSales = Decimal.Parse(MoneyIn.Text)
        Catch ex As Exception
            MessageBox.Show("Please enter only numbers.", "Data entry error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        ''adding one person's sales to the total store sales
        TotalSale += YourSales

        If YourSales >= Quota Then
            YourCom = (YourSales * ComRate)
            YourPay = YourCom + BasePay
            ''adding one person's pay to total pay
            TotalPay += YourPay
            ''adding one person's commision to total commission
            TotalCom += YourCom
            ''output it
            ''I thought we were using message boxes for both, oops. MessageBox.Show("Congrats " & NameIn.Text & " you earned: " & YourCom.ToString("C") & " in commision, for a total pay of: " & Environment.NewLine & YourPay.ToString("C"), "Total Pay", MessageBoxButtons.OK)
            ComisLabel.Text = YourCom.ToString("C")
            PayLabel.Text = YourPay.ToString("C")
            EarnedLabel.Visible = True
            ComTextLabel.Visible = True
        Else
            YourPay = BasePay
            ''adding one person's pay to the total pay
            TotalPay += YourPay
            ''output it
            ''I thought we were using message boxes for both. MessageBox.Show(NameIn.Text & " you earned: " & YourPay.ToString("C"), "Total Pay", MessageBoxButtons.OK)
            PayLabel.Text = YourPay.ToString("C")
            EarnedLabel.Visible = True
        End If
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        ''clearing variables
        YourCom = 0
        YourPay = 0
        YourSales = 0
        With NameIn
            .Clear()
            .Focus()
        End With
        With MoneyIn
            .Clear()
        End With
        With EarnedLabel
            .Visible = False
            .ForeColor = Color.Black
            .ResetFont()
        End With
        With ComTextLabel
            .Visible = False
            .ForeColor = Color.Black
            .ResetFont()
        End With
        With PayLabel
            .Text = ""
            .ForeColor = Color.Black
            .ResetFont()
        End With
        With ComisLabel
            .Text = ""
            .ForeColor = Color.Black
            .ResetFont()
        End With
    End Sub

    Private Sub SummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SummaryToolStripMenuItem.Click
        ''making sure the values are up to date
        TotalCom += YourCom
        TotalPay += YourPay
        TotalSale += YourSales

        MessageBox.Show("Total Sales: " & TotalSale.ToString("C") & Environment.NewLine & "Total Commision: " & TotalCom.ToString("C") & Environment.NewLine & "Total pay: " & TotalPay.ToString("C"), "Summary", MessageBoxButtons.OK)

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("This awesome program, Pay Calculator, was created by Jamie Edwards.", "About", MessageBoxButtons.OK)
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        ComTextLabel.ForeColor = ColorDialog1.Color
        EarnedLabel.ForeColor = ColorDialog1.Color
        ComisLabel.ForeColor = ColorDialog1.Color
        PayLabel.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        ComTextLabel.Font = FontDialog1.Font
        EarnedLabel.Font = FontDialog1.Font
        ComisLabel.Font = FontDialog1.Font
        PayLabel.Font = FontDialog1.Font
    End Sub
End Class
