using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public int Score = 0;
	int Record;
    //	GameObject[] ground;
    public GameObject idle;
    public GameObject dead;
	public bool isDead;
    //public AudioClip dieDD;
	public TextMesh Scoretxt;
    bool cicleSound = true;

    
	/*void OnTriggerEnter2D(Collider2D other)
	{
		if (!isDead)
		{
			switch (other.tag)
			{
			case "Ground":
                 other.transform.position = new Vector3(Random.Range(-3.5f,3.51f),other.transform.position.y + 15f,0);			
				Score++;
				break;

			case "Ground2":
				GameObject.Find("Ground2").transform.position = new Vector3(Random.Range(-3f,3f),GameObject.Find("Ground2").transform.position.y + Random.Range(20f,30f) ,0);
				break;

			case "Ground3":
                    GameObject.Find("Ground3").transform.position = new Vector3(Random.Range(-3.5f,3.51f),other.transform.position.y + Random.Range(20f,25f),0);			
				break;

			case "Enemy":
				GameObject.Find("Enemy").transform.position = new Vector3(Random.Range(-3f,3f),GameObject.Find("Enemy").transform.position.y + Random.Range(12f,15f) ,0);
				break;
			}
		}
//			if (Score % 10 == 0 && Score < 200 && Score > 9)
//			{
//				foreach(GameObject go in ground)
//				{
//					go.transform.localScale = new Vector3(other.transform.localScale.x - 0.1f ,0.5f,1f);
//				}
//			}

//		case "Coin":
//			other.collider2D.enabled = false;
//			other.animation.Play("Coin");
//			break;
	}*/

	GameObject target;

	void Awake()
	{
		Time.timeScale = 0;
	}

	void Start ()
	{
		Camera.main.aspect = 2/3f;
		Time.timeScale = 0;
		isDead = false;
		target = GameObject.FindWithTag ("Player");

//		Ground = GameObject.FindGameObjectsWithTag ("Ground");

		Record = PlayerPrefs.GetInt ("Record", 0);
		Scoretxt.text = "Score : " + Score + '\n' + "Record : " + Record;
	}
	
	void FixedUpdate ()
	{
        if (isDead)
        {
            idle.SetActive(false);
            dead.SetActive(true);
        }
        else
        {
            idle.SetActive(true);
            dead.SetActive(false);
        }
        if (!isDead)
		{
			if (target.GetComponent<Rigidbody2D>().velocity.y > -5.5f)
			{
				transform.position = new Vector3 (0, target.transform.position.y + 1f, -10f);
				Scoretxt.text = "Score : " + Score + '\n' + "Record : " + Record;
			}
			else
			{
				isDead = true;
			}
		}
		else
		{
            //if (cicleSound)
            //{
                Camera.main.GetComponent<CameraShake>().Shake();
                //GetComponent<AudioSource>().clip = dieDD;
                //GetComponent<AudioSource>().Play();
              //  cicleSound = false;
            //}
            StartCoroutine(f_time());
			//GameOver();
		}
	}

    private IEnumerator f_time()
    {
        
        yield return new WaitForSeconds(3);
        Destroy(this.GetComponent<GameManager>());
		Destroy(target.gameObject,2f);
        cicleSound = true;
		
        GameOver();
    }
	public GameObject Restart;
	public GameObject NewRecord;
    //public GameObject player;

	public void GameOver()
	{
		Restart.SetActive (true);

		if (Record < Score)
		{
			NewRecord.SetActive(true);
			PlayerPrefs.SetInt("Record", Score);

			Scoretxt.text = "Score : " + Score + '\n' + "Record : " + Score;
		}
	}
    GameObject player;
	void Update()
	{
       
       
        player = GameObject.Find("Snake");
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
        if (Input.GetMouseButton(0))
        {
            // Inserisco la posizione del mouse sul mondo di gioco in una variabile
            Vector3 PosizioneToccoMouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

            // Imposto una variabile per la velocità
            float Velocita = 25f * Time.deltaTime;

            // Muovo l'oggetto dello script verso la posizione del mouse toccata sullo schermo
            if(player.transform.position.x < PosizioneToccoMouse.x) player.transform.localScale = new Vector3(-1, 1, 1);
            else player.transform.localScale = new Vector3(1, 1, 1);
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(PosizioneToccoMouse.x, player.transform.position.y, 0), Velocita);
        }
    }

}