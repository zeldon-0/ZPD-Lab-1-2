using System;
using System.Collections.Generic;
using System.Text;
using ZPD_1_2.Interfaces;

namespace ZPD_1_2.Algorithms
{
    public class VerticalZigzagAlgorithm : IRouteAlgorithm
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

                    if (j % 2 == 0)
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
                    else
                    if ((rows - i - 1) * columns + j >= message.Length)
                    {
                        encodedMessage.Append(" ");
                    }
                    else
                    {
                        encodedMessage.Append(message[(rows - i - 1) * columns + j]);
                    }
   

                }
            }

            return encodedMessage.ToString();
        }

        public string Decode(string encodedMessage, int rows, int columns)
        {
            
            if (encodedMessage.Length > rows * columns)
                throw new ArgumentException("The provided dimensions are too small or the message.");


            StringBuilder tempMessage = new StringBuilder();
            
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {

                    if (i % 2 == 0)
                    {
                        if (i * rows + j >= encodedMessage.Length)
                        {
                            break;
                        }
                        else
                        {
                            tempMessage.Append(encodedMessage[i * rows + j]);
                        }
                    }
                    else
                    if (i * rows + (rows - j - 1) >= encodedMessage.Length)
                    {
                        break;
                    }
                    else
                    {
                        tempMessage.Append(encodedMessage[i * rows + (rows - j - 1)]);
                    }


                }
            }

            return new VerticalLinesAlgorithm()
                .Decode(tempMessage.ToString().TrimEnd(), rows, columns);
        }


    }
}
