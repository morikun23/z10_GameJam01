using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class ClimbCommand : IActorCommand {

		public void OnUpdate(LadderUser arg_actor) {
			if (arg_actor.m_currentFloor < 3) {
				arg_actor.m_currentFloor += 1;
			}
			float vertical = -0.75f + (arg_actor.m_currentFloor - 2) * 3;
			arg_actor.transform.position = new Vector3(arg_actor.transform.position.x , vertical , 0);
			arg_actor.LadderIsUnUse();
			arg_actor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		}
	}
}