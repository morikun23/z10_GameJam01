//担当：森田　勝
//概要：梯子を使用するときに中継するクラス
//参考：特になし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class LadderHolder : MonoBehaviour {

		//梯子を格納するリスト
		private List<Ladder> m_ladders;

		//最大の梯子数
		public const int LADDER_COUNT = 2;

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize() {
			m_ladders = new List<Ladder>(LADDER_COUNT);
			for(int i = 0; i < LADDER_COUNT; i++) {
				Ladder ladder = Instantiate(Resources.Load<GameObject>(Ladder.PREFAB_PASS),this.transform).GetComponent<Ladder>();
				ladder.Initialize();
				m_ladders.Add(ladder);
			}
		}

		/// <summary>
		/// 空き梯子を探します
		/// </summary>
		/// <returns>空き梯子がない場合はNULLを返す</returns>
		private Ladder FindFreeLadder() {
			return m_ladders.Find(_ => !_.m_isActive);
		}

		/// <summary>
		/// 梯子を置きます
		/// 空き梯子がない場合は置きません
		/// </summary>
		/// <param name="arg_floor">置く階</param>
		/// <param name="arg_horizontal">置くx座標</param>
		public void PutLadder(int arg_floor , float arg_horizontal) {
			Ladder ladder = FindFreeLadder();
			if (!ladder) return;

			float vertical = 0.1f + (arg_floor - 2) * 3;
			ladder.transform.position = new Vector3(arg_horizontal , vertical);
			ladder.SetActive(true);
		}

		/// <summary>
		/// 梯子を外します
		/// </summary>
		/// <param name="arg_ladder">外す梯子</param>
		public void RemoveLadder(Ladder arg_ladder) {
			arg_ladder.SetActive(false);
		}

		/// <summary>
		/// 梯子リストを配列化して渡します
		/// 梯子の使用状況を確認する
		/// </summary>
		/// <returns>梯子の配列</returns>
		public Ladder[] GetLaddersActive() {
			return m_ladders.ToArray();
		}

	}
}