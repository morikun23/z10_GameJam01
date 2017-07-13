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

		private void ViewStateAnimation() {

		}
	}
}
