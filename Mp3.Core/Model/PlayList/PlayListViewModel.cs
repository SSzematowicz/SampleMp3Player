using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3.Core
{
    public class PlayListViewModel : BaseViewModel
    {
        public List<PlayListitemControlViewModel> Items { get; set; }
    }
}
