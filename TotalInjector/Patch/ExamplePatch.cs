using Harmony;
using StudioForge.TotalMiner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TotalInjector.Patch
{
    [HarmonyPatch("TradeCore")]
    public class ExamplePatch
    {
        [HarmonyPrefix]
        public static bool Prefix(object __instance, bool __result, object win, int qty, bool buy)
        {
            var item = Traverse.Create(win).Property("InvItem").GetValue<InventoryItem>();
            Logger.Info($"Traded {qty} {item.ItemID}");
            return true;
        }

        [HarmonyPostfix]
        public static void Postfix()
        {

        }
    }
}
