using PodzialPracy.Server.Repozytoria;
using PodzialPracy.Server.Serwis;

var builder = WebApplication.CreateBuilder(args);

// Dodanie us�ug do kontenera
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Rejestracja w�asnych serwis�w i repozytori�w
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskSerwice>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

// (opcjonalnie) Dodaj CORS, je�li nie u�ywasz proxy
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

// Dla �rodowiska deweloperskiego � poka� szczeg�y b��d�w
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// U�ycie CORS (je�li potrzebne)
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
///// Dodaje wymagane us�ugi do kontenera DI.
///// Konfiguracja obejmuje kontrolery API oraz mechanizmy uwierzytelniania i autoryzacji.
///// </summary>
///// 
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

///// <summary>
///// Konfiguracja Swagger dla generowania dokumentacji API.
///// Swagger pozwala na testowanie endpoint�w w interfejsie webowym.
///// </summary>
///// 
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

///// <summary>
///// Konfiguracja uwierzytelniania z wykorzystaniem Negotiate (NTLM/Kerberos).
///// Pozwala na integracj� z systemami Windows i domenami Active Directory.
///// </summary>

//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//   .AddNegotiate();

///// <summary>
///// Konfiguracja polityki autoryzacji.
///// Domy�lnie wszystkie ��dania s� autoryzowane wed�ug domy�lnej polityki.
///// </summary>
///// 

//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy.
//    options.FallbackPolicy = options.DefaultPolicy;
//});

///// <summary>
///// Tworzy obiekt aplikacji z wcze�niej skonfigurowanymi us�ugami.
///// </summary>

//var app = builder.Build();

///// <summary>
///// Obs�uga statycznych plik�w (np. HTML, CSS, JS).
///// Zapewnia dost�p do zawarto�ci strony bezpo�rednio z katalogu `wwwroot`.
///// </summary>

//app.UseDefaultFiles();
//app.UseStaticFiles();

///// <summary>
///// Konfiguracja pipeline dla HTTP - ustawienia dotycz�ce obs�ugi ��da�.
///// Je�li aplikacja dzia�a w trybie deweloperskim, uruchamiane s� Swagger i UI.
///// </summary>
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

///// <summary>
///// Wymusza przekierowanie ruchu HTTP na HTTPS.
///// Zapewnia szyfrowanie komunikacji z aplikacj�.
///// </summary>

//app.UseHttpsRedirection();

///// <summary>
///// W��cza mechanizm autoryzacji w aplikacji.
///// Musi by� wywo�ane przed mapowaniem kontroler�w.
///// </summary>

//app.UseAuthorization();

///// <summary>
///// Mapuje kontrolery API na �cie�ki HTTP.
///// </summary>

//app.MapControllers();

///// <summary>
///// Obs�uguje ��dania, kt�re nie pasuj� do �adnego endpointu API.
///// Przekierowuje na `index.html` w przypadku aplikacji SPA (Angular/React/Vue).
///// </summary>

//app.MapFallbackToFile("/index.html");

///// <summary>
///// Uruchamia aplikacj� i rozpoczyna nas�uchiwanie ��da� HTTP.
///// </summary>

//app.Run();
