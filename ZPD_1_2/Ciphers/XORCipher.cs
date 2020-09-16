using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ZPD_1_2.Interfaces;
using ZPD_1_2.Utility;

namespace ZPD_1_2.Ciphers
{
    public class XORCipher
    {
        IAlphabet _alphabet;
        public XORCipher(IAlphabet alphabet)
        {
            _alphabet = alphabet ?? throw new ArgumentNullException("Provided alphabet is null.");
        }

        public void SetAlphabet(IAlphabet alphabet)
        {
            _alphabet = alphabet ?? throw new ArgumentNullException("Provided alphabet is null.");
        }

        public string Encode(string message, string key)
        {
            if (message == null)
                throw new ArgumentNullException("Provided message is null.");

            if (key == null)
                throw new ArgumentNullException("Provided key is null.");


            message = message.ToUpper();
            key = key.ToUpper();

            StringBuilder encodedMessage = new StringBuilder();
            Regex pattern = new Regex(@"\W|[0-9]");

            for (int i = 0; i < message.Length; i++)
            {

                if (message[i] == '[')
                {
                    int j = i;
                    while (message[j] != ']')
                        j ++;

                    int messageCharCode = Int32.Parse(message.Substring(i + 1, j - i - 1));
                    int keyCharCode = _alphabet[key[i % key.Length]];

                    MyByte messageCharByte = new MyByte(messageCharCode);
                    MyByte keyCharByte = new MyByte(keyCharCode);

                    int encodedCharCode = (int)(messageCharByte ^ keyCharByte);

                    if (encodedCharCode >= _alphabet.Size)
                    {
                        encodedMessage.Append($"[{encodedCharCode}]");
                    }
                    else 
                    {
                        encodedMessage.Append(_alphabet[encodedCharCode]);

                    }

                    i = j;
                }

                else if (pattern.Match(message[i].ToString()).Success)
                {
                    encodedMessage.Append(message[i]);
                }

                else 
                {

                    int messageCharCode = _alphabet[message[i]];

                    int keyCharCode = _alphabet[key[i % key.Length]];

                    MyByte messageCharByte = new MyByte(messageCharCode);
                    MyByte keyCharByte = new MyByte(keyCharCode);

                    int encodedCharCode = (int)(messageCharByte ^ keyCharByte);

                    if (encodedCharCode >= _alphabet.Size)
                    {
                        encodedMessage.Append($"[{encodedCharCode}]");
                    }
                    else
                    {
                        encodedMessage.Append(_alphabet[encodedCharCode]);

                    }

                    /*
                     int messageCharCode = (int) message[i];

                     int keyCharCode = (int) key[i % key.Length];

                     MyByte messageCharByte = new MyByte(messageCharCode);
                     MyByte keyCharByte = new MyByte(keyCharCode);

                     int encodedCharCode = (int)(messageCharByte ^ keyCharByte);

                     encodedMessage.Append((char) encodedCharCode]);*/
                }
            }

            return encodedMessage.ToString();
        }

        public string Decode(string message, string key)
        {
            if (message == null)
                throw new ArgumentNullException("Provided message is null.");

            if (key == null)
                throw new ArgumentNullException("Provided key is null.");


            message = message.ToUpper();
            key = key.ToUpper();

            StringBuilder encodedMessage = new StringBuilder();
            Regex pattern = new Regex(@"\W|[0-9]");

            for (int i = 0; i < message.Length; i++)
            {

                if (message[i] == '[')
                {
                    int j = i;
                    while (message[j] != ']')
                        j++;

                    int messageCharCode = Int32.Parse(message.Substring(i + 1, j - i - 1));
                    int keyCharCode = _alphabet[key[i % key.Length]];

                    MyByte messageCharByte = new MyByte(messageCharCode);
                    MyByte keyCharByte = new MyByte(keyCharCode);

                    int encodedCharCode = (int)(messageCharByte ^ keyCharByte);


                    encodedMessage.Append(_alphabet[encodedCharCode % _alphabet.Size]);

                    message = message.Substring(0, i + 1) + message.Substring(j + 1);

                }

                else if (pattern.Match(message[i].ToString()).Success)
                {
                    encodedMessage.Append(message[i]);
                }

                else
                {

                    int messageCharCode = _alphabet[message[i]];

                    int keyCharCode = _alphabet[key[i % key.Length]];

                    MyByte messageCharByte = new MyByte(messageCharCode);
                    MyByte keyCharByte = new MyByte(keyCharCode);

                    int encodedCharCode = (int)(messageCharByte ^ keyCharByte);

                    encodedMessage.Append(_alphabet[encodedCharCode % _alphabet.Size]);

                    /*
                     int messageCharCode = (int) message[i];

                     int keyCharCode = (int) key[i % key.Length];

                     MyByte messageCharByte = new MyByte(messageCharCode);
                     MyByte keyCharByte = new MyByte(keyCharCode);

                     int encodedCharCode = (int)(messageCharByte ^ keyCharByte);

                     encodedMessage.Append((char) encodedCharCode]);*/
                }
            }

            return encodedMessage.ToString();
        }

    

        private bool _checkForOverflow(int result, int key, int message)
            {


                MyByte resultCharByte = new MyByte(result);
                MyByte keyCharByte = new MyByte(key);

                int encodedCharCode = (int)(resultCharByte ^ keyCharByte);

                if (encodedCharCode == message)
                    return false;

                return true;
            }
        }
}
