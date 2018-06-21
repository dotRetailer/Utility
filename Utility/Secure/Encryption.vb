Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Namespace Security
    Public Class Encryption
        Private Sub New()
        End Sub
        Private Shared keyAndIvBytes As Byte()

        Shared Sub New()
            keyAndIvBytes = UTF8Encoding.UTF8.GetBytes("")
        End Sub

        Public Shared Function ByteArrayToHexString(ba As Byte()) As String
            Return BitConverter.ToString(ba).Replace("-", "")
        End Function

        Public Shared Function StringToByteArray(hex As String) As Byte()
            Return Enumerable.Range(0, hex.Length).Where(Function(x) x Mod 2 = 0).[Select](Function(x) Convert.ToByte(hex.Substring(x, 2), 16)).ToArray()
        End Function

        Public Shared Function DecodeAndDecrypt(cipherText As String, key As String) As String
            Dim Decode As String = AesDecrypt(StringToByteArray(cipherText), key)
            Return (Decode)
        End Function

        Public Shared Function EncryptAndEncode(plaintext As String, key As String) As String
            Return ByteArrayToHexString(AesEncrypt(plaintext, key))
        End Function

        Public Shared Function AesDecrypt(inputBytes As [Byte](), key As String) As String
            Dim outputBytes As [Byte]() = inputBytes
            keyAndIvBytes = UTF8Encoding.UTF8.GetBytes(key)
            Dim plaintext As String = String.Empty

            Using memoryStream As New MemoryStream(outputBytes)
                Using cryptoStream As New CryptoStream(memoryStream, GetCryptoAlgorithm().CreateDecryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Read)
                    Using srDecrypt As New StreamReader(cryptoStream)
                        plaintext = srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using

            Return plaintext
        End Function

        Public Shared Function AesEncrypt(inputText As String, key As String) As Byte()
            Dim inputBytes As Byte() = UTF8Encoding.UTF8.GetBytes(inputText)

            keyAndIvBytes = UTF8Encoding.UTF8.GetBytes(key)
            Dim result As Byte() = Nothing
            Using memoryStream As New MemoryStream()
                Using cryptoStream As New CryptoStream(memoryStream, GetCryptoAlgorithm().CreateEncryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Write)
                    cryptoStream.Write(inputBytes, 0, inputBytes.Length)
                    cryptoStream.FlushFinalBlock()

                    result = memoryStream.ToArray()
                End Using
            End Using

            Return result
        End Function

        Private Shared Function GetCryptoAlgorithm() As RijndaelManaged
            Dim algorithm As New RijndaelManaged()
            'set the mode, padding and block size
            algorithm.Padding = PaddingMode.PKCS7
            algorithm.Mode = CipherMode.CBC
            algorithm.KeySize = 128
            algorithm.BlockSize = 128
            Return algorithm
        End Function

        Public Shared Function HashedString(ByVal sStringToHash As String) As String
            Dim hash, hash1 As String
            Dim sReturn As String = ""
            hash1 = getSha1(sStringToHash)
            hash = computeHash(hash1)
            sReturn = hash
            Return sReturn

        End Function
        Private Shared Function computeHash(ByVal value As String) As String
            Dim result = ""
            Dim valueBytes = Encoding.ASCII.GetBytes(value)
            Dim sha1Alg = SHA1Managed.Create
            Dim resultBytes = sha1Alg.ComputeHash(valueBytes)
            result = BitConverter.ToString(resultBytes).Replace("-", "").ToLower
            Return result
        End Function

        Private Shared Function getSha1(ByVal stringa As String) As String
            Dim result = ""
            Dim ascii = Encoding.ASCII.GetBytes(stringa)
            For Each b In ascii
                result = result & b.ToString("X")
            Next
            Return result.ToLower
        End Function

    End Class
End Namespace
