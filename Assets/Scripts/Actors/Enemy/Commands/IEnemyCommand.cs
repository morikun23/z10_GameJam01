using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public interface IEnemyCommand {

		void Execute(ActorEnemy arg_enemy);

	}
}