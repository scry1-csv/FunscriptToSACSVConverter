using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunscriptToSACSVConverter
{
    public static class SACSV
    {
        public static bool WriteCsv(List<ScriptRow> script)
        {
            StringBuilder sb = new();

            foreach (var row in script)
            {
                int d = row.Direction ? 1 : 0;
                sb.AppendLine($"{row.InternalTime},{d},{row.Power}");
            }

            try
            {
                File.WriteAllText(@"result.csv", sb.ToString());
                return true;
            }
            catch (Exception e)
            {
                Util.ShowErrorMessageBoxTopMost("CSVの書き込みに失敗しました: " + e.ToString());
                return false;
            }
        }

        public record ScriptRow
        {
            public int InternalTime;
            public bool Direction;
            public int Power;
            public double Milliseconds { get => (double)InternalTime * 100; }
            public override string ToString()
            {
                var builder = new StringBuilder();
                builder.Append($"InternalTime:{InternalTime}, ");
                builder.Append($"Direction:{Direction}, ");
                builder.Append($"Power:{Power}");
                return builder.ToString();
            }
        }
    }
}
