using WebApplication2;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true)
    .AddIniFile("appsettings.ini", optional: true, reloadOnChange: true)
    .AddJsonFile("personalsettings.json", optional: true, reloadOnChange: true);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<CompanyService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.Run();
