using UnityEngine;
using System.Collections;

public class MoveGround2 : MonoBehaviour
{
	float speed = -0.05f;

	void FixedUpdate()
	{
        
        if (transform.localPosition.x > 2)
		{
			speed = -0.05f;

			if (gameObject.name == "en")
			{
				transform.localScale = new Vector3(-1, 1, 1);
			}
		}
		else if (transform.localPosition.x < -2)
		{
			speed = 0.05f;

			if (gameObject.name == "en")
			{
				transform.localScale = new Vector3(1, 1, 1);
			}
		}

		transform.localPosition = new Vector3(transform.localPosition.x + speed ,0,0);
	}
}
