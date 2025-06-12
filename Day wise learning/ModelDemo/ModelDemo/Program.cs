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
    //convention based routing
    endpoints.MapControllerRoute("default","{controller=ProductInfo}/{action=ProductList}/{id?}");
});

app.Run();
