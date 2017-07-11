using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class LadderUser : MonoBehaviour {

		//梯子が使える状態か
		private bool m_isUseful;

		public virtual void OnTriggerEnter2D(Collider2D arg_colliderInfo) {
			if(arg_colliderInfo.gameObject.tag == "Ladder")
			m_isUseful = true;
		}

		public virtual void OnTriggerExit2D(Collider2D arg_colliderInfo) {
			if(arg_colliderInfo.gameObject.tag == "Ladder")
			m_isUseful = false;
		}

		/// <summary>
		/// 梯子が使える状態かを調べる
		/// </summary>
		/// <returns></returns>
		public bool IsLadderUseFul() {
			return m_isUseful;
		}
	}
}