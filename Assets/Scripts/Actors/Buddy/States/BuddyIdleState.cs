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
				-3.75f + (arg_actor.m_currentFloor - 1) * 2.95f , 0);

			if (Input.GetKey(arg_actor.m_leftKey)) {
				arg_actor.StateTransition(new BuddyRunState());
				arg_actor.m_currentTask.Enqueue(new RunLeftCommand());
			}
			else if (Input.GetKey(arg_actor.m_rightKey)) {
				arg_actor.StateTransition(new BuddyRunState());
				arg_actor.m_currentTask.Enqueue(new RunRightCommand());
			}

			if (Input.GetKeyDown(arg_actor.m_upKey)) {
				if (arg_actor.FindLadderFromUp()) {
					arg_actor.StateTransition(new BuddyUpstairsState());
					return;
				}
			}
			if (Input.GetKeyDown(arg_actor.m_downKey)) {
				if (arg_actor.FindLadderFromDown()) {
					arg_actor.StateTransition(new BuddyDownstairsState());
					return;
				}
			}

			if (Input.GetKeyDown(arg_actor.m_actionKey1)) {
				arg_actor.m_currentTask.Enqueue(new PutLadderCommand(arg_actor.m_ladderHolder));
			}
			else if (Input.GetKeyDown(arg_actor.m_actionKey2)) {
				arg_actor.m_currentTask.Enqueue(new RemoveLadderCommand(arg_actor.m_ladderHolder));
			}

			if (arg_actor.m_currentTask.Count > 0) {
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