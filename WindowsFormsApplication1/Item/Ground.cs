using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Funcition;
using System.Drawing;

namespace WindowsFormsApplication1.Item
{
    class Ground
    {
        public static Sprtie sprGround;
        public static Color[,] _imgColorArry;
        string filePath = System.Windows.Forms.Application.StartupPath + "\\Rescouse\\Village.png";

        public Ground()
        {
            sprGround = new Sprtie(filePath);
            sprGround.SetPos(0f, 410f);
            ImgColorArry = new Color[sprGround.GetImange().Width, sprGround.GetImange().Height];
            for (int i = 0; i < sprGround.GetImange().Width; ++i)
            {
                for (int j = 0; j < sprGround.GetImange().Height; ++j)
                {
                    ImgColorArry[i,j] = sprGround.GetPixel(i, j);
                }
            }
        }

        public Color[,] ImgColorArry
        {
            get
            {
                return _imgColorArry;
            }

            set
            {
                _imgColorArry = value;
            }
        }
    }
}
