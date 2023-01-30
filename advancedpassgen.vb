Imports System
Imports System.Text

Module AdvancedPasswordGenerator

    Dim names As String() = {"John", "Jane", "Tom", "Sophie", "Michael", "Emma", "William", "Olivia", "James", "Isabella"}

    Sub Main()
        Console.WriteLine("System32's Advanced Password Generator")
        Console.WriteLine("---------------------------")
        Console.Write("Enter password length: ")
        Dim length As Integer = Convert.ToInt32(Console.ReadLine())
        Console.Write("Include lowercase letters (y/n): ")
        Dim useLowercase As Boolean = (Console.ReadLine().ToLower() = "y")
        Console.Write("Include uppercase letters (y/n): ")
        Dim useUppercase As Boolean = (Console.ReadLine().ToLower() = "y")
        Console.Write("Include numbers (y/n): ")
        Dim useNumbers As Boolean = (Console.ReadLine().ToLower() = "y")
        Console.Write("Include special characters (y/n): ")
        Dim useSpecial As Boolean = (Console.ReadLine().ToLower() = "y")

        Dim password As String = GeneratePasswordWithRandomName(length, useLowercase, useUppercase, useNumbers, useSpecial)

        Console.WriteLine("Your password is: " + password)
    End Sub

    Function GeneratePassword(length As Integer, useLowercase As Boolean, useUppercase As Boolean, useNumbers As Boolean, useSpecial As Boolean) As String
        Dim validChars As String = ""
        If useLowercase Then validChars += "abcdefghijklmnopqrstuvwxyz"
        If useUppercase Then validChars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        If useNumbers Then validChars += "0123456789"
        If useSpecial Then validChars += "!@#$%^&*?"

        Dim password As String = ""
        Dim random As New Random()
        For i As Integer = 0 To length - 1
            password += validChars(random.Next(0, validChars.Length))
        Next
        Return password
    End Function

    Function GeneratePasswordWithRandomName(length As Integer, useLowercase As Boolean, useUppercase As Boolean, useNumbers As Boolean, useSpecial As Boolean) As String
        Dim random As New Random()
        Dim randomName As String = names(random.Next(0, names.Length))

        Dim password As String = GeneratePassword(length, useLowercase, useUppercase, useNumbers, useSpecial)

        Return randomName + password
    End Function

End Module
