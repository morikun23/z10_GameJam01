using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class PlayerIdle : IPlayerState {

		public void OnEnter(Player arg_player) {

		}

		public void OnUpdate(Player arg_player) {
			if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
				arg_player.StateTransition(new PlayerMove());
			}
		}

		public void OnExit(Player arg_player) {

		}
	}
}