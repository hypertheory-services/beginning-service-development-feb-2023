var builder = WebApplication.CreateBuilder(args);

// the builder is the thing we use to configure our application "behind the scenes" - this is mostly hooking up
// services that our is going to need.


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// The builder "builds" our configured application - and we can program the "request pipeline here"

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/oncalldeveloper", () =>
{
    return Results.Ok(); // this will return a 200 OK response.
});

app.Run(); // This is a "Blocking Call"
// It basically starts a loop where it will LISTEN for incoming HTTP requests and try to process them
// until the application is shut down.

