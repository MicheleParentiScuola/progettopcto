using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages();

var app = builder.Build();

DatabaseTest dt = new DatabaseTest("Server=localhost;Database=library;Integrated Security=True;TrustServerCertificate=True");
dt.TestConnection();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

public class DatabaseTest
{
    private string _connectionString;

    // Passa la stringa di connessione come parametro
    public DatabaseTest(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Metodo per testare la connessione
    public void TestConnection()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Open(); // Prova a aprire la connessione
                Console.WriteLine("Connessione riuscita al database!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la connessione: {ex.Message}");
            }
        }
    }
}

