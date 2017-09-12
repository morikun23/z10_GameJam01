using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {

	public class BuddyDownAttackState : IBuddyState {

		//梯子を上る際のキーフレーム数
		private const int FRAME = 30;

		//現在のフレーム数
		private int m_currentFrame;

		private Ladder m_ladder;

		//到着地点
		private Vector2 m_destination;

		//開始地点
		private Vector2 m_startPosition;

		public IBuddyState m_stateBuffer;

		public BuddyDownAttackState(IBuddyState arg_stateBuffer) {
			m_stateBuffer = arg_stateBuffer;
		}

		/// <summary>
		/// ステート開始時に一度だけ呼ばれる
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnEnter(ActorBuddy arg_actor) {
			m_ladder = arg_actor.m_usingLadder;
			arg_actor.transform.position = new Vector3(m_ladder.transform.position.x , arg_actor.transform.position.y);

			m_startPosition = new Vector2(arg_actor.transform.position.x , arg_actor.transform.position.y);
			int tempCurrentFloor = (m_stateBuffer.GetType() == typeof(BuddyDownstairsState)) ? arg_actor.m_currentFloor : arg_actor.m_currentFloor + 1;
			m_destination = new Vector2(arg_actor.transform.position.x , (Stage.LOWEST_FLOOR_Y + (tempCurrentFloor -1 - 1) * Stage.FLOOR_HEIGHT));
			Debug.Log(m_destination.y);
		}

		/// <summary>
		/// ステート中毎フレーム更新される
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnUpdate(ActorBuddy arg_actor) {

			//下に敵がいたら攻撃する
			RaycastHit2D hitInfo = Physics2D.BoxCast(arg_actor.transform.position,
				new Vector2(0.8f , 0.1f) ,
				0 , Vector2.down , 1 , 1 << LayerMask.NameToLayer("Enemy"));

			if (hitInfo) {
				ActorEnemy enemy = hitInfo.collider.gameObject.GetComponent<ActorEnemy>();
				if (enemy) {
					if (enemy.GetType() == typeof(HeadEnemy)) { arg_actor.OnDamaged(); }
					else { enemy.OnDamaged(); }
				}
			}

			float vertical = (m_destination.y - m_startPosition.y) / FRAME;
			arg_actor.transform.position = m_startPosition + new Vector2(0 , vertical * m_currentFrame);

			m_currentFrame += 1;

			if (m_currentFrame >= FRAME) {
				if(m_stateBuffer.GetType() == typeof(BuddyDownstairsState)) {
					arg_actor.m_currentFloor -= 1;
				}
				arg_actor.StateTransition(new BuddyIdleState());
				return;
			}
		}

		/// <summary>
		/// ステート終了時に一度だけ呼ばれる
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnExit(ActorBuddy arg_actor) {
			arg_actor.m_isLadderUsing = false;
			arg_actor.m_usingLadder.UnUse();
			arg_actor.m_usingLadder = null;
		}
	}
}