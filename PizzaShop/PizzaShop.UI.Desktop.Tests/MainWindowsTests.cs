using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Reflection;
using System.Windows.Forms;

namespace PizzaShop.UI.Desktop.Tests
{
    public class MainWindowsTests
    {
        [Fact]
        public void Button1_click_should_show_HalloWelt_in_Tb1()
        {
            //var appPath = @"C:\Users\Fred\source\repos\Tests_2022_11\PizzaShop\PizzaShop.UI.Desktop\bin\Debug\net7.0-windows\PizzaShop.UI.Desktop.exe";
            var appPath = typeof(MainWindow).Assembly.Location.Replace(".dll", ".exe");
            var app = FlaUI.Core.Application.Launch(appPath);
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                //var b1 = window.FindFirstDescendant(x => x.ByClassName("Button")).AsButton();
                var b1 = window.FindFirstDescendant(x => x.ByAutomationId("b1")).AsButton();
                b1.Invoke();

                //var tb1 = window.FindFirstDescendant(x => x.ByClassName("TextBox")).AsTextBox();
                var tb1 = window.FindFirstDescendant(x => x.ByAutomationId("tb1")).AsTextBox();
                Assert.Equal("Hallo Welt!", tb1.Text);
                app.Close();
            }
        }
    }
}
