var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Doctores}/{action=Index}");

//app.MapControllerRoute(
//    name: "seguridad",
//    pattern: "seguridad{controller=Security}/{action=Login");

//app.MapGet("/", () => "Hello World!");

app.Run();
