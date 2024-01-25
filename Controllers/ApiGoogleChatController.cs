using Google;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.HangoutsChat.v1;
using Google.Apis.HangoutsChat.v1.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace WebAppChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGoogleChatController : ControllerBase
    {
        private readonly ILogger<ApiGoogleChatController> _logger;
        public ApiGoogleChatController(ILogger<ApiGoogleChatController> logger)
        {
            _logger = logger;
        }
        [Route("ChatApi")]
        [HttpGet]
        public async Task<IActionResult> ChatApiAsync()
        {

            var googleChatApiClient = new GoogleChatApiClient();
            var chatWebhookUrl = "https://chat.googleapis.com/v1/spaces/hj4OQkAAAAE/messages?key=AIzaSyDdI0hCZtE6vySjMm-WEfRq3CPzqKqqsHI&token=gTJPxRzdctKBh7A7qPigC5mMEYMOGY928k4zo2cPK5w";
            var message = "Anh Mịnh sinh năm bao nhiêu?";

            await googleChatApiClient.SendMessage(chatWebhookUrl, message);

            return Ok();

        }

        [Route("GetUsers")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            string serviceAccountKeyPath = "C:\\Users\\thinh.nguyenngoc\\Desktop\\adminapi.json"; // Đường dẫn đến tệp tin JSON chứa thông tin xác thực
            //domain email
            string domain = "vnresource.biz";

            // Phạm vi API
            string[] scopes = { DirectoryService.Scope.CloudPlatform,
                 DirectoryService.Scope.AdminDirectoryUserReadonly,
                 DirectoryService.Scope.AdminDirectoryUser,
               };
            try
            {
                // Tạo xác thực dịch vụ từ tệp tin JSON chứa thông tin xác thực
                var credential = GoogleCredential.FromFile(serviceAccountKeyPath);
                // Check if creating a new scope is required
                if (credential.IsCreateScopedRequired)
                {
                  credential = credential.CreateScoped(scopes).CreateWithUser("admin@vnresource.biz"); // email admin

                }
                // Tạo đối tượng dịch vụ Directory
                var service = new DirectoryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "ChatDemo"
                });
                // Lấy danh sách người dùng
                UsersResource.ListRequest request = service.Users.List();
                request.Domain = domain;
                try
                {
                    var users = request.Execute().UsersValue;
                    if (users != null && users.Count > 0)
                    {
                        Console.WriteLine("Danh sách người dùng:");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"{user.PrimaryEmail} - {user.Name.FullName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Không có người dùng nào.");
                    }
                    return Ok(users);
                }
                catch (GoogleApiException ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                    throw;
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            return Ok();
        }
    }
}
