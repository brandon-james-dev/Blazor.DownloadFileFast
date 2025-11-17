var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddRazorPages();

var app = builder.Build();

// Middleware configuration
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/myapp"), myapp =>
{
    myapp.UseRouting();
    myapp.UseBlazorFrameworkFiles("/myapp");
    myapp.UseStaticFiles("/myapp");
    myapp.UsePathBase("/myapp/");
    myapp.UseEndpoints(endpoints =>
    {
        endpoints.MapFallbackToFile("/myapp/{*path:nonfile}", "/myapp/index.html");
    });
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
