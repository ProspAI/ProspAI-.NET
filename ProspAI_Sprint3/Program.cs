using Microsoft.OpenApi.Models;
using ProspAI_Sprint3.Data;
using Microsoft.EntityFrameworkCore;
using ProspAI_Sprint3.Repositories;
using ProspAI_Sprint3.Services;
using System.Reflection;
using System.Text.Json.Serialization;
using ProspAI_Sprint3.Models;
using Microsoft.ML;
using System.Data;
using ProspAI_Sprint3.Persistencia.Services;

var builder = WebApplication.CreateBuilder(args);

// Caminho para o arquivo CSV
string dataPath = "Data/funcionario_desempenho.csv";

// Inicializar o MLContext
MLContext mlContext = new MLContext();

// Carregar os dados de treinamento
IDataView dataView = mlContext.Data.LoadFromTextFile<FuncionarioDesempenho>(dataPath, hasHeader: true, separatorChar: ',');

// Criar a pipeline de treinamento
var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "FuncionarioId", "ReclamacoesResp", "DesempenhoGeral" })
    .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "ReclamacoesSolu", featureColumnName: "Features"));

// Treinar o modelo
var model = pipeline.Fit(dataView);

// Salvar o modelo
mlContext.Model.Save(model, dataView.Schema, "Data/ModeloReclamacoes.zip");

// Repositórios
builder.Services.AddScoped<IRepository<Funcionario>, FuncionarioRepository>();
builder.Services.AddScoped<IRepository<Reclamacao>, ReclamacaoRepository>();
builder.Services.AddScoped<IRepository<Desempenho>, DesempenhoRepository>();

// Serviços
builder.Services.AddScoped<IService<Funcionario>, FuncionarioService>();
builder.Services.AddScoped<IService<Reclamacao>, ReclamacaoService>();
builder.Services.AddScoped<IService<Desempenho>, DesempenhoService>();
builder.Services.AddScoped<ReclamacaoPredictionService>();

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
        Description = "API para ProspAI usando Oracle, Microsoft.ML"
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
