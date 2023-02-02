using ISTQBQuiz.Services;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
AppSettingsService.AppSettingsConfigure(builder.Configuration);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();








