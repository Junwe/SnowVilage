using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Scene;
namespace WindowsFormsApplication1
{
    static class GameMain
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        public static SceneManager _scenemgr = new SceneManager();

        public static int SizeX = 960;
        public static int SizeY = 720;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new Form1());
            //Form1 myFrom = new Form1();
            using (Form1 form1 = new Form1())
            {
                form1.Show();
                form1.GameLoop();
            }



        }
    }
}
