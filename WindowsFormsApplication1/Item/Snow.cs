using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Funcition;
using System.Drawing;
using WindowsFormsApplication1.Scene;

namespace WindowsFormsApplication1.Item
{
    class Snow
    {
        public Brush SnowBrush = new SolidBrush(Color.White);

        public bool isUse = false;

        public float windPowerX = 0f;
        public float windSpeedX = 0f;

        public float _x = 0f;
        public float _y = 0f;
        private float width = 5f;
        private float height = 5f;

        private long timeCount = 0;
        private long _startTime = 0;

        private int _downSpeed = 0;

        public Snow()
        {
            _downSpeed = SnowManager.speedRandom.Next(3, 7);
        }

        public void Render()
        {
            Form1.buffer_graphics.Graphics.FillPie(SnowBrush, _x, _y, width, height, 0f, 360f);
        }

        public void SetPos(float x, float y)
        {
            _x = x;
            _y = y;
        }

        private float GetWind()
        {
            windPowerX += (windSpeedX * SnowManager.wind.Direction) * 0.01f;

            if (windPowerX <= -5f)
            {
                windPowerX = -5f;
            }
            if (windPowerX >= 5f)
            {
                windPowerX = 5f;
            }

            return windPowerX;
        }

        public void Move()
        {
            int check = CheckWall();
            if (check == 3)
            {
                _x += UFO.moveSpeed;
            }
            if (check == 2)
            {
                _y += _downSpeed;

                _x += GetWind();

                if (_x <= 0)
                {
                    _x = 0;
                }
                if (_x >= GameMain.SizeX - 10)
                {
                    _x = GameMain.SizeX - 10;
                }

                SetPos(_x, _y);
                _startTime = System.DateTime.Now.Ticks;
            }
            else if (check == 1)
            {
                timeCount = System.DateTime.Now.Ticks;
                double dGap = (timeCount - _startTime) / 10000.0f;

                if (dGap > 10000f)
                {
                    ClearSnow();
                }
            }
        }

        public void ClearSnow()
        {
            isUse = false;

            SetPos((float)SnowManager.posRandom.Next(0, GameMain.SizeX), -10);
            timeCount = 0;
            windSpeedX = SnowManager.wind.GetSpeed();
            windPowerX = 0;
        }

        // 1 : 땅 , 2 : 하늘 , 3: ufo
        int CheckWall()
        {
            // 땅 충돌 체크
            if ((_x >= 0 && _x < Ground.sprGround.GetImange().Width - 1) &&
            (_y >= Ground.sprGround.Y && (_y) < Ground.sprGround.GetImange().Height + Ground.sprGround.Y))
            {
                // 이미지 기준으로 색 검사
                Color CheckGroundAlpha = SnowScene.GroundColorArry[(int)_x - ((int)Ground.sprGround.X - 1)
                                            , (int)_y - ((int)Ground.sprGround.Y - 1)];
                // Alpha가 0이 아니면 거기서 멈춤
                if (CheckGroundAlpha.A != 0)
                {
                    return 1; // 땅일때
                }
                else
                {
                    return 2; // 하늘일때
                }
            }

            // UFO 충돌체크
            if ((_x >= UFO.sprUFO.X) &&
                (_y >= UFO.sprUFO.Y) &&
                (_x <= UFO.sprUFO.X + UFO.sprUFO.GetImange().Width - 1) &&
                (_y <= UFO.sprUFO.Y + UFO.sprUFO.GetImange().Height - 1))
            {
                Color CheckUFOAlpha = UFO._imgColorArry[(int)_x - (int)UFO.sprUFO.X,(int)_y - (int)UFO.sprUFO.Y];

                if (CheckUFOAlpha.A != 0)
                {
                    UFO.ufoSnow.Add(this);
                    return 3;
                }
                else
                {
                    return 2;
                }
            }

            return 2; // 하늘일때
        }
    }
}
