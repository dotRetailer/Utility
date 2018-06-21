Imports System.Text.RegularExpressions

Namespace Common

    Public Class CommonFunctions

        Public Shared Function CreateGUID() As Guid
            Return Guid.NewGuid()
        End Function

        Public Shared Function IsGuid(ByVal GUID As String) As Boolean
            Dim guidRegex As Regex = New Regex("^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled)
            If guidRegex.IsMatch(GUID) Then
                Return True
            Else
                Return False
            End If

        End Function
        ''' <summary>
        ''' Remove HTML Tags from String
        ''' </summary>
        ''' <param name="source"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function RemoveHTMLTags(source As String) As String
            Dim expn As String = "<.*?>"
            Return Regex.Replace(source, expn, String.Empty)
        End Function

        Public Shared Function IsValidEmailAddress(emailaddress As String) As Boolean
            Dim emailRegex As Regex = New Regex("^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", RegexOptions.Compiled)
            If emailRegex.IsMatch(emailaddress) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Shared Function Safe(ByVal Input As String, Optional ByVal ParseHTML As Boolean = True) As String
            Try

                Safe = Input
                Dim cSafe As String = Input

                Dim lSafe As String = Safe.ToLower()

                If lSafe.Contains("cast(") Or _
                lSafe.Contains("convert(") Or _
                lSafe.Contains("char(") Or _
                lSafe.Contains("chr(") Or _
                lSafe.Contains("<script>") Or _
                lSafe.Contains("</script>") Or _
                lSafe.Contains("delete") Or _
                lSafe.Contains("update") Or _
                lSafe.Contains("modify") Or _
                lSafe.Contains("create") Or _
                lSafe.Contains("exec(") Then


                    Safe = "-"
                End If


                If ParseHTML Then
                    Safe = Replace(Safe, "&lt", "")
                    Safe = Replace(Safe, "&#60", "")
                    Safe = Replace(Safe, "&gt", "")
                    Safe = Replace(Safe, "&#62", "")
                    Safe = Replace(Safe, "&amp", "")
                    Safe = Replace(Safe, "&#34", "")
                    Safe = Replace(Safe, "&#38", "")
                    Safe = Replace(Safe, "&nbsp;", "")
                    Safe = Replace(Safe, "&#40;", "")
                    Safe = Replace(Safe, "&#41;", "")
                    Safe = Replace(Safe, "&#35;", "")
                    Safe = Replace(Safe, "/", "")
                    Safe = Replace(Safe, "\", "")
                    Safe = Replace(Safe, ".", "")
                    Safe = Replace(Safe, ",", "")

                End If
            Catch
                Safe = ""
            End Try
        End Function
        Public Shared Function RelaxedSafe(ByVal Input As String, Optional ByVal ParseHTML As Boolean = True) As String
            Try

                RelaxedSafe = Input
                Dim cSafe As String = Input

                Dim lSafe As String = RelaxedSafe.ToLower()

                If lSafe.Contains("cast(") Or _
                lSafe.Contains("convert(") Or _
                lSafe.Contains("char(") Or _
                lSafe.Contains("chr(") Or _
                lSafe.Contains("<script>") Or _
                lSafe.Contains("</script>") Or _
                lSafe.Contains("delete") Or _
                lSafe.Contains("update") Or _
                lSafe.Contains("modify") Or _
                lSafe.Contains("create") Or _
                lSafe.Contains("exec(") Then


                    RelaxedSafe = "-"
                End If


                If ParseHTML Then
                    RelaxedSafe = Replace(RelaxedSafe, "&lt", "")
                    RelaxedSafe = Replace(RelaxedSafe, "&#60", "")
                    RelaxedSafe = Replace(RelaxedSafe, "&gt", "")
                    RelaxedSafe = Replace(RelaxedSafe, "&#62", "")
                    RelaxedSafe = Replace(RelaxedSafe, "&amp", "")
                    RelaxedSafe = Replace(RelaxedSafe, "&#34", "")
                    RelaxedSafe = Replace(RelaxedSafe, "&#38", "")


                    RelaxedSafe = Replace(RelaxedSafe, "&nbsp;", "")
                    RelaxedSafe = Replace(RelaxedSafe, "&#40;", "")
                    RelaxedSafe = Replace(RelaxedSafe, "&#41;", "")
                    RelaxedSafe = Replace(RelaxedSafe, "&#35;", "")
                    RelaxedSafe = Replace(RelaxedSafe, "\", "")
                    RelaxedSafe = Replace(RelaxedSafe, ",", "")

                End If
            Catch
                RelaxedSafe = ""
            End Try
        End Function

    End Class

End Namespace
