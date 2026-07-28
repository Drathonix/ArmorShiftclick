using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Vintagestory.API.Common;
using Vintagestory.Common;
using Vintagestory.GameContent;

namespace ArmorShiftclick.Patches;

[HarmonyPatch(typeof(InventoryTrader), "LateInitialize")]
public class PatchInventoryTrader
{
    public static void Postfix(InventoryTrader __instance)
    {
        Traverse.Create(__instance).Field("baseWeight").SetValue(3f);
    }
}
