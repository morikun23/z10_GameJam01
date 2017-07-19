using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class RunLeftCommand : IActorCommand {

		public void OnUpdate(LadderUser arg_actor) {
			arg_actor.transform.position += Vector3.left * arg_actor.m_speed;
			arg_actor.m_direction = ActorBase.Direction.LEFT;
		}
	}
}