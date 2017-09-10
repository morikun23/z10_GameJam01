using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public interface IEnemyState {

		void OnEnter(ActorEnemy arg_enemy);
		void OnUpdate(ActorEnemy arg_enemy);
		void OnExit(ActorEnemy arg_enemy);
	}
}
