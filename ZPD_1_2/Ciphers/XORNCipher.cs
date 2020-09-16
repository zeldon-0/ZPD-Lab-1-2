using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ZPD_1_2.Alphabets;
using ZPD_1_2.Interfaces;

namespace ZPD_1_2.Ciphers
{
    public class XORNCipher
    {
        private IAlphabet _alphabet;

        public XORNCipher(IAlphabet alphabet)
        {
            _alphabet = alphabet ?? throw new ArgumentNullException("Provided alphabet is null.");
        }

        public void SetAlphabet(IAlphabet alphabet)
        {
            _alphabet = alphabet ?? throw new ArgumentNullException("Provided alphabet is null.");
        }

        public string Encode(string message, string key)
        {
            return Encode(message, _alphabet.Size, key);
        }

        public string Encode(string message, int modulo, string key)
        {
            if (message == null)
                throw new ArgumentNullException("Provided message is null");

            message = message.ToUpper();
            key = key.ToUpper();

            StringBuilder encodedMessage = new StringBuilder();
            Regex pattern = new Regex(@"\W|[0-9]");

            for (int i = 0; i < message.Length; i++)
            {
                if (pattern.Match(message[i].ToString()).Success)
                {
                    encodedMessage.Append(message[i]);
                }
                else
                {
                    int keyCode = _alphabet[key[i % key.Length]];
                    int newSymbolCode
                        = (_alphabet[message[i]] + keyCode) % modulo;

                    encodedMessage.Append(_alphabet[newSymbolCode]);
                }
            }

            return encodedMessage.ToString();
        }

        public string Decode(string encodedMessage, string key)
        {
            return Decode(encodedMessage, _alphabet.Size, key);
        }


        public string Decode(string encodedMessage, int modulo, string key)
        {
            if (encodedMessage == null)
                throw new ArgumentNullException("Provided message is null");

            encodedMessage = encodedMessage.ToUpper();
            key = key.ToUpper();

            StringBuilder decodedMessage = new StringBuilder();
            Regex pattern = new Regex(@"\W|[0-9]");

            for (int i = 0; i < encodedMessage.Length; i++)
            {
                if (pattern.Match(encodedMessage[i].ToString()).Success)
                {
                    decodedMessage.Append(encodedMessage[i]);
                }
                else
                {
                    int keyCode = _alphabet[key[i % key.Length]];
                    int newSymbolCode
                        = (_alphabet[encodedMessage[i]] - keyCode + modulo) % modulo;

                    decodedMessage.Append(_alphabet[newSymbolCode]);
                }
            }

            return decodedMessage.ToString();
        }

    }
}
