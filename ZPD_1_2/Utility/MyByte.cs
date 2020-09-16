using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZPD_1_2.Utility
{
    public class MyByte
    {
        private List<bool> _bits;
        public MyByte(int number)
        {
            if (number < 0)
                throw new NotImplementedException();

            _bits = new List<bool>();

            if (number == 0)
            {
                _bits.Add(false);
                return;
            }
            int maxPower = 0;
            while (Math.Pow(2, maxPower) < number)
            {
                maxPower++;
            }

            for (int i = maxPower; i >= 0 ; i--)
            {
                if (number - Math.Pow(2, i) >= 0)
                {
                    number =  (int) (number - Math.Pow(2, i));
                    _bits.Add(true);
                }
                else
                {
                    _bits.Add(false);
                }
            }

            _bits.Reverse();

        }

        public MyByte(IEnumerable<bool> bits)
        {
            _bits = bits.ToList();
        }


        public static  MyByte operator ^(MyByte myByte1, MyByte myByte2)
        {
            List<bool> result = new List<bool>(myByte1._bits );

            int length = myByte1._bits.Count > myByte2._bits.Count
                ? myByte1._bits.Count : myByte2._bits.Count;

            for (int i = 0; i < myByte2._bits.Count; i++)
            {
                if (result.Count <= i)
                {
                    result.Add(myByte2._bits[i]);
                }
                else
                {
                    result[i] = result[i] ^ myByte2._bits[i];
                }
            }

            return new MyByte(result);
        }


        public static explicit operator int (MyByte myByte)
        {
            int result = 0;
            for (int i = 0; i < myByte._bits.Count; i++)
            {
                if (myByte._bits[i])
                {
                    result += (int) Math.Pow(2, i);
                }
            }
            return result;
        }



    }
}
