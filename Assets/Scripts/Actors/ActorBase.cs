//担当：森田　勝
//概要：キャラクターの共通のステータス
//　　　実装クラスに継承させてください
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public abstract class ActorBase : MonoBehaviour {

		//最大体力
		public int m_maxHp;

		//残り体力
		public int m_hp;

		//移動速度
		public float m_speed;

		//攻撃力
		public int m_power;

		//向き
		public enum Direction {
			LEFT = -1,
			RIGHT = 1
		}

		//現在向いている方向
		public Direction m_direction;

		//現在いる階層
		public int m_currentFloor;

		/// <summary>
		/// 初期化
		/// </summary>
		public virtual void Initialize() {

		}

		/// <summary>
		/// 更新
		/// </summary>
		public virtual void UpdateByFrame() {

		}
	}
}
