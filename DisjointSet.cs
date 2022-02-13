namespace asim.unity.datastructures
{
    /// <summary>
    /// https://www.dotnetlovers.com/Article/184/disjoint-sets-data-structure
    /// https://www.youtube.com/watch?v=ibjEGG7ylHk&ab_channel=WilliamFiset
    /// https://algorithms.tutorialhorizon.com/disjoint-set-union-find-algorithm-union-by-rank-and-path-compression/#:~:text=Union%20by%20rank%20always%20attaches,and%20a%20rank%20of%20zero.&text=Both%20trees%20have%20the%20different,the%20larger%20of%20the%20two.
    /// </summary>
    public class DisjointSet
    {
        int[] parent;   // stores index of parent node
        int[] rank;     //stores rank of perticular node

        /// <summary>
        /// Create a number of disjoint sets
        /// </summary>
        public DisjointSet(int NumOfSets)
        {
            parent = new int[NumOfSets];   //initializng length of set
            rank = new int[NumOfSets];

            //initially making parent of element itself
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i; //making parent itself
                rank[i] = 0;    //initially rank is zero
            }
        }

        /// <summary>
        /// Union by rank -  attaches the shorter tree to the root of the taller tree, additional optimization
        /// </summary>
        public void Union(int x, int y)
        {
            int representativeX = FindSet(x); //finding representative of x
            int representativeY = FindSet(y); //finding representative of y

            //if both has same rank , then make x to be y's parent
            if (rank[representativeX] == rank[representativeY])
            {
                rank[representativeY]++; //incrementing rank of y
                parent[representativeX] = representativeY;
            }
            //else making the parent which is having higher rank
            else if (rank[representativeX] > rank[representativeY])
            { 
                parent[representativeY] = representativeX; 
            }
            else
            { 
                parent[representativeX] = representativeY; 
            }
        }
        /// <summary>
        /// Finds representative of a set, by simply looking though the parent list until recursively until it is referncning itself(then it becomes the root node)
        /// </summary>
        public int FindSet(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = FindSet(parent[x]); //path compression , after finding the root node, re-refenrence all the other nodes to point to that root node
            }

            return parent[x];
        }
    }
}

