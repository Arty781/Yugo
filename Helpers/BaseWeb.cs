﻿using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Temlate.Helpers
{
    [AllureNUnit]
    public class BaseWeb
    {
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            Browser.Initialize();
            AllureHelper.CreateAllureFile();
        }

        [TearDown]
        public static void TearDown()
        {
            Browser._Driver?.Close();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Browser._Driver?.Dispose();
        }
    }
}
