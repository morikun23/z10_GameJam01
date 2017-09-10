using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Z10
{
    public class UIManager : MonoBehaviour
    {

        //スコアの表示先、１桁目のオブジェクト
        GameObject score_obj,score_first;
        

        //スコア表示用スプライト、パス
        Sprite[] score_sprites;
        string file_name_score = "Sprites/UI/ScoreNumber_sprite";

        //はしご使用状況を表示しているオブジェクト
        GameObject hashigo_count_obj;

        //はしごの使用状況用スプライト、パス
        Sprite[] hashigo_count_sprites;
        string file_name_hashigo = "Sprites/UI/hashigo_count_number";

        //体力バーを格納しているオブジェ
        GameObject life_obj;

        //体力バー達
        List<Image> life_bars = new List<Image>();

        // Use this for initialization
        void Start()
        {

            score_obj = GameObject.Find("Score");
            score_first = GameObject.Find("score_number");

            score_sprites = Resources.LoadAll<Sprite>(file_name_score);

            hashigo_count_obj = GameObject.Find("hashigo_count");

            hashigo_count_sprites = Resources.LoadAll<Sprite>(file_name_hashigo);

            life_obj = GameObject.Find("Life");

            if (life_obj)
            {

                foreach (Transform obj in life_obj.transform)
                {
                    if (0 <= obj.name.LastIndexOf("Life_bar"))
                    {
                        life_bars.Add(obj.GetComponent<Image>());
                    }
                }

            }
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (score_obj)
                {
                    var random = Random.Range(1, 9000000);
                    scoreView(random);
                }

                if (hashigo_count_obj)
                {
                    var randomrondamo = Random.Range(0, 4);
                    hashigoView(randomrondamo);
                }

                if (life_obj)
                {
                    var randomr = Random.Range(0, 4);
                    Debug.Log("Life = " + randomr);
                    lifeView(randomr);
                }

            }

        }

        //はしご使用状況更新
        void hashigoView(int count)
        {
            hashigo_count_obj.GetComponent<Image>().sprite = hashigo_count_sprites[count];
        }

        //体力更新
        void lifeView(int lifecount)
        {
            for (int i = 0; i < lifecount; i++)
            {
                life_bars[i].color = new Color(1, 1, 1, 1);
            }

            for (int i = life_bars.Count; i > lifecount; i--)
            {
                life_bars[i - 1].color = new Color(0, 0, 0, 1);
            }
        }

        //スコア更新
        void scoreView(int score)
        {
            //前回までのスコアを消す
            foreach (Transform obj in score_obj.transform)
            {
                if (obj.tag == "ScoreNumber" && 0 <= obj.name.LastIndexOf("Clone"))
                {
                    Destroy(obj.gameObject);
                }
            }

            int score_buff = score;
            
            List<int> score_list = new List<int>();

            while (score_buff != 0)
            {
                score = score_buff % 10;
                score_buff = score_buff / 10;
                score_list.Add(score);
            }

            //要素数0には１桁目の値が格納
            score_first.GetComponent<Image>().sprite = score_sprites[score_list[0]];

            for (int i = 1; i < score_list.Count; i++)
            {
                RectTransform scoreimage = (RectTransform)Instantiate(score_first).transform;
                scoreimage.SetParent(score_obj.transform, false);
                scoreimage.localPosition = new Vector2(
                    scoreimage.localPosition.x - scoreimage.sizeDelta.x * i,
                    scoreimage.localPosition.y);
                scoreimage.GetComponent<Image>().sprite = score_sprites[score_list[i]];
            }
        }

    }

}