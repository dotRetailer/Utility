Namespace Secure
    Public Class Strings
        Private Shared SQLKeywords() As String = {"EXEC", "SELECT", _
                                          "INSERT", "UPDATE", _
                                          "DELETE", "CAST", _
                                          "DECLARE", "NVARCHAR", _
                                          "VARCHAR", "CREATE", _
                                          "DROP"}

        ' Used as a block against injection attacks.
        Private Shared Function Barracade(ByVal Input As String) As String

            Dim sReturn As String = ""
            Dim QS As String = Input
            Dim bFoundKey As Boolean = False
            'Select Case QS

            'End Select

            For Each Keyword As String In SQLKeywords
                If QS.ToUpper().Contains(Keyword) Or QS.Length > 350 And Not bFoundKey Then
                    ' Once a banned key is found then end 
                    bFoundKey = True
                    sReturn = "-"
                End If

            Next
            ' if no key is found then it is ok to continue
            If bFoundKey = False Then
                sReturn = Input
            Else
                sReturn = ""
            End If

            Return sReturn

        End Function

        Public Shared Function Safe(ByVal Input As String, Optional ByVal ParseHTML As Boolean = True) As String
            Try


                Safe = Barracade(Input)
                Dim cSafe As String = Barracade(Input)

                Dim lSafe As String = Safe.ToLower()

                If lSafe.Contains("cast(") Or _
                lSafe.Contains("convert(") Or _
                lSafe.Contains("char(") Or _
                lSafe.Contains("chr(") Or _
                lSafe.Contains("exec(") Then

                    Safe = "-"
                End If



                If ParseHTML Then
                    Safe = Replace(Safe, "<", "")
                    Safe = Replace(Safe, "&#60", "")
                    Safe = Replace(Safe, ">", "")
                    Safe = Replace(Safe, "&#62", "")
                    Safe = Replace(Safe, "&#34", "")
                    Safe = Replace(Safe, "'", "''")
                    Safe = Replace(Safe, "&#38", "")
                    Safe = Replace(Safe, "&", "")
                    Safe = Replace(Safe, ";", "")
                    Safe = Replace(Safe, "#", "")
                    Safe = Replace(Safe, "&#40;", "")
                    Safe = Replace(Safe, "&#41;", "")
                    Safe = Replace(Safe, "&#35;", "")
                    Safe = Replace(Safe, "/", "")
                    Safe = Replace(Safe, "\", "")
                    Safe = Replace(Safe, ".", "")
                End If
            Catch
                Safe = ""
            End Try
        End Function

    End Class

End Namespace
