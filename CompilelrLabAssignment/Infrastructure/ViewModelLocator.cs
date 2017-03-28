using CompilelrLabAssignment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilelrLabAssignment.Infrastructure
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
        }
        public MainViewModel MainViewModel { get; set; }
    }
}
