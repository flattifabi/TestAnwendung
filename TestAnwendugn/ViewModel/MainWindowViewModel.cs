using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using TestAnwendugn.Helpers;
using TestAnwendugn.Views;

namespace TestAnwendugn.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string TestString { get; set; }
        public Control Content { get; set; }
        public ICommand ChangeContentToView1 { get; set; }
        public ICommand ChangeContentToView2 { get; set; }

        public MainWindowViewModel()
        {
            Content = new EineAnzeige();

            ChangeContentToView1 = new RelayCommand(param => OnChangeContentToView1());
            ChangeContentToView2 = new RelayCommand(param => OnChangeContentToView2());
        }

        private void OnChangeContentToView2()
        {
            Content = new EineAnzeige();
            TestString = "Test";
            OnPropertyChanged(nameof(TestString));
            OnPropertyChanged(nameof(Content));
        }

        private void OnChangeContentToView1()
        {
            Content = new ZweiteAnzeige();
            TestString = "Bestanden";
            OnPropertyChanged(nameof(TestString));
            OnPropertyChanged(nameof(Content));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
