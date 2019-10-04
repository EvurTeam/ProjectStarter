using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ProjectStarter.TextTemplates;

namespace ProjectStarter
{
    public class PhpPage : IPage
    {
        public string Extension { set; get; } = "php";

        public string PageTitle { set; get; }
        public bool WithLorem { set; get; }
        public bool WithHeader { set; get; }
        public bool WithMain { set; get; }
        public bool WithFooter { set; get; }

        public List<string> Scripts { set; get; } = new List<string>();
        public List<string> Styles { set; get; } = new List<string>();

        public string Generate()
        {
            var source = PhpPageSource;
            if (!WithHeader && !WithMain && !WithFooter)
            {
                source = source.Insert(HtmlPageSource.IndexOf("$HEADER$"), $"$LOREM${Environment.NewLine}");
            }
            var styles = Styles.Count > 0 ? string.Join(Environment.NewLine, Styles) : "";
            var scripts = Scripts.Count > 0 ? string.Join(Environment.NewLine, Scripts) : "";
            var page = source
                .Macro("TITLE", PageTitle)
                .Macro("HEADER", Header, WithHeader)
                .Macro("MAIN", Main, WithMain)
                .Macro("FOOTER", Footer, WithFooter)
                .Macro("STYLES", styles)
                .Macro("SCRIPTS", scripts)
                .Macro("LOREM", Lorem, WithLorem);
            return page;
        }
    }
}
