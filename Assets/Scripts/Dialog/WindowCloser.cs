using UnityEngine;
using System.Collections;

/// <summary>
/// クラス名	:WindowCloser
/// 作成者	:森田　勝
/// 作成日	:H28/11/09
/// 内容		:ウィンドウを閉じる動きをさせます
/// </summary>
public class WindowCloser : MonoBehaviour {

	//現在のウィンドウのスケール
	float windowScale;

	//ウィンドウが閉まりきっているか(true：閉まりきっている)
	[HideInInspector]
	public bool isClosed;

	//最大値
	const int MAX = 1;

	//最小値
	const int MIN = 0;

	// Use this for initialization
	void OnEnable() {
		//enabled値がtrueになる度に初期化します
		Reset();
	}

	// Update is called once per frame
	void Update() {

		//スケール値が最少になったら終了
		if (windowScale <= MIN) {
			windowScale = MIN;
			transform.localScale = new Vector3(MIN , 1 , 1);
			isClosed = true;
			return;
		}

		//時間ごとに値を減算
		windowScale -= Time.deltaTime;
		//加速させるための補正値
		windowScale -= 0.05f;

		//スケール値を更新
		transform.localScale = new Vector3(windowScale , 1 , 1);
	}

	/// <summary>
	/// 初期化します
	/// </summary>
	void Reset() {
		windowScale = 1;
		transform.localScale = Vector3.one;
		isClosed = false;
	}
}
