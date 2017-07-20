using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public interface IActorCommand {

		void Execute(LadderUser arg_actor);
		void Undo(LadderUser arg_actor);
	}
}