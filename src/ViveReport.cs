using BepInEx;
using System;
using UnityEngine;
using Utilla;
using HarmonyPatches;

namespace ViveReport {
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("org.andrewpcvr.gorillatag.oculusreportmenu", "Vive Report Menu", "1.0.0")]
    
    public class Plugin : BaseUnityPlugin
    {
        

        public void Update()
        {
            // TODO

            // This code displays the report menu:
            // ViveReport.Menus.OculusReportMenu(true)
        }

        public void OnEnable() { HarmonyPatches.ApplyHarmonyPatches(); }
        public void OnDisable() { HarmonyPatches.RemoveHarmonyPatches(); }

        public void OnGameInitialized(object sender, EventArgs e)
        {
            //

            UnityEngine.Debug.Log("ViveReport should be working, test it with your sandwich btn");
        }
    }
}

/*
Vector3 offset = new Vector3(0f, 0f, 0f);
Vector3 targetPosition = LocalPlayerCameraObject.transform.position + LocalPlayerCameraObject.transform.TransformDirection(offset);
*/
