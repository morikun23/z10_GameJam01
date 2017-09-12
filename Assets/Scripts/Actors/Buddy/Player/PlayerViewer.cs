using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class PlayerViewer : MonoBehaviour {

		//Animator
		private Animator m_animator { get; set; }
		private SpriteRenderer m_spriteRenderer { get; set; }

		public void Initialize(Player arg_player) {
			m_animator = GetComponent<Animator>();
			m_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void UpdateByFrame(Player arg_player) {
			ViewDirection(arg_player.m_direction);
            ViewStateAnimation(arg_player.m_currentState);
            


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

		private void ViewStateAnimation(IBuddyState arg_currentCommand) {
			if(arg_currentCommand == null) { m_animator.Play("Idle"); }
			else if (arg_currentCommand.GetType() == typeof(BuddyRunState)) {
				m_animator.Play("Run");
			}
			else if(arg_currentCommand.GetType() == typeof(BuddyUpstairsState) ||
                    arg_currentCommand.GetType() == typeof(BuddyDownstairsState)) {
				m_animator.Play("Stairs");
			}
            else if (arg_currentCommand.GetType() == typeof(BuddyUpAttackState))
            {
                m_animator.Play("UpAttack");
            }
            else if (arg_currentCommand.GetType() == typeof(BuddyDownAttackState))
            {
                m_animator.Play("DownAttack");
            }
            else {
				m_animator.Play("Run");
			}
		}
	}
}
