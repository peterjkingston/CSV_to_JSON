using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib
{
	public static class ArrayHelpers
	{
		public static void Fill<T>(this T[] array, T value)
		{
			for(int i = 0; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

		public static void Fill<T>(this T[,] array, T value)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for(int j = 0; j < array.GetLength(1); j++)
				{
					array[i,j] = value;
				}
			}
		}

		public static T[] Append<T>(this T[] array, T[] appendArray)
        {
			T[] newArray = new T[array.Length + appendArray.Length];

			for(int i = 0; i < array.Length; i++)
            {
				newArray[i] = array[i];
            }
			for(int i = array.Length; i < newArray.Length; i++)
            {
				newArray[i] = appendArray[i];
            }

			return newArray;
        }

		public static T[,] To2DArray<T>(this T[][] jagged, int fixedWidth)
        {
			T[,] new2D = new T[jagged.GetLength(0),fixedWidth];
			for(int row = 0; row < new2D.GetLength(0); row++)
            {
				for(int col = 0; col < new2D.GetLength(1); col++)
                {
					new2D[row, col] = jagged[row][col];
                }
            }
			return new2D;
        }

		public static bool OnlyContains<T>(this T[] array, T[] allowed)
        {
			foreach(T arrayMember in array)
            {
                if (!allowed.Contains(arrayMember))
                {
					return false;
                }
            }
			return true;
        }
	}
}
