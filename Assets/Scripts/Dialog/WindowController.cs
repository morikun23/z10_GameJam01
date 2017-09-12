using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// クラス名	:WindowController
/// 作成者	:森田　勝
/// 作成日	:H28/11/09
/// 内容		:ウィンドウの生成から表示、破棄までの一連の流れを制御します
/// 更新		:H28/11/10　[実装] 文字列を１文字ずつ表示、表示が完了したときにマウスクリックで終了
/// </summary>
public class WindowController : MonoBehaviour {

	/// <summary>
	/// 各コンポーネントへの参照
	/// </summary>
	WindowOpener opener;
	WindowCloser closer;
	Text text;
	RawImage rawImage;

	/// <summary>
	/// ステータス
	/// </summary>
	enum State {
		Open,
		Play,
		Close,
		Finished
	}
	State currentState;

	/// <summary>
	/// 表示リスト
	/// </summary>

	//ヨコアリくんの画像
	[SerializeField]
	[Tooltip("ヨコアリくんの画像")]
	Texture[] yokoaris;

	//Inspectorだと\nが反応してくれないので、以下にコピペでお願いします
	string[] texts = new string[10]{
		"ぼくの たんじょうび は\n1989年4月1日だよ。\nよこはまアリーナと おなじ \nたんじょうび なのさ。",
		"ぼくは 2020年\nとうきょうオリンピックに むけて\nスポーツに ちょうせんしてるよ！",
		"おしえて！ヨコアリくん という\nまんが が よこはまアリーナで\nれんさい されているよ",
		"ぼくは ぶんしんのじゅつ や\nへんしん が できるよ。\nそれで イベントを てつだうんだ！",
		"ぼくの せいかくは\nこうきしんおうせい で\nめだちたがりや なんだ。",
		"ぼくは あまいおかし と あまいパンが\nすきなんだ！",
		"ぼくは ドラムを えんそう できるよ！\nライブイベント で えんそう したこともあるんだ！",
		"ぼくの くちぐせは\n「そんなのアリ～ッ！？」",
		"ぼくは つねに けいごを つかって\nしゃべるよ。ていねいな ものごしのアリ なんだ。",
		"ぼくの かつどう は\nツイッター や フェイスブック でもみられるよ",
	};

	/// <summary>
	/// 変数
	/// </summary>

	//経過時間（表示時間と比較します）
	private float elapsedTime;

	//現在表示している番号
	private int currentShowCount;

	//表示している文字数
	int ShowingTextCount;
	//テキストが表示できているか
	bool textFinished;

	/// <summary>
	/// プロパティ
	/// </summary>

	//ウィンドウを表示しているか
	public bool IsShowing {
		get {
			return currentState == State.Play;
		}
	}

	//表示が終了しているか
	public bool IsFinished {
		get {
			return currentState == State.Finished;
		}
	}

	void Awake() {
		//シーンがロードされたときに呼ばれます

		//各コンポーネントを取得
		opener = GetComponent<WindowOpener>();
		closer = GetComponent<WindowCloser>();
		text = GetComponentInChildren<Text>();
		rawImage = GetComponentInChildren<RawImage>();

		//コンポーネントの非アクティブ化
		opener.enabled = closer.enabled = false;

		//非表示
		this.gameObject.SetActive(false);
	}

	void OnEnable() {
		//アクティブ状態になるたびに呼ばれます

		//値のリセット
		Reset();

		//表示させる内容を切り替えます
		text.text = "";
		rawImage.texture = yokoaris[currentShowCount];
	}

	// Update is called once per frame
	void Update() {
		switch (currentState) {
			case State.Open: Open(); break;
			case State.Play: Play(); break;
			case State.Close: Close(); break;
			case State.Finished: return;
		}
	}

	private void Open() {
		opener.enabled = true;

		if (opener.isOpened) {
			opener.enabled = false;
			currentState = State.Play;
		}
	}

	private void Play() {
		//0.15秒ごとに１文字ずつ表示します
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= 0.15f) {
			//0.15秒ごとに１文字ずつ表示します
			elapsedTime = 0;
			if (texts[currentShowCount].Length <= ShowingTextCount) {
				textFinished = true;
				ShowingTextCount = texts[currentShowCount].Length;
			}
			else {
				ShowingTextCount++;
			}
		}

		//マウスイベント
		if (Input.GetMouseButtonDown(0)) {
			if (textFinished) {
				//テキスト表示が終わっていたら閉じる
				currentState = State.Close;
			}
			else {
				//テキスト表示を終わらせる
				ShowingTextCount = texts[currentShowCount].Length;
				textFinished = true;
			}
		}

		//表示している文字列を更新
		text.text = texts[currentShowCount].Substring(0 , ShowingTextCount);
	}

	private void Close() {
		closer.enabled = true;

		if (closer.isClosed) {
			closer.enabled = false;
			currentState = State.Finished;
			this.gameObject.SetActive(false);
		}
	}

	private void Reset() {
		//経過時間を初期化
		elapsedTime = 0;

		//テキストの表示数を初期化
		ShowingTextCount = 0;
		textFinished = false;

		//ステートの初期化
		currentState = State.Open;
	}

	/// <summary>
	/// ウィンドウをポップアップさせます。
	/// 同時に引数で表示させるヨコアリくんとテキストを決定できます
	/// </summary>
	/// <param name="type">表示させるヨコアリくん(0~10)</param>
	public void Show(int type) {
		if (IsShowing) return;
		//ウィンドウの生成
		currentShowCount = type;
		currentState = State.Open;

		this.gameObject.SetActive(true);
	}
}
