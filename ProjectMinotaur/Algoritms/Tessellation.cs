using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    internal class Tessellation : MazeGeneretingAlgoritm
    {
        private int[,] offsetCoeficinets = { { 1, 0 }, { 0, 1 },{ 1, 1 } };
        private int[,] wallRemovingCoeficients = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        private bool[,] maze;
        private int chunkSize;

        public Tessellation(string name) : base(name) { }


        public override bool ValidSize(int mazeSize, out int[] sugestedSizes)
        {
            sugestedSizes = new int[2];
            if (IsPowerOfTwo(mazeSize))
            {
                return true;
            }
            else
            {
                sugestedSizes = NearestPowersOfTwo(mazeSize);
                return false;
            }
        }
        public override bool[,] GenerateMaze(int mazeSize)
        {
            maze = new bool[mazeSize, mazeSize];
            chunkSize = 2;
            StartingConfiguration();
            while (chunkSize < mazeSize)
            {
                CopyChunk();
                RemoveChunkWalls();
                chunkSize = chunkSize * 2;
            }
            return maze;
        }

        private void CopyChunk()
        {
            int x,y;
            int mazeSize = maze.GetLength(0);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < chunkSize; j++)
                {
                    for (int k = 0; k < chunkSize; k++)
                    {
                        x = chunkSize * offsetCoeficinets[i, 0] + j;
                        y = chunkSize * offsetCoeficinets[i, 1] + k;
                        if(x<mazeSize && y< mazeSize)
                            maze[x, y] = maze[j, k];
                    }
                }
            }
        }

        private void RemoveChunkWalls()
        {
            Random random = new Random();
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

        private bool IsPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }
        private int[] NearestPowersOfTwo(int x)
        {
            int[] nearestPowers = new int[2];
            nearestPowers[1] = (int)BitOperations.RoundUpToPowerOf2((uint)x);
            nearestPowers[0] = (nearestPowers[1] >> 1)-1;
            nearestPowers[1]--;
            return nearestPowers;

        }

        private void StartingConfiguration()
        {
            maze[1, 0] = true;
            maze[1,1] = true;
            maze[0,1] = true;
        }

    }
}
