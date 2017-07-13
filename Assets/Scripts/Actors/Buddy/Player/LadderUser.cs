using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Z10 {
	public class LadderUser : ActorBase {

		//梯子の使用状況
		public enum LadderStatus {
			USEFUL,     //使用可能
			USING,      //使用している
			FREE        //使用していない
		}

		public LadderStatus m_currentLadderStatus;

		//梯子を使用している状態か
		private bool m_isUsing;
		
		public Ladder FindLadderFromUp() {
			Vector3 top = transform.position + Vector3.up * m_height / 2;
			RaycastHit2D ladder = Physics2D.Raycast(top, Vector2.up , 0.2f,1 << LayerMask.NameToLayer("Ladder"));
			if (ladder) {
				return ladder.collider.gameObject.GetComponent<Ladder>();
			}
			return null;
		}

		public Ladder FindLadderFromDown() {
			Vector3 bottom = transform.position + Vector3.down * m_height / 2;

			RaycastHit2D ladder = Physics2D.Raycast(bottom , Vector2.down , 0.2f , 1 << LayerMask.NameToLayer("Ladder"));
			if (ladder) {
				return ladder.collider.gameObject.GetComponent<Ladder>();
			}
			return null;
		}

		public void ToLadder() {
			m_isUsing = true;
		}

		public void LadderIsUnUse() {
			m_isUsing = false;
		}

		/// <summary>
		/// 梯子が使える状態かを調べる
		/// </summary>
		/// <returns></returns>
		public bool IsLadderUseFul() {
			//双方向を確認し、どちらかに梯子があれば良し
			return FindLadderFromDown() || FindLadderFromUp();
		}

		public bool IsLadderUsing() {
			return m_isUsing;
		}

		/// <summary>
		/// 地上に立てるかを調べる
		/// 梯子から降りたいときに使用する
		/// </summary>
		/// <returns></returns>
		public bool IsGrounded() {
			Vector3 bottom = transform.position + Vector3.down * m_height / 2;
			return Physics2D.Raycast(bottom , Vector2.down , 0.1f , 1 << LayerMask.NameToLayer("Ground"));
		}

		/// <summary>
		/// 天井に接しているかを調べる
		/// 梯子から次の階へ上るときに使用する
		/// </summary>
		/// <returns></returns>
		public bool IsCeiled() {
			Vector3 top = transform.position + Vector3.up * m_height / 2;
			return Physics2D.Raycast(top , Vector2.up , 0.1f , 1 << LayerMask.NameToLayer("Ground"));
		}
	}
}