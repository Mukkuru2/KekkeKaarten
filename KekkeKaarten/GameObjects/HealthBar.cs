﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Centipede.GameObjects
{
    class HealthBar : SpriteGameObject
    {
        public HealthBar(Vector2 startposition) : base("HealthBar")
        {
            position = startposition;
        }
    }
}
