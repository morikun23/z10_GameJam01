using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Z10 {
	public class EnemyJoinState : IEnemyState {

		Vector3 m_startPosition;
		Vector3 m_destination;

		private const int FRAME = 60;

		private int t;

		public void OnEnter(ActorEnemy arg_enemy) {
			m_startPosition = arg_enemy.transform.position;
			m_destination = m_startPosition + new Vector3((int)arg_enemy.m_direction * 2.0f,0);
			t = 0;
		}

		public void OnUpdate(ActorEnemy arg_enemy) {
			Vector3 velocity = (m_destination - m_startPosition) / FRAME;
			arg_enemy.transform.position += velocity;
			t += 1;
			if(t >= FRAME) {
				arg_enemy.StateTransition(new EnemyRunState());
			}
		}

		public void OnExit(ActorEnemy arg_enemy) {

		}
		
	}
}