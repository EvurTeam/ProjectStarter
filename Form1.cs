using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ProjectStarter.Properties;

namespace ProjectStarter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Package.InitPackages();
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var safeTitle = textBox1.Text.RemoveTags();
            IPage page;
            if (radioButton1.Checked)
            {
                page = new HtmlPage();
            } else
            {
                page = new PhpPage();
            }
            page.PageTitle = safeTitle;
            page.WithHeader = checkBox3.Checked;
            page.WithMain = checkBox4.Checked;
            page.WithFooter = checkBox5.Checked;
            page.WithLorem = checkBox6.Checked;

            var pkgNames = checkedListBox1.CheckedItems.Cast<object>().Select(x => x.ToString());
            var packages = Package.Packages.Where(x => pkgNames.Contains(x.Name));
            foreach (var pkg in packages)
            {
                if (pkg.ScriptTags.Count > 0)
                {
                    // не включать jquery от бутстрапа, если он подключится отдельно
                    if (pkg.Name == "Bootstrap" && pkgNames.Contains("JQuery"))
                    {
                        page.Scripts.AddRange(pkg.ScriptTags.Where(x => !x.Contains("jquery")));
                    }
                    else
                    {
                        page.Scripts.AddRange(pkg.ScriptTags);
                    }
                }
                if (pkg.LinkTags.Count > 0)
                    page.Styles.AddRange(pkg.LinkTags);
            }
            var indexPage = page.Generate();
            var dirPath = (!Settings.Default.ProjectFolder.IsNull()) ? Settings.Default.ProjectFolder : (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My sites");
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            var dirSite = $"{dirPath}\\{safeTitle}";
            if (checkBox1.Checked)
            {
                var dirScripts = $"{dirSite}\\scripts";
                Directory.CreateDirectory(dirScripts);
                var js = File.CreateText($"{dirScripts}\\script.js");
                js.Close();
            }
            if (checkBox2.Checked)
            {
                var dirStyles = $"{dirSite}\\styles";
                Directory.CreateDirectory(dirStyles);
                var css = File.CreateText($"{dirStyles}\\style.css");
                css.Close();
                if (radioButton3.Checked)
                {
                    var less = File.CreateText($"{dirStyles}\\style.less");
                    less.Close();
                }
            }
            var index = new StreamWriter($"{dirSite}\\index.{page.Extension}");
            index.Write(indexPage);
            index.Close();

            System.Diagnostics.Process.Start($"{dirSite}\\index.{page.Extension}");
        }
    }
}
