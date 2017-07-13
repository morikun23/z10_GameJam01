﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class DownstairsCommand : IActorCommand {

		public void OnUpdate(LadderUser arg_actor) {
			arg_actor.transform.position += Vector3.down * arg_actor.m_speed / 2;
		}
	}
}