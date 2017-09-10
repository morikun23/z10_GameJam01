using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class BuddyIdleState : IBuddyState {

		/// <summary>
		/// ステート開始時に一度だけ呼ばれる
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnEnter(ActorBuddy arg_actor) {
			arg_actor.m_currentTask.Clear();
		}

		/// <summary>
		/// ステート中毎フレーム更新される
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnUpdate(ActorBuddy arg_actor) {

			arg_actor.transform.position = 
				new Vector3(arg_actor.transform.position.x ,
				Stage.LOWEST_FLOOR_Y + (arg_actor.m_currentFloor - 1) * Stage.FLOOR_HEIGHT , 0);

			if (Input.GetKey(arg_actor.m_leftKey)) {
				arg_actor.StateTransition(new BuddyRunState());
				arg_actor.m_currentTask.Enqueue(new RunLeftCommand());
			}
			if (Input.GetKey(arg_actor.m_rightKey)) {
				arg_actor.StateTransition(new BuddyRunState());
				arg_actor.m_currentTask.Enqueue(new RunRightCommand());
			}

			if (Input.GetKeyDown(arg_actor.m_upKey)) {
				Ladder ladder = arg_actor.FindLadderFromUp();
				if (ladder) {
					arg_actor.StateTransition(new BuddyUpstairsState(ladder));
					return;
				}
			}
			if (Input.GetKeyDown(arg_actor.m_downKey)) {
				Ladder ladder = arg_actor.FindLadderFromDown();
				if (ladder) {
					arg_actor.StateTransition(new BuddyDownstairsState(ladder));
					return;
				}
			}

			if (Input.GetKeyDown(arg_actor.m_actionKey1)) {
				float vertical = -5.5f + (arg_actor.m_currentFloor - 1) * Stage.FLOOR_HEIGHT;
				if (arg_actor.m_ladderHolder.IsLadderExist(arg_actor.transform.position.x , vertical)) {
					arg_actor.m_currentTask.Enqueue(new RemoveLadderCommand(arg_actor.m_ladderHolder));
				}
				else {
					arg_actor.m_currentTask.Enqueue(new PutLadderCommand(arg_actor.m_ladderHolder));
				}
			}

			while (arg_actor.m_currentTask.Count > 0) {
				arg_actor.m_currentTask.Dequeue().Execute(arg_actor);
			}
		}

		/// <summary>
		/// ステート終了時に一度だけ呼ばれる
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnExit(ActorBuddy arg_actor) {

		}
	}
}