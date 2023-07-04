using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Binding = System.Windows.Data.Binding;

namespace diploom
{
    public class ResultData
    {

    }
    public partial class Output : Window
    {
        public Output(Dictionary<string, string> data, string str, Dictionary<string, string> data2)
        {
            InitializeComponent();
            myDataGrid.BeginningEdit += (s, ss) => ss.Cancel = true;
            
            // добавление столбцов в Datagrid
            myDataGrid.Columns.Add(new DataGridTextColumn { Header = "Ключ", Binding = new Binding("Key") });
            myDataGrid.Columns.Add(new DataGridTextColumn { Header = "Значение", Binding = new Binding("Value") });
            
            // заполнение таблицы данными из словаря
            foreach (var item in data)
            {
                myDataGrid.Items.Add(new { Key = item.Key, Value = item.Value });
            }
          //  System.Windows.MessageBox.Show(str);
          //  System.Windows.MessageBox.Show(data2["Цвет"]);
            if (String.IsNullOrEmpty(str))
            {
                foreach (var item in data2)
                {
                    myDataGrid.Items.Add(new { Key = item.Key, Value = item.Value });
                }
            }
            else { myDataGrid.Items.Add(new { Key = "Дополнительная информация", Value = str }); }
        }

      
        
    }
}