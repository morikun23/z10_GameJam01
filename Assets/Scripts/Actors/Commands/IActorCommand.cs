﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public interface IActorCommand {

		void OnUpdate(LadderUser arg_ladder);
		
	}
}