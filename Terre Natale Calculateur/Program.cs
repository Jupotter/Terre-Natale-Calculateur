using System;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
           // try
          //  {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
           // }
           // catch (Exception e)
           // {
           //     Log.Logger.WriteException(e);
           // }
        }
    }
}