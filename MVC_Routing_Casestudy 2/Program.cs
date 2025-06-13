var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Default route to go to ContactController and ShowContacts action
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=ABCInfo}/{action=ShowContacts}/{id?}");
});

app.Run();
