using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TotalInjector.Patch
{
    public class ExamplePatch
    {
        [HarmonyPrefix]
        public static bool Prefix(object __instance, bool __result, object win, int qty, bool buy)
        {
            Logger.Info($"Traded {qty} items");
            return true;
        }

        [HarmonyPostfix]
        public static void Postfix()
        {

        }
    }
}
