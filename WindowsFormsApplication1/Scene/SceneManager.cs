using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Scene;
using System.Drawing;
namespace WindowsFormsApplication1.Scene
{
    public class SceneManager
    {
        Scene _CurrentScene = null;

        public List<Image> lImage = new List<Image>();
        public List<Brush> lBrush = new List<Brush>();

        public void SetScene(Scene _scene)
        {
            if(_CurrentScene != null)
                _CurrentScene.Clear();
            _CurrentScene = _scene;
            _CurrentScene.Init();
        }

        void Init()
        {
            _CurrentScene.Init();
        }
        

        public void Render()
        {
            Form1.buffer_graphics.Graphics.Clear(System.Drawing.Color.Gray);
            _CurrentScene.Render();
            Form1.buffer_graphics.Render();
        }

        public void Update()
        {
            _CurrentScene.Update();
        }

        void Clear()
        {
            _CurrentScene.Clear();
        }


    }
}
