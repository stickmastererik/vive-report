using BepInEx;
using System;
using System.Reflection;
using UnityEngine;

namespace OculusReportMenu {
    [BepInPlugin("org.oatsalmon.gorillatag.oculusreportmenu", "Oculus Report Menu", "1.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        GorillaMetaReport gr = GameObject.Find("Miscellaneous Scripts").transform.Find("MetaReporting").GetComponent<GorillaMetaReport>();
        static bool MenuOpen = false;
        static bool ModEnabled = true;

        public void Update()
        {
            if (ControllerInputPoller.instance.leftControllerSecondaryButton)
            {
                if (!MenuOpen && ModEnabled)
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

        public void OnEnable() {
            HarmonyPatches.ApplyHarmonyPatches();
            ModEnabled = true;
        }
        
        public void OnDisable() {
            HarmonyPatches.RemoveHarmonyPatches();
            ModEnabled = false;
        }
    }
}