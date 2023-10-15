using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supground : MonoBehaviour {
    public GameObject ground;
    public GameObject player;

    public float maxSpeed;
    public float maxJump;
    public float magnutide;
    GameManager Gmanager;

    public AudioClip jumpSound;
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
                ground.transform.position = new Vector3(Random.Range(-3.5f, 3.51f), ground.transform.position.y + Random.Range(20f, 25f), 0);
            }
        }
    }
   
    void OnTriggerEnter2D(Collider2D pley)
    {
        if (pley.tag == "Player")
        {
            if (pley.GetComponent<Rigidbody2D>().velocity.magnitude < magnutide)
            {
                pley.GetComponent<Rigidbody2D>().AddForce(Vector2.up * maxJump * 3f);
                GetComponent<AudioSource>().clip = jumpSound;
                GetComponent<AudioSource>().Play();
                //pley.GetComponent<Animation>().Play("Jump");
            }
        }
    }
}
