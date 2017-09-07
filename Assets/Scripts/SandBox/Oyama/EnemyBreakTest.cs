using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBreakTest : MonoBehaviour {

    public GameObject enemy;

    int max = 40;

    // Use this for initialization
    void Start() {

        for (int j = 0; j < 6; j++) {
            for (int i = 0; i < 10; i++)
            {
                

                Instantiate(enemy, transform.position + new Vector3(i + 1, -j - 1, 0), Quaternion.identity);
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
