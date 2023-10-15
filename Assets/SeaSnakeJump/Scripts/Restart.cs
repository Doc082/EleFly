using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;
public class Restart : MonoBehaviour 
{
    public string placementId = "LevelComplete";
    void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
            ShowAd();
            Time.timeScale = 0;
			SceneManager.LoadScene(1);
		}
	}
    public void ShowAd()
    {
        StartCoroutine(ShowAdWhenReady());
    }

    private IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show();
        }
    }
}
