using System;
using System.Collections.Generic;
using System.Text;
using ZPD_1_2.Interfaces;

namespace ZPD_1_2.Algorithms
{
    public class VerticalLinesAlgorithm : IRouteAlgorithm
    {
        public string Encode(string message, int rows, int columns)
        {
            if (message.Length > rows * columns)
                throw new ArgumentException("The provided dimensions are too small or the message.");


            StringBuilder encodedMessage = new StringBuilder();

            for (int j = 0; j < columns; j++) 
            {
                for (int i = 0; i < rows; i++)
                {
                    if (i * columns + j >= message.Length)
                    {
                        encodedMessage.Append(" ");
                    }
                    else
                    {
                        encodedMessage.Append(message[i * columns + j]);
                    }
                }
            }

            return encodedMessage.ToString();
        }

        public string Decode(string encodedMessage, int rows, int columns)
        {

            return Encode(encodedMessage, columns, rows).TrimEnd();
        }


    }
}
