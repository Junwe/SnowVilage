using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Item
{
    class Wind
    {
        private int direction = -1; // 바람의 방향

        private Random powerRandom = new Random();
        private Random speedRandom = new Random();

        public int Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }

        public float GetPower()
        {
            return (float)powerRandom.Next(1, 3);
        }

        public float GetSpeed()
        {
            return (float)powerRandom.Next(1,3);
        }

        public int GetDirection()
        {
            return Direction;
        }
    }
}
