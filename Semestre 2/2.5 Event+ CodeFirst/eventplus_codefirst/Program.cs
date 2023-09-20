using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                // Ignora os loopings nas consultas
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // Ignora valores nulos ao fazer junções nas consultas
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }
);

// Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

// Define os parametros de validação do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem está solicitando
        ValidateIssuer = true,

        // Valida quem está recebendo
        ValidateAudience = true,

        // Define se o tempo de expiração do token será validado
        ValidateLifetime = true,

        // Define a forma de criptografia e a validação de chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("EventPlus_CodeFirst-ABCDEFGHIJKLMNOP")),

        // Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(10),

        // De onde está vindo
        ValidIssuer = "webapi.inlock_codefirst",

        // Até aonde irá
        ValidAudience = "webapi.inlock_codefirst"
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Jogos",
        Description = "Deselvolvimento de uma API com ORM e codefirst para uma empresa fictícia de jogos.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Richard Felintro da Silva",
            Url = new Uri("https://github.com/Richard-Felintro")
        },
        License = new OpenApiLicense
        {
            Name = "null",
            Url = new Uri("https://example.com/license")
        }
    });
    // Configura o Swagger para o uso do XML
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    // Usando a autenticação no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

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
