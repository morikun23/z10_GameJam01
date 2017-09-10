using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Z10 {
	public class EnemyManager : MonoBehaviour {

		//敵の最大出現数
		public const int MAX_ENEMY_COUNT = 10;

		private Player m_player;

		public List<ActorEnemy> m_enemies;

		public void Initialize() {
			m_enemies = new List<ActorEnemy>();
			for (int i = 0; i < MAX_ENEMY_COUNT; i++) {
				m_enemies.Add(null);
			}
		}

		public void UpdateByFrame() {

			//List<ActorEnemy> activeEnemy = m_enemies.Where(_ => _.gameObject.activeInHierarchy).ToList();
			//if (activeEnemy.Count > 0) {
			//	foreach (ActorEnemy enemy in activeEnemy) {
			//		enemy.UpdateByFrame();
			//	}
			//}
			
		}

		public void SetPlayer(Player arg_player) {
			m_player = arg_player;
		}

		private IEnumerator Generate() {
			while (true) {

				yield return new WaitWhile(WaitStillFree);

				yield return new WaitForSeconds(3.0f);
			}
		}

		private bool WaitStillFree() {
			return m_enemies.FindAll(_ => !_.gameObject.activeInHierarchy).ToList().Count <= 0;
		}
	}
}