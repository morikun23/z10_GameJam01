using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBreakTest : MonoBehaviour {

    public GameObject enemy;

    int max = 40;

    GameObject[] unkos = new GameObject[120];

    public GameObject effect;

    ParticleSystem effect_ps;

    public AudioClip sound;
    AudioSource audio;

    int cnt = 0;

    // Use this for initialization
    void Start() {

        audio = GetComponent<AudioSource>();
        effect_ps = effect.GetComponent<ParticleSystem>();

        for (int j = 0; j < 7; j++) {
            for (int i = 0; i < 14; i++)
            {
                unkos[cnt] = Instantiate(enemy, transform.position + new Vector3(i + 1, -j - 1, 0), Quaternion.identity);
                cnt++;
            }
        }

        cnt = 0;

    }
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio.PlayOneShot(sound,1);
            

            //放出量を上げる
            effect_ps.emission.SetBursts(new ParticleSystem.Burst[]{
                new ParticleSystem.Burst(0, 0),
                new ParticleSystem.Burst(0, (short)(5 + (cnt/4)))
            });
            GameObject eff = Instantiate(effect, unkos[cnt].transform.position, Quaternion.identity);
            Destroy(unkos[cnt]);
            Destroy(eff,3);


            cnt++;
        }

	}
}
