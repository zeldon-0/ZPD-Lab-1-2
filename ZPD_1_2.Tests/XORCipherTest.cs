using System;
using Xunit;
using ZPD_1_2.Ciphers;
using ZPD_1_2.Interfaces;
using ZPD_1_2.Algorithms;
using ZPD_1_2.Alphabets;
using System.Collections;

namespace ZPD_1_2.Tests
{
    public class XORCipherTest
    {
        [Theory]
        [InlineData("ABCDEFG", "ABC",
            "AAADFHG")]
        [InlineData("In the lap of the Gods The last one did explode In a blaze all fiery " +
            "I sit in the cockpit It may be a sinking ship But fortune favors bravery Road trip " +
            "with me Vitamin V In focus now Venu(venu) - Sian two(-sian two) Fingers getting warm " +
            "And eyes are turning gold Evil twin is coming in Weathering the storm I put the birdie down" +
            " For the sin, I have a grin",
            "VENUSIAN",
            "[29]J HVM GVL [26]X TKR L[26]R[26] [30]SA [31]S[26]T [27]JJ RAD RTC[31][28]LE [29]J " +
            "U JLNMA UZD I[29]A[28]M A [31][29]X [28][31] TKR P[26]QCPFG FH EAV FJ S SFYOFZU SK[29]L VG[27] " +
            "I[27]V[30]A[31]M IVRDFA B[28]VRJFK RDVH HDAP DM[30]T EE AM[30]U[30]AN A FZ NOPBW Z[28][30] YRJZ(HMNZ) - " +
            "AAAA X[27][26](-SFVJ HEG) QMASWZS TA[30]H[26]FG DE[28]Y INO AVQA A[28]R [30]ADFIAT L[26]ZL JAMG B[30]IA M[31] " +
            "QGMFYC [28][31] WJVXKQDANL XKQ [26]TDEI [28] HU[30] XKQ JI[28]WMJ RGWA BDF [27]HJ WFZ, I SEYQ I LEMA")]
        [InlineData("JUGEMU JUGEMU GOKO NO SURIKIRE KAIJARI SUGYO NO SUGYOMATSU URAIMATSU FURAIMATSU",
            "CHOUSUKE", 
            "LTIQ[30]A NWBKYG MKIJ Z[28] YQTPE[28]DQ OCPHUD[28] WWBW[26] ZE QTIM[28]YKXQT ADUCICU[28]A R[30]VCPCUBG[30]")]

        public void Encode_MessageWithKey_ReturnsMessageEncodedForXorCipherForEnglishAlphabet(
            string message, string key, string encodedMessage)
        {
            var xorCipher = new XORCipher(new EnglishAlphabet());

            var encoded = xorCipher.Encode(message, key);

            Assert.Equal(encodedMessage, encoded);
        }

