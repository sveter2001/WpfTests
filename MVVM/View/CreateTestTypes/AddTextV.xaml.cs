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
using WpfTests.MVVM.Model;

namespace WpfTests.MVVM.View.CreateTestTypes
{
    /// <summary>
    /// Логика взаимодействия для AddTextV.xaml
    /// </summary>
    public partial class AddTextV : UserControl
    {
        public AddTextV()
        {
            InitializeComponent();
        }
        public void Show(TextQuestion Question, bool TakeOrCreate)
        {
            TB0.Text = Question.question;

            if (TakeOrCreate)
            {
                if (Question.answers != null)
                {
                    if (Question.answers[0] != null && Question.answers[0] != "")
                    {
                        TB1.Visibility = Visibility.Visible;
                        TB1.Content = Question.answers[0];
                    }
                    else
                    {
                        TB1.Visibility = Visibility.Hidden;
                    }
                    if (Question.answers[1] != null && Question.answers[1] != "")
                    {
                        TB2.Visibility = Visibility.Visible;
                        TB2.Content = Question.answers[1];
                    }
                    else
                    {
                        TB2.Visibility = Visibility.Hidden;
                    }
                    if (Question.answers[2] != null && Question.answers[2] != "")
                    {
                        TB3.Visibility = Visibility.Visible;
                        TB3.Content = Question.answers[2];
                    }
                    else
                    {
                        TB3.Visibility = Visibility.Hidden;
                    }
                    if (Question.answers[3] != null && Question.answers[3] != "")
                    {
                        TB4.Visibility = Visibility.Visible;
                        TB4.Content = Question.answers[3];
                    }
                    else
                    {
                        TB4.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                if (Question.answers != null)
                {
                    if (Question.answers[0] != null)
                    {
                        TB11.Text = Question.answers[0];
                    }
                    if (Question.answers[1] != null)
                    {
                        TB12.Text = Question.answers[1];
                    }
                    if (Question.answers[2] != null)
                    {
                        TB13.Text = Question.answers[2];
                    }
                    if (Question.answers[3] != null)
                    {
                        TB14.Text = Question.answers[3];
                    }
                    ///////////////////////////////////////
                    Cbox.Items.Clear();
                    if (Question.answers[0] != "")
                    {
                        Cbox.Items.Add(1);
                    }
                    if (Question.answers[1] != "")
                    {
                        Cbox.Items.Add(2);
                    }
                    if (Question.answers[2] != "")
                    {
                        Cbox.Items.Add(3);
                    }
                    if (Question.answers[3] != "")
                    {
                        Cbox.Items.Add(4);
                    }
                }
            }
        }
    }
}
