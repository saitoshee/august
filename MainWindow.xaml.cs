using System;
using System.Windows;
using System.IO;
using System.Windows.Input;


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
            double x2 = (0.47 - Convert.ToDouble(textInput3.Text)) / (4 * Convert.ToDouble(textInput3.Text) * 3.14 * 3.14
                * 10000 * 3.3E-6);
            string C9 = "C9: " + Math.Round(x2,3) + "мкФ \r";
            string C10 = "C10: [470 пФ - 10 нФ ] подбирается по осциллограмме\r";
            string C11 = "C11: 4.7 нФ (класс Y1 или Y2)\r";
             
            string answer = C1 + C2 + C3 + C4C5C7 + C6 + C9 + C10 + C11;

            return answer;
        }

        public string Resistance()
        {
            // string R9 = 10 / Ig;
            // string R11 = 0,9/Ipri;
            string b = textInput2.Text;
            double R15 = (10 * (Convert.ToDouble(b) - 2.5)) / 2.5;
            string answer = "R1, R2: 100 кОм " + "R3: [25 - 75 Ом] резистор демпфера. подбирается по осциллограмме \r"
                + "R4: 10 - 47 Ом \r" + "R5, R7, R16: 10 кОм"+
                "R8: 26,1 кОм" + "R9: " + "R10: 470 Ом" + "R11: " + "R12: 910 Ом \r R13: 2,7 кОм " +
                "\r R14: 47 кОм \r" + "R15: " + Convert.ToString(R15) + " кОм \r" ;
            return answer;
        }
        public string Power()
        {   
            //string P3 = 220 * 220 / R3;
            string answer = "P1, P2: 0.64 Вт " + "P3: 220^2 / R3 " + "\r";
            return answer;
        }

        public string Hr()
        {
            string ans = "*";
            for (int i = 0; i < 40; i++)
            {
                ans += "*";
            }
            return ans;
        }
        public void CheckPoint(string x,string x1, string x2, string x3)
        {
            
            if (x  != string.Empty && x1 != string.Empty && x2 != string.Empty &&
                x3 != string.Empty && textPath.Text != string.Empty) { 
                if (Convert.ToDouble(x) > 0 && Convert.ToDouble(x1) > 0 && Convert.ToDouble(x2) > 0
                    && Convert.ToDouble(x3) > 0)
                {   
                    
                    string text = "C:\\Users\\" + Environment.UserName + "\\Desktop\\" + textPath.Text;
                    File.WriteAllText(text, Hr() + "\r" + Capacity() + Hr() + "\r" + Power() + Hr() + "\r" + Resistance() + Hr() + "\r" +
                        "\r ***** " + DateTime.Now);
                    MessageBox.Show("Done!");
                }
                else
                {
                    MessageBox.Show("Only positive numbers!");
                }
 
            }

            else
            {
                MessageBox.Show("Empty Field!");

            }
        }

        //Обработчик нажатия по кнопке
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            CheckPoint(textInput1.Text, textInput2.Text, textInput3.Text, textInput4.Text);
            
            this.Cursor = null;
        }

    }
}