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
        string file_name = "Sprites/UI/ScoreNumber_sprite";

        // Use this for initialization
        void Start()
        {

            score_obj = GameObject.Find("Score");
            score_first = GameObject.Find("score_number");

            score_sprites = Resources.LoadAll<Sprite>(file_name);
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                RandomScore();
            }

        }

        public void RandomScore()
        {
            //クリックされるたびにrandomでスコアを変動
            var random = Random.Range(1, 9000000);

            
            scoreView(random);
        }

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