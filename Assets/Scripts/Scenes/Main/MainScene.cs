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
		
		private UIManager m_uiManager { get; set; }

		[SerializeField]
		AudioClip m_messageSE;

		public override IEnumerator OnEnter() {

			AppManager.Instance.m_fade.StartFade(new FadeIn() , Color.black , 0.5f);
			yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
			yield return MessageView();
			GetComponent<AudioSource>().Play();

			m_gameScore = new Score();
			m_gameScore.totalScore = 0;

			m_player = FindObjectOfType<Player>();
			m_player.Initialize();
			m_enemyManager = FindObjectOfType<EnemyManager>();
			m_enemyManager.Initialize();
			m_enemyManager.SetPlayer(m_player);
			m_uiManager = FindObjectOfType<UIManager>();
			m_uiManager.Initialize();
		}

		public override IEnumerator OnUpdate() {
			while (true) {

				m_player.UpdateByFrame();
				m_enemyManager.UpdateByFrame();
				m_uiManager.UpdateByFrame();

				if (m_player.m_currentState.GetType() == typeof(BuddyDeadState)) {
					break;
				}
				yield return null;
			}
		}

		public override IEnumerator OnExit() {
			//TODO:退出アニメーション
			Instantiate(Resources.Load<GameObject>("Prefabs/Effect/Dialog") , Vector3.zero , Quaternion.identity);
			Instantiate(Resources.Load<GameObject>("Prefabs/Effect/Smoke") , m_player.transform.position , Quaternion.identity);
			m_player.gameObject.SetActive(false);
			yield return new WaitForSeconds(3.0f);
			//TODO:ゲームオーバー

			AppManager.Instance.m_fade.StartFade(new FadeOut() , Color.black , 0.5f);
			yield return new WaitWhile(AppManager.Instance.m_fade.IsFading);
			UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
			yield return null;

		}

		IEnumerator MessageView() {
			GameObject m_startMessageOrigin;
			m_startMessageOrigin = Resources.Load<GameObject>("Prefabs/UI/StartMessage");

			GameObject startObj = Instantiate(m_startMessageOrigin , new Vector3(0 + Random.Range(-0.5f , 0.5f) , 0 + Random.Range(-0.5f , 0.5f) , 0) , Quaternion.identity);
			startObj.SetActive(false);

			yield return new WaitForSeconds(1f);

			startObj.SetActive(true);
			startObj.transform.position = new Vector3(0 + Random.Range(-0.5f , 0.5f) , 0 + Random.Range(-0.5f , 0.5f) , 0);

			yield return new WaitForSeconds(0.01f);

			startObj.transform.position = new Vector3(0 + Random.Range(-0.5f , 0.5f) , 0 + Random.Range(-0.5f , 0.5f) , 0);

			yield return new WaitForSeconds(0.01f);

			startObj.transform.position = new Vector3(0 + Random.Range(-0.5f , 0.5f) , 0 + Random.Range(-0.5f , 0.5f) , 0);

			yield return new WaitForSeconds(0.01f);

			startObj.transform.position = new Vector3(0 + Random.Range(-0.5f , 0.5f) , 0 + Random.Range(-0.5f , 0.5f) , 0);

			yield return new WaitForSeconds(0.01f);

			startObj.transform.position = new Vector3(0 + Random.Range(-0.5f , 0.5f) , 0 + Random.Range(-0.5f , 0.5f) , 0);

			yield return new WaitForSeconds(0.01f);

			startObj.transform.position = new Vector3(0 + Random.Range(-0.5f , 0.5f) , 0 + Random.Range(-0.5f , 0.5f) , 0);

			yield return new WaitForSeconds(0.01f);

			startObj.transform.position = Vector3.zero;

			yield return new WaitForSeconds(1.5f);


			float moveSpeed = 0.3f;
			float decreaseTime = 0;

			SpriteRenderer upobj = startObj.transform.FindChild("MainStartMessage_up").GetComponent<SpriteRenderer>();
			SpriteRenderer downobj = startObj.transform.FindChild("MainStartMessage_down").GetComponent<SpriteRenderer>();

			AudioSource se = AppManager.Instance.m_audioManager.CreateSe(m_messageSE);
			se.Play();
			while (true) {


				if (decreaseTime < moveSpeed - 0.1f) decreaseTime += 0.1f * Time.deltaTime;

				upobj.gameObject.transform.position += new Vector3(-moveSpeed + decreaseTime , 0 , 0);
				downobj.gameObject.transform.position += new Vector3(moveSpeed - decreaseTime , 0 , 0);

				upobj.color -= new Color(0 , 0 , 0 , decreaseTime);
				downobj.color -= new Color(0 , 0 , 0 , decreaseTime);

				if (upobj.color.a < 0) {
					startObj.SetActive(false);
					break;
				}

				yield return null;
			}

			Destroy(startObj);

		}
	}
}