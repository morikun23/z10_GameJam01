using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class GoDownstairsCommand : IActorCommand {

		public void OnUpdate(LadderUser arg_actor) {

			if (arg_actor.m_currentFloor > 1) {
				arg_actor.m_currentFloor -= 1;
			}

			arg_actor.ToLadder();

			Ladder ladder = arg_actor.FindLadderFromDown();
			Vector3 ladderPos = ladder.transform.position;
			float ladderHeight = ladder.transform.localScale.y;

			arg_actor.transform.position = ladderPos + Vector3.up * ladderHeight / 2;
			arg_actor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		}
	}
}