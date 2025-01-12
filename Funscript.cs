using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FunscriptToSACSVConverter
{
#pragma warning disable IDE1006 // 命名スタイル
#pragma warning disable CS8981 // 型名には、小文字の ASCII 文字のみが含まれています。このような名前は、プログラミング言語用に予約されている可能性があります。
    public class Funscript
    {
        public string version { get; set; } = "";
        public bool inverted { get; set; }
        public int range { get; set; }
        public List<action> actions { get; set; } = new List<action>();

        public class action
        {
            public int pos { get; set; }
            public int at { get; set; }
            public override string ToString() => $"pos: {pos}, at: {at}";
        }

        public static Funscript LoadJson(string path)
        {
            var jsonstr = File.ReadAllText(path);
            JsonSerializerOptions options = new()
            {
                AllowTrailingCommas = true
            };
            var result = JsonSerializer.Deserialize<Funscript>(jsonstr, options);

            if (result is null)
                throw new IOException($"ファイルの読み込みに失敗しました: {path}");
            else 
                return result;
        }
    }
#pragma warning restore IDE1006
#pragma warning restore CS8981 // 型名には、小文字の ASCII 文字のみが含まれています。このような名前は、プログラミング言語用に予約されている可能性があります。
}
