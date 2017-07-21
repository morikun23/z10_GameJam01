//担当：大山
//概要：導入シーン全体の管理をします。
//参考：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Z10.Introduction{
	public class GameManager : MonoBehaviour {

        //流れるテキスト
        public GameObject m_introText;

        //テキストの最初の位置
        public float startYPos = -15;

        //テキストの最後の位置
        public float endYPos = 25;

        //移動量
        public float addY = 0.015f;

        //フィルター
        public SpriteRenderer filter;

        //フェードする速さ
        float addAlpha = 0.003f;

        //スキップメッセージ
        public SpriteRenderer skipMessage;

        //スキップフラグ
        bool skipFlag;

		// Use this for initialization
		void Start() {
            m_introText.transform.position = new Vector3(0, startYPos, 0);
            skipFlag = false;
		}

		// Update is called once per frame
		void Update() {

            m_introText.transform.position += new Vector3(0, addY, 0);
            skipMessage.color = new Color(1, 1, 1, Mathf.PingPong(Time.time, 1));

            if (Input.GetKeyDown(KeyCode.Space)) skipFlag = true;


            if(m_introText.transform.position.y > endYPos || skipFlag)
            {
                skipMessage.color = new Color(1, 1, 1, 0);
                filter.sortingOrder = 3;
                filter.color += new Color(0,0,0, addAlpha);
                if(filter.color.a >= 1)
                {
					//シーン遷移
					SceneManager.LoadScene("Title");
                }
            }

		}
	}
}