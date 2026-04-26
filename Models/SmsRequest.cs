namespace SmsService.Models;

public class SmsRequest
{
    public string RequestId { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Message { get; set; } = "";
}
