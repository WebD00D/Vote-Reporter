Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Security.Cryptography

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
 Public Class UserManagementService
    Inherits System.Web.Services.WebService

    Public Class VRUser

        Public UserID As Integer
        Public FirstName As String
        Public LastName As String
        Public UserName As String
        Public Type As String
        Public Chamber As String

    End Class
    Shared UserList As New List(Of VRUser)() From {}

    <WebMethod()> _
    Public Function GetAllUsers()

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim da As New SqlDataAdapter("SELECT * FROM Users", con)
        Dim ds As New DataSet("Users")
        da.Fill(ds, "Users")

        UserList.Clear()

        For Each item As DataRow In ds.Tables(0).Rows()
            Dim u As New VRUser()
            u.UserID = item("ID")
            u.FirstName = item("FirstName")
            u.LastName = item("LastName")
            u.UserName = item("Username")
            u.Type = item("Type")
            ' u.Chamber = item("ChamberCode")
            UserList.Add(u)
        Next

        Return UserList
    End Function

    <WebMethod()> _
    Public Function GetHash(ByVal Hash As MD5, ByVal Input As String)

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = Hash.ComputeHash(Encoding.UTF8.GetBytes(Input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string. 
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()

    End Function

    <WebMethod()> _
    Public Function UnHashIt(ByVal hashOfInput As String, ByVal ControlHash As String)

        ' Hash the input. 
        ' Dim hashOfInput As String = GetHash(md5Hash, input)

        ' Create a StringComparer an compare the hashes. 
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, ControlHash) Then
            Return True
        Else
            Return False
        End If


    End Function




    <WebMethod(EnableSession:=True)> _
    Public Function CreateUser(ByVal first As String, ByVal last As String, ByVal username As String, ByVal type As Integer, ByVal chamber As Integer, ByVal password As String)

        Dim hash As String
        Using md5Hash As MD5 = MD5.Create()
            hash = GetHash(md5Hash, password)
        End Using


        Dim returnVal = Nothing
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            Dim cmd As New SqlCommand
            With cmd
                .Connection = con
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sp_VRUser_Create"
                .Parameters.AddWithValue("@first", first)
                .Parameters.AddWithValue("@last", last)
                .Parameters.AddWithValue("@username", username)
                .Parameters.AddWithValue("@type", type)
                .Parameters.AddWithValue("@password", hash)
                .Parameters.AddWithValue("@createDate", Date.Now)
                .Connection.Open()
                .ExecuteNonQuery()
            End With
            returnVal = 1
            Session("NewUserCreated") = 1

        Catch ex As Exception
            'To Do : Create Error Logging Class
            returnVal = 0
            Session("NewUserCreated") = 0
        End Try

        Return returnVal
    End Function


    <WebMethod()> _
    Public Function UpdateUser(ByVal PersonID As Integer, ByVal FirstName As String, ByVal LastName As String, ByVal Username As String, ByVal Type As Integer, ByVal Chamber As String, ByVal Password As String, ByVal PasswordFlag As Boolean)

        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
            Dim cmd As New SqlCommand
            With cmd
                .Connection = con
                .Connection.Open()
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sp_VRUser_Update"
                .Parameters.AddWithValue("@PersonID", PersonID)
                .Parameters.AddWithValue("@first", FirstName)
                .Parameters.AddWithValue("@last", LastName)
                .Parameters.AddWithValue("@User", Username)
                .Parameters.AddWithValue("@Type", Type)

                'Dim chambervalue As String = String.Empty
                'Select Case Chamber
                '    Case 1
                '        chambervalue = "H"
                '    Case 2
                '        chambervalue = "S"
                '    Case Else
                '        chambervalue = "NA"
                'End Select

                '   .Parameters.AddWithValue("@Chamber", Chamber)
                .Parameters.AddWithValue("@PassBool", CByte(PasswordFlag))
                .Parameters.AddWithValue("@Password", Password)
                .ExecuteNonQuery()
                .Connection.Close()
            End With

        Catch ex As Exception
            'To Do: Add error handling class
        End Try

        Return ""
    End Function

    <WebMethod()> _
    Public Function DeleteUser(ByVal Person As Integer)
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("VRDB").ConnectionString)
        Dim cmd As New SqlCommand
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_VRUser_Delete"
            .Connection = con
            .Connection.Open()
            .Parameters.AddWithValue("@PersonID", Person)
            .ExecuteNonQuery()
            .Connection.Close()
        End With

        Return ""
    End Function


End Class