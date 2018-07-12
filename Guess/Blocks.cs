using System;
using System.Collections.Generic;
using System.Text;

namespace Guess
{
    public static class Blocks
    {
        public static char[] blockOne = new char[] { 'G', 'H' };
        public static char[] blockTwo = new char[] { 'F', 'E' };
        public static char[] blockThree = new char[] { 'S', 'T' };
        public static char[] blockFour = new char[] { 'B', 'A' };
        public static char[] blockFive = new char[] { 'Q', 'R' };

        public static char[][] allBlocks = new char[][] { blockOne, blockTwo, blockThree, blockFour, blockFive};
    }
}
