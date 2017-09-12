using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class EnemyViewer : MonoBehaviour {

		//Animator
		private Animator m_animator { get; set; }
		private SpriteRenderer m_spriteRenderer { get; set; }

		public void Initialize(ActorEnemy arg_enemy) {
			m_animator = GetComponent<Animator>();
			m_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void UpdateByFrame(ActorEnemy arg_enemy) {
			ViewDirection(arg_enemy.m_direction);
            ViewStateAnimation(arg_enemy.m_currentState);
        }

		private void ViewDirection(ActorBase.Direction arg_direction) {
			switch (arg_direction) {
				case ActorBase.Direction.LEFT:
				m_spriteRenderer.flipX = true;
				break;
				case ActorBase.Direction.RIGHT:
				m_spriteRenderer.flipX = false;
				break;
			}
		}

		private void ViewStateAnimation(IEnemyState arg_currentState) {
			if(arg_currentState == null) { m_animator.Play("Idle"); }
			else if (arg_currentState.GetType() == typeof(EnemyRunState)) {
				m_animator.Play("Run");
			}
			else if(arg_currentState.GetType() == typeof(EnemyUpstairsState) ||
                    arg_currentState.GetType() == typeof(EnemyDownstairsState)) {
				m_animator.Play("Stairs");
			}
			else if(arg_currentState.GetType() == typeof(EnemyDeadState)) {
				//m_animator.Play("Dead");
			}

            else {
				m_animator.Play("Idle");
			}
		}
	}
}
