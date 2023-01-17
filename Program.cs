// See https://aka.ms/new-console-template for more information


using BaltaDataAcess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=DELLG15\\SQLEXPRESS;Database=balta; Integrated Security =SSPI; TrustServerCertificate=True";
//const string connectionString1 = "Server=DELLG15\\SQLEXPRESS;Database=balta;Trusted_Connection=True;";
//const string connectionString22 = "Data Source=DELLG15\\SQLEXPRESS;Initial Catalog=balta;Database=balta;Trusted_Connection=True;";


using (var connection = new SqlConnection(connectionString))
{
    Console.WriteLine("conectado!");
    connection.Open();


    using (var comamnd = new SqlCommand())
    {
        UpdateCatagory(connection);

        ListCategories(connection);

    }
}

static void ListCategories(SqlConnection connection)
{
    var categories = connection.Query<Category>("Select [Id],[Title] from [Category]");

    foreach (var categorie in categories)
    {
        Console.WriteLine($"{categorie.Id} - {categorie.Title}");
    }
}

static void CreateCategory(SqlConnection connection)
{

    var category = new Category();
    category.Description = "Amazon AWS  sw2";
    category.Featured = false;
    category.Id = Guid.NewGuid();
    category.Order = 8;
    category.Summary = "AWS amaxon2";
    category.Title = "Amazon server2";
    category.Url = "amazon2";


    var insertSql = "INSERT INTO [Category] values (@Id, @Title, @Url, @Summary , @Order ,@Description ,@Featured)";
    var rows = connection.Execute(insertSql, new
    {
        category.Description,
        category.Featured,
        category.Id,
        category.Order,
        category.Summary,
        category.Title,
        category.Url,
    });
    Console.WriteLine($"{rows} linhas inseridas ");
}

static void UpdateCatagory(SqlConnection connection)
{
    var updateQuery = "Update [Category] set [Title]=@title where [Id]=@id";

    var rows = connection.Execute(updateQuery, new
    {
        id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
        title = "Front End  2023 "
    });
    Console.WriteLine($"{rows} +  registros atualizados");
}


