using BepInEx;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Management;

namespace OculusReportMenu {
    [BepInPlugin("org.oatsalmon.gorillatag.oculusreportmenu", "OculusReportMenu", "1.0.6")]
    public class Plugin : BaseUnityPlugin
    {
        static bool ModEnabled = true;
        public static bool Menu = false;
        public static bool NoSecondary = false;

        public void Update()
        {
            if (!ModEnabled) return;
            if (Menu)
            {
                // hide the fact that they're in report menu to prevent comp cheating
                GorillaLocomotion.Player.Instance.disableMovement = false;
                GorillaLocomotion.Player.Instance.inOverlay = false;
            }

            if ((ControllerInputPoller.instance.leftControllerSecondaryButton || (NoSecondary && ControllerInputPoller.instance.leftControllerPrimaryButton)) || Keyboard.current.rightAltKey.wasPressedThisFrame)
            {
                if (!Menu) // stop it from opening the menu a whole ton
                {
                    GorillaMetaReport gr = GameObject.Find("Miscellaneous Scripts").transform.Find("MetaReporting").GetComponent<GorillaMetaReport>();
                    gr.gameObject.SetActive(true);
                    Menu = true;
                    gr.enabled = true;
                    MethodInfo inf = typeof(GorillaMetaReport).GetMethod("StartOverlay", BindingFlags.NonPublic | BindingFlags.Instance);
                    inf.Invoke(gr, null);
                }
            }
        }

        public static void ShowMenu() {
        // This was placed here for my Vive report patch, see here
        // https://github.com/oatsalmon/vive-orm-patch
            if (!Menu)
            {
                GorillaMetaReport gr = GameObject.Find("Miscellaneous Scripts").transform.Find("MetaReporting").GetComponent<GorillaMetaReport>();
                gr.gameObject.SetActive(true);
                Menu = true;
                gr.enabled = true;
                MethodInfo inf = typeof(GorillaMetaReport).GetMethod("StartOverlay", BindingFlags.NonPublic | BindingFlags.Instance);
                inf.Invoke(gr, null);
            }
        }

        public void OnEnable() {
            HarmonyPatches.ApplyHarmonyPatches();

            // check for HTC vive headset
            var displaySubsystems = new List<XRDisplaySubsystem>();
            SubsystemManager.GetInstances(displaySubsystems);
        
            XRDisplaySubsystem displaySubsystem = displaySubsystems[0];
            Debug.Log("VR Headset detected by Unity: " + displaySubsystem.SubsystemDescriptor.id);

            if (displaySubsystem.SubsystemDescriptor.id.Contains("HTC Vive")) {
                NoSecondary = true;
            } else {
                NoSecondary = false;
            }

            // enable
            ModEnabled = true;
        }
        
        public void OnDisable() {
            HarmonyPatches.RemoveHarmonyPatches();
            ModEnabled = false;
        }
    }

    [HarmonyPatch(typeof(GorillaMetaReport), "Teardown")] // GorillaMetaReport.Teardown() is called when X is pressed
    public class CheckMenuClosed
    {
        static void Postfix()
        {
            Plugin.Menu = false;
        }
    }
}
