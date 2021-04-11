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

		public static int IndexAfter<T>(this T[] array, T value)
        {
			int index = 0;
            foreach (T member in array)
            {
                if (member.Equals(value))
                {
					return index == array.Length-1? -1: index + 1;
                }
				index++;
            }
			return -1;
        }

		public static T[] Append<T>(this T[] array, T[] appendArray)
        {
			T[] newArray = new T[array.Length + appendArray.Length];
			int n = 0;
			for(int i = 0; i < array.Length; i++)
            {
				newArray[i] = array[i];
            }
			for(int i = array.Length; i < newArray.Length; i++)
            {
				newArray[i] = appendArray[n];
				n++;
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

		public static T[] SubArray<T>(this T[,] array, int row, int col, int rowWidth)
        {
			T[] newArray = new T[rowWidth];
			for(int i = 0; i < rowWidth; i++)
            {
				newArray[i] = array[row, col + i];
            }
			return newArray;
        }

		public static bool EqualArray<T>(this T[] inArray, T[] otherArray)
		{
			if (inArray.Length != otherArray.Length)
			{
				return false;
			}

			for (int i = 0; i < inArray.Length; i++)
			{
				if (!inArray[i].Equals(otherArray[i]))
				{
					return false;
				}
			}

			return true;
		}

		public static bool EachTrue<T>(this Func<T,bool>[] funcs, T toEach)
        {
			bool eachTrue = false;
            foreach (Func<T,bool> func  in funcs)
            {
                if (!func(toEach))
                {
					eachTrue = false;
					break;
                }
                else
                {
					eachTrue = true;
                }
            }

			return eachTrue;
        }
	}
}
