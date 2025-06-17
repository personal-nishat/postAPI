var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

static async Task<bool> PostNotif(string meetingId, DateTime meetingTime)
{
    using var httpClient = new HttpClient();
    var url = "https://app-pushnotifdotnet.azurewebsites.net/meeting";
    var payload = new
    {
        meetingId,
        meetingTime
    };
    var response = await httpClient.PostAsJsonAsync(url, payload);
    return response.IsSuccessStatusCode;
}
app.Run();