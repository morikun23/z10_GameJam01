using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class EnemyRunState : IEnemyState {

		public void OnEnter(ActorEnemy arg_enemy) {
			
		}

		public void OnUpdate(ActorEnemy arg_enemy) {

			//向きを更新
			arg_enemy.UpdateDirection();

			arg_enemy.transform.position =
				new Vector3(arg_enemy.transform.position.x ,
				Stage.LOWEST_FLOOR_Y + (arg_enemy.m_currentFloor - 1) * Stage.FLOOR_HEIGHT , 0);

			//TODO:目の前にプレイヤーがいるか
			Player target = arg_enemy.FindPlayer(new Vector2((int)arg_enemy.m_direction , 0) * 0.5f);
			if (target) {
				target.OnDamaged();
				return;
			}

			//TODO:梯子チェック
			Ladder ladder = arg_enemy.FindLadderFromUp();
			if (ladder == arg_enemy.ladderBuf) { }
			else if (ladder) {
				arg_enemy.StateTransition(new EnemyUpstairsState(ladder));
				return;
			}

			ladder = arg_enemy.FindLadderFromDown();
			if (ladder == arg_enemy.ladderBuf) { }
			else if (ladder) {
				arg_enemy.StateTransition(new EnemyDownstairsState(ladder));
				return;
			}

			//移動（コマンド使うと重かった）
			arg_enemy.transform.position += Vector3.right * (int)arg_enemy.m_direction * arg_enemy.m_speed;
			
		}

		public void OnExit(ActorEnemy arg_enemy) {

		}

	}
}