using MiraAPI.Utilities;
using TMPro;
using UnityEngine;

namespace CIA.Mod.Events;

public static class CiaRolePanelUi
{
    private static GameObject? _root;
    private static TextMeshPro? _roleText;

    public static void Open(string roleName)
    {
        var camera = Camera.main;
        if (camera == null)
            return;

        if (_root == null)
        {
            _root = new GameObject("CIA_RolePanel");
            _root.transform.SetParent(camera.transform, false);
            _root.transform.localPosition = new Vector3(0f, 0f, -50f);
            _root.layer = LayerMask.NameToLayer("UI");

            _roleText = Helpers.CreateTextLabel(
                "Role",
                _root.transform,
                AspectPosition.EdgeAlignments.Center,
                new Vector3(0f, 0f, 0f),
                3f,
                TextAlignmentOptions.Center);
            _roleText.rectTransform.sizeDelta = new Vector2(9f, 5f);
        }

        _roleText!.text = roleName + "\n\nPress X to continue";
        _root.SetActive(true);

        if (PlayerControl.LocalPlayer != null)
            PlayerControl.LocalPlayer.moveable = false;
    }

    public static void Update()
    {
        if (!CiaIntroState.IsRolePanelOpen || _root == null || !_root.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.X))
            Close();
    }

    public static void Close()
    {
        _root?.SetActive(false);
        CiaIntroState.IsRolePanelOpen = false;

        if (PlayerControl.LocalPlayer != null)
            PlayerControl.LocalPlayer.moveable = true;
    }
}
