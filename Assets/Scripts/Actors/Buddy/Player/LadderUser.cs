using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Z10 {
	public class LadderUser : ActorBase {
		
		//梯子を使用している状態か
		public bool m_isLadderUsing;

		//最低フロアのときの座標
		private const float LOWEST_FLOOR_Y = -5.5f;

		public Ladder FindLadderFromUp() {
			return FindLadder(new Vector2(transform.position.x , Stage.LOWEST_FLOOR_Y + (m_currentFloor - 1) * Stage.FLOOR_HEIGHT));
		}

		public Ladder FindLadderFromDown() {
			if (m_currentFloor <= 1) return null;
			return FindLadder(new Vector2(transform.position.x , -3 + (m_currentFloor - 2) * Stage.FLOOR_HEIGHT));
		}

		private Ladder FindLadder(Vector2 arg_origin) {
			RaycastHit2D hitInfo = Physics2D.Raycast(arg_origin , Vector2.zero , 0 , 1 << LayerMask.NameToLayer("Ladder"));

			if (hitInfo) {
				return hitInfo.collider.gameObject.GetComponent<Ladder>();
			}
			return null;
		}
	}
}