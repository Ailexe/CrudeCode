using System;
using System.Collections.Generic;

namespace TowerOfHanoi
{
    class MainClass
    {
        static int count = 0;
        static List<List<int>> piles;
        public static void Main(string[] args)
        {
            int num = 3;
            initialize(num);
            hanoi(num, 0, 2, 1);
            Console.WriteLine(count);
        }

        static void initialize(int n){
            piles = new List<List<int>>();
            List<int> temp = new List<int>();
            piles.Add(temp);
			for (int i = 0; i < 3; i++)
			{
				piles.Add(new List<int>());
			}
			for (int i = 0; i < n; i++)
			{
                piles[0].Add(i);
			}
        }

        static void printPiles(){
            for (int i = 0; i < piles.Count; i++)//ジェネリックの出力
			{
                Console.Write(i + ":");
                foreach (int disk in piles[i])
				{
					Console.Write(disk + " ");
				}
                Console.WriteLine();
			}
        }

        static void moveOne(int from, int to){
            int disk = piles[from][piles[from].Count - 1];
            piles[from].RemoveAt(piles[from].Count - 1);
            piles[to].Add(disk);
            count++;
        }

        static void hanoi(int n, int from, int to, int work){
            if(n == 0){
                return;
            }
            hanoi(n - 1, from, work, to);
            moveOne(from, to);
            printPiles();
            hanoi(n - 1, work, to, from);
        }
    }
}
