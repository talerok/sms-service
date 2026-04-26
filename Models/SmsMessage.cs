namespace SmsService.Models;

public class SmsMessage
{
    public int Id { get; set; }
    public string RequestId { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Message { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}
