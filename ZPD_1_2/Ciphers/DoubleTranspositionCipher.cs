using System;
using System.Collections.Generic;
using System.Text;

namespace ZPD_1_2.Ciphers
{
    public class DoubleTranspositionCipher
    {

        public string Encode(string message, int[] rowTransposition, int[] columnTransposition)
        {
            int rows = rowTransposition.GetLength(0);
            int columns = columnTransposition.GetLength(0);

            if (rows * columns < message.Length)
                throw new ArgumentException("Provided matrix is far too small for the message.");

            char[] encodedMessage = new char[rows * columns];


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int row = _findIndex(rowTransposition, i);
                    if (row == -1)
                        throw new ArgumentException("Could not decode for provided key");

                    int column = _findIndex(columnTransposition, j);
                    if (column == -1)
                        throw new ArgumentException("Could not decode for provided key");

                    if (row * columns + column >= message.Length)
                    {
                        encodedMessage
                           [i * columns + j]
                           = ' ';
                    }
                    else
                    {
                        int a = row * columns + column;
                        char b = message[row * columns + column];
                        encodedMessage
                            [i * columns + j]
                            = message[row * columns + column];
                    }
                }
            }

            return new string(encodedMessage);

        }

        public string Decode(string encodedMessage, int[] rowTransposition, int[] columnTransposition)
        {

            int rows = rowTransposition.GetLength(0);
            int columns = columnTransposition.GetLength(0);

            if (rows * columns < encodedMessage.Length)
                throw new ArgumentException("Provided matrix is far too small for the message.");

            char[] decodedMessage = new char[rows * columns];


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int initialRow = _findIndex(rowTransposition, i);
                    if (initialRow == -1)
                        throw new ArgumentException("Could not decode for provided key");

                    int initialColumn = _findIndex(columnTransposition, j);
                    if (initialColumn == -1)
                        throw new ArgumentException("Could not decode for provided key");


                    decodedMessage
                        [initialRow * columns + initialColumn]
                        = encodedMessage[i * columns + j];
                    
                }
            }

            return new string(decodedMessage).TrimEnd();

        }


        private int _findIndex(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }

            }
            return -1;
        }

    }
}
