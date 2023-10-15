using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Monetization;

public class menu : MonoBehaviour {
    string gameId = "3141115";
    bool testMode = false;
    // Use this for initialization
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
    void Start () {
        Monetization.Initialize(gameId, testMode);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
