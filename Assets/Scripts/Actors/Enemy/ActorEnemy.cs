

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public abstract class ActorEnemy : LadderUser {

		public Queue<IActorCommand> m_currentTask { get; private set; }

		public override void Initialize() {
			
		}

		public override void UpdateByFrame() {
			this.m_currentTask.Enqueue(new RunRightCommand());
			if(m_currentTask.Count > 0) {
				m_currentTask.Dequeue().Execute(this);
			}
		}

	}
}