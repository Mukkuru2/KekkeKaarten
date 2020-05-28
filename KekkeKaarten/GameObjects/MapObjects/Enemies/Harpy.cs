using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects.MapObjects.Enemies
{
    class Harpy : EnemyMap
    {
        private static readonly Vector2[] PossibleMoves = GetMoves();

       

        public Harpy(Vector2 positionOnGrid) : base("Sprites/Map/harpy", positionOnGrid)
        {
            damage = 7;
            health = 50;
            timeToKill = 12;
            enemyID = 1;
        }

        public override void Move(Map map, Player player)
        {
            //set initial values, there will always have to be a move better then bestMove
            int bestMove = 100000;
            int bestMoveIndex = -1;

            //loop through possible moves and 
            for (int i = 0; i < PossibleMoves.Length; i++)
            {
                Vector2 move = PossibleMoves[i];
                int moveDist = (int)Math.Abs(locationOnGrid.X + move.X - player.LocationOnGrid.X) + (int)Math.Abs(locationOnGrid.Y + move.Y - player.LocationOnGrid.Y);
                MapObject targetTile = (MapObject)map.Objects[(int)(locationOnGrid.X + move.X), (int)(locationOnGrid.Y + move.Y)];
                if (moveDist < bestMove
                    && !targetTile.IsSolid)
                {
                    bestMove = moveDist;
                    bestMoveIndex = i;
                }
            }
            locationOnGrid += PossibleMoves[bestMoveIndex];
        }

        public static Vector2[] GetMoves()
        {
            Vector2[] moves = new Vector2[25];
            int n = 0;
            for (int x = -3; x <= 3; x++)
            {
                for (int y = -3; y <= 3; y++)
                {
                    if (Math.Abs(x) + Math.Abs(y) <= 3)
                    {
                        moves[n] = new Vector2(x, y);
                        n++;
                    }
                }
            }
            moves[moves.Length - 1] = new Vector2(0, 0);
            return moves;
        }
    }
}
