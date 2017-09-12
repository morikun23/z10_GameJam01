using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTest : MonoBehaviour {

    GameObject m_startMessageOrigin;

	// Use this for initialization
	void Start () {
        m_startMessageOrigin = Resources.Load<GameObject>("Prefabs/UI/StartMessage");

        StartCoroutine("Test");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Test()
    {
        GameObject startObj = Instantiate(m_startMessageOrigin, new Vector3(0 + Random.Range(-0.5f, 0.5f), 0 + Random.Range(-0.5f, 0.5f), 0), Quaternion.identity);
        startObj.SetActive(false);

        while (true)
        {
            

            yield return new WaitForSeconds(1f);

            startObj.SetActive(true);
            startObj.transform.position = new Vector3(0 + Random.Range(-0.5f, 0.5f), 0 + Random.Range(-0.5f, 0.5f), 0);

            yield return new WaitForSeconds(0.01f);

            startObj.transform.position = new Vector3(0 + Random.Range(-0.5f, 0.5f), 0 + Random.Range(-0.5f, 0.5f), 0);

            yield return new WaitForSeconds(0.01f);

            startObj.transform.position = new Vector3(0 + Random.Range(-0.5f, 0.5f), 0 + Random.Range(-0.5f, 0.5f), 0);

            yield return new WaitForSeconds(0.01f);

            startObj.transform.position = new Vector3(0 + Random.Range(-0.5f, 0.5f), 0 + Random.Range(-0.5f, 0.5f), 0);

            yield return new WaitForSeconds(0.01f);

            startObj.transform.position = new Vector3(0 + Random.Range(-0.5f, 0.5f), 0 + Random.Range(-0.5f, 0.5f), 0);

            yield return new WaitForSeconds(0.01f);

            startObj.transform.position = new Vector3(0 + Random.Range(-0.5f, 0.5f), 0 + Random.Range(-0.5f, 0.5f), 0);

            yield return new WaitForSeconds(0.01f);

            startObj.transform.position = Vector3.zero;

            yield return new WaitForSeconds(1.5f);

            break;

        }


        float moveSpeed = 0.3f;
        float decreaseTime = 0;

        SpriteRenderer upobj = startObj.transform.FindChild("MainStartMessage_up").GetComponent<SpriteRenderer>();
        SpriteRenderer downobj = startObj.transform.FindChild("MainStartMessage_down").GetComponent<SpriteRenderer>();


        while (true)
        {
            

            if (decreaseTime < moveSpeed - 0.1f) decreaseTime += 0.1f * Time.deltaTime;

            upobj.gameObject.transform.position += new Vector3(-moveSpeed + decreaseTime, 0, 0);
            downobj.gameObject.transform.position += new Vector3(moveSpeed - decreaseTime, 0, 0);

            upobj.color -= new Color(0,0,0,decreaseTime);
            downobj.color -= new Color(0, 0, 0, decreaseTime);

            if(upobj.color.a < 0)
            {
                startObj.SetActive(false);
                break;
            }

            yield return null;
        }

        Destroy(startObj);

        yield break;
    }

}
