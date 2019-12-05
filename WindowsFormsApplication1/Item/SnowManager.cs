using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApplication1.Item
{
    class SnowManager
    {
        Snow[] _snow = new Snow[1000];

        public static Random speedRandom = new Random();
        public static Random posRandom = new Random();
        public static Wind wind = new Wind();

        private long _startTime = 0;
        private long timeCount = 0;

        public void Init()
        {
            _startTime = System.DateTime.Now.Ticks;
            Random r = new Random();
            for (int i = 0; i < _snow.Length; ++i)
            {
                _snow[i] = new Snow();
                _snow[i].SetPos((float)r.Next(0, GameMain.SizeX),-10);
                _snow[i].windSpeedX = wind.GetSpeed();
            }
        }

        public Snow GetSnow()
        {
            for (int i = 0; i < _snow.Length; ++i)
            {
                if (_snow[i].isUse == false)
                {
                    _snow[i].isUse = true;
                    return _snow[i];
                }
            }
            return null;
        }

        public void SnowRender()
        {
            for (int i = 0; i < _snow.Length; ++i)
            {
                _snow[i].Render();
            }
        }

        public void UseSnowDown()
        {
            for (int i = 0; i < _snow.Length; ++i)
            {
                if (_snow[i].isUse)
                {
                    _snow[i].Move();
                }
            }
        }

        public void ChangeWind()
        {
            timeCount = System.DateTime.Now.Ticks;
            double dGap = (timeCount - _startTime) / 10000.0f;

            if (dGap > 3000f)
            {
                wind.Direction *= -1;
                for (int i = 0; i < _snow.Length; ++i)
                {
                    if (_snow[i].isUse)
                    {
                        _snow[i].windSpeedX = wind.GetSpeed();
                    }
                }

                _startTime = System.DateTime.Now.Ticks;
            }
        }

    }
}
