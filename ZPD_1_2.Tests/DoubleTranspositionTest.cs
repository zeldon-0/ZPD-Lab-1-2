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
/*      [InlineData("JUGEMU JUGEMU GOKO NO SURIKIRE KAIJARI SUGYO NO SUGYOMATSU URAIMATSU FURAIMATSU", 9, 9,
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
        [InlineData("У всякого своя доляІ свій шлях широкий,Той мурує, той руйнує,Той неситим оком " +
            "За край світа зазирає,Чи нема країни,Щоб загарбать і з собою Взять у домовину.Той тузами обирає " +
            "Свата в його хаті, А той нишком у куточку Гострить ніж на брата.А той, тихий та тверезий,Богобоязливий, " +
            "Як кішечка підкрадеться, Вижде нещасливий У тебе час та й запустить Пазурі в печінки, —І не благай: не вимолять " +
            "Ні діти, ні жінка.А той, щедрий та розкошний,Все храми мурує;", 30, 25,
            "У тоЧаовин йяерйір;            шомитвашіт,, і: о            " +
            "влй  ьиткжа  ч  жз            ся Зн нао  ЯВавнік            яхраеіу мнткис ено            " +
            "к у м .в ав ж п кш            ошйказТ у екдтеван            гинр  ой бріеачи.и            " +
            "оруаксйокреш  імАй             оєйро гуазенйно ,            ск, абтоттиче клтВ            " +
            "виТсїоу оайкщзияос            ойовнюзхч.,ааа,тйе            я,йіи аакАБ сп ь,              " +
            "Т т,Вмту оплу—  х            донаЩзиі тгіисІНщр            ойе оя ,Гоодвт іеа            " +
            "л сзбто ойбкиин дм            ямиа ьбАс,орйтедри            Іутзз и т яа ь іи              " +
            "рииауртртздУ бтйм            сумрг аоииле Пли у            вє аадєйтхиттаа,тр            " +
            "і,оєро  ьивьезг ау            й к,бмСн йисбуан є            ")]
 */
        public void Encode_MessageWithTransitionTable_ReturnsMessageEncodedForDoubleTransitionCipher(
            string message, int[] rowTransposition, int[] columnTransposition, string encodedMessage)
        {
            var doubleTranspositionCipher = new DoubleTranspositionCipher();

            var encoded = doubleTranspositionCipher.Encode(message, rowTransposition, columnTransposition);

            Assert.Equal(encodedMessage, encoded);

        }

/*
        [Theory]
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
        [InlineData("У тоЧаовин йяерйір;            шомитвашіт,, і: о            " +
            "влй  ьиткжа  ч  жз            ся Зн нао  ЯВавнік            яхраеіу мнткис ено            " +
            "к у м .в ав ж п кш            ошйказТ у екдтеван            гинр  ой бріеачи.и            " +
            "оруаксйокреш  імАй             оєйро гуазенйно ,            ск, абтоттиче клтВ            " +
            "виТсїоу оайкщзияос            ойовнюзхч.,ааа,тйе            я,йіи аакАБ сп ь,              " +
            "Т т,Вмту оплу—  х            донаЩзиі тгіисІНщр            ойе оя ,Гоодвт іеа            " +
            "л сзбто ойбкиин дм            ямиа ьбАс,орйтедри            Іутзз и т яа ь іи              " +
            "рииауртртздУ бтйм            сумрг аоииле Пли у            вє аадєйтхиттаа,тр            " +
            "і,оєро  ьивьезг ау            й к,бмСн йисбуан є            ", 30, 25,
            "У всякого своя доляІ свій шлях широкий,Той мурує, той руйнує,Той неситим оком " +
            "За край світа зазирає,Чи нема країни,Щоб загарбать і з собою Взять у домовину.Той тузами обирає " +
            "Свата в його хаті, А той нишком у куточку Гострить ніж на брата.А той, тихий та тверезий,Богобоязливий, " +
            "Як кішечка підкрадеться, Вижде нещасливий У тебе час та й запустить Пазурі в печінки, —І не благай: не вимолять " +
            "Ні діти, ні жінка.А той, щедрий та розкошний,Все храми мурує;")]
        public void Decode_MessageWithTransitionTable_ReturnsMessageDecodedForDoubleTransitionCipher(
            string message, int rows, int columns, string encodedMessage)
        {
            var routeCipher = new RouteCipher(new VerticalLinesAlgorithm());

            var encoded = routeCipher.Decode(message, rows, columns);

            Assert.Equal(encodedMessage, encoded);

        }
*/
 
    }
}
