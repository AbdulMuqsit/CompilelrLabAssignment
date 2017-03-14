using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilelrLabAssignment.Infrastructure
{
    public class ViewModelBase
    {
        private ViewModelLocator _viewModelLocator;

        protected ViewModelLocator ViewModelLocator
        {
            get { return _viewModelLocator ?? (_viewModelLocator = (ViewModelLocator)App.Current.Resources["ViewModelLocator"]); }
        }

    }
}
