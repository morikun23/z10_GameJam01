using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class PlayerPut : IPlayerState {

		private const float FREEZE_TIME = 1.5f;

		private float m_elapsedTime;

		public void OnEnter(Player arg_player) {
			m_elapsedTime = 0f;
		}

		public void OnUpdate(Player arg_player) {
			m_elapsedTime += Time.deltaTime;

			if(m_elapsedTime >= 1.0f) {
				PutLadder(arg_player);
				arg_player.StateTransition(new PlayerIdle());
			}
		}

		public void OnExit(Player arg_player) {

		}

		private void PutLadder(Player arg_player) {
			arg_player.m_ladderHolder.PutLadder(arg_player.m_currentFloor , arg_player.transform.position.x);
		}
	}
}