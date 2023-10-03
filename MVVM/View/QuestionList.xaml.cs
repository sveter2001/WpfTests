using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using WpfTests.Core;
using WpfTests.MVVM.Model;

namespace WpfTests.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для QuestionList.xaml
    /// </summary>
    public partial class QuestionList : UserControl, INotifyPropertyChanged
    {
        private int _currentQuestion;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int currentQuestion
        {
            get { return _currentQuestion; }
            set { _currentQuestion = value; OnPropertyChanged(); }
        }

        public QuestionList()
        {
            InitializeComponent();
        }

        public void ShowList(object list)
        {
            QuestionList1.ItemsSource = (System.Collections.IEnumerable)list;
        }

        private void QuestionList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(QuestionList1.SelectedIndex!=-1)
                currentQuestion = QuestionList1.SelectedIndex;
        }
    }
}
