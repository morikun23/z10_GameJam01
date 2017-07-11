using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class Ladder : MonoBehaviour {

		public const string PREFAB_PASS = "Prefabs/Ladder/Ladder";

		public bool m_isActive { get; private set; }

		public void Initialize() {
			SetActive(false);
		}
		
		public void SetActive(bool arg_value) {
			m_isActive = arg_value;
			gameObject.SetActive(m_isActive);
		}

	}
}