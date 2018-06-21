Imports System.Web.Security


Public Class Authentication

    'Public Shared Function Login(username As String, password As String, persistAsCookie As Boolean)
    '    Dim loggedIn As Boolean = False

    '    Dim validLogin As Boolean = BusinessLayer.User.Security.LogOnUser(username, password)
    '    If validLogin Then
    '        FormsAuthentication.SetAuthCookie(username, persistAsCookie)
    '        loggedIn = True
    '    End If


    '    Return loggedIn
    'End Function

    'Public Shared Function CreateUserAndAccount(username As String, password As String) As String
    '    Dim accountCreated As Boolean = BusinessLayer.User.Security.CreateUserAccount(username, password)
    '    If accountCreated Then
    '        Return "Account successfully created"
    '    Else
    '        Return String.Empty
    '    End If

    'End Function

End Class
