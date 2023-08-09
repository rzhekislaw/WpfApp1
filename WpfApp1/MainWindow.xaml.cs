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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int n = 2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ModeSwitch_Click(object sender, RoutedEventArgs e)
        {
            var plusStatus = Plus.Visibility;
            var powStatus = Pow2.Visibility;

            if(plusStatus == Visibility.Visible)
            {
                ModeSwitch.Content = "Advanced";
                Plus.Visibility = Visibility.Hidden;
                Minus.Visibility = Visibility.Hidden;
                Multiply.Visibility = Visibility.Hidden;
                Divide.Visibility = Visibility.Hidden;
                rOperand.Visibility = Visibility.Hidden;
            }
            else
            {
                ModeSwitch.Content = "Default";
                Plus.Visibility = Visibility.Visible;
                Minus.Visibility = Visibility.Visible;
                Multiply.Visibility = Visibility.Visible;
                Divide.Visibility = Visibility.Visible;
                rOperand.Visibility = Visibility.Visible;
            }

            if (powStatus == Visibility.Visible)
            {
                Pow2.Visibility = Visibility.Hidden;
                PowN.Visibility = Visibility.Hidden;
                Sqrt2.Visibility = Visibility.Hidden;
                SqrtN.Visibility = Visibility.Hidden;
                RB2.Visibility = Visibility.Hidden;
                RB3.Visibility = Visibility.Hidden;
                RB4.Visibility = Visibility.Hidden;
                SelectLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                Pow2.Visibility = Visibility.Visible;
                PowN.Visibility = Visibility.Visible;
                Sqrt2.Visibility = Visibility.Visible;
                SqrtN.Visibility = Visibility.Visible;
                RB2.Visibility = Visibility.Visible;
                RB3.Visibility = Visibility.Visible;
                RB4.Visibility = Visibility.Visible;
                SelectLabel.Visibility = Visibility.Visible;
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if(!decimal.TryParse(lOperand.Text, out decimal lO))
            {
                lOperand.Text = "Parsing failure. Try again";
                return;
            }
            if (!decimal.TryParse(rOperand.Text, out decimal rO))
            {
                rOperand.Text = "Parsing failure. Try again";
                return;
            }
            Result.Text = (lO + rO).ToString();
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(lOperand.Text, out decimal lO))
            {
                lOperand.Text = "Parsing failure. Try again";
                return;
            }
            if (!decimal.TryParse(rOperand.Text, out decimal rO))
            {
                rOperand.Text = "Parsing failure. Try again";
                return;
            }
            Result.Text = (lO - rO).ToString();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(lOperand.Text, out decimal lO))
            {
                lOperand.Text = "Parsing failure. Try again";
                return;
            }
            if (!decimal.TryParse(rOperand.Text, out decimal rO))
            {
                rOperand.Text = "Parsing failure. Try again";
                return;
            }
            Result.Text = (lO * rO).ToString();
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(lOperand.Text, out decimal lO))
            {
                lOperand.Text = "Parsing failure. Try again";
                return;
            }
            if (!decimal.TryParse(rOperand.Text, out decimal rO))
            {
                rOperand.Text = "Parsing failure. Try again";
                return;
            }
            if(rO == 0)
            {
                Result.Text = "Dividing by 0 is forbidden";
                return;
            }
            Result.Text = (lO / rO).ToString();
        }

        private void RB2_Click(object sender, RoutedEventArgs e)
        {
            n = int.Parse(RB2.Content.ToString());
        }

        private void RB3_Click(object sender, RoutedEventArgs e)
        {
            n = int.Parse(RB3.Content.ToString());
        }

        private void RB4_Click(object sender, RoutedEventArgs e)
        {
            n = int.Parse(RB4.Content.ToString());
        }

        private void Sqrt2_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(lOperand.Text, out decimal lO))
            {
                lOperand.Text = "Parsing failure. Try again";
                return;
            }
            Math.DivRem(n, 2, out int rem);
            if(rem == 0 && lO < 0)
            {
                Result.Text = "Operand must be non-negative";
                return;
            }
            Result.Text = "+-" + (Math.Sqrt(double.Parse(lO.ToString()))).ToString();
        }

        private void SqrtN_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(lOperand.Text, out decimal lO))
            {
                lOperand.Text = "Parsing failure. Try again";
                return;
            }
            Math.DivRem(n, 2, out int rem);
            var pow = ((double)(1) / (double)(n)).ToString();
            if (rem == 0 && lO < 0)
            {
                Result.Text = "Operand must be non-negative";
                return;
            }
            if (rem != 0 && lO < 0)
            {
                lO *= -1;
                Result.Text = "-" + (Math.Pow(double.Parse(lO.ToString()), double.Parse(pow))).ToString();
                return;
            }
            if (rem == 0 && lO > 0)
            {
                Result.Text = "+-" + (Math.Pow(double.Parse(lO.ToString()), double.Parse(pow))).ToString();
                return;
            }
            if (rem != 0 && lO > 0)
            {
                Result.Text = (Math.Pow(double.Parse(lO.ToString()), double.Parse(pow))).ToString();
                return;
            }
        }

        private void Pow2_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(lOperand.Text, out decimal lO))
            {
                lOperand.Text = "Parsing failure. Try again";
                return;
            }
            Result.Text = (Math.Pow(double.Parse(lO.ToString()), 2)).ToString();
        }

        private void PowN_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(lOperand.Text, out decimal lO))
            {
                lOperand.Text = "Parsing failure. Try again";
                return;
            }
            Result.Text = (Math.Pow(double.Parse(lO.ToString()), n)).ToString();
        }
    }
}
