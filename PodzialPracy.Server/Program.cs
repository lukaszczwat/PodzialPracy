using PodzialPracy.Server.Repozytoria;
using PodzialPracy.Server.Serwis;

var builder = WebApplication.CreateBuilder(args);

// Dodanie us³ug do kontenera
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Rejestracja w³asnych serwisów i repozytoriów
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskSerwice>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

// (opcjonalnie) Dodaj CORS, jeœli nie u¿ywasz proxy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Dla œrodowiska deweloperskiego – poka¿ szczegó³y b³êdów
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// U¿ycie CORS (jeœli potrzebne)
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



//using Microsoft.AspNetCore.Authentication.Negotiate;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<PodzialPracy.Server.Serwis.TaskSerwice>();
//builder.Services.AddScoped<PodzialPracy.Server.Repozytoria.ITaskRepository, PodzialPracy.Server.Repozytoria.TaskRepository>();
//builder.Services.AddScoped<PodzialPracy.Server.Serwis.UserService>();
//builder.Services.AddScoped<PodzialPracy.Server.Repozytoria.IUserRepository, PodzialPracy.Server.Repozytoria.UserRepository>();


//// Add services to the container.
///// <summary>
///// Dodaje wymagane us³ugi do kontenera DI.
///// Konfiguracja obejmuje kontrolery API oraz mechanizmy uwierzytelniania i autoryzacji.
///// </summary>
///// 
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

///// <summary>
///// Konfiguracja Swagger dla generowania dokumentacji API.
///// Swagger pozwala na testowanie endpointów w interfejsie webowym.
///// </summary>
///// 
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

///// <summary>
///// Konfiguracja uwierzytelniania z wykorzystaniem Negotiate (NTLM/Kerberos).
///// Pozwala na integracjê z systemami Windows i domenami Active Directory.
///// </summary>

//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//   .AddNegotiate();

///// <summary>
///// Konfiguracja polityki autoryzacji.
///// Domyœlnie wszystkie ¿¹dania s¹ autoryzowane wed³ug domyœlnej polityki.
///// </summary>
///// 

//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy.
//    options.FallbackPolicy = options.DefaultPolicy;
//});

///// <summary>
///// Tworzy obiekt aplikacji z wczeœniej skonfigurowanymi us³ugami.
///// </summary>

//var app = builder.Build();

///// <summary>
///// Obs³uga statycznych plików (np. HTML, CSS, JS).
///// Zapewnia dostêp do zawartoœci strony bezpoœrednio z katalogu `wwwroot`.
///// </summary>

//app.UseDefaultFiles();
//app.UseStaticFiles();

///// <summary>
///// Konfiguracja pipeline dla HTTP - ustawienia dotycz¹ce obs³ugi ¿¹dañ.
///// Jeœli aplikacja dzia³a w trybie deweloperskim, uruchamiane s¹ Swagger i UI.
///// </summary>
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

///// <summary>
///// Wymusza przekierowanie ruchu HTTP na HTTPS.
///// Zapewnia szyfrowanie komunikacji z aplikacj¹.
///// </summary>

//app.UseHttpsRedirection();

///// <summary>
///// W³¹cza mechanizm autoryzacji w aplikacji.
///// Musi byæ wywo³ane przed mapowaniem kontrolerów.
///// </summary>

//app.UseAuthorization();

///// <summary>
///// Mapuje kontrolery API na œcie¿ki HTTP.
///// </summary>

//app.MapControllers();

///// <summary>
///// Obs³uguje ¿¹dania, które nie pasuj¹ do ¿adnego endpointu API.
///// Przekierowuje na `index.html` w przypadku aplikacji SPA (Angular/React/Vue).
///// </summary>

//app.MapFallbackToFile("/index.html");

///// <summary>
///// Uruchamia aplikacjê i rozpoczyna nas³uchiwanie ¿¹dañ HTTP.
///// </summary>

//app.Run();
