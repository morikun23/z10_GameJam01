using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class BuddyDownstairsState : IBuddyState {

		//梯子を上る際のキーフレーム数
		private const int FRAME = 50;

		//現在のフレーム数
		private int m_currentFrame;

		//現在の階層のバッファ
		private int m_floorBuf;

		private Stack<IActorCommand> m_task;

		/// <summary>
		/// ステート開始時に一度だけ呼ばれる
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnEnter(ActorBuddy arg_actor) {
			m_task = new Stack<IActorCommand>();
			m_floorBuf = arg_actor.m_currentFloor;
			m_currentFrame = 0;
		}

		/// <summary>
		/// ステート中毎フレーム更新される
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnUpdate(ActorBuddy arg_actor) {

			//上キーで昇る
			if (Input.GetKey(arg_actor.m_upKey)) {
				m_currentFrame -= 1;
				m_task.Pop().Undo(arg_actor);
				if (m_currentFrame <= 0) {
					arg_actor.StateTransition(new BuddyIdleState());
					return;
				}
			}

			//下キーで降りる
			if (Input.GetKey(arg_actor.m_downKey)) {
				m_currentFrame += 1;
				m_task.Push(new DownstairsCommand(arg_actor,FRAME,m_currentFrame));
				m_task.Peek().Execute(arg_actor);
				if (m_currentFrame >= FRAME) {
					arg_actor.m_currentFloor -= 1;
					arg_actor.StateTransition(new BuddyIdleState());
					return;
				}
			}
		}

		/// <summary>
		/// ステート終了時に一度だけ呼ばれる
		/// </summary>
		/// <param name="arg_actor"></param>
		public void OnExit(ActorBuddy arg_actor) {
			m_task.Clear();
			m_task = null;
		}
	}
}