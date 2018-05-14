//--------------------------------------------------------------
//
// Browser Efficiency Test
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// MIT License
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files(the ""Software""),
// to deal in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell copies
// of the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS
// OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF
// OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//--------------------------------------------------------------

using System;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium;

namespace BrowserEfficiencyTest
{
    internal class Muni : Scenario
    {
        public Muni()
        {
            // Specifify name and that it's 30s
            Name = "MuniTest";
            DefaultDuration = 60;
        }
        public override void Run(RemoteWebDriver driver, string browser, CredentialManager credentialManager, ResponsivenessTimer timer)
        {
            driver.NavigateToUrl("https://www.muni.cz/");
            driver.Wait(5);

            ScenarioEventSourceProvider.EventLog.ScenarioActionStart("Fill search field");
            driver.TypeIntoField(driver.FindElementByCssSelector(".inp-fix.inp-icon.inp-icon--after input"),
                "Software Quality" + Keys.Enter);

            driver.Wait(10);

            ScenarioEventSourceProvider.EventLog.ScenarioActionStart("Click on the first result");
            driver.ClickElement(
                driver.FindElementByCssSelector(".gsc-results.gsc-webResult>.gsc-webResult.gsc-result a.gs-title"));

            timer.ExtractPageLoadTime();
        }
    }
}
