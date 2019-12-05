using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Scene;
using WindowsFormsApplication1.Item;
using System.Drawing;
using WindowsFormsApplication1.Funcition;

namespace WindowsFormsApplication1.Scene
{
    class SnowScene : Scene
    {
        public static Color[,] GroundColorArry;

        SnowManager _snowmgr = new SnowManager();
        Brush BgBrush = new SolidBrush(Color.Gray);
        Ground _ground = new Ground();
        UFO _ufo = new UFO();


        Sprtie _moon = new Sprtie(System.Windows.Forms.Application.StartupPath + "\\Rescouse\\Moon.png");

        long time = 0;
        long startTime = 0;

        void Scene.Init()
        {
            _snowmgr.Init();
            _moon.SetPos(0f, 0f);
            startTime = DateTime.Now.Ticks;
            GroundColorArry = _ground.ImgColorArry;
        }

        void Scene.Render()
        {
            Form1.buffer_graphics.Graphics.FillRectangle(BgBrush, 0f, 0f, (float)GameMain.SizeX, (float)GameMain.SizeY);
            _moon.Render();
            UFO.sprUFO.Render();
            Ground.sprGround.Render();
            _snowmgr.SnowRender();
//
        }

        void Scene.Update()
        {
            _snowmgr.UseSnowDown();
            _snowmgr.ChangeWind();
            _ufo.Move();
            time = DateTime.Now.Ticks;
            double dGap = (time - startTime) / 10000.0f;
            if (dGap > 1f)
            {
                _snowmgr.GetSnow();
                startTime = DateTime.Now.Ticks;
                time = 0;
            }
        }

        void Scene.Clear()
        {

        }
    }
}
