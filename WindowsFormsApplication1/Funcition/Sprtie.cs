using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1.Funcition
{
    public class Sprtie
    {
        Image _spr;
        Bitmap _bitmap;

        float _x = 0f;
        float _y = 0f;

        Size _size = new Size(100, 100);

        public float X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public Sprtie(string szPath)
        {
            _spr = Image.FromFile(szPath);
            _bitmap = new Bitmap(_spr);
        }

        public void Render()
        {
            Form1.buffer_graphics.Graphics.DrawImage(_spr, X, Y);

        }

        public void Update()
        {

        }

        public void SetPos(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void SetPos(Point point)
        {
            Form1.buffer_graphics.Graphics.DrawImage(_spr, point);
        }

        public void Roate(float angle)
        {
            Form1.buffer_graphics.Graphics.RotateTransform(angle);
        }

        public Image GetImange()
        {
            return _spr;
        }

        public Color GetPixel(int x, int y)
        {
            Color clr = _bitmap.GetPixel(x, y);
            return clr;
        }
    }
}
