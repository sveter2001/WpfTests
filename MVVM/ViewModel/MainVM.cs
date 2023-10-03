using System;
using WpfTests.Core;

namespace WpfTests.MVVM.ViewModel
{
    class MainVM : ObservableObject
    {
        public RelayCommand TakeTestCommand { get; set; }
        public RelayCommand CreateTestCommand { get; set; }
        public TakeTestVM TTVM { get; set; }
        public CreateTestVM CTVM { get; set; }
        private object _currentView;

        public object currentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainVM()
        {
            TTVM = new TakeTestVM();
            CTVM = new CreateTestVM();

            currentView = TTVM;

            TakeTestCommand = new RelayCommand(obj =>
            {
                currentView = TTVM;
            });

            CreateTestCommand = new RelayCommand(obj =>
            {
                currentView = CTVM;
            });
        }
    }
}
