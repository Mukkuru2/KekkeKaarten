using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KekkeKaarten.GameObjects.MapObjects.Enemies
{
    class ChessHorse : EnemyMap
    {
        private static readonly Vector2[] PossibleMoves = GetMoves();

        private bool canMove;

        public bool CanMove { get => canMove; set => canMove = value; }
        public ChessHorse(Vector2 positionOnGrid) : base("Sprites/Map/horse", positionOnGrid)
        {
            damage = 3;
            health = 100;
            timeToKill = 15;
            enemyID = 2;
        }

        public override void Move(Map map, Player player)
        {
            base.Move(map, player);
            if (canMove)
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
                Console.WriteLine(locationOnGrid);
                canMove = false;
            }
            else {
                canMove = true;
            }
        }

        public static Vector2[] GetMoves()
        {
            Vector2[] moves = new Vector2[9];
            int n = 0;
            for (int x = -2; x <= 2; x++)
            {
                for (int y = -2; y <= 2; y++)
                {
                    if ((Math.Abs(x) == 2 && Math.Abs(y) == 1) || (Math.Abs(y) == 2 && Math.Abs(x) == 1))
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
