//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
    options.IdleTimeout = TimeSpan.FromDays(2));
var app = builder.Build();
app.UseSession();

app.MapDefaultControllerRoute();

app.Run();

app.Use(async (cont, nex) =>
{

    if (cont.Request.Cookies.ContainsKey("ReqNum"))
    {
       
        int num = int.Parse(cont.Request.Cookies["ReqNum"]);
        cont.Response.Cookies.Append("ReqNum", (++num).ToString());
        switch (num)
        {
            case 10:
                cont.Response.Cookies.Append("Star", "*");
                break;
            case 20:
                cont.Response.Cookies.Append("Star", "**");
                break;
            case 30:
                cont.Response.Cookies.Append("Star", "***");
                break;
            case 40:
                cont.Response.Cookies.Append("Star", "****");
                break;
            case 50:
                cont.Response.Cookies.Append("Star", "*****");
                break;
            default:
                break;
        }
    }
    else
    {
        cont.Response.Cookies.Append("ReqNum", "1");
    }
    await nex();
});
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=employee}");

//app.Run();