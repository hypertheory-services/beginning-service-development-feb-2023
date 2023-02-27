

using OnCallDeveloperApi.Adapters;
using OnCallDeveloperApi.Models;

var builder = WebApplication.CreateBuilder(args);

// the builder is the thing we use to configure our application "behind the scenes" - this is mostly hooking up
// services that our is going to need.


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Hey, API, if you run any code that needs an ISystemTime, use this class.
builder.Services.AddSingleton<ISystemTime, SystemTime>();

var app = builder.Build();

// The builder "builds" our configured application - and we can program the "request pipeline here"

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/oncalldeveloper", (ISystemTime systemTime) =>
{
    // if it is during the business time, this what we send
    var now = systemTime.GetCurrent();
    if (now.Hour >= 9 && now.Hour < 17)
    {
        var contact = new OnCallDeveloperContact("Bob", "Smith", "Bob@aol.com", "xt123");
        var response = new OnCallDeveloperResponse(contact);
        // else - we are going to tell them to call the help desk service.
        return Results.Ok(response); // this will return a 200 OK response.
    } else
    {
        var contact = new OnCallServiceResponseContact("Our Help Service", "800 555-5555", "helpdesk@aol.com");
        var response = new OnCallServiceResponse(contact);
        // else - we are going to tell them to call the help desk service.
        return Results.Ok(response); // this will return a 200 OK response.
    }
});

app.Run(); // This is a "Blocking Call"
// It basically starts a loop where it will LISTEN for incoming HTTP requests and try to process them
// until the application is shut down.

