using System;

namespace LeagueActivityBot
{
    public static class InsultGenerator
    {
        private static readonly string[] Insults =
        {
            "а вот хуй", "ахуеть", "без пизды", "бля", "бля буду", "бляди", "блядиада", "блядина", "блядище",
            "блядство", "блядушник", "блядь", "блять", "в пизду", "выблядок", "гадина", "гандон", "гандонище",
            "гандоша", "гнида", "говнюк", "голоёбище", "гомодрила", "гондон", "далбаёбина", "дебил", "дебилойд",
            "дерьмо", "дибил", "долбаеп", "долбоёб", "допизды", "дурачина", "дурень", "ебало", "ебальник", "ебанат",
            "ебанатик", "ебанатство", "ебаныйврот", "ебанько", "ебарь", "ебасос", "ебать", "ебистика", "еблан",
            "еблище", "ёбну", "ёбарь", "жидоёб", "заебал", "заебись", "заебца", "залупа", "идиот", "идиотина",
            "козлоёбина", "лох", "лохудра", "лошара", "лошок", "манда", "мандавошка", "мозгоёб", "Стас", "мудак",
            "мудила", "мудоеб", "опёздл", "опизденел", "опизденело", "отъёбанный", "охуевший",
            "охуеть", "пёзды", "падла", "педик", "педрила", "педрилко", "пидар", "пидарас", "пидарюка", "пидр", "пизда",
            "пиздабол", "пиздакрыл", "пиздализ", "пиздец", "пиздобратия", "пиздос",
            "пиздуй", "пиздун", "пиздюлина", "пиндос", "подика на хуй", "подъебка", "поебать", "поебень", "поебота",
            "поеботина", "похуй", "похую", "пошел нахуй", "пошел по пизде", "придурок", "распиздяй", "скотоёб",
            "скотоебина", "соси хуй", "соси хуйский", "сракохуй", "страхоёбище", "страхуилина", "сука", "сучара",
            "сучонок", "сцуко", "тупарылый", "тупица", "тупышка", "уебан", "уебать", "уебистче", "уёбок", "урод",
            "уродец", "уродина", "ушлепок", "хуёво", "хуевато", "хуеглот", "хуегрыз", "хуем", "хуеплет", "хуепутало",
            "хуесос", "хуета", "хуетень", "хуило", "хуита", "хуй", "хуй вам", "хуй вам всем", "хуй вот",
            "хуйлище", "хуй ложу", "хуй моржовый", "хуйня", "хуй там", "хуй тебе", "хули надо",
            "хули смотришь", "чмо", "чмошник", "чмырь", "рот ебал"
        };

        public static string GetInsult() => Insults[new Random().Next(0, Insults.Length)];
    }
}