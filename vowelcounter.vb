Imports System

Module Program
    Sub Main()
        ' Get user input for the string
        Console.WriteLine("Enter a string: ")
        Dim inputString As String = Console.ReadLine()

        ' Initialize the count for each vowel
        Dim aCount As Integer = 0
        Dim eCount As Integer = 0
        Dim iCount As Integer = 0
        Dim oCount As Integer = 0
        Dim uCount As Integer = 0

        ' Iterate through the input string
        For Each c As Char In inputString
            ' Check if the current character is a vowel
            Select Case Char.ToLower(c)
                Case "a"
                    aCount += 1
                Case "e"
                    eCount += 1
                Case "i"
                    iCount += 1
                Case "o"
                    oCount += 1
                Case "u"
                    uCount += 1
            End Select
        Next

        ' Print the number of vowels found
        Console.WriteLine("Number of vowels found:")
        Console.WriteLine("A: " & aCount)
        Console.WriteLine("E: " & eCount)
        Console.WriteLine("I: " & iCount)
        Console.WriteLine("O: " & oCount)
        Console.WriteLine("U: " & uCount)
    End Sub
End Module
