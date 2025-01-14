using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunscriptToSACSVConverter
{
    public static class ScriptConverter
    {
        public static List<SACSV.ScriptRow> ConvertScript(string path)
        {
            var funscript = Funscript.LoadJson(path);

            List<SACSV.ScriptRow> result = [new SACSV.ScriptRow { InternalTime = 0, Direction = false, Power = 0 }];
            bool start = false;

            foreach (var action in funscript.Actions)
            {
                if (action.Pos == 0 && !start)
                    continue;

                start = true;

                int a = (action.Pos - 50) * 2;

                int time = action.At / 100;
                bool direction = a > 0;
                int power = Math.Abs(a);
                if (power > 100)
                    power = 100;

                result.Add(new SACSV.ScriptRow()
                {
                    InternalTime = time,
                    Direction = direction,
                    Power = power
                });
            }

            return result;
        }
    }
}
