Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Marka

    Public Property Ime As String
    Public Property Sifra As String

    Public Overrides Function toString() As String
        Return String.Format("{0} ({1})", Ime, Sifra)
    End Function

End Class
