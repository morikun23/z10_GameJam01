using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController {

#if UNITY_STANDALONE_WIN
	[RuntimeInitializeOnLoadMethod]
	static void OnRuntimeMethodLoad() {
		Screen.SetResolution(1600 , 900 , false , 60);
	}
#endif
}
