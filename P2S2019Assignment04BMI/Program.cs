using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2S2019Assignment04BMI
{
    internal static class Program
    {
        public static SplashForm startForm;
        public static BMICalculatorForm bmiform;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            startForm = new SplashForm();
            bmiform = new BMICalculatorForm();

            Application.Run(new SplashForm());
        }
    }
}