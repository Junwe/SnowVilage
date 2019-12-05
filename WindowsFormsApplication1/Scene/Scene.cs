using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Scene
{
    public interface Scene
    {
        void Init();
        void Render();
        void Update();
        void Clear();
    }
}
