using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public interface PlayerState {

		void OnEnter(Player arg_player);

		void OnUpdate(Player arg_player);

		void OnExit(Player arg_player);

	}
}