using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class EnemyDownstairsState : IEnemyState {

		//梯子を上る際のキーフレーム数
		private const int FRAME = 180;

		//現在のフレーム数
		private int m_currentFrame;

		private Ladder m_ladder;

		//到着地点
		private Vector2 m_destination;

		//開始地点
		private Vector2 m_startPosition;

		public EnemyDownstairsState(Ladder arg_ladder) {
			m_ladder = arg_ladder;
		}

		public void OnEnter(ActorEnemy arg_enemy) {
			arg_enemy.m_isLadderUsing = true;
			arg_enemy.transform.position = new Vector3(m_ladder.transform.position.x , arg_enemy.transform.position.y);

			m_startPosition = new Vector2(arg_enemy.transform.position.x , (Stage.LOWEST_FLOOR_Y + (arg_enemy.m_currentFloor - 1) * Stage.FLOOR_HEIGHT));
			m_destination = new Vector2(arg_enemy.transform.position.x , (Stage.LOWEST_FLOOR_Y + (arg_enemy.m_currentFloor - 1 - 1) * Stage.FLOOR_HEIGHT));
			arg_enemy.m_usingLadder = m_ladder;
			arg_enemy.m_usingLadder.Use();
		}

		public void OnUpdate(ActorEnemy arg_enemy) {

			//下に敵がいたら攻撃する
			RaycastHit2D hitInfo = Physics2D.BoxCast(arg_enemy.transform.position ,
				new Vector2(0.8f , 0.1f) ,
				0 , Vector2.down , 0.5f , 1 << LayerMask.NameToLayer("Player"));

			if (hitInfo) {
				ActorBuddy player = hitInfo.collider.gameObject.GetComponent<ActorBuddy>();
				if (player) {
					if (player.m_currentState.GetType() == typeof(BuddyUpAttackState)) { }
					else {
						player.OnDamaged();
					}
				}
			}

			float vertical = (m_destination.y - m_startPosition.y) / FRAME;
			arg_enemy.transform.position = m_startPosition + Vector2.up * vertical * m_currentFrame;

			m_currentFrame += 1;

			if (m_currentFrame >= FRAME) {
				arg_enemy.m_currentFloor -= 1;
				arg_enemy.StateTransition(new EnemyRunState());
				return;
			}
		}

		public void OnExit(ActorEnemy arg_enemy) {
			arg_enemy.m_isLadderUsing = false;
			arg_enemy.FreezeLadder(m_ladder);
			arg_enemy.m_usingLadder.UnUse();
			arg_enemy.m_usingLadder = null;
		}

	}
}