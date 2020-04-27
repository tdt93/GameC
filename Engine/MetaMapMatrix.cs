using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine
{
    [Serializable]
    class MetaMapMatrix
    {
        // how many maps in total in the game world
        private const int maps = 25;
        private int minPortals = 35;
        // connections between maps
        private int[,] adjacencyMatrix = new int[maps, maps];
        private int[] visited;
        private int lastNumber;
        private int currentNumber;
        // maps
        private MapMatrix[] matrix;

        public MetaMapMatrix()
        {
            // create adjacency matrix
            Random rng = new Random();
            for (int i = 0; i < minPortals; i++)
            {
                int a = rng.Next(maps);
                int b = rng.Next(maps);
                if (a == b || adjacencyMatrix[a, b] == 1) { i--; continue; }
                adjacencyMatrix[a, b] = 1;
                adjacencyMatrix[b, a] = 1;
            }
            while (!CheckConnectivity())
            {
                int a = rng.Next(maps);
                int b = rng.Next(maps);
                if (a == b || adjacencyMatrix[a, b] == 1) continue;
                adjacencyMatrix[a, b] = 1;
                adjacencyMatrix[b, a] = 1;
            }
            // create maps
            matrix = new MapMatrix[maps];
            for (int i = 0; i < maps; i++)
            {
                matrix[i] = new MapMatrix(MakePortalsList(i), rng.Next(1000 * maps));
            }
        }

        public MapMatrix GetCurrentMatrix(int codeNumber)
        {
            lastNumber = currentNumber;
            currentNumber = codeNumber;
            return matrix[codeNumber];
        }

        public int GetPreviousMatrixCode()
        {
            // for display when portal hopping
            return lastNumber;
        }

        private bool CheckConnectivity()
        {
            // check if the adjacencyMatrix represents a fully connected graph
            visited = new int[maps];
            SearchAndMark(0);
            for (int i = 0; i < maps; i++)
            {
                if (visited[i] == 0) return false;
            }
            return true;
        }

        private void SearchAndMark(int nodeNumber)
        {
            // recursive function
            visited[nodeNumber] = 1;
            for (int i = 0; i < maps; i++)
            {
                if (visited[i] == 1) continue;
                if (adjacencyMatrix[i, nodeNumber] == 0) continue;
                SearchAndMark(i);
            }
        }

        private List<int> MakePortalsList(int node)
        {
            // utility method for converting from matrix to list of portals
            List<int> ans = new List<int>();
            for (int i = 0; i < maps; i++)
            {
                if (adjacencyMatrix[i, node] == 1) ans.Add(i);
            }
            return ans;
        }
    }
}
