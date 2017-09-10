using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;
using UnityEngine.SceneManagement;

namespace Z10 {
	public class MainScene : ToyBox.Scene {

		public class Score {
			public int totalScore;
		}

		public static Score m_gameScore;

		public Player m_player { get; private set; }
		public EnemyManager m_enemyManager { get; private set; }

		public override IEnumerator OnEnter() {

			m_player = FindObjectOfType<Player>();
			m_player.Initialize();
			m_enemyManager = FindObjectOfType<EnemyManager>();
			m_enemyManager.Initialize();
			m_enemyManager.SetPlayer(m_player);

			AppManager.Instance.m_fade.StartFade(new FadeIn() , Color.black , 0.5f);
			yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
		}

		public override IEnumerator OnUpdate() {
			while (true) {

				m_player.UpdateByFrame();
				m_enemyManager.UpdateByFrame();

				if (m_player.m_hp <= 0) {
					break;
				}
				yield return null;
			}
		}

		public override IEnumerator OnExit() {
			//TODO:退出アニメーション
			//TODO:ゲームオーバー

			AppManager.Instance.m_fade.StartFade(new FadeOut() , Color.black , 0.5f);
			yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
			UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
			yield return null;

		}
	}
}