using System;
using Xunit;
using ZPD_1_2.Ciphers;
using ZPD_1_2.Interfaces;
using ZPD_1_2.Algorithms;
using ZPD_1_2.Alphabets;

namespace ZPD_1_2.Tests
{
    public class XORNCipherTest
    {
        [Theory]
        [InlineData("ABCDEFG", "ABD",
            "ACFDFIG")]
        [InlineData("In the lap of the Gods The last one did explode In a blaze all fiery " +
            "I sit in the cockpit It may be a sinking ship But fortune favors bravery Road trip " +
            "with me Vitamin V In focus now Venu(venu) - Sian two(-sian two) Fingers getting warm " +
            "And eyes are turning gold Evil twin is coming in Weathering the storm I put the birdie down" +
            " For the sin, I have a grin",
            "Venusian",
            "DR NZM YVT IX TUZ TIVA GCI FSAT JRR VQD ZBCFGLE DR U JLNUI UDT SDIES Q FDX CF TUZ PIUSPVO VN UAL " +
            "FR S SVIOVHY SUDT VMB SJVGOFM SVZBLK BEVZRLQ RBVH NJQP RMGB UE QMGUEQN Q VH NOPPW HGE IZRH(NMNH) - " +
            "KQAA XJI(-SVVR NOW) AMAAWZS BIGNAVG REEG INQ ILYK AEZ GOJVIAB TIDL RQMY LEIA MF UWMVIK CF WRVXUYJQNT " +
            "XUY ATBMQ C XUG XUY JIEYMR VWWA JBL BHR WVH, I CEIY I TMMA")]
        [InlineData("JUGEMU JUGEMU GOKO NO SURIKIRE KAIJARI SUGYO NO SUGYOMATSU URAIMATSU FURAIMATSU",
            "Chousuke", "LBUYEO NWNSGM QSMV HG CYTPYCJY OCPXUJC WWNMI HY UBUSGGKXUB OJUSQCAGO ZEVCPAULME")]

 
        public void Encode_MessageWithKeyAndN_ReturnsMessageEncodedForXorNCipherForEnglishAlphabet(
            string message, string key, string encodedMessage)
        {
            var xorCipher = new XORNCipher(new EnglishAlphabet());

            var encoded = xorCipher.Encode(message, key);

            Assert.Equal(encodedMessage, encoded);

        }

        [Theory]
        [InlineData("НОВИНА", "КЛЮЧ", "ЮААҐЮЛ")]
        [InlineData("У всякого своя доляІ свій шлях широкий,Той мурує, той руйнує,Той неситим оком " +
            "За край світа зазирає,Чи нема країни,Щоб загарбать і з собою Взять у домовину.Той тузами обирає " +
            "Свата в його хаті, А той нишком у куточку Гострить ніж на брата.А той, тихий та тверезий,Богобоязливий, " +
            "Як кішечка підкрадеться, Вижде нещасливий У тебе час та й запустить Пазурі в печінки, —І не благай: не вимолять " +
            "Ні діти, ні жінка.А той, щедрий та розкошний,Все храми мурує;", "ГенеральнеМордобиття",
            "Ц ПЧПКААВ ҐРДҐ ЕШҐСИ ЧПНА ИЇМЮ ЙЬХГЛРВ,ССП ТИРДҐ, ДГА ДФУЕЇЕ,ШВП НСОЧШЦБ УЯПЦ ЮЯ РҐЕА ГЯШШМ" +
            " ЩДЧІЬТЩ,ЬМ УЦМЛ ЮЦМЬҐЛ,ЬШУ ЖГЗНЦСАҐЧ Н Ч ЦГВШР БЇДЕГ У ВВТБРЬТЖ.ЯЄВ ХЩЦЕГИ ЛОМГОЧ ЕГИІТ Д ЬФУО ТНШЧ," +
            " Д УШВ МЙБЮФГ Д ЮЩДГКПЖ ЙЄИСУМЕГ НЦД УМ СХОУИ.Т ХФЬ, ТХТЧП ЄР ЄГМЗШЖЙП,ЄДГАЮВДХАЬЄШК, СЙ РШБЦЧЩЬ ХЧУБХОЕМІПРВ, " +
            "ЖЬЖРГ УТКРЦАІЇЯВ Ц ЕЇСЕ ФНЧ ЄР Ю ПТЖТФШЧШН БЬЦЩГЩ Є РММАМНМ, —І КУ НАРЖОК: ЕД ЖЧТДЛКПК АЩ ИЩУР, МК ХНҐКЛ.Н ДГА, " +
            "ЬМЧЗЗМ ЕЕ РАЕЮФІВЬО,ГЮШ ФУЕАМ МДНЄЙ;")]

        public void Encode_MessageWithKeyAndN_ReturnsMessageEncodedForXorNCipherForUkrainianAlphabet(
            string message, string key, string encodedMessage)
        {
            var xorCipher = new XORNCipher(new UkrainianAlphabet());

            var encoded = xorCipher.Encode(message, key);

            Assert.Equal(encodedMessage, encoded);

        }

        [Theory]
        [InlineData("ACFDFIG", "ABD", "ABCDEFG")]

