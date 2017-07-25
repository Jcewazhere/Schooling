Public Class SalonCalc
    ''by Jamie Edwards, this program calculates prices for a salon.
    Const Mako As Integer = 125
    Const Mani As Integer = 35
    Const Hair As Integer = 60
    Const Perma As Integer = 200
    Const TwentyP As Decimal = 0.2
    Const TenP As Decimal = 0.1
    Private PatronCount As Integer
    Friend RunTotal As Decimal
    Friend GroupTotal As Decimal


    Private Sub CloseButton_Click(sender As System.Object, e As System.EventArgs) Handles CloseButton.Click
        ''close program
        Me.Close()
    End Sub

    Private Sub PrintButton_Click(sender As System.Object, e As System.EventArgs) Handles PrintButton.Click
        ''print
        PrintForm1.Print()
    End Sub

    Private Sub ClearButton_Click(sender As System.Object, e As System.EventArgs) Handles ClearButton.Click
        ''prevent double click
        CalcButton.Enabled = True
        ''uncheck stuff
        CheckMani.Checked = False
        CheckHair.Checked = False
        CheckPerma.Checked = False
        CheckMako.Checked = False
        Radio0.Checked = True
        RunTotal = 0
        TextOut.Text = ""
    End Sub

    Private Sub NextButton_Click(sender As System.Object, e As System.EventArgs) Handles NextButton.Click
        ''prevent double click
        CalcButton.Enabled = True
        SumButton.Enabled = True
        ''need a variable for yes/no response
        Dim YesOrNo As DialogResult
        YesOrNo = MessageBox.Show("Do you want to clear the form for the next group?", "Clear Order", MessageBoxButtons.YesNo)
        If YesOrNo = Windows.Forms.DialogResult.Yes Then
            ''prevent double click
            SumButton.Enabled = True
            ''uncheck stuff
            CheckMani.Checked = False
            CheckHair.Checked = False
            CheckPerma.Checked = False
            CheckMako.Checked = False
            Radio0.Checked = True
            ''reset variables
            GroupTotal = 0
            RunTotal = 0
            PatronCount = 0
            TextOut.Text = ""
        Else
            ''do nothing
        End If

    End Sub

    Private Sub CalcButton_Click(sender As System.Object, e As System.EventArgs) Handles CalcButton.Click
        ''prevent double click
        CalcButton.Enabled = False
        ''adding up services
        If CheckHair.Checked Then
            RunTotal += 60
        End If
        If CheckMako.Checked Then
            RunTotal += 125
        End If
        If CheckMani.Checked Then
            RunTotal += 35
        End If
        If CheckPerma.Checked Then
            RunTotal += 200
        End If
        ''applying discount and outputting to text box
        If Radio20.Checked Then
            RunTotal = (RunTotal - (RunTotal * TwentyP))
            TextOut.Text = RunTotal.ToString("C")
        ElseIf Radio10.Checked Then
            RunTotal = (RunTotal - (RunTotal * TenP))
            TextOut.Text = RunTotal.ToString("C")
        Else
            TextOut.Text = RunTotal.ToString("C")
        End If
        '' adding anther patron to the group
        PatronCount += 1
        ''adding to the group total
        GroupTotal += RunTotal

    End Sub

    Private Sub SumButton_Click(sender As System.Object, e As System.EventArgs) Handles SumButton.Click
        SumButton.Enabled = False
        ''adding up services
        If CheckHair.Checked Then
            GroupTotal += 60
        End If
        If CheckMako.Checked Then
            GroupTotal += 125
        End If
        If CheckMani.Checked Then
            GroupTotal += 35
        End If
        If CheckPerma.Checked Then
            GroupTotal += 200
        End If
        ''applying discount and outputting to message box
        If Radio20.Checked Then
            GroupTotal += (RunTotal - (RunTotal * TwentyP))
            MessageBox.Show("The group total was: " & GroupTotal.ToString("C") & Environment.NewLine & "There were " & PatronCount.ToString & " patrons in your group", "Summary", MessageBoxButtons.OK)
        ElseIf Radio10.Checked Then
            GroupTotal += (RunTotal - (RunTotal * TenP))
            MessageBox.Show("The group total was: " & GroupTotal.ToString("C") & Environment.NewLine & "There were " & PatronCount.ToString & " patrons in your group", "Summary", MessageBoxButtons.OK)
        Else
            MessageBox.Show("The group total was: " & GroupTotal.ToString("C") & Environment.NewLine & "There were " & PatronCount.ToString & " patrons in your group", "Summary", MessageBoxButtons.OK)
        End If
    End Sub
End Class
