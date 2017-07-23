using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class PutLadderCommand : IActorCommand {

		private LadderHolder m_ladderHolder;

		public PutLadderCommand(LadderHolder arg_ladderHolder) {
			m_ladderHolder = arg_ladderHolder;
		}

		public void Execute(LadderUser arg_actor) {

			if (arg_actor.m_currentFloor >= 3) return;
			
			m_ladderHolder.PutLadder(arg_actor.m_currentFloor , arg_actor.transform.position.x);
			
		}

		public void Undo(LadderUser arg_actor) {

		}
	}
}