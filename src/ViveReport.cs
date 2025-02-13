using BepInEx;
using System;
using System.Reflection;
using UnityEngine;

namespace ViveReport {
    [BepInPlugin("org.oatsalmon.gorillatag.oculusreportmenu", "Vive Report Menu", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        GorillaMetaReport gr = GameObject.Find("Miscellaneous Scripts").transform.Find("MetaReporting").GetComponent<GorillaMetaReport>();
        static bool MenuOpen = false;

        public void Update()
        {
            if (ControllerInputPoller.instance.leftControllerSecondaryButton)
            {
                if (!MenuOpen)
                {
                    Menus.OculusReportMenu();
                    MenuOpen = true;
                }
            } else
            {
                MenuOpen = false;

                gr.gameObject.SetActive(false);
                gr.enabled = false;
                MethodInfo inf = typeof(GorillaMetaReport).GetMethod("StopOverlay", BindingFlags.NonPublic | BindingFlags.Instance);
                inf.Invoke(gr, null);
            }
        }

        public void OnEnable() { HarmonyPatches.ApplyHarmonyPatches(); }
        public void OnDisable() { HarmonyPatches.RemoveHarmonyPatches(); }

        public void OnGameInitialized(object sender, EventArgs e)
        {
            UnityEngine.Debug.Log("ViveReport initializing");
        }
    }
}

/*
Vector3 offset = new Vector3(0f, 0f, 0f);
Vector3 targetPosition = LocalPlayerCameraObject.transform.position + LocalPlayerCameraObject.transform.TransformDirection(offset);
*/
