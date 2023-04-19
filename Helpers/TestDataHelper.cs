using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
