using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class RemoveLadderCommand : IActorCommand {

		private LadderHolder m_ladderHolder;

		public RemoveLadderCommand(LadderHolder arg_ladderHolder) {
			m_ladderHolder = arg_ladderHolder;
		}

		public void Execute(LadderUser arg_actor) {

			Ladder ladder = arg_actor.FindLadderFromUp();

			if (ladder) {
				m_ladderHolder.RemoveLadder(ladder);
			}
		}

		public void Undo(LadderUser arg_actor) {

		}
	}
}