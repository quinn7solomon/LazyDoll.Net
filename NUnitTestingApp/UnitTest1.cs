/* 
     ___            __     ________   ___  ___  ________      ______    ___      ___               _____  ___    _______  ___________  
    |"  |          /""\   ("      "\ |"  \/"  ||"      "\    /    " \  |"  |    |"  |             (\"   \|"  \  /"     "|("     _   ") 
    ||  |         /    \   \___/   :) \   \  / (.  ___  :)  // ____  \ ||  |    ||  |             |.\\   \    |(: ______) )__/  \\__/  
    |:  |        /' /\  \    /  ___/   \\  \/  |: \   ) || /  /    ) :)|:  |    |:  |             |: \.   \\  | \/    |      \\_ /     
     \  |___    //  __'  \  //  \__    /   /   (| (___\ ||(: (____/ //  \  |___  \  |___    _____ |.  \    \. | // ___)_     |.  |     
    ( \_|:  \  /   /  \\  \(:   / "\  /   /    |:       :) \        /  ( \_|:  \( \_|:  \  ))_  ")|    \    \ |(:      "|    \:  |     
     \_______)(___/    \___)\_______)|___/     (________/   \"_____/    \_______)\_______)(_____(  \___|\____\) \_______)     \__|     
                                                                                                                                   

    Copyright (c) 2020, @ quinn.7@foxmail.com, All rights reserved

    GitPath      : https://github.com/quinn7solomon/LazyDoll.Net
    FrameName    : LazyDoll.Net
    CreatorName  : Quinn7k
    CreationTime : 2020.11.19

    Module Responsibility Description : NA

 */


using System;

using Allure.Commons;

using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;


namespace NunitTestingApp.Case
{
    [TestFixture]
    [AllureNUnit]
    [AllureSubSuite("Example")]
    [AllureSeverity(SeverityLevel.critical)]
    public class Tests
    {

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            /* -- */
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            /* -- */
        }

        [SetUp]
        public void SetUp()
        {
            /* -- */
        }

        [TearDown]
        public void TearDown()
        {
            /* -- */
        }

        [Test]
        [AllureTag("NUnit", "Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Core")]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void EvenTest([Range(0, 5)] int value)
        {
            Assert.IsTrue(value % 2 == 0, $"Oh no :( {value} % 2 = {value % 2}");
        }
    }
}