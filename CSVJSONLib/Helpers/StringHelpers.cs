using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib
{
	public static class StringHelpers
	{
		public static string[] DoubleQuoteSplit(this string text, string delimiter)
		{
			string[] easyQuotes = text.Split('\"');
			string tempText = text;
			Dictionary<string, string> quotedDatas = new Dictionary<string, string>();

			for(int index = 1; index < easyQuotes.Length; index += 2)
			{
				string quotedData = easyQuotes[index];
				string placeHolder = "[PLACEHOLDER #" + index + "]";
				quotedDatas.Add(placeHolder, quotedData);
				tempText = tempText.Replace('\"'+quotedData+'\"', placeHolder);
			}

			string[] result = tempText.Split(new string[] { delimiter }, StringSplitOptions.None);
			foreach(string placeHolder in quotedDatas.Keys)
			{
				for(int column = 0; column < result.Length; column++)
				{
					if(result[column] == placeHolder)
					{
						result[column] = quotedDatas[placeHolder];
					}
				}
			}

			return result;
		}

		public static bool IsNumeric(this string text)
        {
			return int.TryParse(text, out int number);
        }
	}
}
