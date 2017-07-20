using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class Ladder : MonoBehaviour {

		public int m_currentFloor;

		public const string PREFAB_PASS = "Prefabs/Ladder/Ladder";

		public bool m_isActive { get; private set; }

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize() {
			SetActive(false);
			m_currentFloor = 0;
		}
		
		/// <summary>
		/// アクティブ値の設定
		/// </summary>
		/// <param name="arg_value"></param>
		public void SetActive(bool arg_value) {
			m_isActive = arg_value;
			gameObject.SetActive(m_isActive);
		}

	}
}