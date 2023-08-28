namespace Base_Temlate.Helpers
{

    public class OS
    {
        public static dynamic? FileExtention()
        {
            string? extention = null;

            if (OperatingSystem.IsWindows())
            {
               extention = ".bat";
            }else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
            {
               extention = ".sh";
            }

            return extention;
        }
    }
    public class Endpoints
    {
        public const string BASE_URL = "https://yugowow.com/en/";
        public const string VOTE_PAGE = "https://yugowow.com/en/vote";
    }
}
