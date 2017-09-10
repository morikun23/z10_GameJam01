using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class EnemyRunState : IEnemyState {

		public void OnEnter(ActorEnemy arg_enemy) {

		}

		public void OnUpdate(ActorEnemy arg_enemy) {

			arg_enemy.transform.position =
				new Vector3(arg_enemy.transform.position.x ,
				Stage.LOWEST_FLOOR_Y + (arg_enemy.m_currentFloor - 1) * Stage.FLOOR_HEIGHT , 0);

			//TODO:目の前にプレイヤーがいるか
			Player target = arg_enemy.FindPlayer(new Vector2((int)arg_enemy.m_direction , 0) * 3);
			if (target) {
				target.m_hp -= 1;
				return;
			}

			//TODO:梯子チェック
			Ladder ladder = arg_enemy.FindLadderFromUp();
			if (ladder) {
				arg_enemy.StateTransition(new EnemyUpstairsState());
				return;
			}

			ladder = arg_enemy.FindLadderFromDown();
			if (ladder) {
				arg_enemy.StateTransition(new EnemyDownstairsState());
				return;
			}

			//TODO:歩く
			if (arg_enemy.m_direction == ActorBase.Direction.LEFT) {
				arg_enemy.ExecuteTask(new RunLeftCommand());
			}
			else {
				arg_enemy.ExecuteTask(new RunRightCommand());
			}
		}

		public void OnExit(ActorEnemy arg_enemy) {

		}

	}
}