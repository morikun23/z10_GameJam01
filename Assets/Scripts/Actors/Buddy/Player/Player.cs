//担当：森田　勝
//概要：プレイヤーの動きを実装したクラス
//　　　状態別の処理はクラスを分けています。
//参考：特になし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class Player : ActorBuddy {

		//プレハブファイルのパス
		public const string PREFAB_PASS = "Prefabs/Actor/Player";
		
		private PlayerViewer m_viewer { get; set; }

		void Start() {
			this.Initialize();
		}

		void Update() {
			this.UpdateByFrame();
		}

		/// <summary>
		/// 初期化
		/// </summary>
		public override void Initialize() {
			m_width = GetComponent<BoxCollider2D>().bounds.size.x;
			m_height = GetComponent<BoxCollider2D>().bounds.size.y;

			m_ladderHolder = new GameObject("Ladders").AddComponent<LadderHolder>();
			m_ladderHolder.Initialize();
			m_viewer = GetComponent<PlayerViewer>();
			m_viewer.Initialize(this);

			m_currentTask = new Queue<IActorCommand>();
			this.StateTransition(new BuddyIdleState());
		}

		/// <summary>
		/// 更新
		/// </summary>
		public override void UpdateByFrame() {

			m_currentState.OnUpdate(this);

			//描画を行う
			View();
		}

		/// <summary>
		/// 描画を行う
		/// </summary>
		private void View() {
			m_viewer.UpdateByFrame(this);
		}
	}
}