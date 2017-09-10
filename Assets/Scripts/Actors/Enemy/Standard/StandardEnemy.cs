using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class StandardEnemy : ActorEnemy {

		void Start() {
			Initialize();
		}

		void Update() {
			UpdateByFrame();
		}
	}
}