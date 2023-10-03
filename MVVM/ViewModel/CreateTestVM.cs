using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfTests.Core;
using WpfTests.MVVM.Model;
using WpfTests.MVVM.View;
using WpfTests.MVVM.View.CreateTestTypes;
using WpfTests.Services;

namespace WpfTests.MVVM.ViewModel
{
    class CreateTestVM : ObservableObject
    {
        private FileIOService _fileIOService = new FileIOService();

        public string currentFileName = "";

        private BindingList<TextQuestion> _TQDataList = new BindingList<TextQuestion>();

        public BindingList<TextQuestion> TQDataList
        {
            get { return _TQDataList; }
            set { _TQDataList = value;
                OnPropertyChanged();
            }
        }

        public QuestionList QLV;

        public AddTextV TextV;
        public AddTextVM TextVM;

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

        private ICommand _OpenTest_Click;
        public ICommand OpenTest_Click
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
        private ICommand _SaveTest_Click;
        public ICommand SaveTest_Click
        {
            get
            {
                if (_SaveTest_Click == null)
                {
                    _SaveTest_Click = new RelayCommand(
                        param => SaveTest()
                    );
                }
                return _SaveTest_Click;
            }
        }
        private ICommand _CreateTest_Click;
        public ICommand CreateTest_Click
        {
            get
            {
                if (_CreateTest_Click == null)
                {
                    _CreateTest_Click = new RelayCommand(
                        param => CreateTest()
                        
                    );
                }
                return _CreateTest_Click;
            }
        }
        private ICommand _AddQuestion_Click;
        public ICommand AddQuestion_Click
        {
            get
            {
                if (_AddQuestion_Click == null)
                {
                    _AddQuestion_Click = new RelayCommand(
                        param => AddQuestion()

                    );
                }
                return _AddQuestion_Click;
            }
        }
        private ICommand _DeleteQuestion_Click;
        public ICommand DeleteQuestion_Click
        {
            get
            {
                if (_DeleteQuestion_Click == null)
                {
                    _DeleteQuestion_Click = new RelayCommand(
                        param => DeleteQuestion()

                    );
                }
                return _DeleteQuestion_Click;
            }
        }

        private void AddQuestion()
        {
            TQDataList.Add(new TextQuestion() { question = "", rightAnswer = 1 });
            QLV.ShowList(TQDataList);
        }
        private void DeleteQuestion()
        {
            if (TQDataList.Count > 1 && QLV.currentQuestion != 0)
            {
                int i = QLV.currentQuestion;
                QLV.currentQuestion = QLV.currentQuestion - 1;
                TQDataList.RemoveAt(i);
                TextV.Show(TQDataList[QLV.currentQuestion],false);
            }
            else if (QLV.currentQuestion == 0 && TQDataList.Count > 1)
            {
                TQDataList.RemoveAt(QLV.currentQuestion);
                TextV.Show(TQDataList[QLV.currentQuestion], false);
            }
        }

