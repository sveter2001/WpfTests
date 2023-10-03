using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using WpfTests.Core;
using WpfTests.MVVM.Model;
using WpfTests.MVVM.View;
using WpfTests.MVVM.View.CreateTestTypes;
using WpfTests.Services;

namespace WpfTests.MVVM.ViewModel
{
    class TakeTestVM : ObservableObject
    {
        private FileIOService _fileIOService = new FileIOService();

        public QuestionList QLV;

        public AddTextV TextV;
        public AddTextVM TextVM;

        public string currentFile = "";
        public int currentQuestion = 0;
        public int currentAnswer;
        public int[] Answers;

        private BindingList<TextQuestion> _TQDataList = new BindingList<TextQuestion>();

        public BindingList<TextQuestion> TQDataList
        {
            get { return _TQDataList; }
            set
            {
                _TQDataList = value;
                OnPropertyChanged();
            }
        }

        private object _currentView1;

        public object currentView1
        {
            get { return _currentView1; }
            set
            {
                _currentView1 = value;
                OnPropertyChanged();
            }
        }
        private object _currentView2;

        public object currentView2
        {
            get { return _currentView2; }
            set
            {
                _currentView2 = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand _OpenTest_Click;
        public RelayCommand OpenTest_Click
        {
            get
            {
                if (_OpenTest_Click == null)
                {
                    _OpenTest_Click = new RelayCommand(
                        param => OpenTest()
                    );
                }
                return _OpenTest_Click;
            }
        }
        private RelayCommand _FinishTest_Click;
        public RelayCommand FinishTest_Click
        {
            get
            {
                if (_FinishTest_Click == null)
                {
                    _FinishTest_Click = new RelayCommand(
                        param => FinishTest()
                    );
                }
                return _FinishTest_Click;
            }
        }
        

        public TakeTestVM()
        {
            
        }

        private void Label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RestoreColors(currentAnswer);
            currentAnswer = 1;
            Answers[QLV.currentQuestion] = currentAnswer;
            TextV.TB1.Background = Brushes.SteelBlue;
        }
        private void Label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RestoreColors(currentAnswer);
            currentAnswer = 2;
            Answers[QLV.currentQuestion] = currentAnswer;
            TextV.TB2.Background = Brushes.SteelBlue;
        }
        private void Label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RestoreColors(currentAnswer);
            currentAnswer = 3;
            Answers[QLV.currentQuestion] = currentAnswer;
            TextV.TB3.Background = Brushes.SteelBlue;
        }
        private void Label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RestoreColors(currentAnswer);
            currentAnswer = 4;
            Answers[QLV.currentQuestion] = currentAnswer;
            TextV.TB4.Background = Brushes.SteelBlue;
        }

        private void QuestionList1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TextV.Show(TQDataList[QLV.currentQuestion],true);
            RestoreColors(currentAnswer);

            currentAnswer = Answers[QLV.currentQuestion];
            if (currentAnswer > 0)
            {
                switch (currentAnswer)
                {
                    case 1:
                        TextV.TB1.Background = Brushes.SteelBlue;
                        break;
                    case 2:
                        TextV.TB2.Background = Brushes.SteelBlue;
                        break;
                    case 3:
                        TextV.TB3.Background = Brushes.SteelBlue;
                        break;
                    case 4:
                        TextV.TB4.Background = Brushes.SteelBlue;
                        break;
                }
            }
            
        }
        private void RestoreColors(int i)
        {
            switch (i)
            {
                case -1:
                    break;
                case 1:
                    TextV.TB1.Background = TextV.TB0.Background;
                    break;
                case 2:
                    TextV.TB2.Background = TextV.TB0.Background;
                    break;
                case 3:
                    TextV.TB3.Background = TextV.TB0.Background;
                    break;
                case 4:
                    TextV.TB4.Background = TextV.TB0.Background;
                    break;
            }
        }
        public void FinishTest()
        {
            int resultOfTest = 0;
            for(int i = 0; i< TQDataList.Count; i++)
            {
                if (TQDataList[i].rightAnswer == Answers[i])
                {
                    resultOfTest++;
                }
                    
            }
            MessageBox.Show("Ваш результат: " + $"{resultOfTest}/"+$"{Answers.Length}",
                "Тест пройден", MessageBoxButton.OK, MessageBoxImage.Information);
            currentView1 = null;
            currentView2 = null;
            TextV = null;
            TextVM = null;
            QLV = null;
            Answers = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void OpenTest()
        {
            TextV = new AddTextV();
            QLV = new QuestionList();
            QLV.DataContext = this;
            
            TextV.EndTestBtn.Command = FinishTest_Click;
            TextVM = new AddTextVM(QLV, TextV, true);
            TextV.DataContext = TextVM;
            TextV.StackPnl.Visibility = Visibility.Hidden;

            QLV.QuestionList1.SelectionChanged += QuestionList1_SelectionChanged;

            TextV.TB1.MouseLeftButtonDown += Label1_MouseLeftButtonDown;
            TextV.TB2.MouseLeftButtonDown += Label2_MouseLeftButtonDown;
            TextV.TB3.MouseLeftButtonDown += Label3_MouseLeftButtonDown;
            TextV.TB4.MouseLeftButtonDown += Label4_MouseLeftButtonDown;
            TextV.TB11.Visibility = Visibility.Hidden;
            TextV.TB12.Visibility = Visibility.Hidden;
            TextV.TB13.Visibility = Visibility.Hidden;
            TextV.TB14.Visibility = Visibility.Hidden;

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; 
            dialog.DefaultExt = ".json"; 
            dialog.Filter = "Text documents (.json)|*.json"; 
            dialog.InitialDirectory = $"{Environment.CurrentDirectory}";
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                currentFile = filename;
                TQDataList = _fileIOService.LoadData($"{dialog.FileName }");
                currentView1 = TextV;
                currentView2 = QLV;
                TextVM.TQDataList = TQDataList;
                TextVM.SelectQuestion(TextV, true); 
                QLV.ShowList(TQDataList);
                Answers = new int[TQDataList.Count];
                for (int i = 0; i < Answers.Length; i++)
                {
                    Answers[i] = -1;
                }
                QLV.QuestionList1.SelectedItem = QLV.QuestionList1.Items[0];
                TextV.TB0.IsReadOnly = true;
                QLV.Answer.Visibility = Visibility.Hidden;
                QLV.Question.Width = 270;
            }
        }
    }
}
