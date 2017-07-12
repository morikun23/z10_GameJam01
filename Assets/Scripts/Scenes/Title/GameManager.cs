//担当：大山
//概要：タイトルシーン全体の管理をします。
//参考：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Z10.Title {
	public class GameManager : MonoBehaviour {

        //タイトルにいる忍者とハシゴのGameObject
        public GameObject m_titleNinja, m_ladder;

        //↑の初期位置
        Vector3 m_startPosNinja, m_startPosLadder;

        //タイトルにいる忍者,はしごのスプライトレンダラー
        SpriteRenderer m_titleNinjaSP,m_ladderSP;

        //ロゴ
        public GameObject m_logo;

        //ロゴの初期サイズ
        Vector3 m_startLogoSize;

        //フラッシュ用の一枚板
        public SpriteRenderer m_flash;

        //スペースでスタートやで
        public SpriteRenderer m_StartMessage;

        enum TitleState
        {
            ninja,
            hasigo,
            logo,
            toInput
        }

        TitleState state;

		// Use this for initialization
		void Start() {
            //SpriteRendererを取得
            m_titleNinjaSP = m_titleNinja.GetComponent<SpriteRenderer>();
            m_ladderSP = m_ladder.GetComponent<SpriteRenderer>();

            //初期位置取得してずらして色を消す
            m_startPosNinja = m_titleNinja.transform.position;
            m_titleNinja.transform.position -= new Vector3(1,-1,0);
            m_titleNinjaSP.color = new Color(1, 1, 1, 0);

            //初期位置取得してずらして色を消す
            m_startPosLadder = m_ladder.transform.position;
            m_ladder.transform.position += new Vector3(1, 1, 0);
            m_ladderSP.color = new Color(1, 1, 1, 0);

            //ロゴをでっかくして消します
            m_startLogoSize = m_logo.transform.localScale;
            m_logo.transform.localScale = new Vector3(3,3,0);
            m_logo.SetActive(false);

            //忍者の演出から
            state = TitleState.ninja;
        }

		// Update is called once per frame
		void Update() {

            if (state != TitleState.toInput && Input.GetKeyDown(KeyCode.Space)) Skip();

            switch (state)
            {

                case TitleState.ninja:
                    m_titleNinjaSP.color += new Color(0, 0, 0, Time.deltaTime);
                    m_titleNinja.transform.position = Vector3.Lerp(m_titleNinja.transform.position,
                                                                    m_startPosNinja,
                                                                    Time.deltaTime * 2);

                    if(Vector3.Distance(m_titleNinja.transform.position,m_startPosNinja) < 0.02f)
                    {
                        m_titleNinja.transform.position = m_startPosNinja;
                        m_titleNinjaSP.color = new Color(1, 1, 1, 1);

                        state = TitleState.hasigo;
                    }
                    break;

                case TitleState.hasigo:
                    m_ladderSP.color += new Color(0, 0, 0, Time.deltaTime);
                    m_ladder.transform.position = Vector3.Lerp(m_ladder.transform.position,
                                                                    m_startPosLadder,
                                                                    Time.deltaTime * 2);

                    if (Vector3.Distance(m_ladder.transform.position, m_startPosLadder) < 0.02f)
                    {
                        m_ladder.transform.position = m_startPosLadder;
                        m_ladderSP.color = new Color(1, 1, 1, 1);

                        state = TitleState.logo;
                    }
                    break;

                case TitleState.logo:

                    m_logo.SetActive(true);

                    m_logo.transform.localScale = Vector3.Lerp(m_logo.transform.localScale,
                                                                m_startLogoSize,
                                                                Time.deltaTime * 2);
                    m_logo.transform.Rotate(0, 0, 30);

                    if (Vector3.Distance(m_logo.transform.localScale, m_startLogoSize) < 0.1f)
                    {
                        Flash();

                        m_logo.transform.localScale = m_startLogoSize;
                        m_logo.transform.rotation = Quaternion.Euler(0,0,0);

                        state = TitleState.toInput;
                    }

                    break;

                case TitleState.toInput:

                    if(m_flash.color != new Color(1, 1, 1, 0))
                    {
                        m_flash.color -= new Color(0, 0, 0, Time.deltaTime);
                    }

                    m_StartMessage.color = new Color(1, 1, 1, Mathf.PingPong(Time.time, 1));

                    //スペースキー押したらシーン遷移
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        //遷移したい

                    }

                    break;

            }

		}


        //フラッシュ
        void Flash()
        {
            m_flash.color = new Color(1, 1, 1, 1);
        }
        
        //スキップ
        void Skip()
        {
            //にんじゃ
            m_titleNinja.transform.position = m_startPosNinja;
            m_titleNinjaSP.color = new Color(1, 1, 1, 1);

            //はしご
            m_ladder.transform.position = m_startPosLadder;
            m_ladderSP.color = new Color(1, 1, 1, 1);

            //ロゴ
            m_logo.SetActive(true);
            m_logo.transform.localScale = m_startLogoSize;
            m_logo.transform.rotation = Quaternion.Euler(0, 0, 0);

            Flash();
            state = TitleState.toInput;
        }

	}
}