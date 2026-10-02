using CIA.Mod.Roles;
using UnityEngine;
using TMPro;
using MiraAPI.Utilities;

namespace CIA.Mod.Systems.Stats;

public static class CiaInfoPanelUi
{
    private static GameObject? _root;
    private static TextMeshPro? _text;

    public static void Update()
    {
        var local = PlayerControl.LocalPlayer;
        if (local == null || local.Data == null)
            return;

        if (_root == null && Input.GetKeyDown(KeyCode.G))
        {
            Open(local);
            return;
        }

        if (_root == null || !_root.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.G))
        {
            Close();
            return;
        }

        var role = CiaRoleDetector.GetRole(local);
        var roleName = CiaRoleNames.GetDisplayName(role);
        var state = local.Data.IsDead ? "GHOST" : "ALIVE";

        _text!.text =
            "CIA INFO\n\n" +
            "ROLE: " + roleName + "\n" +
            "STATE: " + state + "\n" +
            "KILLS: " + CiaRoundStats.GetKills(local.PlayerId) + "\n" +
            "DEATHS: " + CiaRoundStats.GetDeaths(local.PlayerId) + "\n" +
            "LAST LOCATION: " + CiaLastLocation.Get(local.PlayerId) +
            "\n\nG = CLOSE";
    }

    private static void Open(PlayerControl local)
    {
        var camera = Camera.main;
        if (camera == null)
            return;

        if (_root == null)
        {
            _root = new GameObject("CIA_InfoPanel");
            _root.transform.SetParent(camera.transform, false);
            _root.transform.localPosition = new Vector3(0f, 0f, -50f);
            _root.layer = LayerMask.NameToLayer("UI");

            _text = Helpers.CreateTextLabel(
                "Info",
                _root.transform,
                AspectPosition.EdgeAlignments.Center,
                Vector3.zero,
                2f,
                TextAlignmentOptions.Center);
            _text.rectTransform.sizeDelta = new Vector2(9f, 7f);
        }

        _root.SetActive(true);
    }

    private static void Close()
    {
        _root?.SetActive(false);
    }
}
