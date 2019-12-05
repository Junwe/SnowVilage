using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Funcition;
using System.Drawing;
namespace WindowsFormsApplication1.Item
{
    class UFO
    {
        public static Sprtie sprUFO = new Sprtie(System.Windows.Forms.Application.StartupPath + "\\Rescouse\\UFO.png");
        public static Color[,] _imgColorArry;
        public static List<Snow> ufoSnow = new List<Snow>();
        private float _x = 0f;
        private float _y = 300f;

        public static float moveSpeed = 3f;


        public UFO()
        {
            sprUFO.SetPos(0, 0);
            _imgColorArry = new Color[sprUFO.GetImange().Width, sprUFO.GetImange().Height];
            for (int i = 0; i < sprUFO.GetImange().Width; ++i)
            {
                for (int j = 0; j < sprUFO.GetImange().Height; ++j)
                {
                    _imgColorArry[i, j] = sprUFO.GetPixel(i, j);
                }
            }
        }

        public void Move()
        {
            _x += moveSpeed;
            sprUFO.SetPos(_x, _y);

            if (_x >= GameMain.SizeX + 10)
            {
                _x = -100f;
                for (int i = 0; i < ufoSnow.Count; ++i)
                {
                    ufoSnow[i].ClearSnow();
                }
                ufoSnow.Clear();
            }
        }
    }
}
