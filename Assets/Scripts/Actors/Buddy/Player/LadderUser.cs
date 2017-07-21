using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Z10 {
	public class LadderUser : ActorBase {
		
		//梯子を使用している状態か
		public bool m_isLadderUsing;
		
		public Ladder FindLadderFromUp() {
			
			RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(transform.position.x , -3 + (m_currentFloor - 1) * Stage.FLOOR_HEIGHT)
				, Vector2.zero , 0 , 1 << LayerMask.NameToLayer("Ladder"));

			if (hitInfo) {
				return hitInfo.collider.gameObject.GetComponent<Ladder>();
			}
			return null;
		}

		public Ladder FindLadderFromDown() {

			if (m_currentFloor <= 1) return null;

			RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(transform.position.x , -3 + (m_currentFloor - 2) * Stage.FLOOR_HEIGHT)
				, Vector2.zero , 0 , 1 << LayerMask.NameToLayer("Ladder"));

			if (hitInfo) {
				return hitInfo.collider.gameObject.GetComponent<Ladder>();
			}
			return null;
		}

	}
}