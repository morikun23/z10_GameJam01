using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class PlayerMove : IPlayerState {

		public void OnEnter(Player arg_player) {

		}

		public void OnUpdate(Player arg_player) {

			if (Input.GetKey(KeyCode.RightArrow)) { arg_player.m_direction = ActorBase.Direction.RIGHT; }
			else if (Input.GetKey(KeyCode.LeftArrow)) { arg_player.m_direction = ActorBase.Direction.LEFT; }
			else {
				arg_player.StateTransition(new PlayerIdle());
			}

			switch (arg_player.m_direction) {
				case ActorBase.Direction.LEFT:
				arg_player.transform.position += Vector3.left * arg_player.m_speed;
				break;
				case ActorBase.Direction.RIGHT:
				arg_player.transform.position += Vector3.right * arg_player.m_speed;
				break;
			}

		}

		public void OnExit(Player arg_player) {

		}
	}
}
