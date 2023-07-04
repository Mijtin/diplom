using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace diploom
{
    /// <summary>
    /// Interaction logic for library.xaml
    /// </summary>

    public partial class library : Window
    {
        
        AppConCar DB;


        public library()
        {
            InitializeComponent();
            DB = new AppConCar();

            List<car> list = DB.cars.ToList();
            list_of_cars.ItemsSource = list;
            // добавляем обработчик события выбора элемента
            list_of_cars.SelectionChanged += ListOfCars_SelectionChanged;
            Combo_choose.SelectedIndex = 0;

        }
        private async void ListOfCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // получаем выбранный элемент
            car selectedCar = (car)list_of_cars.SelectedItem;
            
            // проверяем, что элемент был выбран и отображаем информацию о нём
            if (selectedCar != null)
            {
                string lam = selectedCar.vin.ToString();
                
                MessageBox.Show($"Выбран автомобиль: {selectedCar.gosNumber}, год выпуска: {selectedCar.yearNumber},вин: {selectedCar.vin}");
                MessageBoxResult result = MessageBox.Show("Вы хотите заново проверить результаты ?", "ВОПРОС", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {

                    // Действия при ответе "Да"

                    string optimal = "";
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--ignore-certificate-errors");
                    options.AddArgument("--ignore-ssl-errors");
                    options.AddExcludedArgument("enable-automation");
                    options.AddAdditionalChromeOption("useAutomationExtension", false);
                    IWebDriver driver = new ChromeDriver(options);
            
                    // Навигация на страницу с поиском по VIN
                    driver.Navigate().GoToUrl("https://vin01.ru/");

                      string  vin = selectedCar.vin;
                        driver.FindElement(By.XPath("//a[contains(.,'VIN номер')]")).Click();
                        await Task.Delay(500);
                        driver.FindElement(By.XPath("//input[contains(@placeholder,'VIN номер')]"))
                        .SendKeys(vin);
                        driver.FindElement(By.XPath("//button[contains(.,'Поиск!')]")).Click();
                        await Task.Delay(500);



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
                                dictionary.Add(key+"№2", value);
                            }

                        }
                        

                    }
                    Dictionary<string, string> _dict = new Dictionary<string, string>();
                    _dict["дополнительная информация"] = "найдена"; 
                    await Task.Delay(1000);
                    driver.Quit();
                    Output form = new Output(_dict,optimal, dictionary);
                    form.Owner = this;
                    form.Show();
                }
                else
                {
                    // Действия при ответе "Нет" или закрытии диалогового окна
                }
            }
        }
    }
}
