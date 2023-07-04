using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace diploom
{


    public partial class MainWindow : Window
    {
        AppConCar DB;
        private Dictionary<string, string> _dict;

        public MainWindow()
        {
            InitializeComponent();
             DB= new AppConCar();
            _dict = new Dictionary<string, string>();
            text_gos.ToolTip = "А001АА78 - русские буквы, цифры";
            text_vin.ToolTip = "JN1BAUJ31U0305951 - латинские буквы, цифры. VIN состоит из 17 символов";
            Combo_choose.SelectedIndex= 0;
        }



        private async void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            string vin = " ";
            string gos = " ";
            string optimal = null;
            if (string.IsNullOrEmpty(text_vin.Text))
            {
                if (string.IsNullOrEmpty(text_gos.Text))
                {
                    MessageBox.Show("Не выбран гос номер или вим");
                    return;
                }
            }
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--ignore-ssl-errors");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalChromeOption("useAutomationExtension", false);
            IWebDriver driver = new ChromeDriver(options);

            //Selenium_REG(driver);
            driver.Navigate().GoToUrl("https://vin.info/");
            driver.FindElement(By.XPath("(//a[@href='https://vin.info/login'][contains(.,'Войти')])[2]")).Click();
            await Task.Delay(1500);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("zanorin00@mail.ru");
            await Task.Delay(500);
            driver.FindElement(By.XPath("//input[contains(@name,'password')]")).SendKeys("3ZDHi8EX9Rs8Sm");
            await Task.Delay(500);
            driver.FindElement(By.XPath("//button[@type='submit'][contains(.,'Войти')]")).Click();
            await Task.Delay(500);
            driver.FindElement(By.XPath("(//a[@href='https://vin.info'][contains(.,'Проверка авто по вин')])[2]")).Click();

            if (string.IsNullOrEmpty(text_gos.Text))
            {
                vin = text_vin.Text;
                driver.FindElement(By.XPath("(//input[contains(@type,'text')])[2]"))
                .SendKeys(vin);
            }
            else
            {
                gos = text_gos.Text;
                driver.FindElement(By.XPath("(//input[contains(@type,'text')])[1]"))
                .SendKeys(gos);
            }

            await Task.Delay(500);
            driver.FindElement(By.XPath("//div[@class='inline-flex'][contains(.,'Проверить')]")).Click();
            await Task.Delay(1000);

            var gos_name = driver.FindElement(By.XPath("//span[contains(.,'Госномер')]")).GetAttribute("textContent");
            var gos_number = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[2]")).GetAttribute("textContent");
            _dict[gos_name] = gos_number;

            var Power_Engin_name = driver.FindElement(By.XPath("//span[contains(.,'Мощность двигателя')]")).GetAttribute("textContent");
            var Power_Engin_ = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[7]")).GetAttribute("textContent");
            _dict[Power_Engin_name] = Power_Engin_;


            var year_name = driver.FindElement(By.XPath("(//span[contains(.,'Год выпуска')])[1]")).GetAttribute("textContent");
            var year_number = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[11]")).GetAttribute("textContent");
            _dict[year_name] = year_number;

            var weight_name = driver.FindElement(By.XPath("//span[contains(.,'Масса без нагрузки')]")).GetAttribute("textContent");
            var weight_number = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[9]")).GetAttribute("textContent");
            _dict[weight_name] = weight_number;

            var rudder_name = driver.FindElement(By.XPath("//span[contains(.,'Расположение руля')]")).GetAttribute("textContent");
            var rudder_position = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[13]")).GetAttribute("textContent");
            _dict[rudder_name] = rudder_position;

            var TC_name = driver.FindElement(By.XPath("//span[contains(.,'Серия и номер одобрения типа ТС')]")).GetAttribute("textContent");
            var TC_ = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[18]")).GetAttribute("textContent");
            _dict[TC_name] = TC_;

            var Full_Engin_name = driver.FindElement(By.XPath("//span[contains(.,'Объём двигателя')]")).GetAttribute("textContent");
            var Full_Engin_ = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[8]")).GetAttribute("textContent");
            _dict[Full_Engin_name] = Full_Engin_;

            var Type_Engin_name = driver.FindElement(By.XPath("//span[contains(.,'Тип двигателя')]")).GetAttribute("textContent");
            var Type_Engin_ = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[14]")).GetAttribute("textContent");
            _dict[Type_Engin_name] = Type_Engin_;

            var Type_privod_name = driver.FindElement(By.XPath("//span[contains(.,'Тип привода')]")).GetAttribute("textContent");
            var Type_privod_ = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[15]")).GetAttribute("textContent");
            _dict[Type_privod_name] = Type_privod_;

            var Eco_name = driver.FindElement(By.XPath("//span[contains(.,'Экологический класс')]")).GetAttribute("textContent");
            var Eco_class_ = driver.FindElement(By.XPath("(//span[@class='text-sm text-gray-900'])[17]")).GetAttribute("textContent");
            _dict[Eco_name] = Eco_class_;

            await Task.Delay(1000);
            driver.Quit();


            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            // Создание экземпляра браузера Chrome
            driver = new ChromeDriver();
            // Навигация на страницу с поиском по VIN
            driver.Navigate().GoToUrl("https://vin01.ru/");

            if (string.IsNullOrEmpty(text_gos.Text))
            {

                vin = text_vin.Text;
                driver.FindElement(By.XPath("//a[contains(.,'VIN номер')]")).Click();
                await Task.Delay(500);
                driver.FindElement(By.XPath("//input[contains(@placeholder,'VIN номер')]"))
                .SendKeys(vin);
                driver.FindElement(By.XPath("//button[contains(.,'Поиск!')]")).Click();
                await Task.Delay(500);
            }
            else
            {
                gos = text_gos.Text;
                driver.FindElement(By.XPath("//input[contains(@placeholder,'A777AA777')]"))
                .SendKeys(gos);
                driver.FindElement(By.XPath("//input[contains(@id,'num')]"))
                .SendKeys(gos);
                await Task.Delay(500);
                driver.FindElement(By.XPath("(//button[contains(@type,'button')])[2]")).Click();
            }



            await Task.Delay(500);

            driver.FindElement(By.XPath("//select[contains(@id,'checkType')]")).Click();
            await Task.Delay(1500);
            IList<IWebElement> elements = driver.FindElements(By.TagName("option"));
            foreach (IWebElement exp in elements)
            {
                System.Console.WriteLine(exp.Text);
                //if (exp.Text == "История ДТП")
                if (exp.Text == Combo_choose.Text)
                // if (e.Text == "История регистраций")
                {
                    exp.Click();
                }
            }

            driver.FindElement(By.XPath("//button[@type='button'][contains(.,'Проверка')]")).Click();
            //        var lam = driver.FindElement(By.XPath("//div[contains(@class,'alert alert-danger')]")).GetAttribute("textContent");
            //        Console.WriteLine(lam);
            try
            {
                for (int i = 0; i < 30; i++)
                {
                    try
                    {
                        // Ожидание появления поля для ввода VIN
                        driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
                        await Task.Delay(1000);
                        break;
                    }
                    catch (Exception)
                    {
                        await Task.Delay(1000);
                    }
                    optimal = driver.FindElement(By.XPath("//div[@class='alert alert-danger']")).GetAttribute("textContent");
                    //  MessageBox.Show(lom);
                    // Console.WriteLine(lom);
                }
            }

            catch (Exception)
            {
                IList<IWebElement> element = driver.FindElements(By.TagName("td"));
                //foreach (IWebElement exp in element)
                //{
                //    System.Console.WriteLine(exp.Text);
                //}

                for (int i = 0; i < element.Count - 1; i += 2)
                {
                    string key = element[i].Text;
                    string value = element[i + 1].Text;
                    if (key.StartsWith("Данные актуальны"))
                    {
                        break;
                    }
                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, value);
                    }
                    else
                    {
                        dictionary.Add(key + i, value);
                    }

                }


            }

            await Task.Delay(1000);
            driver.Quit();

            car Car = new car(gos_number, year_number, rudder_position, TC_, Power_Engin_, weight_number, Full_Engin_, Type_Engin_, Type_privod_, Eco_class_,optimal,vin);
            DB.cars.Add(Car);
            DB.SaveChanges();

            var result = string.Empty;
            foreach (var item in _dict)
            {
                result = result + $"{item.Key}={item.Value}";
            }
            Output form = new Output(_dict,optimal,dictionary) ;
            form.Owner = this;
            form.Show();

        }
        private void Aurorize_Click(object sender, RoutedEventArgs e)
        {
            Enter form1 = new Enter();
             form1.Owner = this;
            form1.Show();
        }
    }
}