using Microsoft.OpenApi.Models;
using ProspAI_Sprint3.Data;
using Microsoft.EntityFrameworkCore;
using ProspAI_Sprint3.Repositories;
using ProspAI_Sprint3.Services;
using System.Reflection;
using System.Text.Json.Serialization;
using ProspAI_Sprint3.Models;

var builder = WebApplication.CreateBuilder(args);

// Repositórios
builder.Services.AddScoped<IRepository<Funcionario>, FuncionarioRepository>();
builder.Services.AddScoped<IRepository<Reclamacao>, ReclamacaoRepository>();
builder.Services.AddScoped<IRepository<Desempenho>, DesempenhoRepository>();

// Serviços
builder.Services.AddScoped<IService<Funcionario>, FuncionarioService>();
builder.Services.AddScoped<IService<Reclamacao>, ReclamacaoService>();
builder.Services.AddScoped<IService<Desempenho>, DesempenhoService>();

// Contexto do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAP")));

// Configuração do Serializador JSON para ignorar ciclos
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Adicionando controllers
builder.Services.AddControllers();

// Configurando Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ProspAI API",
        Version = "v1",
        Description = "API para ProspAI usando Oracle"
    });

    // Definindo o caminho dos comentários XML para o Swagger
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configurando o pipeline de requisições HTTP

// Middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProspAI API v1");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
