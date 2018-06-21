Namespace Internationalisation
    Public Class Formatting

        Public Shared Function DateTimeFormat24(ByVal current As DateTime, ByVal locale As String) As String
            Dim formatted As String = Nothing
            formatted = FormatDateTime(current, DateFormat.LongDate).ToString & " " & FormatDateTime(current, DateFormat.ShortTime).ToString
            Return formatted
        End Function
    End Class
End Namespace

