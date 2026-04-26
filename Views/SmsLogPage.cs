using SmsService.Models;

namespace SmsService.Views;

public static class SmsLogPage
{
    public static string Render(List<SmsMessage> messages)
    {
        var rows = string.Join("\n", messages.Select(m =>
            $"""
            <tr>
                <td>{m.CreatedAt:yyyy-MM-dd HH:mm:ss}</td>
                <td>{System.Net.WebUtility.HtmlEncode(m.RequestId)}</td>
                <td>{System.Net.WebUtility.HtmlEncode(m.Phone)}</td>
                <td>{System.Net.WebUtility.HtmlEncode(m.Message)}</td>
            </tr>
            """));

        return """
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset="utf-8"/>
            <title>SMS Service — Log</title>
            <style>
                body { font-family: sans-serif; margin: 2rem; }
                table { border-collapse: collapse; width: 100%; }
                th, td { border: 1px solid #ccc; padding: 8px; text-align: left; }
                th { background: #f5f5f5; }
                h1 { color: #333; }
            </style>
        </head>
        <body>
            <h1>SMS Log (last 100)</h1>
            <table>
                <thead>
                    <tr><th>Time</th><th>Request ID</th><th>Phone</th><th>Message</th></tr>
                </thead>
                <tbody>
                    %%ROWS%%
                </tbody>
            </table>
        </body>
        </html>
        """.Replace("%%ROWS%%", rows);
    }
}
