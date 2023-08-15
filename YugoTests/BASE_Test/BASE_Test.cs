using Base_Temlate.Helpers;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Test
{
    [AllureNUnit]
    public class BASE : BaseWeb
    {
        [SetUp]
        public void SetUp() => Browser.Driver.Navigate().GoToUrl(Endpoints.BASE_URL);
    }
}
