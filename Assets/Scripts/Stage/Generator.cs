using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class Generator : MonoBehaviour {

		public void Initialize() {

		}
		
		public void Generate(ActorEnemy arg_enemy) {
			arg_enemy.transform.position = this.transform.position;
			arg_enemy.gameObject.SetActive(true);
			arg_enemy.Initialize();
		}
	}
}