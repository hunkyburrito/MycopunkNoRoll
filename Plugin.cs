using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace NoRoll;

[MycoMod(null, ModFlags.IsClientSide)]
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal new static ManualLogSource Logger = null!;
    private static Harmony _harmony = null!;

    private void Awake()
    {
        Logger = base.Logger;

        _harmony = new Harmony("NoRollPatches");
        _harmony.PatchAll();

        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }

    private void OnDestroy()
    {
        _harmony.UnpatchSelf();
    }
}
