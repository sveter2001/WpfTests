using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTests.Core;
using WpfTests.MVVM.Model;
using WpfTests.MVVM.View;
using WpfTests.MVVM.View.CreateTestTypes;
using WpfTests.Services;

namespace WpfTests.MVVM.ViewModel
{
    class AddTextVM : ObservableObject
    {
        private BindingList<TextQuestion> _TQDataList;
        public QuestionList QLV { get; private set; }
        public AddTextV TextV { get; private set; }
        private bool TakeOrCreate;

        public BindingList<TextQuestion> TQDataList
        {
            get { return _TQDataList; }
            set
            {
                _TQDataList = value;
                OnPropertyChanged();
            }
        }
        public AddTextVM(QuestionList QLV, AddTextV TextV, bool TakeOrCreate)
        {
            this.QLV = QLV;
            this.TextV = TextV;
            this.TakeOrCreate = TakeOrCreate;
        }


        private RelayCommand _PreviousQBtn_Click;
        public RelayCommand PreviousQBtn_Click
        {
            get
            {
                if (_PreviousQBtn_Click == null)
                {
                    _PreviousQBtn_Click = new RelayCommand(
                        param => PreviousQ()
                    );
                }
                return _PreviousQBtn_Click;
            }
        }

        private void PreviousQ()
        {
            if (QLV.currentQuestion >= 1)
            {
                SelectQuestion(TextV, TakeOrCreate);
                QLV.QuestionList1.SelectedItem = QLV.QuestionList1.Items[QLV.currentQuestion - 1];
            }
        }

        private RelayCommand _NextQBtn_Click;
        

        public RelayCommand NextQBtn_Click
        {
            get
            {
                if (_NextQBtn_Click == null)
                {
                    _NextQBtn_Click = new RelayCommand(
                        param => NextQ()
                    );
                }
                return _NextQBtn_Click;
            }
        }

        

        private void NextQ()
        {
            if (QLV.currentQuestion < TQDataList.Count - 1)
            {
                SelectQuestion(TextV, TakeOrCreate);
                QLV.QuestionList1.SelectedItem = QLV.QuestionList1.Items[QLV.currentQuestion + 1];
            }
        }
        public void SelectQuestion(AddTextV TextV, bool TakeOrCreate)
        {
            if(TQDataList.Count != 0)
                TextV.Show(TQDataList[QLV.currentQuestion], TakeOrCreate);
        }
    }
}
