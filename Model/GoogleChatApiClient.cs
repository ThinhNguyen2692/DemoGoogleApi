using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

class GoogleChatApiClient
{
    private readonly HttpClient httpClient;

    public GoogleChatApiClient()
    {
        httpClient = new HttpClient();
    }

    public async Task SendMessage(string chatWebhookUrl, string text)
    {
        var json = $"{{\"text\": \"{text}\"}}";
        var message = new CardMessage
        {
            Cards = new List<Card>
        {
        new Card
        {
            Header = new Header
            {
                Title = "<users/all> Quý anh Nguyễn Văn Mịnh"
            },
            Sections = new List<Section>
            {
               new Section{
                SectionHeader = $"<b><font color=\"#ff0000\">{text}</font></b>",
                Widgets = new List<Widget>{
                    new Widget{
                    TextParagraph = new TextParagraph { Text = "Anh Mịnh sinh năm 2000. Tuổi con Gà." }
                    }

                    }
               }
            }
        }
    }
        };

        string jsonMessage = JsonConvert.SerializeObject(message);
        var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

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
