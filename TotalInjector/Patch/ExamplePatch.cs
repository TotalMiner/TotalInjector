using Harmony;
using StudioForge.TotalMiner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TotalInjector.Patch
{
    [HarmonyPatch]
    public class ExamplePatch
    {
        public const string TypeName = "StudioForge.TotalMiner.Screens2.ShopMenu";
        public const string MethodName = "TradeCore";

        [HarmonyPrefix]
        static bool Prefix(object __instance, bool __result, object win, int qty, bool buy)
        {
            var item = Traverse.Create(win).Property("InvItem").GetValue<InventoryItem>();
            Logger.Info($"Traded {qty} {item.ItemID}");
            return true;
        }

        [HarmonyTargetMethod]
        static MethodInfo CalculateMethod(HarmonyInstance harmony)
        {
            return AccessTools.Method(AccessTools.TypeByName(TypeName), MethodName);
        }
    }
}
