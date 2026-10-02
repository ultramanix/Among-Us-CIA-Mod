namespace CIA.Mod.Roles;

public sealed class CiaPlayerState
{
    public CiaRole Role { get; set; } = CiaRole.None;
    public bool IsCiaMember => Role != CiaRole.None;
}
