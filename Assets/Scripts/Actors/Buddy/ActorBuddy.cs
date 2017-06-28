//担当：森田　勝
//概要：味方キャラクターの共通のステータス
//　　　実装クラスに継承させてください。
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class ActorBuddy : ActorBase {

		//最大残機数
		public const int MAX_LIMIT = 3;

		//現在の残機数
		public int m_currentLimit;

	}
}