using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmm : MonoBehaviour {
    public GameObject ground;
    public GameObject player;
    GameManager Gmanager;
	// Use this for initialization
	void Start () {
        Gmanager = GameObject.Find("Main Camera").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!Gmanager.isDead)
        {
            float plDistance =
                GameObject.Find("Snake").transform.position.y - ground.transform.position.y;
            if (plDistance > 10)
            {
                ground.transform.position = new Vector3(Random.Range(-3.5f, 3.51f), ground.transform.position.y + 15f, 0);
                Gmanager.Score++;
            }
        }
	}

    
}
