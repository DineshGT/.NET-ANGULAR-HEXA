var builder = WebApplication.CreateBuilder(args);

// MVC views + HttpClient
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Cookie authentication
builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", options =>
    {
        options.Cookie.Name = "AdminLoginCookie";
        options.LoginPath = "/Admin/Login";
        options.AccessDeniedPath = "/Admin/AccessDenied";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Login}/{id?}");

app.UseDeveloperExceptionPage(); // Add this just before app.Run()

app.Run();