        [InlineData("DR NZM YVT IX TUZ TIVA GCI FSAT JRR VQD ZBCFGLE DR U JLNUI UDT SDIES Q FDX CF TUZ PIUSPVO VN UAL " +
            "FR S SVIOVHY SUDT VMB SJVGOFM SVZBLK BEVZRLQ RBVH NJQP RMGB UE QMGUEQN Q VH NOPPW HGE IZRH(NMNH) - " +
            "KQAA XJI(-SVVR NOW) AMAAWZS BIGNAVG REEG INQ ILYK AEZ GOJVIAB TIDL RQMY LEIA MF UWMVIK CF WRVXUYJQNT " +
            "XUY ATBMQ C XUG XUY JIEYMR VWWA JBL BHR WVH, I CEIY I TMMA",
            "Venusian",
            "IN THE LAP OF THE GODS THE LAST ONE DID EXPLODE IN A BLAZE ALL FIERY " +
            "I SIT IN THE COCKPIT IT MAY BE A SINKING SHIP BUT FORTUNE FAVORS BRAVERY ROAD TRIP " +
            "WITH ME VITAMIN V IN FOCUS NOW VENU(VENU) - SIAN TWO(-SIAN TWO) FINGERS GETTING WARM " +
            "AND EYES ARE TURNING GOLD EVIL TWIN IS COMING IN WEATHERING THE STORM I PUT THE BIRDIE DOWN" +
            " FOR THE SIN, I HAVE A GRIN")]
        [InlineData("LBUYEO NWNSGM QSMV HG CYTPYCJY OCPXUJC WWNMI HY UBUSGGKXUB OJUSQCAGO ZEVCPAULME",
            "Chousuke",
            "JUGEMU JUGEMU GOKO NO SURIKIRE KAIJARI SUGYO NO SUGYOMATSU URAIMATSU FURAIMATSU")]

        public void Decode_MessageWithKeyAndN_ReturnsMessageDecodedForXorNCipherForEnglishAlphabet(
            string message, string key, string decodedMessage)
        {
            var xorCipher = new XORNCipher(new EnglishAlphabet());

            var decoded = xorCipher.Decode(message, key);

            Assert.Equal(decodedMessage, decoded);
        }

        [Theory]
        [InlineData("ЮААҐЮЛ", "КЛЮЧ", "НОВИНА")]
        [InlineData("Ц ПЧПКААВ ҐРДҐ ЕШҐСИ ЧПНА ИЇМЮ ЙЬХГЛРВ,ССП ТИРДҐ, ДГА ДФУЕЇЕ,ШВП НСОЧШЦБ УЯПЦ ЮЯ РҐЕА ГЯШШМ" +
            " ЩДЧІЬТЩ,ЬМ УЦМЛ ЮЦМЬҐЛ,ЬШУ ЖГЗНЦСАҐЧ Н Ч ЦГВШР БЇДЕГ У ВВТБРЬТЖ.ЯЄВ ХЩЦЕГИ ЛОМГОЧ ЕГИІТ Д ЬФУО ТНШЧ," +
            " Д УШВ МЙБЮФГ Д ЮЩДГКПЖ ЙЄИСУМЕГ НЦД УМ СХОУИ.Т ХФЬ, ТХТЧП ЄР ЄГМЗШЖЙП,ЄДГАЮВДХАЬЄШК, СЙ РШБЦЧЩЬ ХЧУБХОЕМІПРВ, " +
            "ЖЬЖРГ УТКРЦАІЇЯВ Ц ЕЇСЕ ФНЧ ЄР Ю ПТЖТФШЧШН БЬЦЩГЩ Є РММАМНМ, —І КУ НАРЖОК: ЕД ЖЧТДЛКПК АЩ ИЩУР, МК ХНҐКЛ.Н ДГА, " +
            "ЬМЧЗЗМ ЕЕ РАЕЮФІВЬО,ГЮШ ФУЕАМ МДНЄЙ;",
            "ГенеральнеМордобиття",
            "У ВСЯКОГО СВОЯ ДОЛЯІ СВІЙ ШЛЯХ ШИРОКИЙ,ТОЙ МУРУЄ, ТОЙ РУЙНУЄ,ТОЙ НЕСИТИМ ОКОМ " +
            "ЗА КРАЙ СВІТА ЗАЗИРАЄ,ЧИ НЕМА КРАЇНИ,ЩОБ ЗАГАРБАТЬ І З СОБОЮ ВЗЯТЬ У ДОМОВИНУ.ТОЙ ТУЗАМИ ОБИРАЄ " +
            "СВАТА В ЙОГО ХАТІ, А ТОЙ НИШКОМ У КУТОЧКУ ГОСТРИТЬ НІЖ НА БРАТА.А ТОЙ, ТИХИЙ ТА ТВЕРЕЗИЙ,БОГОБОЯЗЛИВИЙ, " +
            "ЯК КІШЕЧКА ПІДКРАДЕТЬСЯ, ВИЖДЕ НЕЩАСЛИВИЙ У ТЕБЕ ЧАС ТА Й ЗАПУСТИТЬ ПАЗУРІ В ПЕЧІНКИ, —І НЕ БЛАГАЙ: НЕ ВИМОЛЯТЬ " +
            "НІ ДІТИ, НІ ЖІНКА.А ТОЙ, ЩЕДРИЙ ТА РОЗКОШНИЙ,ВСЕ ХРАМИ МУРУЄ;")]

        public void Decode_MessageWithKeyAndN_ReturnsMessageDecodedForXorNCipherForUkrainianAlphabet(
            string message, string key, string decodedMessage)
        {
            var xorCipher = new XORNCipher(new UkrainianAlphabet());

            var decoded = xorCipher.Decode(message, key);

            Assert.Equal(decodedMessage, decoded);

        }


    }
}
