Imports System.Security.Cryptography

Module Module1

    Sub Main()
        Console.WriteLine("System32's Password Generator")
        Console.WriteLine("------------------")

        Console.WriteLine("Enter password length:")
        Dim length As Integer = Integer.Parse(Console.ReadLine())

        Console.WriteLine("Include lowercase characters? (Y/N)")
        Dim useLowercase As Boolean = (Console.ReadLine().ToUpper() = "Y")

        Console.WriteLine("Include uppercase characters? (Y/N)")
        Dim useUppercase As Boolean = (Console.ReadLine().ToUpper() = "Y")

        Console.WriteLine("Include numbers? (Y/N)")
        Dim useNumbers As Boolean = (Console.ReadLine().ToUpper() = "Y")

        Console.WriteLine("Include special characters? (Y/N)")
        Dim useSpecial As Boolean = (Console.ReadLine().ToUpper() = "Y")

        Console.WriteLine("Generating password...")

        Dim password As String = GeneratePassword(length, useLowercase, useUppercase, useNumbers, useSpecial)

        Console.WriteLine("Password: " + password)
        Console.ReadLine()
    End Sub

    Private Function GeneratePassword(length As Integer, useLowercase As Boolean, useUppercase As Boolean, useNumbers As Boolean, useSpecial As Boolean) As String
        Dim chars As String = ""
        If useLowercase Then
            chars += "abcdefghijklmnopqrstuvwxyz"
        End If
        If useUppercase Then
            chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        End If
        If useNumbers Then
            chars += "0123456789"
        End If
        If useSpecial Then
            chars += "!@#$%^&*?"
        End If

        Dim password As New Char(length - 1) {}
        Dim data(0) As Byte

        Using crypto As New RNGCryptoServiceProvider()
            For i As Integer = 0 To length - 1
                crypto.GetBytes(data)
                password(i) = chars(data(0) Mod chars.Length)
            Next
        End Using

        Return New String(password)
    End Function

End Module
