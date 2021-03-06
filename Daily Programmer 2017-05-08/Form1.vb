﻿Public Class Form1

	Sub Calculate() Handles SubmitButton.Click
		Dim numbers As String() = Input.Text.Split({" "c})

		Dim compare As Comparison(Of String) =
			Function(x As String, y As String)
				For i As Integer = 0 To Math.Min(x.Length, y.Length) - 1
					Dim xInt As Integer = Val(x.Chars(i))
					Dim yInt As Integer = Val(y.Chars(i))

					If xInt <> yInt Then
						Return xInt - yInt
					End If
				Next

				If x.Length = y.Length Then
					Return 0
				End If

				Dim result As Integer
				If x.Length > y.Length Then
					result = compare(x.Substring(y.Length), y)
				Else
					result = compare(x, y.Substring(x.Length))
				End If
				Return result
			End Function

		Array.Sort(numbers, compare)

		Dim message As String = "Least: " + String.Join(String.Empty, numbers) + vbNewLine
		Array.Reverse(numbers)
		message += "Greatest: " + String.Join(String.Empty, numbers)

		MessageBox.Show(message)
	End Sub

End Class
