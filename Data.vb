Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Data


    Public Function GetConnection()

        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("connex").ConnectionString)
        Return con

    End Function


End Class
