using EmployeesApi;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var oncallDeveloperUri = builder.Configuration.GetValue<string>("developer-api");
if(oncallDeveloperUri == null)
{
    // don't start this api! This isn't set.
    throw new ApplicationException("Can't start API, no URI for the Developer API");
}
// one of these PER adadpter
builder.Services.AddHttpClient<OnCallDeveloperHttpAdapter>(client =>
{
    client.BaseAddress = new Uri(oncallDeveloperUri); // BAD DON'T DO THIS.
})
    .AddPolicyHandler(SrePolicies.GetDefaultRetryPolicy())
.AddPolicyHandler(SrePolicies.GetDefaultCircuitBreaker());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// This line Jeff Was Here Hello World
app.Run();
