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

		//現在の状態（Stateパターンにて実装）
		public IPlayerState m_currentState { get; private set; }

		//梯子
		public LadderHolder m_ladderHolder { get; private set; }

		private PlayerViewer m_viewer { get; set; }

		/// <summary>
		/// 初期化
		/// </summary>
		public override void Initialize() {
			m_ladderHolder = new GameObject("Ladders").AddComponent<LadderHolder>();
			m_ladderHolder.Initialize();
			m_currentState = new PlayerIdle();
			m_currentState.OnEnter(this);
			m_viewer = GetComponent<PlayerViewer>();
			m_viewer.Initialize(this);
		}

		/// <summary>
		/// 更新
		/// </summary>
		public override void UpdateByFrame() {

			

			if (Input.GetKeyDown(KeyCode.Space)) {
				StateTransition(new PlayerPut());
			}

			m_currentState.OnUpdate(this);
			m_viewer.UpdateByFrame(this);
		}

		/// <summary>
		/// 状態の遷移
		/// </summary>
		/// <param name="arg_nextState"></param>
		public void StateTransition(IPlayerState arg_nextState) {
			m_currentState.OnExit(this);
			m_currentState = arg_nextState;
			m_currentState.OnEnter(this);
		}

		void OnTriggerEnter2D(Collider2D arg_colliderInfo) {

		}
		
	}
}