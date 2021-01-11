using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    /// <summary>
    /// The type of value that will go on the cell in the game.
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// This state is when the button hasn't been clicked.
        /// </summary>
        Free,
        Nought,
        Cross
    }
}
