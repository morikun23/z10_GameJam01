using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class RunRightCommand : IActorCommand {

		public void Execute(LadderUser arg_actor) {

			//進行方向に壁があったら中断する
			if (Physics2D.BoxCast(arg_actor.transform.position , 
				new Vector2(arg_actor.m_width , arg_actor.m_height) ,
				0 , Vector2.right , arg_actor.m_speed , 1 << LayerMask.NameToLayer("Wall"))) {
				return;
			}

			arg_actor.transform.position += Vector3.right * arg_actor.m_speed;
			arg_actor.m_direction = ActorBase.Direction.RIGHT;
		}

		public void Undo(LadderUser arg_actor) {

		}
	}
}