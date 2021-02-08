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
	}
}
