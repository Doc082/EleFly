using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float maxSpeed;
	public float maxJump;
	public float magnutide;

	public GameManager gm;

	public AudioClip[] jumpSound;

	void OnTriggerEnter2D(Collider2D other)
	{	
		if (!gm.isDead)
		{
			//switch (other.tag)
			//{
			//case "Ground 1":
				if(GetComponent<Rigidbody2D>().velocity.magnitude < magnutide)
				{
					GetComponent<Rigidbody2D>().AddForce(Vector2.up * maxJump);
					GetComponent<AudioSource>().clip = jumpSound[0];
				    GetComponent<AudioSource>().Play();
					GetComponent<Animation>().Play("Jump");
				}
				//break;

			/*case "Groundgrey":
				if(GetComponent<Rigidbody2D>().velocity.magnitude < magnutide)
				{
					GetComponent<Rigidbody2D>().AddForce(Vector2.up * maxJump);
					GetComponent<AudioSource>().clip = jumpSound[1];
					//GetComponent<AudioSource>().Play();
					GetComponent<Animation>().Play("Jump");
				}
				break;

			/*case "Groundsuper":
				if(GetComponent<Rigidbody2D>().velocity.magnitude < magnutide)
				{
					GetComponent<Rigidbody2D>().AddForce(Vector2.up * maxJump * 3f);
				GetComponent<AudioSource>().clip = jumpSound[2];
					GetComponent<AudioSource>().Play();
					GetComponent<Animation>().Play("Jump");
				}
				break;

			//case "Enemy":
              //      gm.isDead = true;
               //     break;*/
			//}
		}

//		case "Coin":
//			other.collider2D.enabled = false;
//			other.animation.Play("Coin");
//			break;
	}
	
	void Update () 
	{
		if (!gm.isDead)
		{
	#if UNITY_EDITOR
			transform.Translate(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0 ,0);
	#elif UNITY_ANDROID
			transform.Translate(Input.acceleration.x * maxSpeed * Time.deltaTime, 0 ,0);
	#endif

			if (transform.position.x < -5f)
			{
				transform.position = new Vector3(5f, transform.position.y, transform.position.z);
			}
			else if (transform.position.x > 5f)
			{
				transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
			}
		}
	}
}
