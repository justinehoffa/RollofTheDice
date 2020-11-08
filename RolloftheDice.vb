'Justine Hoffa
'RCET0265
'Fall2020
'RolloftheDice
'https://github.com/justinehoffa/RollofTheDice

Option Strict Off
Option Explicit On
Option Compare Text

Module RolloftheDice 'PascalCase - TJR

    Sub Main()

        Randomize() ' This should go in the random number method - TJR
        Dim randomNumber As Integer
        Dim digits As String

        Console.BackgroundColor = ConsoleColor.DarkMagenta
        Console.ForegroundColor = ConsoleColor.White
        Console.SetWindowSize(135, 8)
        Console.WriteLine("                                                         Roll of the Dice") ' Use padleft or strdup - TJR
        Console.WriteLine("                                         Press enter to roll the dice. Press Q to quit.")

        If Console.ReadKey().Key = ConsoleKey.Q Then
            Exit Sub
        End If

        Do
            Dim data(10) As Integer
            Console.WriteLine("                                                         Roll of the Dice")
            Console.WriteLine("                                         Press enter to roll the dice again. Press Q to quit.")
            For i = 1 To 1000
                randomNumber = CInt(GetRandomNumber(1, 6))
                data(randomNumber - 2) += 1
            Next

            Console.Write(vbTab & StrDup(116, "-"))
            Console.WriteLine()
            Console.Write(vbTab & "Rollable Numbers:")
            For i = 2 To 12
                digits = String.Format("{0, 8}", i) & "|"
                Console.Write(digits)
            Next
            Console.WriteLine()

            Console.Write(vbTab & StrDup(116, "-"))
            Console.WriteLine()

            Console.Write(vbTab & "Times Rolled:    ")
            For i = 0 To 10
                digits = String.Format("{0,8}", data(i)) & "|"
                Console.Write(digits)
            Next
            Console.WriteLine()
            Console.Write(vbTab & StrDup(116, "-"))
            Console.WriteLine()

            If Console.ReadKey().Key = ConsoleKey.Q Then
                Exit Sub
            End If

            Erase data
            Console.Clear()
            Console.WriteLine("                                                         Roll of the Dice")
            Console.WriteLine("                                         Press enter to roll the dice again. Press Q to quit.")

        Loop
    End Sub
    Function GetRandomNumber(ByVal minimum As Single, ByVal maximum As Single) As Single

        Dim value1, value2 As Single
        Dim sum As Integer

        Do
            value1 = (maximum * Rnd()) + 0.5
            value2 = (maximum * Rnd()) + 0.5
        Loop While value1 < minimum - 0.5 Or value1 >= maximum + 0.5 Or
            value2 < minimum - 0.5 Or value2 >= maximum + 0.5

        sum = CInt(value1) + CInt(value2)
        Return sum

    End Function

End Module
