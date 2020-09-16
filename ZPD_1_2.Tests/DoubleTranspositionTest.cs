using System;
using Xunit;
using ZPD_1_2.Ciphers;
using ZPD_1_2.Interfaces;
using ZPD_1_2.Algorithms;

namespace ZPD_1_2.Tests
{
    public class DoubleTranspositionTest
    {
        [Theory]
        [InlineData("рядки тастовбці", 
            new int[] { 3, 0, 1, 2} ,
            new int[] { 2, 0, 3, 1} ,
            " аиттвсоц біякрд"
            )]
        [InlineData("JUGEMU JUGEMU GOKO NO SURIKIRE KAIJARI SUGYO NO SUGYOMATSU URAIMATSU FURAIMATSU",
            new int[] { 3, 0, 1, 2, 5, 8, 4, 6, 7},
            new int[] { 8, 5, 1, 2, 0, 6, 3, 7, 4 },
            " MUOOEGKGSO RKNUI KE IARAJIMGE UUUJJ SURITUAAU SY IGORUTSFRA UMTMAU IS AU SYMOGON")]
        [InlineData("In the lap of the Gods The last one did explode In a blaze all fiery " +
            "I sit in the cockpit It may be a sinking ship But fortune favors bravery Road trip " +
            "with me ", 
            new int[] { 2, 10, 15, 5, 0, 1, 4, 6, 7, 11, 19, 18, 12, 9, 8, 3, 13, 16, 14, 17}, 
            new int[] { 9, 0, 2, 3, 6, 7, 1, 4, 5, 8},
            "xepl Iodneaz be laa n  tlahepI  wimeth plr fy ieIl donide  tsnit t ih  pcoitck e  " +
            "Rotradiyras vebrrooef  Gtho t  mbeay Ir tufanevo                    " +
            "s  Tlahesd                    huipt  Bfs isingnk a")]
        [InlineData("У всякого своя доляІ свій шлях широкий,Той мурує, той руйнує,Той неситим оком",
            new int[] { 9, 0, 2, 3, 6, 10, 7, 1, 4, 5, 8 },
            new int[] { 5, 2, 1, 0, 3, 6, 4},
            "с овягойот у рлодя  Ійів лсшєун,ойТен стйиш хиоярруму, єо мкмиосв яоУк,йиТйко")]

        public void Encode_MessageWithTransitionTable_ReturnsMessageEncodedForDoubleTransitionCipher(
            string message, int[] rowTransposition, int[] columnTransposition, string encodedMessage)
        {
            var doubleTranspositionCipher = new DoubleTranspositionCipher();

            var encoded = doubleTranspositionCipher.Encode(message, rowTransposition, columnTransposition);

            Assert.Equal(encodedMessage, encoded);

        }

        [Theory]
        [InlineData(" аиттвсоц біякрд",
            new int[] { 3, 0, 1, 2 },
            new int[] { 2, 0, 3, 1 },
            "рядки тастовбці"
        )]

        [InlineData(" MUOOEGKGSO RKNUI KE IARAJIMGE UUUJJ SURITUAAU SY IGORUTSFRA UMTMAU IS AU SYMOGON",
            new int[] { 3, 0, 1, 2, 5, 8, 4, 6, 7 },
            new int[] { 8, 5, 1, 2, 0, 6, 3, 7, 4 },
            "JUGEMU JUGEMU GOKO NO SURIKIRE KAIJARI SUGYO NO SUGYOMATSU URAIMATSU FURAIMATSU")]

        [InlineData("xepl Iodneaz be laa n  tlahepI  wimeth plr fy ieIl donide  tsnit t ih  pcoitck e  " +
            "Rotradiyras vebrrooef  Gtho t  mbeay Ir tufanevo                    " +
            "s  Tlahesd                    huipt  Bfs isingnk a",
            new int[] { 2, 10, 15, 5, 0, 1, 4, 6, 7, 11, 19, 18, 12, 9, 8, 3, 13, 16, 14, 17 },
            new int[] { 9, 0, 2, 3, 6, 7, 1, 4, 5, 8 },
            "In the lap of the Gods The last one did explode In a blaze all fiery " +
            "I sit in the cockpit It may be a sinking ship But fortune favors bravery Road trip " +
            "with me")]

        [InlineData("с овягойот у рлодя  Ійів лсшєун,ойТен стйиш хиоярруму, єо мкмиосв яоУк,йиТйко",
            new int[] { 9, 0, 2, 3, 6, 10, 7, 1, 4, 5, 8 },
            new int[] { 5, 2, 1, 0, 3, 6, 4 },
            "У всякого своя доляІ свій шлях широкий,Той мурує, той руйнує,Той неситим оком")]


        public void Decode_MessageWithTransitionTable_ReturnsMessageDecodedForDoubleTransitionCipher(
            string encodedMessage, int[] rowTransposition, int[] columnTransposition, string decodedMessage)
        {
            var doubleTranspositionCipher = new DoubleTranspositionCipher();

            var decoded = doubleTranspositionCipher.Decode(encodedMessage, rowTransposition, columnTransposition);

            Assert.Equal(decodedMessage, decoded);

        }

    }
}
