Imports System.Text.RegularExpressions
Imports System.Globalization

Namespace Display
    ''' <summary>
    ''' Image Manipulation
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DisplayFunctions
        Public Enum SizeType


            Small = 0
            Medium = 1
            Large = 2


        End Enum
        Public Shared Function GetImageURL(ByVal nRootPLUID As Integer, ByVal nColourCode As Integer, ByVal imgType As SizeType, ByVal sBaseURL As String, Optional ByVal View As Integer = 0) As String

            Dim sResponse As String = ""
            sResponse = sBaseURL & GetImageName(imgType, nRootPLUID, nColourCode, View)

            Return sResponse

        End Function




        Public Shared Function GetImageName(ByVal Size As SizeType, ByVal RootPluID As String, ByVal ColourCode As String, ByVal ImageView As String) As String
            Dim sResponse As String = ""
            Try

                Dim RootPluRange As String = Left(RootPluID.ToString(), 1)
                Dim RootPluPad As String = RootPluID.PadLeft(6, "0")
                Dim ColourCodePad As String = ColourCode.PadLeft(3, "0")

                Dim SizeType As Char = _ToChar(Size)

                sResponse = SizeType & "\" & RootPluRange & "\" & SizeType & ImageView & "000" & RootPluPad & ColourCodePad & ".jpg"

            Catch
                sResponse = ""
            End Try
            Return sResponse
        End Function

        Private Shared Function _ToChar(ByVal Size As SizeType) As Char
            Dim sResponse As Char = ""
            Select Case Size

                Case SizeType.Small
                    sResponse = "S"

                Case SizeType.Medium
                    sResponse = "M"

                Case SizeType.Large
                    sResponse = "L"


            End Select
            Return sResponse
        End Function

        Public Shared Function TweetToHTML(ByVal sTweet As String) As String
            Dim sResponse As String = ""

            sResponse = ScreenName(MakeLink(HashTag(sTweet).ToString).ToString).ToString
            sResponse = Replace(sResponse, "~~~~~", "https://twitter.com/search?q=%23")
            sResponse = Replace(sResponse, "*****", "https://twitter.com/")

            Return sResponse

        End Function

        Public Shared Function MakeLink(ByVal txt As String) As String
            Dim regx As New Regex("(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?", RegexOptions.IgnoreCase)

            Dim mactches As MatchCollection = regx.Matches(txt)

            For Each match As Match In mactches
                txt = txt.Replace(match.Value, "<a href='" & match.Value & "'>" & match.Value & "</a>")
            Next

            Return txt
        End Function

        Public Shared Function HashTag(ByVal txt As String) As String
            Dim regx As New Regex("(#)((?:[A-Za-z0-9-_]*))", RegexOptions.IgnoreCase)

            Dim mactches As MatchCollection = regx.Matches(txt)

            For Each match As Match In mactches
                txt = txt.Replace(match.Value, "<a href='" & "~~~~~" & Replace(match.Value, "#", "") & "'>" & match.Value & "</a>")

            Next

            Return txt
        End Function

        Public Shared Function ScreenName(ByVal txt As String) As String
            Dim regx As New Regex("(@)((?:[A-Za-z0-9-_]*))", RegexOptions.IgnoreCase)

            Dim mactches As MatchCollection = regx.Matches(txt)

            For Each match As Match In mactches
                txt = txt.Replace(match.Value, "<a href='" & "*****" & Replace(match.Value, "@", "") & "'>" & match.Value & "</a>")

            Next

            Return txt
        End Function
        Public Shared Function TimeDifference(ByVal sDateTime As String) As String
            Dim sResponse As String = ""
            Dim TwitterDate As Date = Date.ParseExact(sDateTime, "ddd MMM dd HH:mm:ss zzz yyyy", CultureInfo.InvariantCulture)

            sResponse = ReturnTimeInterval(DateDiff(DateInterval.Minute, TwitterDate, Now()))

            Return sResponse
        End Function

        Public Shared Function ReturnTimeInterval(ByVal nMinutes As Integer) As String
            Dim sResponse As String = ""
            Dim t As New TimeSpan(0, nMinutes, 0)
            Select Case nMinutes
                Case Is < 60
                    sResponse = nMinutes & " mins ago"
                Case Is < 120
                    sResponse = t.Hours & " hr + " & t.Minutes & " mins ago"
                Case Is < 1440
                    sResponse = t.Hours & " hrs + " & t.Minutes & " mins ago"
                Case Is < 2880
                    sResponse = t.Days & " day + " & t.Hours & " hrs ago"
                Case Else
                    sResponse = t.Days & " days + " & t.Hours & " hrs ago"
            End Select
            Return sResponse

        End Function

    End Class
End Namespace

