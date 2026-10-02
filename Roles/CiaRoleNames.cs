namespace CIA.Mod.Roles;

public static class CiaRoleNames
{
    public static string GetDisplayName(CiaRole role) => role switch
    {
        CiaRole.Killer => "KILLER",
        CiaRole.Alerter => "ALERTER",
        CiaRole.Censorer => "CENSORER",
        _ => "CREWMATE"
    };
}
