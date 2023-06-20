using Excercise_2_Data_Access_Layer.Data.DbContexts;
using Excercise_2_Business_Logic_Layer.Node_BLL;
using Microsoft.EntityFrameworkCore;
using Excercise_2_Data_Access_Layer.DAL;
using Excercise_2_Business_Logic_Layer.NodeAttributeBLL;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Excercise2");

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});
builder.Services.AddDbContext<NodeDbContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Excercise_2_API"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<INodeRepository, NodeRepository>();
builder.Services.AddScoped<INodeDAL, NodeDAL>();
builder.Services.AddScoped<INodeAttributeDAL,  NodeAttributeDAL>();
builder.Services.AddScoped<INodeAttributeRepository ,  NodeAttributeRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
