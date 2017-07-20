//担当：森田　勝
//概要：味方キャラクターの共通のステータス
//　　　実装クラスに継承させてください。
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class ActorBuddy : LadderUser {

		//最大残機数
		public const int MAX_LIMIT = 3;

		//現在の残機数
		public int m_currentLimit;

		//左キー
		public KeyCode m_leftKey;
		//右キー
		public KeyCode m_rightKey;
		//上キー
		public KeyCode m_upKey;
		//下キー
		public KeyCode m_downKey;

		//アクションキー１
		public KeyCode m_actionKey1;

		//アクションキー２
		public KeyCode m_actionKey2;

		//アクションキー３
		public KeyCode m_actionKey3;

		//アクションキー４
		public KeyCode m_actionKey4;

		//タスク
		public Queue<IActorCommand> m_currentTask { get; protected set; }
		//ステート
		public IBuddyState m_currentState { get; private set; }

		//梯子を所持するためのコンポーネント
		public LadderHolder m_ladderHolder { get; protected set; }

		/// <summary>
		/// ステートの変更
		/// </summary>
		/// <param name="arg_nextState"></param>
		public void StateTransition(IBuddyState arg_nextState) {
			if (m_currentState != null) m_currentState.OnExit(this);
			m_currentState = arg_nextState;
			m_currentState.OnEnter(this);
		}
	}
}