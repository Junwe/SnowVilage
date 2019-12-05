using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Scene;
using WindowsFormsApplication1.Funcition;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static Timer timer = new Timer();

        public static BufferedGraphics buffer_graphics;
        public static BufferedGraphicsContext currentContext;

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            currentContext = BufferedGraphicsManager.Current;
            buffer_graphics = currentContext.Allocate(this.CreateGraphics(),
                this.DisplayRectangle);
        }

        public void GameLoop()
        {
            SnowScene snowScene = new SnowScene();

            GameMain._scenemgr.SetScene(snowScene);

            while (this.Created)
            {
                timer.Reset();
                GameMain._scenemgr.Update();
                GameMain._scenemgr.Render();
                Application.DoEvents();
                while (timer.GetTicks() < 30) ;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();   //컨트롤을 다시 그리는 명령
        }
    }
}
