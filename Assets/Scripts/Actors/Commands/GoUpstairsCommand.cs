using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class GoUpstairsCommand : IActorCommand {

		public void OnUpdate(LadderUser arg_actor) {

			//上にある梯子を取得
			Ladder ladder = arg_actor.FindLadderFromUp();

			arg_actor.transform.position = new Vector3(ladder.transform.position.x , arg_actor.transform.position.y , 0);

			arg_actor.ToLadder();
			arg_actor.transform.position += Vector3.up * arg_actor.m_speed / 2;
			arg_actor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
		}
	}
}