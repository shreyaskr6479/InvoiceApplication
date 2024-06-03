using InvoiceApplication.Container;
using InvoiceApplication.Data;
using InvoiceApplication.Handler;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var dbContext = builder.Services.BuildServiceProvider().GetRequiredService<ApplicationDbContext>();

dbContext.Database.Migrate();

builder.Services.AddTransient<ICategoryContainer, CategoryContainer>();
builder.Services.AddTransient<ICustomerContainer, CustomerContainer>();
builder.Services.AddTransient<IProductContainer, ProductContainer>();
builder.Services.AddTransient<IInvoiceItemContainer, InvoiceItemContainer>();

// Configuring the auto mapper.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var automapper = new MapperConfiguration(item => item.AddProfile(new MappingProfile()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();