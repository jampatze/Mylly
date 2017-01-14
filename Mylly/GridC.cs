using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mylly
{
    /// <summary>
    /// Yksinkertainen koordinaatti-olio
    /// </summary>
    public class GridC
    {
        // x-koordinaatti
        public int X;
        // y-koordinaatti
        public int Y;

        /// <summary>
        /// Konstruktori
        /// </summary>
        /// <param name="x">x-kooridaatti</param>
        /// <param name="y">y-koordinaatti</param>
        public GridC(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// ToString-metodi
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return X + "," + Y;
        }

    }
}
