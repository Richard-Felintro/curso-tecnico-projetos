using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o de Controllers
builder.Services.AddControllers();

// Adiciona servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

// Define os parametros de valida��o do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem est� solicitando
        ValidateIssuer = true,

        // Valida quem est� recebendo
        ValidateAudience = true,

        // Define se o tempo de expira��o do token ser� validado
        ValidateLifetime = true,

        // Define a forma de criptografia e a valida��o de chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao-senai.inlock.webApi")),

        // Valida o tempo de expira��o do token
        ClockSkew = TimeSpan.FromMinutes(10),

        // De onde est� vindo
        ValidIssuer = "senai.inlock.webApi",

        // At� aonde ir�
        ValidAudience = "senai.inlock.webApi"
    };
});


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Jogos",
        Description = "Deselvolvimento de uma API para uma empresa fict�cia de jogos.",
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
    // Usando a autentica��o no Swagger
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Usar Autentica��o
app.UseAuthentication();

// User Autoriza��o.
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

app.Run();