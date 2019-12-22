using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using enum
namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            Model.EF.ModelDbContext mode = new Model.EF.ModelDbContext();
            Model.EF.Student s = new Model.EF.Student();
            s.Code = "SV01";
            s.Name = "Sinh viên 01";

            mode.Students.Add(s);
            mode.SaveChanges();

            Application.Run(new Form1());
        }
    }
}
