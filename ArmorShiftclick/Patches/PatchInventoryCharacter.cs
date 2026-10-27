using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Util;
using Vintagestory.Common;
using Vintagestory.Server;

namespace ArmorShiftclick.Patches;

[HarmonyPatch(typeof(InventoryCharacter), "GetBestSuitedSlot")]
public class PatchInventoryCharacter
{
    public static void Postfix(InventoryCharacter __instance, ref WeightedSlot __result, ItemSlot sourceSlot, ItemStackMoveOperation op, List<ItemSlot> skipSlots = null)
    {
        foreach (var slot in __instance)
        {
            if(slot != null && slot.Empty && sourceSlot != slot && slot.CanHold(sourceSlot))
            {
                if (sourceSlot.Itemstack != null && sourceSlot.Itemstack.Collectible.GetTemperature(op.World, sourceSlot.Itemstack) < GlobalConstants.TooHotToTouchTemperature)
                {
                    __result.slot = slot;
                    __result.weight = 3;
                    return;
                }
            }
        }
    }
}
