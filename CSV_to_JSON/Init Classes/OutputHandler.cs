using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_to_JSON.Init_Classes
{
    public class OutputHandler : IOutputHandler
    {
        private ISwitchArgs _switchArgs;

        public OutputHandler(ISwitchArgs switchArgs)
        {
            _switchArgs = switchArgs;
        }

        public void OutputError(string errorMessage)
        {
            File.AppendAllText("ErrorLog.txt", "<!--START ERROR-->\n" + DateTime.Now.ToString() + " " + errorMessage + "\n<!--END ERROR-->\n");
        }

        public void ToOutputStream(string outputObj)
        {
            Console.WriteLine(outputObj);
        }

        public void ToOutputStream(byte[] vs)
        {
            Console.Write(vs);
        }

        public void PrintToFile(string outputObj, string toFile)
        {
            //byte[] outputBytes = _switchArgs.TargetFileEncoding.GetBytes(outputObj);
            //byte[] utf8Bytes = Encoding.Convert(_switchArgs.TargetFileEncoding, Encoding.UTF8, outputBytes);
            //bool samefuckinbytes = outputBytes.EqualArray(utf8Bytes);
            //File.WriteAllText(toFile, Encoding.UTF8.GetString(uBtf8Bytes), Encoding.UTF8);
            if(_switchArgs.TargetFileEncoding.CodePage == 1252)
            {
                string utf8String = ConvertFromWindowsToUnicode(outputObj);
                File.WriteAllText(utf8String, toFile, Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(toFile, outputObj);
            }

        }

        public void PrintToFile(byte[] outputObj, string toFile)
        {
            File.WriteAllBytes(toFile, outputObj);
        }

        private static readonly Dictionary<int, char> CharactersToMap = new Dictionary<int, char>
        {
            {130, '‚'},
            {131, 'ƒ'},
            {132, '„'},
            {133, '…'},
            {134, '†'},
            {135, '‡'},
            {136, 'ˆ'},
            {137, '‰'},
            {138, 'Š'},
            {139, '‹'},
            {140, 'Œ'},
            {145, '‘'},
            {146, '’'},
            {147, '“'},
            {148, '”'},
            {149, '•'},
            {150, '–'},
            {151, '—'},
            {152, '˜'},
            {153, '™'},
            {154, 'š'},
            {155, '›'},
            {156, 'œ'},
            {159, 'Ÿ'},
            {173, '-'},
            {176, '°'}
        };

        public static string ConvertFromWindowsToUnicode(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return txt;
            }

            var sb = new StringBuilder();
            foreach (var c in txt)
            {
                var i = (int)c;

                if (i >= 130 && i <= 173 && CharactersToMap.TryGetValue(i, out var mappedChar))
                {
                    sb.Append(mappedChar);
                    continue;
                }

                sb.Append(c);
            }

            return sb.ToString();
        }

    }

    public static class pseudoclass
    {
        public static bool EqualArray<T>(this T[] inArray, T[] otherArray)
        {
            if(inArray.Length != otherArray.Length)
            {
                return false;
            }

            for(int i = 0; i < inArray.Length ; i++)
            {
                if(!inArray[i].Equals(otherArray[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
