using HarmonyLib;
using System.Reflection;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace ArmorShiftclick
{
    public class ArmorShiftclickModSystem : ModSystem
    {
        private const string HarmonyId = "armorshiftclick";

        private Harmony _harmony;
        public override void Start(ICoreAPI api)
        {
            _harmony = new Harmony(HarmonyId);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
        }

        public override void Dispose()
        {
            _harmony?.UnpatchAll(HarmonyId);
        }
    }
}
