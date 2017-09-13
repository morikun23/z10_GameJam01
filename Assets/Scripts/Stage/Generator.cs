using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10 {
	public class Generator : MonoBehaviour {

		//敵を格納
		GameObject[] m_existEnemies;
		//アクティブの最大数
		public int maxEnemy = 2;

		public float m_interval;

		[SerializeField]
		private ActorBase.Direction m_defaultDirection;

		[SerializeField]
		private int m_defaultFloor;

		private Animator m_warningEffect;

		// Use this for initialization
		public void Initialize() {
			m_existEnemies = new GameObject[maxEnemy];
			m_interval = Random.Range(3 , 10);
			m_warningEffect =
				Instantiate(Resources.Load<GameObject>("Prefabs/Effect/BalloonEffect") ,
				transform.position + Vector3.right * (float)m_defaultDirection * 1.5f , Quaternion.identity , this.transform).
				GetComponent<Animator>();
			if (m_defaultDirection == ActorBase.Direction.LEFT) {
				m_warningEffect.gameObject.GetComponent<SpriteRenderer>().flipX = true;
			}
			m_warningEffect.gameObject.SetActive(false);

			StartCoroutine(Exec());
			
		}

		//敵を作成する
		private IEnumerator Exec() {
			while (true) {
				yield return new WaitForSeconds(m_interval);

				for (int enemyCount = 0; enemyCount < m_existEnemies.Length; enemyCount++) {
					if (m_existEnemies[enemyCount] == null) {
						//敵作成
						yield return Warning();
						Generate(enemyCount);
						break;
					}
				}

				m_interval = Random.Range(10 , 20);
			}
		}

		private void Generate(int i) {
			m_existEnemies[i] =
							Instantiate(ChooseEnemy() , transform.position , transform.rotation) as GameObject;

			ActorEnemy emergedEnemy = m_existEnemies[i].GetComponent<ActorEnemy>();
			emergedEnemy.m_direction = m_defaultDirection;
			emergedEnemy.m_currentFloor = m_defaultFloor;
			emergedEnemy.m_speed += Random.Range(0 , 0.02f);
			emergedEnemy.Initialize();
		}

		private GameObject ChooseEnemy() {

			string pass = "Prefabs/Actor/Enemy/";

			int num = Random.Range(0 , 20);

			if (num < 1) { pass += "GoldenEnemy"; }
			else if (num < 3) { pass += "HeadEnemy"; }
            else if (num < 5) { pass += "FootEnemy"; }
            else { pass += "StandardEnemy"; }
			return Resources.Load<GameObject>(pass);
		}


		private IEnumerator Warning() {
			this.m_warningEffect.gameObject.SetActive(true);
			this.m_warningEffect.Play("Warning");
			yield return new WaitForSeconds(1.0f);
			this.m_warningEffect.gameObject.SetActive(false);
		}
	}
}