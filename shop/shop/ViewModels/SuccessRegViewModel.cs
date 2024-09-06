using shop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace shop.ViewModels
{
    public class SuccessRegViewModel: ViewModelBase
    {
        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                this.text = value;
                OnPropertyChanged("Text");
            }
        }
        public SuccessRegViewModel(string text)
        {
            Text = text;
        }

        //на главную
        private DelegateCommand openAuthCommand;
        public ICommand OpenAuthCommand
        {
            get
            {
                if (openAuthCommand == null)
                {
                    openAuthCommand = new DelegateCommand(() =>
                    {
                        App.OpenAuth();
                    });
                }
                return openAuthCommand;

            }
        }
    }
}
