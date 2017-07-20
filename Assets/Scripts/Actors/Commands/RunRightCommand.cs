using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class RunRightCommand : IActorCommand {

		public void Execute(LadderUser arg_actor) {
			arg_actor.transform.position += Vector3.right * arg_actor.m_speed;
			arg_actor.m_direction = ActorBase.Direction.RIGHT;
		}

		public void Undo(LadderUser arg_actor) {

		}
	}
}