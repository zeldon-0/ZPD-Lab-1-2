using System;
using Xunit;
using ZPD_1_2.Ciphers;
using ZPD_1_2.Interfaces;
using ZPD_1_2.Algorithms;

namespace ZPD_1_2.Tests
{
    public class RouteCipherTest
    {
        [Theory]
        [InlineData("«јЎ»‘–ќ¬јЌ≈ ѕќ¬≤ƒќћЋ≈ЌЌя", 5, 5, "«–≈≤≈јќ ƒЌЎ¬ѕќЌ»јќћя‘Ќ¬Ћ ")]
        [InlineData("JUGEMU JUGEMU GOKO NO SURIKIRE KAIJARI SUGYO NO SUGYOMATSU URAIMATSU FURAIMATSU", 9, 9,
            "JG IRNAMAUENRIOTAIGMOE  STMEU  SSUSAM SKUU UTUGUAGGU S ORIYYRFUJKIJOOAU UOKA MIR ")]
        [InlineData("In the lap of the Gods The last one did explode In a blaze all fiery " +
            "I sit in the cockpit It may be a sinking ship But fortune favors bravery Road trip " +
            "with me Vitamin V In focus now Venu(venu) - Sian two(-sian two) Fingers getting warm " +
            "And eyes are turning gold Evil twin is coming in Weathering the storm I put the birdie down" +
            " For the sin, I have a grin", 25, 17,
            "I ea ksfaiI((rnn t  ,    " +
            "nG  Ipiovtnv-sdgihId      odb inreh es   se oI    " +
            "tdilstktr fnigeg rpw     hsdai iuymouaeyociunh    e  ztInn ec)ntelont a" +
            "     Tee tgeR u  tsdmg Fv    lhx i   oVs-ti  i toe    aepanmsfai  wnaEnthr     " +
            "p ll ahadtnSogrvghe a     loltyiv aoi) ei e t     oad h potmwa w li bhg    fsefeb " +
            "rri nFat nsier     t i eBsinV irut tr i    t Iec u p etnmrwWodsn    " +
            "honroatb Vnwg nierii     en yc  rw uoeAinamen     ")]
        [InlineData("” вс€кого сво€ дол€ ≤ св≥й шл€х широкий, “ой муруЇ, той руйнуЇ, “ой неситим оком" +
            " «а край св≥та зазираЇ, „и нема крањни, ўоб загарбать ≥ з собою ¬з€ть у домовину.", 20, 10,
            "”с≤х ,ус вааўабу.    в  “ Їи«≥Ї ото     восшот,тат,кбьюд    с€вийо и а р   о    €" +
            " ≥р й“мк „аз≥¬м    кдйом о рзиња зо    оо курйоаа нгз€в    глширу кйзниа ти    о€лйуйно ие," +
            "рсьн      €,Їнемсрм бо у    ")]
        public void Encode_MessageWithTableDimensions_ReturnsMessageEncodedForVerticalLinesAlgorithm(
            string message, int rows, int columns, string encodedMessage)
        {
            var routeCipher = new RouteCipher(new VerticalLinesAlgorithm());

            var encoded = routeCipher.Encode(message, rows, columns);

            Assert.Equal(encodedMessage, encoded);

        }


        [Theory]
        [InlineData("«–≈≤≈јќ ƒЌЎ¬ѕќЌ»јќћя‘Ќ¬Ћ",  5, 5, "«јЎ»‘–ќ¬јЌ≈ ѕќ¬≤ƒќћЋ≈ЌЌя")]
        [InlineData("JG IRNAMAUENRIOTAIGMOE  STMEU  SSUSAM SKUU UTUGUAGGU S ORIYYRFUJKIJOOAU UOKA MIR ", 9, 9,
            "JUGEMU JUGEMU GOKO NO SURIKIRE KAIJARI SUGYO NO SUGYOMATSU URAIMATSU FURAIMATSU")]
        [InlineData("I ea ksfaiI((rnn t  ,    " +
            "nG  Ipiovtnv-sdgihId      odb inreh es   se oI    " +
            "tdilstktr fnigeg rpw     hsdai iuymouaeyociunh    e  ztInn ec)ntelont a" +
            "     Tee tgeR u  tsdmg Fv    lhx i   oVs-ti  i toe    aepanmsfai  wnaEnthr     " +
            "p ll ahadtnSogrvghe a     loltyiv aoi) ei e t     oad h potmwa w li bhg    fsefeb " +
            "rri nFat nsier     t i eBsinV irut tr i    t Iec u p etnmrwWodsn    " +
            "honroatb Vnwg nierii     en yc  rw uoeAinamen     ",
            25, 17,
            "In the lap of the Gods The last one did explode In a blaze all fiery " +
            "I sit in the cockpit It may be a sinking ship But fortune favors bravery Road trip " +
            "with me Vitamin V In focus now Venu(venu) - Sian two(-sian two) Fingers getting warm " +
            "And eyes are turning gold Evil twin is coming in Weathering the storm I put the birdie down" +
            " For the sin, I have a grin")]
        [InlineData("”с≤х ,ус вааўабу.    в  “ Їи«≥Ї ото     восшот,тат,кбьюд    с€вийо и а р   о    €" +
            " ≥р й“мк „аз≥¬м    кдйом о рзиња зо    оо курйоаа нгз€в    глширу кйзниа ти    о€лйуйно ие," +
            "рсьн      €,Їнемсрм бо у    ", 20, 10,
            "” вс€кого сво€ дол€ ≤ св≥й шл€х широкий, “ой муруЇ, той руйнуЇ, “ой неситим оком" +
            " «а край св≥та зазираЇ, „и нема крањни, ўоб загарбать ≥ з собою ¬з€ть у домовину.")]
        public void Decode_MessageWithTableDimensions_ReturnsMessageDecodedForVerticalLinesAlgorithm(
            string message, int rows, int columns, string encodedMessage)
        {
            var routeCipher = new RouteCipher(new VerticalLinesAlgorithm());

            var encoded = routeCipher.Decode(message, rows, columns);

            Assert.Equal(encodedMessage, encoded);

        }
        [Theory]
        [InlineData("«јЎ»‘–ќ¬јЌ≈ ѕќ¬≤ƒќћЋ≈ЌЌя", 5, 5, "«–≈≤≈Ќƒ ќјЎ¬ѕќЌяћќј»‘Ќ¬Ћ ")]

        public void Encode_MessageWithTableDimensions_ReturnsMessageEncodedForVerticalZigzagAlgorithm(
            string message, int rows, int columns, string encodedMessage)
        {
            var routeCipher = new RouteCipher(new VerticalZigzagAlgorithm());

            var encoded = routeCipher.Encode(message, rows, columns);

            Assert.Equal(encodedMessage, encoded);

        }
    }
}
