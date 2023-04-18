using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestsExcercise

{
    public class WebDriverTests
    {
        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }
        
        [Test]
        public void Test_Calculate_Two_Valid_Numbers()
        {
            var searchField1 = driver.FindElement(By.Id("number1"));
            searchField1.SendKeys("1");

            var searchField2 = driver.FindElement(By.Id("number2"));
            searchField2.SendKeys("2");

            var operationOption = driver.FindElement(By.XPath("//select[contains(@id,'operation')]"));
            operationOption.SendKeys("+ sum");

            var result = driver.FindElement(By.Id("calcButton"));
            result.Click();

            var resultText = driver.FindElement(By.XPath("//*[@id=\"result\"]/pre")).Text;

            //Assert
            Assert.That(resultText, Is.EqualTo("3"));
        }
        [Test]
        public void Test_Calculate_Invalid_Data()
        {
            var searchField1 = driver.FindElement(By.Id("number1"));
            searchField1.SendKeys("");

            var searchField2 = driver.FindElement(By.Id("number2"));
            searchField2.SendKeys("2");

            var operationOption = driver.FindElement(By.XPath("//select[contains(@id,'operation')]"));
            operationOption.SendKeys("+ sum");

            var result = driver.FindElement(By.Id("calcButton"));
            result.Click();

            var resultText = driver.FindElement(By.XPath("//*[@id='result']/i")).Text;

            //Assert
            Assert.That(resultText, Is.EqualTo("invalid input"));
        }
        [Test]

        public void Test_AssertNotEmpty()
        {
            driver.FindElement(By.Id("number1")).SendKeys("1");
            var searchField1 = driver.FindElement(By.Id("number1")).GetAttribute("value");

            Assert.IsNotEmpty(searchField1);

            driver.FindElement(By.Id("number2")).SendKeys("2");
            var searchField2 = driver.FindElement(By.Id("number2")).GetAttribute("value");

            Assert.IsNotEmpty(searchField2);

            var operationOption = driver.FindElement(By.XPath("//select[contains(@id,'operation')]"));
            operationOption.SendKeys("+ sum");

            var result = driver.FindElement(By.Id("calcButton"));
            result.Click();

            var resultText = driver.FindElement(By.XPath("//*[@id=\"result\"]/pre")).Text;

            Assert.IsNotEmpty(resultText);


        }
        [Test]

        public void Test_Reset()
        {
            var resetButton = driver.FindElement(By.Id("resetButton"));
            resetButton.Click();

            var searchField1 = driver.FindElement(By.Id("number1")).GetAttribute("value");

            Assert.AreEqual("", searchField1);
           
            var searchField2 = driver.FindElement(By.Id("number2")).GetAttribute("value");

            Assert.AreEqual("", searchField2);
           
            var resultText = driver.FindElement(By.CssSelector("#result")).Text;

            Assert.AreEqual("", resultText);
            Assert.IsEmpty(resultText);

            
        }
        [Test]
        public void Test_Subtract_Negative_Numbers()
        {
            var searchField1 = driver.FindElement(By.Id("number1"));
            searchField1.SendKeys("-2");

            var searchField2 = driver.FindElement(By.Id("number2"));
            searchField2.SendKeys("-3");

            var operationOption = driver.FindElement(By.XPath("//select[contains(@id,'operation')]"));
            operationOption.SendKeys("- subtract");

            var result = driver.FindElement(By.Id("calcButton"));
            result.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;

            //Assert
            Assert.That(resultText, Is.EqualTo("Result: 1"));
        }
        [Test]
        public void Test_Multiply_Positive_Numbers()
        {
            var searchField1 = driver.FindElement(By.Id("number1"));
            searchField1.SendKeys("3");

            var searchField2 = driver.FindElement(By.Id("number2"));
            searchField2.SendKeys("5");

            var operationOption = driver.FindElement(By.XPath("//select[contains(@id,'operation')]"));
            operationOption.SendKeys("* multiply");

            var result = driver.FindElement(By.Id("calcButton"));
            result.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;

            //Assert
            Assert.That(resultText, Is.EqualTo("Result: 15"));
        }
        [Test]
        public void Test_Divide_Positive_Numbers()
        {
            var searchField1 = driver.FindElement(By.Id("number1"));
            searchField1.SendKeys("15");

            var searchField2 = driver.FindElement(By.Id("number2"));
            searchField2.SendKeys("5");

            var operationOption = driver.FindElement(By.XPath("//select[contains(@id,'operation')]"));
            operationOption.SendKeys("/ divide");

            var result = driver.FindElement(By.Id("calcButton"));
            result.Click();

            var resultText = driver.FindElement(By.CssSelector("#result")).Text;

            //Assert
            Assert.That(resultText, Is.EqualTo("Result: 3"));
        }
    }
    
}
        
        
    
