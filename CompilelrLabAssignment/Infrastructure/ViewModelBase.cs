using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompilelrLabAssignment.Infrastructure
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private ViewModelLocator _viewModelLocator;

        protected ViewModelLocator ViewModelLocator
        {
            get { return _viewModelLocator ?? (_viewModelLocator = (ViewModelLocator)App.Current.Resources["ViewModelLocator"]); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
