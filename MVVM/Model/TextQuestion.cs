using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfTests.Core;

namespace WpfTests.MVVM.Model
{
    public class TextQuestion : ObservableObject
    {


        private string _question;

        public string question
        {
            get { return _question; }
            set { _question = value; OnPropertyChanged(); }
        }

        private string[] _answers;

        public string[] answers
        {
            get { return _answers; }
            set { _answers = value; OnPropertyChanged(); }
        }


        private int _rightAnswer;

        public int rightAnswer
        {
            get { return _rightAnswer; }
            set { _rightAnswer = value; OnPropertyChanged(); }
        }

        public TextQuestion()
        {
            answers = new string[4];
            answers[0] = " ";
            answers[1] = "";
            answers[2] = "";
            answers[3] = "";
        }


    }
}
