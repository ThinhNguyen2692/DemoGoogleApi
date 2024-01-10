using Google.Apis.Auth.OAuth2;
using Google.Apis.HangoutsChat.v1.Data;
using Google.Apis.HangoutsChat.v1;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebAppChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTest : ControllerBase
    {

        //[Route("ChatApi")]
        //[HttpGet]
        //public async Task<IActionResult> ChatApiAsync()
        //{

        //    await SendMessageAsync("AIzaSyCKH3fm6dHvQpa_JHiGtlDl323LrLnRV3Q", "MyProjectTestAPIGoogleChat", "2000 có phải tuôi con GÀ");


        //    return Ok();
        //}

        //static void SendMessage(HangoutsChatService service)
        //{
        //    //Thay đổi spaceId và text theo nhu cầu của bạn
        //    var message = new Message
        //    {
        //        Text = "Hello, this is a test message from Hangouts Chat API."
        //    };

        //    var createMessageRequest = service.Spaces.Messages.Create(message, "spaces/AAAAZP67txU");
        //    createMessageRequest.Execute();
        //}

        //[Route("ChatApiSendMessage")]
        //[HttpGet]
        //public IActionResult ChatApi()
        //{

        //    string pathToCredentialsJson = "C:\\Users\\thinh.nguyenngoc\\Downloads\\KeyApiChatDemo.json";

        //    // Đọc thông tin xác thực từ tệp JSON
        //    var credential = GoogleCredential.FromFile(pathToCredentialsJson)
        //        .CreateScoped(HangoutsChatService.Scope.ChatBot);

        //    // Tạo dịch vụ HangoutsChat
        //    var service = new HangoutsChatService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = "MyProjectTestAPIGoogleChat"
        //    });
        //    var spacesListRequest = service.Spaces.List();
        //    var spaces = spacesListRequest.Execute();
        //    foreach (var space in spaces.Spaces)
        //    {
        //        Console.WriteLine($"Space Name: {space.DisplayName}, Space ID: {space.Name}");
        //    }
        //    SendMessage(service);

        //    return Ok();
        //}

        ////static void SendMessage(HangoutsChatService service)
        ////{
        ////    Thay đổi spaceId và text theo nhu cầu của bạn
        ////    var message = new Message
        ////    {
        ////        Text = "Hello, this is a test message from Hangouts Chat API."
        ////    };

        ////    var createMessageRequest = service.Spaces.Messages.Create(message, "spaces/AAAAZP67txU");
        ////    createMessageRequest.Execute();
        ////}

        //static async Task SendMessageAsync(string accessToken, string spaceId, string message)
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

        //            string apiUrl = $"https://chat.googleapis.com/v1/spaces/{spaceId}/messages";

        //            var content = new StringContent($"{{\"text\":\"{message}\"}}", Encoding.UTF8, "application/json");

        //            var response = await client.PostAsync(apiUrl, content);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine("Message sent successfully!");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Failed to send message. Status Code: {response.StatusCode}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //}
    }

}
