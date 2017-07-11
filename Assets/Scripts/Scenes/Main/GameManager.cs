//担当：
//概要：メインシーン全体の管理をします。
//参考：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10.Main {
	public class GameManager : MonoBehaviour {

		private ActorManager m_actorManager { get; set; }

		// Use this for initialization
		void Start() {
			m_actorManager = new GameObject("Actors").AddComponent<ActorManager>();
			m_actorManager.Initialize();
		}

		// Update is called once per frame
		void Update() {
			m_actorManager.UpdateByFrame();
		}
	}
}