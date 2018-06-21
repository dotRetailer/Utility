Namespace Finance
    Public Class Currency

        Public Shared Function CurrencyConvert(ByVal amount As Decimal, ByVal exchangeRate As Decimal, ByVal ceilingRate As Decimal) As Decimal
            Dim convertedAmount As Decimal = amount
            If exchangeRate <> 1.0 Then
                convertedAmount = amount * exchangeRate

                If ceilingRate > 0 Then
                    Dim pointValue As Decimal = (convertedAmount - Math.Floor(convertedAmount))
                    Dim remainingValue As Decimal = (pointValue Mod ceilingRate)
                    Dim updateValue As Decimal = Math.Floor(pointValue / ceilingRate)

                    If pointValue > ceilingRate And (ceilingRate * 2 >= 1) Then
                        convertedAmount = Math.Ceiling(convertedAmount)
                    Else
                        convertedAmount = Math.Floor(convertedAmount) + ((Math.Ceiling(remainingValue) + updateValue) * ceilingRate)
                    End If
                End If
            End If
            Return FormatNumber(convertedAmount, 2)
        End Function

        Public Shared Function GetFormattedCurrency(amount As Decimal, Optional decimalPlaces As Integer = 2) As Decimal
            Return FormatNumber(amount, decimalPlaces)
        End Function

    End Class
End Namespace
