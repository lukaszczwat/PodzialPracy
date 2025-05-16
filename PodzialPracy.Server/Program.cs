using Microsoft.AspNetCore.Authentication.Negotiate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/// <summary>
/// Dodaje wymagane us�ugi do kontenera DI.
/// Konfiguracja obejmuje kontrolery API oraz mechanizmy uwierzytelniania i autoryzacji.
/// </summary>
/// 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

/// <summary>
/// Konfiguracja Swagger dla generowania dokumentacji API.
/// Swagger pozwala na testowanie endpoint�w w interfejsie webowym.
/// </summary>
/// 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// Konfiguracja uwierzytelniania z wykorzystaniem Negotiate (NTLM/Kerberos).
/// Pozwala na integracj� z systemami Windows i domenami Active Directory.
/// </summary>

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

/// <summary>
/// Konfiguracja polityki autoryzacji.
/// Domy�lnie wszystkie ��dania s� autoryzowane wed�ug domy�lnej polityki.
/// </summary>
/// 

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

/// <summary>
/// Tworzy obiekt aplikacji z wcze�niej skonfigurowanymi us�ugami.
/// </summary>

var app = builder.Build();

/// <summary>
/// Obs�uga statycznych plik�w (np. HTML, CSS, JS).
/// Zapewnia dost�p do zawarto�ci strony bezpo�rednio z katalogu `wwwroot`.
/// </summary>

app.UseDefaultFiles();
app.UseStaticFiles();

/// <summary>
/// Konfiguracja pipeline dla HTTP - ustawienia dotycz�ce obs�ugi ��da�.
/// Je�li aplikacja dzia�a w trybie deweloperskim, uruchamiane s� Swagger i UI.
/// </summary>
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/// <summary>
/// Wymusza przekierowanie ruchu HTTP na HTTPS.
/// Zapewnia szyfrowanie komunikacji z aplikacj�.
/// </summary>

app.UseHttpsRedirection();

/// <summary>
/// W��cza mechanizm autoryzacji w aplikacji.
/// Musi by� wywo�ane przed mapowaniem kontroler�w.
/// </summary>

app.UseAuthorization();

/// <summary>
/// Mapuje kontrolery API na �cie�ki HTTP.
/// </summary>

app.MapControllers();

/// <summary>
/// Obs�uguje ��dania, kt�re nie pasuj� do �adnego endpointu API.
/// Przekierowuje na `index.html` w przypadku aplikacji SPA (Angular/React/Vue).
/// </summary>

app.MapFallbackToFile("/index.html");

/// <summary>
/// Uruchamia aplikacj� i rozpoczyna nas�uchiwanie ��da� HTTP.
/// </summary>

app.Run();
