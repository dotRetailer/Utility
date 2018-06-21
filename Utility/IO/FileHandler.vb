Imports System.IO
Imports System.Web

Namespace IO
    Public Class FileHandler

        Public Shared Function FileUpload(UploadFile As HttpPostedFileBase, ByVal sFileRoot As String, ByVal sFileNamePrefix As String, ByVal sFileName As String, ByVal sFileExtension As String) As Boolean
            Dim fullFileName As String = ""
            Dim bResponse As Boolean = False
            fullFileName = sFileNamePrefix & sFileName & sFileExtension
            Dim sFullPathIncludingFile = Path.Combine(sFileRoot, fullFileName)
            Try
                UploadFile.SaveAs(sFullPathIncludingFile)
                bResponse = True
            Catch ex As Exception
                bResponse = False
            End Try
            Return bResponse
        End Function

        Public Shared Function DeleteFile(ByVal FilePath As String) As Boolean
            Dim bResponse As Boolean = False
                If File.Exists(FilePath) Then
                    Try
                    File.Delete(FilePath)
                        bResponse = True
                    Catch ex As Exception
                        bResponse = False
                    End Try
                Else
                bResponse = True
            End If
            Return bResponse
        End Function

    End Class
End Namespace

