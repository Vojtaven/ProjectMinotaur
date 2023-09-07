using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms
{
    internal class RandomizedKruskal : MazeGeneretingAlgorithm
    {
        public RandomizedKruskal(string name) : base(name) { }


        public override bool[,] GenerateMaze(int mazeSize)
        {
            StartingConfiguration(mazeSize);

            List<Point> walls = AddWalls();
            DisjointSetUBR disjointSetUBR = new DisjointSetUBR((mazeSize+1) * (mazeSize+1), mazeSize);


            Point currentWall, cell1, cell2;
            int index;

            while (walls.Count > 0)
            {
                index = random.Next(walls.Count);
                currentWall = walls[index];
                walls.RemoveAt(index);


                //Rozhodne, kde se nachází buňky, které by ta zed měla spojovat.
                //Pokud je souřadnice Y sudá nachází se na souřadnicích X-+1 a naopak
                if (currentWall.Y % 2 == 0)
                {
                    cell1 = new Point(currentWall.X - 1, currentWall.Y);
                    cell2 = new Point(currentWall.X + 1, currentWall.Y);
                }
                else
                {
                    cell1 = new Point(currentWall.X, currentWall.Y - 1);
                    cell2 = new Point(currentWall.X, currentWall.Y + 1);

                }

                //Pokud se buňky nacházi v dvou rozdílných setech tak je spojíme
                if (disjointSetUBR.CheckIfTwoSetsAreDifferent(cell1, cell2))
                {
                    maze[currentWall.X, currentWall.Y] = false;
                    maze[cell1.X, cell1.Y] = false;
                    maze[cell2.X, cell2.Y] = false;

                    disjointSetUBR.Union(cell1, cell2);
                }
            }



            return maze;
        }

        /// <summary>
        /// Přidá všechny zdi, které jsou mezi buňkami bludiště
        /// </summary>
        /// <returns></returns>
        private List<Point> AddWalls()
        {
            List<Point> walls = new List<Point>();
            for (int i = 1; i < mazeSize; i+=2)
            {
                for (int j = 0; j < mazeSize; j+=2)
                {
                    walls.Add(new Point(i, j));
                    walls.Add(new Point(j, i));
                }
            }
            return walls;
        }

        /// <summary>
        /// Disjoint set upraveny pro práci s bodami
        /// 2D pole je uloženo po řádcích položených za sebou
        /// </summary>
        class DisjointSetUBR
        {
            private int[] parent;
            private int[] rank;
            private int dimensionSize;

            public DisjointSetUBR(int lenght, int dimensionSize)
            {
                lenght++;
                parent = new int[lenght];
                rank = new int[lenght];
                for (int i = 0; i < lenght; i++)
                {
                    MakeSet(i);
                }

                this.dimensionSize = dimensionSize;
            }

            public void MakeSet(int i)
            {
                parent[i] = i;
            }

            public bool CheckIfTwoSetsAreDifferent(Point firstSet, Point secondSet)
            {
                return Find(firstSet) != Find(secondSet);
            }

            public int Find(Point set)
            {
                int i = (set.X) + dimensionSize * (set.Y + 1);
                while (i != parent[i])
                {
                    i = parent[i];
                }
                return i;
            }
            public void Union(Point firstSet, Point secondSet)
            {
                int i_id = Find(firstSet);
                int j_id = Find(secondSet);

                if (i_id == j_id)
                {
                    return;
                }

                if (rank[i_id] > rank[j_id])
                {
                    parent[j_id] = i_id;
                }
                else
                {
                    parent[i_id] = j_id;
                    if (rank[i_id] == rank[j_id])
                    {
                        rank[j_id]++;
                    }
                }
            }
        }
    }
}
