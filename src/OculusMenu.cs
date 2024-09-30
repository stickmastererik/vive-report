using UnityEngine;
using System;

namespace ViveReport {
	class Menus {
		public static void OculusReportMenu(bool showMenu)
		{
      		if (showMenu)
			{
				GorillaMetaReport gr = GameObject.Find("Miscellaneous Scripts").transform.Find("MetaReporting").GetComponent<GorillaMetaReport>();
				gr.gameObject.SetActive(true);
				gr.enabled = true;
				MethodInfo inf = typeof(GorillaMetaReport).GetMethod("StartOverlay", BindingFlags.NonPublic | BindingFlags.Instance);
				inf.Invoke(gr, null);
      		} else
        	{
				GorillaMetaReport gr = GameObject.Find("Miscellaneous Scripts").transform.Find("MetaReporting").GetComponent<GorillaMetaReport>();
				if (gr.gameObject.activeSelf)
				{
				  gr.gameObject.SetActive(false);
				  gr.enabled = false;
				  MethodInfo inf = typeof(GorillaMetaReport).GetMethod("Teardown", BindingFlags.NonPublic | BindingFlags.Instance);
				  inf.Invoke(gr, null);
				}
			}
		}
	}
}
