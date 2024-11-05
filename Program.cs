////using OurProject.Data;
////using OurProject.Services;
////using Microsoft.Extensions.Options;
////using MongoDB.Driver;

////var builder = WebApplication.CreateBuilder(args);

////builder.Services.AddControllers();
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

////builder.Services.AddSingleton<MongoDBContext>();

////builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
////{
////    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
////    return new MongoClient(settings.ConnectionString);
////});

////builder.Services.AddSingleton(sp =>
////{
////    var client = sp.GetRequiredService<IMongoClient>();
////    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
////    return client.GetDatabase(settings.DatabaseName);
////});

////builder.Services.AddSingleton<AuthenticationService>();

////var app = builder.Build();

////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseHttpsRedirection();
////app.UseAuthorization();

////app.MapControllers();

////app.Run();



//using OurProject.Data;
//using OurProject.Services;
//using Microsoft.Extensions.Options;
//using MongoDB.Driver;

//var builder = WebApplication.CreateBuilder(args);

//// Configure CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontendOrigin", policy =>
//    {
//        policy.WithOrigins("http://localhost:5173") // Update this to match your frontend's URL
//              .AllowAnyHeader()
//              .AllowAnyMethod()
//              .AllowCredentials(); // Include this if you are using cookies or credentials
//    });
//});

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
//builder.Services.AddSingleton<MongoDBContext>();
//builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
//{
//    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
//    return new MongoClient(settings.ConnectionString);
//});
//builder.Services.AddSingleton(sp =>
//{
//    var client = sp.GetRequiredService<IMongoClient>();
//    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
//    return client.GetDatabase(settings.DatabaseName);
//});
//builder.Services.AddSingleton<AuthenticationService>();
//builder.Services.AddSingleton<AssignmentService>();
//builder.Services.AddSingleton<AssignmentSubmissionService>();



//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// Apply CORS Middleware
//app.UseCors("AllowFrontendOrigin");

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.Run();



using OurProject.Data;
using OurProject.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Update this to match your frontend's URL
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Include if using cookies/credentials
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB Configuration
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<MongoDBContext>();
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});
builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return client.GetDatabase(settings.DatabaseName);
});

// Services
builder.Services.AddSingleton<AuthenticationService>();
builder.Services.AddSingleton<AssignmentService>();
builder.Services.AddSingleton<AssignmentSubmissionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Middleware
app.UseCors("AllowFrontendOrigin");

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
