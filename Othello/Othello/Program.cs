using System;

namespace Othello
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			Simulator rs = new Simulator();
			/*
             * 
             *
             */
		}
	}

	class Simulator
	{
		//オセロ
		private Othello othello = new Othello();
		//コンストラクター
		public Simulator()
		{
		}

		//手番判定
		public void phaseCheck(string phase, int x, int y)
		{
			if ("B".Equals(phase))
			{
				simulate(1, x - 1, y - 1);
			}
			else if ("W".Equals(phase))
			{
				simulate(-1, x - 1, y - 1);
			}
		}

		public String getResultString()
		{
			int black = 0;
			int white = 0;
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (this.othello.isWhite(i, j))
					{
						white++;
					}
					else if (this.othello.isBlack(i, j))
					{
						black++;
					}
				}
			}
			String resultFormat = getResultFormat(black, white);
			if (white < black)
			{
				return String.Format("{0} The black won!", resultFormat);
			}
			else if (white > black)
			{
				return String.Format("{0} The white won!", resultFormat);
			}

			return String.Format("{0} Draw!", resultFormat);
		}

		//マスを配置してシミュレートを行う
		public void simulate(int phase, int xIndex, int yIndex)
		{
			// マスに配置
			this.othello.setBoards(xIndex, yIndex, phase);

			// 左が異なる色か
			simulateNext(phase, xIndex, yIndex, -1, 0);
			// 左上が異なる色か
			simulateNext(phase, xIndex, yIndex, -1, -1);
			// 上が異なる色か
			simulateNext(phase, xIndex, yIndex, 0, -1);
			// 右上が異なる色か
			simulateNext(phase, xIndex, yIndex, 1, -1);
			// 右が異なる色か
			simulateNext(phase, xIndex, yIndex, 1, 0);
			// 右下が異なる色か
			simulateNext(phase, xIndex, yIndex, 1, 1);
			// 下が異なる色か
			simulateNext(phase, xIndex, yIndex, 0, 1);
			// 左下が異なる色か
			simulateNext(phase, xIndex, yIndex, -1, 1);
		}

		//チェック位置のマスの状態を判定
		private void simulateNext(int phase, int xIndex, int yIndex, int xDirection, int yDirection)
		{
			// 配置したマスの隣が存在するか
			if (!this.othello.hasIndex(xIndex + xDirection, yIndex + yDirection))
			{
				return;
			}
			// 配置したマスの隣が異なる色か
			if (this.othello.isSame(xIndex + xDirection, yIndex + yDirection, (phase * -1)))
			{
				simulateReverse(phase, xIndex, yIndex, xDirection, yDirection);
			}
		}

		//裏返しの判定をシミュレートする
		private void simulateReverse(int phase, int xIndex, int yIndex, int xDirection, int yDirection)
		{
			for (int i = xIndex + (xDirection * 2), j = yIndex + (yDirection * 2); ((this.othello.hasIndex(i, j))); i = i + xDirection, j = j + yDirection)
			{
				//マスを挟むことができた場合に裏返し処理を行う
				if (this.othello.isSame(i, j, phase))
				{
					// 裏返す
					reverseBoards(phase, xIndex, yIndex, xDirection, yDirection, i, j);
					return;
				}
			}
		}

		//ひっくり返す
		private void reverseBoards(int phase, int xIndex, int yIndex, int xDirection, int yDirection, int xIndex2, int yIndex2)
		{
			for (int i = xIndex + xDirection, j = yIndex + yDirection; (this.othello.hasIndex(i, j)); i = i + xDirection, j = j + yDirection)
			{
				// 裏返す
				this.othello.setBoards(i, j, phase);
				// 最後まで裏返したか
				if (i == xIndex2 && j == yIndex2)
				{
					return;
				}
			}

		}

		//環境向けに形式を整える
		private String getResultFormat(int black, int white)
		{
			return String.Format("{0}-{1}", black, white);
		}
	}

	class Othello
	{

		//初期位置を格納した配列
		private int[,] boards = {
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 1, -1, 0, 0, 0 },
			{ 0, 0, 0, -1, 1, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 }
		};

		//コンストラクタ
		public Othello()
		{
		}

		//(x,y)に置かれているコマが黒ならtrueを返す
		public bool isBlack(int xIndex, int yIndex)
		{
			return (this.boards[xIndex, yIndex] == 1);
		}

		//(x,y)に置かれているコマが黒ならtrueを返す
		public bool isWhite(int xIndex, int yIndex)
		{
			return (this.boards[xIndex, yIndex] == -1);
		}

		//(x,y)に置かれているコマがvalueと等しい時にtrueを返す
		public bool isSame(int xIndex, int yIndex, int value)
		{
			return (this.boards[xIndex, yIndex] == value);
		}

		//(x,y)に指定のコマを置く
		public void setBoards(int xIndex, int yIndex, int value)
		{
			this.boards[xIndex, yIndex] = value;
		}

		//端以降の処理を行わない
		public bool hasIndex(int xIndex, int yIndex)
		{
			if ((0 <= xIndex) && (xIndex <= 7) && (0 <= yIndex) && (yIndex <= 7))
			{
				return true;
			}
			return false;
		}
	}
}
