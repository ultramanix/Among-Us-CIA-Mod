using UnityEngine;

namespace CIA.Mod.Training;

public static class CiaTrainingLinks
{
    public const string ChannelUrl = "https://www.youtube.com/@chakabania";

    public static void OpenChannel()
    {
        Application.OpenURL(ChannelUrl);
    }
}
