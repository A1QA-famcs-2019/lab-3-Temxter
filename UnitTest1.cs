using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace CalculatorTest
{
    public class Tests 
    {
        private Application applicationMain;
        private Window windowMain;

        [SetUp]
        public void Setup()
        {
            applicationMain = Application.Launch("C:\\Windows\\System32\\calc1.exe");
            Assert.IsNotNull(applicationMain);
            windowMain = applicationMain.GetWindow("Calculator");
        }

        [Test]
        public void Test1()
        {
            GetButtonByName("1").Click();
            GetButtonByName("2").Click();
            //Add "+"
            GetButtonById("81").Click();
            for (int i = 0; i < 3; i++)
                GetButtonByName("9").Click();
            //Remember the result "M+"
            GetButtonById("124").Click();
            //Clean text "C"
            GetButtonById("81").Click();
            GetButtonByName("1").Click();
            GetButtonByName("9").Click();
            //Add "+"
            GetButtonById("93").Click();
            //Number from memory "MR"
            GetButtonById("123").Click();
            //Equals "="
            GetButtonById("121").Click();

            string result = windowMain.Get<Label>(SearchCriteria.ByAutomationId("150")).Text;
            string expected = "1030";
            Assert.AreEqual(expected, result, "Calculator Main Steps Failed");
            //Assert.Pass();
        }

        [TearDown]
        public void Teardown()
        {
            applicationMain.Close();
        }

        private Button GetButtonByName(string buttonName)
        {
            Button button = windowMain.Get<Button>(SearchCriteria.ByText(buttonName));
            return button;
        }
        private Button GetButtonById(string buttonId)
        {
            Button button = windowMain.Get<Button>(SearchCriteria.ByAutomationId(buttonId));
            return button;
        }


    }
}