        public CreateTestVM()
        {
            _TQDataList.ListChanged += _TQDataList_ListChanged;
        }
        private void _TQDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SaveData(sender, currentFileName); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void TB0_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (e.OriginalSource.ToString() != "System.Windows.Controls.TextBox")
                {
                    TQDataList[QLV.currentQuestion].question = e.OriginalSource.ToString().Remove(0, 33);
                }
                else
                {
                    TQDataList[QLV.currentQuestion].question = "";
                }
                _fileIOService.SaveData(TQDataList, currentFileName);
                QLV.ShowList(TQDataList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TB11_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (e.OriginalSource.ToString() != "System.Windows.Controls.TextBox")
                {
                    TQDataList[QLV.currentQuestion].answers[0] = e.OriginalSource.ToString().Remove(0, 33);
                }
                else
                {
                    TQDataList[QLV.currentQuestion].answers[0] = "";
                }
                _fileIOService.SaveData(TQDataList, currentFileName);
                QLV.ShowList(TQDataList);
                TextV.Show(TQDataList[QLV.currentQuestion], false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TB12_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (e.OriginalSource.ToString() != "System.Windows.Controls.TextBox")
                {
                    TQDataList[QLV.currentQuestion].answers[1] = e.OriginalSource.ToString().Remove(0, 33);
                }
                else
                {
                    TQDataList[QLV.currentQuestion].answers[1] = "";
                }
                _fileIOService.SaveData(TQDataList, currentFileName);
                QLV.ShowList(TQDataList);
                TextV.Show(TQDataList[QLV.currentQuestion], false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TB13_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (e.OriginalSource.ToString() != "System.Windows.Controls.TextBox")
                {
                    TQDataList[QLV.currentQuestion].answers[2] = e.OriginalSource.ToString().Remove(0, 33);
                }
                else
                {
                    TQDataList[QLV.currentQuestion].answers[2] = "";
                }
                _fileIOService.SaveData(TQDataList, currentFileName);
                QLV.ShowList(TQDataList);
                TextV.Show(TQDataList[QLV.currentQuestion], false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TB14_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if(e.OriginalSource.ToString() != "System.Windows.Controls.TextBox")
                {
                    TQDataList[QLV.currentQuestion].answers[3] = e.OriginalSource.ToString().Remove(0, 33);
                }
                else
                {
                    TQDataList[QLV.currentQuestion].answers[3] = "";
                }
                
                _fileIOService.SaveData(TQDataList, currentFileName);
                QLV.ShowList(TQDataList);
                TextV.Show(TQDataList[QLV.currentQuestion], false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QuestionList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextV.Show(TQDataList[QLV.currentQuestion], false);
        }
        private void Cbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count != 0) 
                {
                    TQDataList[QLV.currentQuestion].rightAnswer = (int)e.AddedItems[0];
                }

                _fileIOService.SaveData(TQDataList, currentFileName);
                QLV.ShowList(TQDataList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void OpenTest()
        {
            TextV = new AddTextV();
            QLV = new QuestionList();
            QLV.DataContext = this;
            TextV.TB0.TextChanged += TB0_TextChanged;
            TextV.TB11.TextChanged += TB11_TextChanged;
            TextV.TB12.TextChanged += TB12_TextChanged;
            TextV.TB13.TextChanged += TB13_TextChanged;
            TextV.TB14.TextChanged += TB14_TextChanged;
            TextV.Cbox.SelectionChanged += Cbox_SelectionChanged;

            QLV.QuestionList1.SelectionChanged += QuestionList1_SelectionChanged;

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; 
            dialog.DefaultExt = ".json"; 
            dialog.Filter = "Text documents (.json)|*.json"; 
            dialog.InitialDirectory = $"{Environment.CurrentDirectory}";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                currentFileName = filename;
                TQDataList = _fileIOService.LoadData($"{dialog.FileName }");
                currentView1 = TextV;
                currentView2 = QLV;
                TextVM = new AddTextVM(QLV, TextV, false);
                TextVM.TQDataList = TQDataList;
                TextV.DataContext = TextVM;

                TextVM.SelectQuestion(TextV, false);
                QLV.ShowList(TQDataList);
                QLV.QuestionList1.SelectedItem = QLV.QuestionList1.Items[0];
                TextV.EndTestBtn.Command = AddQuestion_Click;
                TextV.EndTestBtn.Content = "Добавить вопрос";
                TextV.DeleteQBtn.Visibility = Visibility.Visible;
                TextV.DeleteQBtn.Command = DeleteQuestion_Click;
            }
        }
        private void SaveTest()
        {
            if (currentFileName != "")
            {
                var dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.FileName = "Document"; 
                dialog.DefaultExt = ".json"; 
                dialog.Filter = "Text documents (.json)|*.json"; 
                dialog.InitialDirectory = $"{Environment.CurrentDirectory}";
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    string filename = dialog.FileName;
                    currentFileName = filename;
                    _fileIOService.SaveData(TQDataList, $"{dialog.FileName }");
                }
            }
            
        }

        private void CreateTest()
        {
            TextV = new AddTextV();
            QLV = new QuestionList();
            QLV.DataContext = this;
            TextV.TB0.TextChanged += TB0_TextChanged;
            TextV.TB11.TextChanged += TB11_TextChanged;
            TextV.TB12.TextChanged += TB12_TextChanged;
            TextV.TB13.TextChanged += TB13_TextChanged;
            TextV.TB14.TextChanged += TB14_TextChanged;
            TextV.Cbox.SelectionChanged += Cbox_SelectionChanged;
            QLV.QuestionList1.SelectionChanged += QuestionList1_SelectionChanged;
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".json";
            dialog.Filter = "Text documents (.json)|*.json";
            dialog.InitialDirectory = $"{Environment.CurrentDirectory}";
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                currentFileName = filename;
                TQDataList = _fileIOService.LoadData($"{dialog.FileName }");
                currentView1 = TextV;
                currentView2 = QLV;
                TextVM = new AddTextVM(QLV, TextV, false);
                TextVM.TQDataList = TQDataList;
                TextV.DataContext = TextVM;

                TextVM.SelectQuestion(TextV, false);
                QLV.ShowList(TQDataList);
                QLV.QuestionList1.SelectedItem = QLV.QuestionList1.Items[0];
                TextV.EndTestBtn.Command = AddQuestion_Click;
                TextV.EndTestBtn.Content = "Добавить вопрос";
                TextV.DeleteQBtn.Visibility = Visibility.Visible;
                TextV.DeleteQBtn.Command = DeleteQuestion_Click;
            }
        }
    }
}
