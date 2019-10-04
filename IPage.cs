using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStarter
{
    public interface IPage
    {
        string Extension { set; get; }

        string PageTitle { set; get; }
        bool WithLorem { set; get; }
        bool WithHeader { set; get; }
        bool WithMain { set; get; }
        bool WithFooter { set; get; }

        List<string> Scripts { set; get; }
        List<string> Styles { set; get; }

        string Generate();
    }
}
