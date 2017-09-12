using UnityEngine;
using System.Collections;

/// <summary>
/// クラス名	:WindowOpener
/// 作成者	:森田　勝
/// 作成日	:H28/11/09
/// 内容		:ウィンドウを開く動きをさせます
/// </summary>
public class WindowOpener : MonoBehaviour {

	//現在のウィンドウのスケール
	float windowScale;

	//ウィンドウが開ききっているか(true：開ききっている)
	[HideInInspector]
	public bool isOpened;

	//最大値
	const int MAX = 1;

	//最小値
	const int MIN = 0;

	// Use this for initialization
	void OnEnable () {
		//enabled値がtrueになる度に初期化します
		Reset();
	}
	
	// Update is called once per frame
	void Update () {

		//スケール値が最大になったら終了
		if (windowScale >= MAX) {
			windowScale = MAX;
			transform.localScale = new Vector3(MAX , 1 , 1);
			isOpened = true;
			return;
		}

		//時間ごとに値を加算
		windowScale += Time.deltaTime;
		//加速させるための補正値
		windowScale += 0.05f;

		//スケール値を更新
		transform.localScale = new Vector3(windowScale, 1 , 1);
	}

	/// <summary>
	/// 初期化します
	/// </summary>
	void Reset() {
		windowScale = 0;
		transform.localScale = Vector3.zero;
		isOpened = false;
	}
}
