using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Mvvm;

namespace Calculateur.ViewModel
{
    class AboutDialog : BindableBase
    {
        private Assembly assembly;
        private FileVersionInfo fileVersionInfo;

        public string AppName
        {
            get { return fileVersionInfo.ProductName; }
        }

        public string AppVersion
        {
            get { return assembly.GetName().Version.ToString(); }
        }

        public string AppPublisher
        {
            get { return FileVersionInfo.GetVersionInfo(assembly.Location).CompanyName; }
        }

        public AboutDialog()
        {
            assembly = Assembly.GetExecutingAssembly();
            fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
        }

        public Uri UpdateUri
        {
            get { return new Uri("https://github.com/Jupotter/Terre-Natale-Calculateur/releases/latest"); }
        }
    }
}
