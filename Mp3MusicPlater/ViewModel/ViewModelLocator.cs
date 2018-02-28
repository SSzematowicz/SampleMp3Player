using Mp3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3MusicPlater
{
    public class ViewModelLocator
    {
        private static ViewModelLocator _Instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get { return ViewModelLocator._Instance; }
            set { ViewModelLocator._Instance = value; }
        }

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
