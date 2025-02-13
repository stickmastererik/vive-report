using UnityEngine;
using System;
using System.Reflection;

namespace ViveReport {
	class Menus {
		public static void OculusReportMenu()
		{
            GorillaMetaReport gr = GameObject.Find("Miscellaneous Scripts").transform.Find("MetaReporting").GetComponent<GorillaMetaReport>();
            gr.gameObject.SetActive(true);
            gr.enabled = true;
            MethodInfo inf = typeof(GorillaMetaReport).GetMethod("StartOverlay", BindingFlags.NonPublic | BindingFlags.Instance);
            inf.Invoke(gr, null);
		}
	}
}
