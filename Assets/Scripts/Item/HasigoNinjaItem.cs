using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z10{

    public class HasigoNinjaItem : Item
    {

        string bombpass = "Sprites/UI/BombItem";
        string hazurepass = "Sprites/UI/HazureItem";
        string goldpass = "Sprites/UI/GoldItem";
        string lifepass = "Sprites/UI/LifeItem";

        string bombTextpass = "Sprites/UI/BombTEX";
        string hazureTextpass = "Sprites/UI/HazureTEX";
        string goldTextpass = "Sprites/UI/GoldTEX";
        string lifeTextpass = "Sprites/UI/LifeTEX";

        SpriteRenderer Item_Renderer;

        int Item_num;

        float xspeed = 0.05f;

        public AudioClip openSE,effectSE;

        // Use this for initialization
        void Start()
        {

            Item_Renderer = transform.FindChild("Item").GetComponent<SpriteRenderer>();
            Item_Renderer.enabled = false;

            Item_num = Random.Range(0, 4);
            

            switch (Item_num)
            {
                //爆弾
                case 0:
                    Item_Renderer.sprite = Resources.Load<Sprite>(bombpass);
                    break;
                //体力
                case 1:
                    Item_Renderer.sprite = Resources.Load<Sprite>(lifepass);
                    break;
                //はずれ
                case 2:
                    Item_Renderer.sprite = Resources.Load<Sprite>(hazurepass);
                    break;
                //千ポイント
                case 3:
                    Item_Renderer.sprite = Resources.Load<Sprite>(goldpass);
                    break;


            }
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(xspeed,0,0);
        }

        void OnGotten()
        {
            AudioSource.PlayClipAtPoint(openSE, Camera.main.transform.position);
            GetComponent<SpriteRenderer>().enabled = false;
            Item_Renderer.enabled = true;

            StartCoroutine("ItemEffect");
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                player = collider.gameObject.GetComponent<Player>();
                xspeed = 0;
                OnGotten();
            }
        }

        IEnumerator ItemEffect()
        {
            
            float time = 0;

            while (time < 1) {
                yield return new WaitForEndOfFrame();
                time += Time.deltaTime;
                Item_Renderer.gameObject.transform.position += new Vector3(0, 2, 0) * Time.deltaTime;
 
            }

            GameObject emergedEffect = Instantiate(effect, Item_Renderer.gameObject.transform.position, Quaternion.identity);

            switch (Item_num)
            {
                //爆弾
                case 0:

                    //敵を殲滅するスクリプト

                    emergedEffect.transform.FindChild("Text PS").GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(bombTextpass);
                    break;
                //体力
                case 1:

                    //体力を１回復

                    emergedEffect.transform.FindChild("Text PS").GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(lifeTextpass);
                    break;
                //はずれ
                case 2:

                    //１スコア増やす

                    emergedEffect.transform.FindChild("Text PS").GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(hazureTextpass);
                    break;
                //千ポイント
                case 3:

                    //1000スコア増やす

                    emergedEffect.transform.FindChild("Text PS").GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>(goldTextpass);
                    break;


            }

            AudioSource.PlayClipAtPoint(effectSE, Camera.main.transform.position);
            Destroy(emergedEffect, 1.5f);
            Destroy(this.gameObject);

        }
    }

}