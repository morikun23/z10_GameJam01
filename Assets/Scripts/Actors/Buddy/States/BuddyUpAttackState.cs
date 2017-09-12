using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {

	public class BuddyUpAttackState : IBuddyState {

		//攻撃の時間
		const float m_attackTime = 0.5f;

		//経過時間
		float m_elapsedTime;

		IBuddyState m_stateBuffer;

		public BuddyUpAttackState(IBuddyState arg_stateBuffer) {
			m_stateBuffer = arg_stateBuffer;
		}

		/// <summary>
		/// ステート開始時に一度だけ呼ばれる
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnEnter(ActorBuddy arg_actor) {
			m_elapsedTime = 0;
		}

		/// <summary>
		/// ステート中毎フレーム更新される
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnUpdate(ActorBuddy arg_actor) {

			//上に敵がいたら攻撃する
			RaycastHit2D hitInfo = Physics2D.BoxCast(arg_actor.transform.position,
				new Vector2(0.8f , 0.1f) ,
				0 , Vector2.up , 1 , 1 << LayerMask.NameToLayer("Enemy"));

			if (hitInfo) {
				ActorEnemy enemy = hitInfo.collider.gameObject.GetComponent<ActorEnemy>();
				if (enemy) {
					if (enemy.GetType() == typeof(FootEnemy)) { arg_actor.OnDamaged(); }
					else { enemy.OnDamaged(); }
				}
			}

			m_elapsedTime += Time.deltaTime;

			if (m_elapsedTime >= m_attackTime) {
				arg_actor.m_currentState = m_stateBuffer;
				this.OnExit(arg_actor);
			}

		}

		/// <summary>
		/// ステート終了時に一度だけ呼ばれる
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnExit(ActorBuddy arg_actor) {

		}
	}
}