using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class GoogleChatApiClient
{
    private readonly HttpClient httpClient;

    public GoogleChatApiClient()
    {
        httpClient = new HttpClient();
    }

    public async Task SendMessage(string chatWebhookUrl, string htmlMessage)
    {
        var json = $"{{\"text\": \"{htmlMessage}\"}}";
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(chatWebhookUrl, content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Message sent successfully!");
        }
        else
        {
            Console.WriteLine($"Failed to send message. Status code: {response.StatusCode}");
        }
    }
}