        [Theory]
        [InlineData("У всякого своя доляІ свій шлях широкий,Той мурує, той руйнує,Той неситим оком " +
            "За край світа зазирає,Чи нема країни,Щоб загарбать і з собою Взять у домовину.Той тузами обирає " +
            "Свата в його хаті, А той нишком у куточку Гострить ніж на брата.А той, тихий та тверезий,Богобоязливий, " +
            "Як кішечка підкрадеться, Вижде нещасливий У тебе час та й запустить Пазурі в печінки, —І не благай: не вимолять " +
            "Ні діти, ні жінка.А той, щедрий та розкошний,Все храми мурує;",
            "ГенеральнеМордобиття",
            "Р ПП[52]КЩЩГ ДМЕ[37] ҐФХ[54][43] ППЙХ ПН[49]Ю КЬНАЛАЧ,[54]НІ ТГРФХ, ЕАХ ЕТЄЄБ[39],МГІ НЗІЧМЦВ УШПЦ ЮЯ ЖДЕХ ЦШЦММ ЩДЧІЬТН," +
            "ФЇ УОМЛ ЮОМЬДЛ,ШФУ [41]ГДНОСАХА Й Ч МААФЗ [34]И[38]ЄФ У ЧГТВМЬРД.ШҐЧ СНФЕҐИ ЇМЇҐОП ЄГИАТ Б ШРУО ЄНМЧ, Д УФЧ [49]ЗЦЮРҐ Ф " +
            "ЮНЕАЛІД ЗҐГ[54]УЇЄФ НҐТ УМ СНОУИ.Т СРШ, ТДЄЧІ ҐР ҐГЇВМ[41]ЗІ,ЄЕГЩЮГ[38]ХЩЬЄФЇ, [54][46] ЖЦЦОЧБЬ СЧУЦНОҐЇАЖ[53][35], ҐЬЖИФ " +
            "УТЛРМЩІЖШЧ Р ЄАСЕ ДНП ҐР Ю ГТД[55]ТМЧМИ ШЬФНҐХ Є ОЇЙЩ[49]ЙЇ, —І ЛУ НЩРЕОЇ: Є[38] ҐЧТЕЛ[47]ЖЛ БХ АХУА, [49]Ж ХЙДКЛ.Н ЕАХ, " +
            "ШЇПВ[42]К ЄЕ РЩУЮРЇГЬЖ,ГЮМ [57]УЕБЇ МФИЕБ;")]
        public void Encode_MessageWithKey_ReturnsMessageEncodedForXorCipherForUkrainianAlphabet(
            string message, string key, string encodedMessage)
        {
            var xorCipher = new XORCipher(new UkrainianAlphabet());

            var encoded = xorCipher.Encode(message, key);

            Assert.Equal(encodedMessage, encoded);
        }



        [Theory]
        [InlineData("AAADFHG", "ABC",
            "ABCDEFG")]
        [InlineData("[29]J HVM GVL [26]X TKR L[26]R[26] [30]SA [31]S[26]T [27]JJ RAD RTC[31][28]LE [29]J " +
            "U JLNMA UZD I[29]A[28]M A [31][29]X [28][31] TKR P[26]QCPFG FH EAV FJ S SFYOFZU SK[29]L VG[27] " +
            "I[27]V[30]A[31]M IVRDFA B[28]VRJFK RDVH HDAP DM[30]T EE AM[30]U[30]AN A FZ NOPBW Z[28][30] YRJZ(HMNZ) - " +
            "AAAA X[27][26](-SFVJ HEG) QMASWZS TA[30]H[26]FG DE[28]Y INO AVQA A[28]R [30]ADFIAT L[26]ZL JAMG B[30]IA M[31] " +
            "QGMFYC [28][31] WJVXKQDANL XKQ [26]TDEI [28] HU[30] XKQ JI[28]WMJ RGWA BDF [27]HJ WFZ, I SEYQ I LEMA",
            "VENUSIAN",
            "IN THE LAP OF THE GODS THE LAST ONE DID EXPLODE IN A BLAZE ALL FIERY " +
            "I SIT IN THE COCKPIT IT MAY BE A SINKING SHIP BUT FORTUNE FAVORS BRAVERY ROAD TRIP " +
            "WITH ME VITAMIN V IN FOCUS NOW VENU(VENU) - SIAN TWO(-SIAN TWO) FINGERS GETTING WARM " +
            "AND EYES ARE TURNING GOLD EVIL TWIN IS COMING IN WEATHERING THE STORM I PUT THE BIRDIE DOWN" +
            " FOR THE SIN, I HAVE A GRIN")]
        [InlineData("LTIQ[30]A NWBKYG MKIJ Z[28] YQTPE[28]DQ OCPHUD[28] WWBW[26] ZE QTIM[28]YKXQT ADUCICU[28]A R[30]VCPCUBG[30]",
                        "CHOUSUKE",
            "JUGEMU JUGEMU GOKO NO SURIKIRE KAIJARI SUGYO NO SUGYOMATSU URAIMATSU FURAIMATSU")]
        public void Decode_MessageWithKey_ReturnsMessageDecodedForXorCipherForEnglishAlphabet(
            string message, string key, string encodedMessage)
        {
            var xorCipher = new XORCipher(new EnglishAlphabet());

            var encoded = xorCipher.Decode(message, key);

            Assert.Equal(encodedMessage, encoded);
        }


