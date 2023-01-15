// See https://aka.ms/new-console-template for more information


using Microsoft.Data.SqlClient;

const string connectionString  = "Server=DELLG15\\SQLEXPRESS;Database=balta; Integrated Security =SSPI; TrustServerCertificate=True";
//const string connectionString1 = "Server=DELLG15\\SQLEXPRESS;Database=balta;Trusted_Connection=True;";
//const string connectionString22 = "Data Source=DELLG15\\SQLEXPRESS;Initial Catalog=balta;Database=balta;Trusted_Connection=True;";


using (var conn = new SqlConnection(connectionString))
{
    Console.WriteLine("conectado!");
    conn.Open();
    using (var comamnd = new SqlCommand())
    {
        comamnd.Connection = conn;
        comamnd.CommandType = System.Data.CommandType.Text;
        comamnd.CommandText  = "select [Id], [Title] from [Category]";
        var reader  = comamnd.ExecuteReader();
        while(reader.Read()) {
            Console.WriteLine($"{reader.GetGuid(0) } - {reader.GetString(1)}");
        }
    }
}



Console.WriteLine("Hello, World!");
