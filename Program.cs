using Microsoft.EntityFrameworkCore;
using SmsService.Data;
using SmsService.Models;
using SmsService.Views;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SmsDbContext>(opt =>
    opt.UseSqlite("Data Source=/data/sms.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SmsDbContext>();
    db.Database.EnsureCreated();
}

app.MapGet("/", async (SmsDbContext db) =>
{
    var messages = await db.SmsMessages
        .OrderByDescending(m => m.CreatedAt)
        .Take(100)
        .ToListAsync();

    return Results.Content(SmsLogPage.Render(messages), "text/html");
});

// POST /api/sms/send
app.MapPost("/api/sms/send", async (SmsRequest request, SmsDbContext db) =>
{
    var entity = new SmsMessage
    {
        RequestId = request.RequestId,
        Phone = request.Phone,
        Message = request.Message,
        CreatedAt = DateTime.UtcNow
    };

    db.SmsMessages.Add(entity);
    await db.SaveChangesAsync();

    return Results.Ok(new { status = "delivered" });
});

app.Run();