        [Theory]
        [InlineData("Р ПП[52]КЩЩГ ДМЕ[37] ҐФХ[54][43] ППЙХ ПН[49]Ю КЬНАЛАЧ,[54]НІ ТГРФХ, ЕАХ ЕТЄЄБ[39],МГІ НЗІЧМЦВ УШПЦ ЮЯ ЖДЕХ ЦШЦММ ЩДЧІЬТН," +
            "ФЇ УОМЛ ЮОМЬДЛ,ШФУ [41]ГДНОСАХА Й Ч МААФЗ [34]И[38]ЄФ У ЧГТВМЬРД.ШҐЧ СНФЕҐИ ЇМЇҐОП ЄГИАТ Б ШРУО ЄНМЧ, Д УФЧ [49]ЗЦЮРҐ Ф " +
            "ЮНЕАЛІД ЗҐГ[54]УЇЄФ НҐТ УМ СНОУИ.Т СРШ, ТДЄЧІ ҐР ҐГЇВМ[41]ЗІ,ЄЕГЩЮГ[38]ХЩЬЄФЇ, [54][46] ЖЦЦОЧБЬ СЧУЦНОҐЇАЖ[53][35], ҐЬЖИФ " +
            "УТЛРМЩІЖШЧ Р ЄАСЕ ДНП ҐР Ю ГТД[55]ТМЧМИ ШЬФНҐХ Є ОЇЙЩ[49]ЙЇ, —І ЛУ НЩРЕОЇ: Є[38] ҐЧТЕЛ[47]ЖЛ БХ АХУА, [49]Ж ХЙДКЛ.Н ЕАХ, " +
            "ШЇПВ[42]К ЄЕ РЩУЮРЇГЬЖ,ГЮМ [57]УЕБЇ МФИЕБ;",
             "ГенеральнеМордобиття",
            "У ВСЯКОГО СВОЯ ДОЛЯІ СВІЙ ШЛЯХ ШИРОКИЙ,ТОЙ МУРУЄ, ТОЙ РУЙНУЄ,ТОЙ НЕСИТИМ ОКОМ " +
            "ЗА КРАЙ СВІТА ЗАЗИРАЄ,ЧИ НЕМА КРАЇНИ,ЩОБ ЗАГАРБАТЬ І З СОБОЮ ВЗЯТЬ У ДОМОВИНУ.ТОЙ ТУЗАМИ ОБИРАЄ " +
            "СВАТА В ЙОГО ХАТІ, А ТОЙ НИШКОМ У КУТОЧКУ ГОСТРИТЬ НІЖ НА БРАТА.А ТОЙ, ТИХИЙ ТА ТВЕРЕЗИЙ,БОГОБОЯЗЛИВИЙ, " +
            "ЯК КІШЕЧКА ПІДКРАДЕТЬСЯ, ВИЖДЕ НЕЩАСЛИВИЙ У ТЕБЕ ЧАС ТА Й ЗАПУСТИТЬ ПАЗУРІ В ПЕЧІНКИ, —І НЕ БЛАГАЙ: НЕ ВИМОЛЯТЬ " +
            "НІ ДІТИ, НІ ЖІНКА.А ТОЙ, ЩЕДРИЙ ТА РОЗКОШНИЙ,ВСЕ ХРАМИ МУРУЄ;")]
        public void Decode_MessageWithKey_ReturnsMessageDecodedForXorCipherForUkrainianAlphabet(
            string message, string key, string encodedMessage)
        {
            var xorCipher = new XORCipher(new UkrainianAlphabet());

            var encoded = xorCipher.Decode(message, key);

            Assert.Equal(encodedMessage, encoded);
        }
    }
}
