using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class GoUpstairsCommand : IActorCommand {

		public void OnUpdate(LadderUser arg_actor) {

			if (arg_actor.m_currentFloor < 3) {
				arg_actor.m_currentFloor += 1;
			}

			arg_actor.ToLadder();
			arg_actor.transform.position += Vector3.up * arg_actor.m_speed / 2;
			arg_actor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		}
	}
}