//担当：大山
//概要：ゲームオーバーシーン全体の管理をします。
//参考：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;
using UnityEngine.SceneManagement;

namespace Z10.GameOver {
	public class ResultScene : ToyBox.Scene {

        //フェード用
        public SpriteRenderer m_filter;

        //フェード用の値
        public float addAlpha = 0.015f;

        //コンテメッセージ
        public SpriteRenderer conteMessage;

        bool unko;

		private UIManager m_uiManager;

		// Use this for initialization
		public override IEnumerator OnEnter() {
			AppManager.Instance.m_fade.Clear();
			
			//まずは真っ暗
			m_filter.color = new Color(0, 0, 0, 1);
            //コンテメッセージは消す
            conteMessage.color = new Color(1, 1, 1, 0);

            unko = false;
			m_uiManager = FindObjectOfType<UIManager>();
			m_uiManager.Initialize();
			yield return null;
		}

		// Update is called once per frame
		public override IEnumerator OnUpdate() {

			while (true) {
				m_uiManager.UpdateByFrame();

				if (m_filter.color.a > 0) {
					m_filter.color -= new Color(0 , 0 , 0 , addAlpha);
				}
				else {

					Invoke("SetFlag" , 2);
					m_filter.color = new Color(0 , 0 , 0 , 0);

				}

				if (unko) {
					conteMessage.color += new Color(0 , 0 , 0 , addAlpha);

					if (Input.GetKeyDown(KeyCode.Space)) {
						break;
					}

				}
				yield return null;
			}
        }

		public override IEnumerator OnExit() {
			SceneManager.LoadScene("Title");
			yield return null;
		}

        //ふらぐ
        void SetFlag()
        {
            unko = true;
        }

	}
}