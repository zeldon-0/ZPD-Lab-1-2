using System;
using System.Collections.Generic;
using System.Text;
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

            StringBuilder encodedMessage = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                int messageCharCode = _alphabet[message[i]];

                int keyCharCode = _alphabet[key[i % key.Length]];

                MyByte messageCharByte = new MyByte(messageCharCode);
                MyByte keyCharByte = new MyByte(keyCharCode);

                var a = message[i];
                var b = key[i % key.Length];
                int encodedCharCode = (int) (messageCharByte ^ keyCharByte) % _alphabet.Size;

                encodedMessage.Append(_alphabet[encodedCharCode]);
            }

            return encodedMessage.ToString();
        }
    }
}
