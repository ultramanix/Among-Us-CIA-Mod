using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI.PluginLoading;
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
    public Harmony Harmony { get; } = new(Id);

    public string OptionsTitleText => "CIA";
    public string CustomOptionMenuNameTwo => "CIA";

    public ConfigFile GetConfigFile() => Config;

    public override void Load()
    {
        Harmony.PatchAll();
        Log.LogInfo("CIA loaded.");
    }
}
