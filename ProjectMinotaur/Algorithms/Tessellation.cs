using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    internal class Tessellation : MazeGeneretingAlgorithm
    {
        private int[,] offsetCoeficinets = { { 1, 0 }, { 0, 1 }, { 1, 1 } };
        private int[,] wallRemovingCoeficients = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        private int chunkSize;

        public Tessellation(string name) : base(name) { }


        public override bool ValidSize(int mazeSize, out int[] sugestedSizes)
        {

            if (IsPowerOfTwo(mazeSize+1))
            {
                return base.ValidSize(mazeSize, out sugestedSizes);
            }
            else
            {
                sugestedSizes = NearestPowersOfTwoMinusOne(mazeSize);
                return false;
            }
        }
        public override bool[,] GenerateMaze(int mazeSize)
        {

            StartingConfiguration(mazeSize);
            while (chunkSize < this.mazeSize)
            {
                CopyChunk(chunkSize);
                RemoveChunkWalls(chunkSize);
                chunkSize = chunkSize * 2;
            }
            return maze;
        }

        /// <summary>
        /// Zkopíruje chunk dané velikosti začínající na souřadnicích [0,0] na sousedící chunky dané velikosti 
        /// </summary>
        /// <param name="chunkSize"></param>
        private void CopyChunk(int chunkSize)
        {
            int x, y;
            int mazeSize = maze.GetLength(0);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < chunkSize; j++)
                {
                    for (int k = 0; k < chunkSize; k++)
                    {
                        x = chunkSize * offsetCoeficinets[i, 0] + j;
                        y = chunkSize * offsetCoeficinets[i, 1] + k;
                        if (x < mazeSize && y < mazeSize)
                            maze[x, y] = maze[j, k];
                    }
                }
            }
        }
        /// <summary>
        /// Odstraní zdi na pomezí chunů dané velikosti
        /// </summary>
        /// <param name="chunkSize"></param>
        private void RemoveChunkWalls(int chunkSize)
        {
            int wallWithoutHole = random.Next(4);
            int holePosition;
            int x, y;
            for (int i = 0; i < 4; i++)
            {
                if (i != wallWithoutHole)
                {
                    if (wallRemovingCoeficients[i, 0] != 0)
                    {
                        do
                        {
                            holePosition = random.Next(1, chunkSize);
                            x = chunkSize - 1 + wallRemovingCoeficients[i, 0] * holePosition;
                            y = chunkSize - 1 + wallRemovingCoeficients[i, 1] * holePosition;
                        } while ((maze[x, y + 1] || maze[x, y - 1]));
                    }
                    else
                    {
                        do
                        {
                            holePosition = random.Next(1, chunkSize);
                            x = chunkSize - 1 + wallRemovingCoeficients[i, 0] * holePosition;
                            y = chunkSize - 1 + wallRemovingCoeficients[i, 1] * holePosition;
                        } while ((maze[x + 1, y] || maze[x - 1, y]));
                    }
                    maze[x, y] = false;
                }
            }
        }

        /// <summary>
        /// Zkontroluje zda x je mocninou 2
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private bool IsPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }

        /// <summary>
        /// Najde dvě nejbližší mocniny dvojky minus jedna k číslu x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int[] NearestPowersOfTwoMinusOne(int x)
        {
            int[] nearestPowers = new int[2];
            nearestPowers[1] = (int)BitOperations.RoundUpToPowerOf2((uint)x);
            nearestPowers[0] = (nearestPowers[1] >> 1) - 1;
            nearestPowers[1]--;
            return nearestPowers;

        }

        protected override void StartingConfiguration(int mazeSize)
        {
            this.mazeSize = mazeSize;
            maze = new bool[mazeSize, mazeSize];
            chunkSize = 2;
            maze[1, 0] = true;
            maze[1, 1] = true;
            maze[0, 1] = true;
        }

    }
}
