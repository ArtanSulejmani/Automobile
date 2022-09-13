Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class NovaMarka

    Public Property Marka As Marka

    Public Sub NovaMarka()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Marka = New Marka()
        Marka.Ime = TextBox1.Text
        Marka.Sifra = TextBox2.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Ime_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles TextBox1.Validating
        If TextBox1.Text.Trim().Length = 0 Then
            ErrorProvider1.SetError(TextBox1, "Името е задолжително")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(TextBox1, Nothing)
            e.Cancel = False
        End If

    End Sub

    Private Sub Sifra_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles TextBox2.Validating
        If TextBox2.Text.Trim().Length = 0 Then
            ErrorProvider1.SetError(TextBox2, "Шифрата е задолжително")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(TextBox2, Nothing)
            e.Cancel = False
        End If
    End Sub
End Class