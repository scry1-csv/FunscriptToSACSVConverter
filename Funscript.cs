using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FunscriptToSACSVConverter
{
    public class Funscript
    {
        [JsonPropertyName("version")]
        public string Version { get; set; } = "";
        [JsonPropertyName("inverted")]
        public bool Inverted { get; set; }
        [JsonPropertyName("range")]
        public int Range { get; set; }
        [JsonPropertyName("actions")]
        public List<Action> Actions { get; set; } = new List<Action>();

        public class Action
        {
            [JsonPropertyName("pos")]
            public int Pos { get; set; }
            [JsonPropertyName("at")]
            public int At { get; set; }
            public override string ToString() => $"pos: {Pos}, at: {At}";
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
}
