using System;
using System.Collections.Generic;
using System.Text;

namespace ZPD_1_2.Interfaces
{
    public interface IRouteAlgorithm
    {
        string Encode(string message, int rows, int columns);
        string Decode(string message, int rows, int columns);
    }
}
