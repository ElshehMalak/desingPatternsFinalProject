using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using desingPatternsFinalProject.Patterns;
using static desingPatternsFinalProject.Program;

namespace desingPatternsFinalProject
{
    internal static class Program
    {
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MockData.InitData();
            Application.Run(new RegisterForm());

        }
    }
}
