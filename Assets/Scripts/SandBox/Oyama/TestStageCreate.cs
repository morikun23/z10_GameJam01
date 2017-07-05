using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStageCreate : MonoBehaviour {

    public GameObject normal, hasira, kakejiku;

    int[,] stageArray = { { 0, 2, 1, 0, 0, 1, 0, 0, 1},
                          { 0, 1, 0, 1, 0, 2, 0, 1, 0},
                          { 1, 0, 1, 0, 0, 1, 0, 0, 1}};

    float startPosX = -9;
    float startPosY = 4.5f;


	// Use this for initialization
	void Start () {
		for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 9; j++)
            {

                if(stageArray[i,j] == 0)
                {
                    Instantiate(normal, new Vector3((startPosX + j * 2), (startPosY - i * 3), 0), Quaternion.identity);
                }
                if (stageArray[i, j] == 1)
                {
                    Instantiate(hasira, new Vector3((startPosX + j * 2), (startPosY - i * 3), 0), Quaternion.identity);
                }
                if (stageArray[i, j] == 2)
                {
                    Instantiate(kakejiku, new Vector3((startPosX + j * 2), (startPosY - i * 3), 0), Quaternion.identity);
                }

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
