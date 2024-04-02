using NUnit.Framework;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Base_Temlate.Helpers
{
    public partial class TelegramHelper
    {
        private static string token = "5130591097:AAF6jNtd1H3l9baweL7QQsD5npn2ODqmlhk";
        private static TelegramBotClient? _clientM;
        private static readonly string _id = "595478648";
        protected static Message messageText { get; set; }
        protected static Message messagePhoto { get; set; }

        public static async Task SendMessage()
        {
            switch (Browser.Driver)
            {
                case null:
                    _clientM = new TelegramBotClient(token);

                    messageText = await _clientM.SendTextMessageAsync(
                        chatId: _id,
                        text: "The test-case \"" + TestContext.CurrentContext.Test.Name.ToString() +
                        "\" has failed" + "\n" + "\n" + TestContext.CurrentContext.Result.Message);

                    break;
                case not null:
                    _clientM = new TelegramBotClient(token);

                    string filePath = ScreenShotHelper.MakeScreenShot().Result;
                    FileStream stream = System.IO.File.OpenRead(filePath);

                    messageText = await _clientM.SendTextMessageAsync(
                        chatId: _id,
                        text: "The test-case \"" + TestContext.CurrentContext.Test.Name.ToString() +
                        "\" has failed" + "\n" + "\n" + TestContext.CurrentContext.Result.Message);

                    messagePhoto = await _clientM.SendPhotoAsync(
                        chatId: _id,
                        photo: InputFile.FromStream(stream, filePath)
                        );
                    await ScreenShotHelper.DeleteScreenShot(filePath);
                    break;
            }
        }

    }

    public class ScreenShotHelper
    {
        public static async Task<string> MakeScreenShot()
        {
            var screenshot = await Browser.Driver.ScreenshotAsync();


            string timestampPath = DateTime.Now.ToString("yyyy-MM-dd");
            string timestampName = DateTime.UtcNow.ToString("dd-MMMM-yyyy' 'HH-mm-ss");
            string path = Browser.RootPath() + @"ErrorImages\" + timestampPath + @"\";
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
            string name = path + "Exception-" + timestampName + ".png";
            await System.IO.File.WriteAllBytesAsync(name, screenshot);
            return name;
        }

        public static async Task DeleteScreenShot(string file)
        {
            string timestampPath = DateTime.Now.ToString("yyyy-MM-dd");
            var directoryPath = Browser.RootPath() + @"ErrorImages\" + timestampPath + @"\";
            if (Directory.Exists(directoryPath))
            {
                await Task.Delay(1000);
                Directory.Delete(directoryPath, true);

            }

        }
    }
}
