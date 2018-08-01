using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using WPFFF;


namespace XamlApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public string Capacity()
        {
            double x = Convert.ToDouble(textInput1.Text) * Convert.ToDouble(textInput2.Text);
            string C1 = "C1: " + Convert.ToString(x * 1.2 * 1.5) + "мкФ \r";
            string C2 = "C2: 10 нФ \r";
            double x1 = (19 * ((4.7 * Convert.ToDouble(textInput2.Text)) / Convert.ToDouble(textInput1.Text))) / 6;
            string C3 = "C3: " + Convert.ToString(Math.Round(x1,3)) + " мкФ \r";
            string C4C5C7 = "C4, C5, C7: 330 пФ \r";
            string C6 = "C6: 0,1 мкФ \r";
            double x2 = (0.47 - Convert.ToDouble(textInput3.Text)) / (4 * Convert.ToDouble(textInput3.Text) * 3.14 * 3.14 * 10000 * 3.3E-6);
            string C9 = "C9: " + Math.Round(x2,3) + "мкФ \r";
            string C10 = "C10: [470 пФ - 10 нФ ] \r";
            string C11 = "C11: 4.7 нФ \r";
             
            string answer = C1 + C2 + C3 + C4C5C7 + C6 + C9 + C10 + C11;

            return answer;
        }

        public string Transf()
        {
            string answer = "";
            return answer;
        }
        public void CheckPoint(string x,string x1, string x2, string x3)
        {
            if (x  == string.Empty || x1 == string.Empty || x2 == string.Empty||
                x3 == string.Empty) { MessageBox.Show("Empty Field!"); }
            else { 
                txb.Text = "C:\\Users\\" + Environment.UserName + "\\Desktop\\OUTPUT.dat";
                File.WriteAllText(txb.Text, Capacity() + "\r" + Transf());
            }
        }

        //Обработчик нажатия по кнопке
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            CheckPoint(textInput1.Text, textInput2.Text, textInput3.Text, textInput4.Text);
            
            this.Cursor = null;
        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
                
        }

    }
}