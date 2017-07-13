//担当：大山
//概要：ゲームオーバーシーン全体の管理をします。
//参考：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10.GameOver {
	public class GameManager : MonoBehaviour {

        //フェード用
        public SpriteRenderer m_filter;

        //フェード用の値
        public float addAlpha = 0.015f;

        //コンテメッセージ
        public SpriteRenderer conteMessage;

        bool unko;

		// Use this for initialization
		void Start() {
            //まずは真っ暗
            m_filter.color = new Color(0, 0, 0, 1);
            //コンテメッセージは消す
            conteMessage.color = new Color(1, 1, 1, 0);

            unko = false;
		}

		// Update is called once per frame
		void Update() {

            if (m_filter.color.a > 0)
            {
                m_filter.color -= new Color(0, 0, 0, addAlpha);
            }
            else {

                Invoke("SetFlag", 2);
                m_filter.color = new Color(0, 0, 0, 0);

            }

            if (unko)
            {
                conteMessage.color += new Color(0, 0, 0, addAlpha);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Application.LoadLevel(1);
                }

            }
        }


        //ふらぐ
        void SetFlag()
        {
            unko = true;
        }

	}
}