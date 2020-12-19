using System;
using System.Collections.Generic;
using System.Text;

namespace Metar_decoder.interfaces
{
    public interface ILink
    {
        (object, string remainMetart) Parse(string data);
    }
}
