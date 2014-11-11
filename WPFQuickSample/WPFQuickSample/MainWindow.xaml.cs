using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace WPFQuickSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Search()
        {
            IEnumerable<Employee> result = GetEmployees();

            int income, age, id;            
            if (int.TryParse(this.TextBoxID.Text, out id) && RangeComboBox_ID.SelectedItem != null) // <- TexBoxIncome.Text is directly accessing View so not truely good interms of ViewModel instead it should be binded to class specific to this property
            {
                result = from r in result
                         where RangeFromComboBox(RangeComboBox_ID, (int)r.EmployeeID, id)
                         select r;
                //result = result.Where(r => RangeFromComboBox(RangeComboBox_ID, (int)r.EmployeeID, id)); // whichever works : just displaying purpose
            }

            if (this.TextBoxJob.Text != string.Empty)
            {
                result = from r in result
                         where r.JobTitle.Contains(this.TextBoxJob.Text)
                         select r;
            }

            if (this.TextBoxName.Text != string.Empty)
            {
                result = from r in result
                         where r.Name.Contains(this.TextBoxName.Text)
                         select r;
            }

            if (int.TryParse(this.TextBoxAge.Text, out age) && RangeComboBox_Age.SelectedItem != null)
            {
                result = from r in result
                         where RangeFromComboBox(RangeComboBox_Age, (int)r.Age, age)
                         select r;
            }

            if (int.TryParse(this.TextBoxIncome.Text, out income) && RangeComboBox_Income.SelectedItem != null)
            {
                result = from r in result
                         where RangeFromComboBox(RangeComboBox_Income, (int)r.Income, income)
                         select r;
            }
            
            this.ListViewMain.ItemsSource = result;
        }

        private bool RangeFromComboBox(ComboBox cb, int a, int b)
        {
            if (cb != null && cb.SelectedItem != null)
            {
                string range = cb.SelectedItem.ToString();
                switch (range)
                {
                    case ">":
                        return a > b;
                    case "=":
                        return a == b;
                    case "<":
                        return a < b;
                    default:
                        return false;
                }
            }

            return false;
        }

        public List<Employee> GetEmployees()
        {
            using (StreamReader r = new StreamReader("Employees.xml"))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Employee>));

                return (List<Employee>)s.Deserialize(r);
            }
        }

        #region Events

        private void TextBoxIncome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            Search();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        #endregion
    }
}
