// See https://aka.ms/new-console-template for more information


using BaltaDataAcess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=DELLG15\\SQLEXPRESS;Database=balta; Integrated Security =SSPI; TrustServerCertificate=True";
//const string connectionString1 = "Server=DELLG15\\SQLEXPRESS;Database=balta;Trusted_Connection=True;";
//const string connectionString22 = "Data Source=DELLG15\\SQLEXPRESS;Initial Catalog=balta;Database=balta;Trusted_Connection=True;";


using (var conn = new SqlConnection(connectionString))
{
    Console.WriteLine("conectado!");
    conn.Open();

    var category = new Category();
    category.Description = "Amazon AWS  sw";
    category.Featured = false;
    category.Id = Guid.NewGuid();
    category.Order = 8;
    category.Summary = "AWS amaxon";
    category.Title = "Amazon server";
    category.Url = "amazon";


    var insertSql = "INSERT INTO [Category] values (@Id, @Title, @Url, @Summary , @Order ,@Description ,@Featured)";

    using (var comamnd = new SqlCommand())
    {

      var rows =   conn.Execute(insertSql, new
        {
            category.Description,
        category.Featured ,
        category.Id ,
        category.Order ,
        category.Summary ,
        category.Title ,
        category.Url ,
    });
Console.WriteLine($"{rows} linhas inseridas ");
        var categories = conn.Query<Category>("Select [Id],[Title] from [Category]");

    foreach (var categorie in categories)
    {
        Console.WriteLine($"{categorie.Id} - {categorie.Title}");
    }

}
}



Console.WriteLine("Hello, World!");
