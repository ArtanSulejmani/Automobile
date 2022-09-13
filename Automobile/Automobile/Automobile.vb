Imports System
Imports System.ComponentModel
Imports System.Windows.Forms


Public Class Automobile
    Public Property Marka As Marka
    Public Property Model As String
    Public Property Potrosuvacka As Double
    Public Property Cena As Integer

    Public Overrides Function ToString() As String
        Return String.Format("{0} {1} {2:0.0} {3}", Marka.Ime, Model, Potrosuvacka, Cena)
    End Function
End Class
