using Emgu.CV.CvEnum;
using Emgu.CV;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using Emgu.CV.Structure;

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

    public async Task Tesseract(IFormFile file, bool isCheck = true)
    {
        string res = "";
        using (var engine = new TesseractEngine(@"D:\Tesseract-OCR\tessdata", "vie", EngineMode.LstmOnly))
        {

            // Create a Pix object from the image file
           
            using (var memoryStream = new MemoryStream())
            {
              
                await file.CopyToAsync(memoryStream);
                byte[] afterbytes = memoryStream.ToArray();
                Mat image = new Mat();
                if (isCheck)
                {
                    CvInvoke.Imdecode(memoryStream.GetBuffer(), ImreadModes.Color, image);
                    CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
                    //CvInvoke.Imshow("Grayscale Image", image);
                    //CvInvoke.WaitKey(0); // Chờ đến khi người dùng nhấn một phím

                    // Chuyển đổi hình ảnh trắng đen thành hình ảnh Bitmap
                    Image<Bgr, byte> afterImage = image.ToImage<Bgr, byte>();

                    afterbytes = afterImage.ToJpegData();
                }
                
                using (var img = Pix.LoadFromMemory(afterbytes))
                {
                    using (var page = engine.Process(img, PageSegMode.SparseText))
                        res = page.GetText();
                }
                image.Dispose();
            }

        }
        string filePath = "D:\\example.txt";
        try
        {
            // Sử dụng StreamWriter để ghi vào tệp
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Ghi dữ liệu vào tệp
                writer.WriteLine(res);
                // Các dòng khác cũng có thể được thêm vào bằng cách sử dụng writer.WriteLine(...) hoặc writer.Write(...).
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}
