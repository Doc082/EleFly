using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
	void Update()
	{
        if (Input.GetMouseButton(0))
        {
			Time.timeScale = 1f;
			Destroy (this.gameObject);
		}
	}
}
