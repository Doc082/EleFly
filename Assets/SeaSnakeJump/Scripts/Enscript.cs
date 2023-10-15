using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enscript : MonoBehaviour {
    public GameObject ground;
    public GameObject player;
    GameManager dead;
    public AudioClip dieDan;
    // Use this for initialization
    void Start () {
		dead = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!dead.isDead)
        {
            float plDistance =
                GameObject.Find("Snake").transform.position.y - ground.transform.position.y;
            if (plDistance > 10)
            {
                ground.transform.position = new Vector3(Random.Range(-3f, 3f), ground.transform.position.y + Random.Range(12f, 15f), 0);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D ene)
    {
        if (ene.tag == "Player")
        {
            
            dead.isDead = true;
        }
    
    }
}
