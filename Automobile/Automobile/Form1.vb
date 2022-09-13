Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1

    Public Sub Form1()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Sub BtnDodadi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim NovaMarka As NovaMarka = New NovaMarka()
        If NovaMarka.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ListBox1.Items.Add(NovaMarka.Marka)
            addMarka()

        End If
    End Sub

    Private Sub AddMarka()
        ComboBox1.Items.Clear()

        For i As Integer = 0 To ListBox1.Items.Count - 1
            Dim m As Marka = CType(ListBox1.Items(i), Marka)
            ComboBox1.Items.Add(m)
        Next

    End Sub


    Private Sub btnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Изберете марка!")
            Return
        End If
        If TextBox1.Text.Trim().Length <= 0 Then
            MessageBox.Show("Внесете модел!")
            Return
        End If
        Dim auto As Automobile = New Automobile()
        auto.Marka = TryCast(ComboBox1.SelectedItem, Marka)
        auto.Model = TextBox1.Text
        auto.Potrosuvacka = CDbl(NumericUpDown1.Value)
        auto.Cena = CInt(NumericUpDown2.Value)
        ListBox2.Items.Add(auto)
        ComboBox1.SelectedIndex = -1
        TextBox1.Clear()
        NumericUpDown1.Value = 0
        NumericUpDown1.ResetText()
        NumericUpDown2.Value = 0
        NumericUpDown2.ResetText()
        calculate()

    End Sub

    Private Sub calculate()
        If ListBox2.Items.Count > 0 Then
            Dim najekonomicen As Automobile = TryCast(ListBox2.Items(0), Automobile)
            Dim najskap As Automobile = TryCast(ListBox2.Items(0), Automobile)
            Dim sum As Double = najekonomicen.Potrosuvacka

            For i As Integer = 1 To ListBox2.Items.Count - 1
                Dim av As Automobile = TryCast(ListBox2.Items(i), Automobile)

                If av.Potrosuvacka < najekonomicen.Potrosuvacka Then

                    najekonomicen = av

                End If

                If av.Cena > najskap.Cena Then
                    najskap = av
                End If

                sum = sum + av.Potrosuvacka
            Next
            TextBox2.Text = String.Format("{0:0.0}", sum / ListBox2.Items.Count)
            TextBox3.Text = najekonomicen.ToString()
            TextBox4.Text = najskap.ToString()
        Else
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListBox2.SelectedIndex <> -1 Then
            If MessageBox.Show("Дали сте сигурни дека сакате да го избришете овој автомобил?", "Потврда за бришење?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            End If
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
            calculate()

        End If
    End Sub
End Class
