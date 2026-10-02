using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using CIA.Mod.Events;
using HarmonyLib;
using MiraAPI.PluginLoading;
using MiraAPI.Translation;
using Reactor;
using Reactor.Networking.Attributes;

namespace CIA.Mod;

[BepInAutoPlugin("ultramanix.cia", "CIA")]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(MiraApiPlugin.Id)]
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public partial class CiaPlugin : BasePlugin, IMiraPlugin
{
    public CiaPlugin()
    {
        MiraLocaleManager.Register("CIA.Mod");
    }

    public Harmony Harmony { get; } = new(Id);

    public string OptionsTitleText => "CIA";
    public string CustomOptionMenuNameTwo => "CIA";

    public ConfigFile GetConfigFile() => Config;

    public override void Load()
    {
        CiaIntroEvents.Initialize();
        Harmony.PatchAll();
        Log.LogInfo("CIA loaded.");
    }
}
