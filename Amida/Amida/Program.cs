using System;
using System.Collections.Generic;

namespace Amida
{
    class MainClass
    {
		static List<int> top;
		static List<int> bottom;
		static List<int> tempTop;
		static List<int> tempBottom;
        static int num = 5;

        public static void Main(string[] args)
        {
            initialize();

            printInt(top);
            printInt(bottom);

            amidakuji(tempTop, tempBottom);

            printInt(tempTop);
            printInt(tempBottom);
        }

        static void initialize(){
			top = new List<int>();
			bottom = new List<int>();

            for (int i = 0; i < num; i++){
                top.Add(i);
            }

            rndInt(bottom, num);

			tempTop = new List<int>(top);
            tempBottom = new List<int>(bottom);
        }

        //2要素間の入れ替え
        static void swap(List<int> list, int i1, int i2){
            //値を格納する変数
            int temp = list[i2];

            //要素の入れ替え
            list[i2] = list[i1];
            list[i1] = temp;
        }

        static void printInt(List<int> list){
			foreach (int n in list)
			{
				Console.Write(n + " ");
			}
            Console.WriteLine();
        }

        static void rndInt(List<int> list, int n){
            Random rnd = new System.Random();
            bool[] isUse = new bool[n];
            for (int i = 0; i < 0; i++){
                isUse[i] = false;
            }

            while(true){
                if(list.Count>=n){
                    break;
                }
                int temp = rnd.Next(0, n);
                if(!isUse[temp]){
                    list.Add(temp);
                    isUse[temp] = true;
                }
            }
        }

        static void amidakuji(List<int> _top, List<int> _bottom){
            for (int i = 0; i < _bottom.Count - 1; i++)
			{
                int j = _top.FindIndex(item => item == _bottom[i]);
				for (int k = j; k > i; k--)
				{
					Console.WriteLine("({0} {1})", k - 1 , k);
					swap(_top, k - 1, k);
				}
			}
        }
    }
}
