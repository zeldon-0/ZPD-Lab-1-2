using System;
using System.Collections.Generic;
using System.Text;
using ZPD_1_2.Interfaces;

namespace ZPD_1_2.Ciphers
{
    public class RouteCipher
    {
        private IRouteAlgorithm _algorithm;

        public RouteCipher(IRouteAlgorithm algorithm)
        {
            _algorithm = algorithm ?? throw new NullReferenceException("Algorithm provided is null.");
        }

        public void SetAlgorithm(IRouteAlgorithm algorithm)
        {
            _algorithm = algorithm ?? throw new NullReferenceException("Algorithm provided is null.");
        }

        public string Encode(string message, int rows, int columns)
        {
            if (message == null)
                throw new NullReferenceException("Message provided is null.");

            return _algorithm.Encode(message, rows, columns);
        }

        public string Decode(string message, int rows, int columns)
        {
            if (message == null)
                throw new NullReferenceException("Message provided is null.");

            return _algorithm.Decode(message, rows, columns);
        }
    }
}