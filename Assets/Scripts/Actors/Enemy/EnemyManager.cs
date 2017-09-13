using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Z10 {
	public class EnemyManager : MonoBehaviour {

		//敵の最大出現数
		public const int MAX_ENEMY_COUNT = 10;

		private Player m_player;

		private ActorEnemy[] m_enemies;

		private Generator[] m_generators;

		[System.Serializable]
		public class EnemyBrokenData {
			public int m_currentScore;
			public GameObject m_effect;
			public AudioClip m_coinSE;
			public int m_enemyBrokenCount;

			public EnemyBrokenData() {
				m_currentScore = 50;
				m_enemyBrokenCount = 0;
			}

		}

		[SerializeField]
		private GameObject m_itemBox;

		[SerializeField]
		private EnemyBrokenData m_enemyBrokenData;

		public void Initialize() {
			m_generators = FindObjectsOfType<Generator>();
			foreach(Generator generator in m_generators) {
				generator.Initialize();
			}
		}

		public void UpdateByFrame() {

			m_enemies = FindObjectsOfType<ActorEnemy>();
			foreach(ActorEnemy enemy in m_enemies) {
				enemy.UpdateByFrame();
				
			}
		}

		public void SetPlayer(Player arg_player) {
			m_player = arg_player;
		}

		public void CallEnemyIsBroken(ActorEnemy arg_enemy) {
			m_enemyBrokenData.m_enemyBrokenCount += 1;
            //if(m_enemyBrokenData.m_enemyBrokenCount % 5 == 0) {
            //m_enemyBrokenData.m_currentScore += 5;
            //}

            m_enemyBrokenData.m_currentScore += 10;


            if (m_enemyBrokenData.m_enemyBrokenCount % 10 == 0) {
				Instantiate(m_itemBox , new Vector3(-18 , 1.6f) , Quaternion.identity);
			}

			AudioSource se = ToyBox.AppManager.Instance.m_audioManager.CreateSe(m_enemyBrokenData.m_coinSE);
			se.Play();

			//放出量を上げる
			m_enemyBrokenData.m_effect.GetComponent<ParticleSystem>().emission.SetBursts(new ParticleSystem.Burst[]{
				new ParticleSystem.Burst(0, 0),
				new ParticleSystem.Burst(0, (short)((arg_enemy.m_score / 10) + (m_enemyBrokenData.m_enemyBrokenCount/2)))
				}
			);

			GameObject eff = Instantiate(m_enemyBrokenData.m_effect , arg_enemy.transform.position , Quaternion.identity);
			MainScene.m_gameScore.totalScore += (m_enemyBrokenData.m_currentScore + arg_enemy.m_score);
			Destroy(eff , 3);
		}

		public void AllEnemyDestroy() {
			foreach(ActorEnemy enemy in m_enemies) {
				enemy.OnDamaged();
			}
		}
	}
}