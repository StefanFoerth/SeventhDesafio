using System.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System;

namespace PanelManagement
{
    public class GeneralFunctions
    {
        // Transforma uma string hexadecimal num array de bytes.
        public byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        // Transforma um array de bytes numa string hexadecimal.
        public string ByteArrayToHexString(byte[] byteArray)
        {
            StringBuilder hexValue = new StringBuilder(byteArray.Length * 2);
            foreach (byte byteValue in byteArray)
            {
                hexValue.AppendFormat("{0:x2}", byteValue);
            }

            return hexValue.ToString();
        }

        // Soma os bytes do intervalo de posições de um array.
        public byte SumBytesOfArray(byte[] byteArray, int startIndex, int offSet)
        {
            byte sumBytes = 0;
            for (int i = startIndex; i < offSet; i++)
            {
                sumBytes += byteArray[i];
            }

            return sumBytes;
        }

        // Converte uma string hexadecimal em inteiro.
        public string HexStringToIntString(string hexString, int startIndex, int offSet)
        {
            return int.Parse(hexString.Substring(startIndex, offSet), NumberStyles.HexNumber).ToString();
        }

        // Recupera as descrições dos erros.        
        public string GetErrorCodeDescription(string errorCode)
        {
            // Foi utilizado um arquivo texto como recurso da aplicação.
            StringReader strReader = new StringReader(Properties.Resources.ErrorCodes);
            while (true)
            {
                string line = strReader.ReadLine();
                if (line != null)
                {
                    if (line.Contains(errorCode))
                    {
                        return line.Split('|')[1];
                    }
                }
                else break;
            }

            return "";
        }
    }
}
