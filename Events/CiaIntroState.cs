namespace CIA.Mod.Events;

public static class CiaIntroState
{
    public static string CurrentRoleName { get; set; } = "CREWMATE";
    public static bool IsCustomRole { get; set; }
    public static bool IsIntroActive { get; set; }
    public static bool IsRolePanelOpen { get; set; }
}
