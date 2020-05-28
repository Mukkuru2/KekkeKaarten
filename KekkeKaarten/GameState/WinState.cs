using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameState
{
    class WinState:GameObjectList
    {
        private static int points = 0;
        public static int Points { get => points; set => points = value; }
        public WinState() : base()
        {

        }
    }
}
