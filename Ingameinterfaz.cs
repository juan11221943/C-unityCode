using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class Ingameinterfaz : MonoBehaviour
{
	private InterstitialAd interstitialAd;
	public GameObject pausescreen;

	[SerializeField] private string interstitialID = "";

	private void MostrarInstertitial(){
        interstitialAd.Show();
        interstitialAd.Destroy();
        PedirInterstitial();
    }

	private void PedirInterstitial(){
        interstitialAd = new InterstitialAd(interstitialID);
        AdRequest pedir = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(pedir);
    }

    public void Reload(){
    	Scene scene = SceneManager.GetActiveScene();
    	MostrarInstertitial();
    	SceneManager.LoadScene(scene.name);
    	 
    }

    public void iraMenu(){
    	MostrarInstertitial();
    	SceneManager.LoadScene("Menu");
    }

    public void Pause(){
        Time.timeScale = 0;
        pausescreen.SetActive(true);

    }

    public void Continue(){
        Time.timeScale = 1;
        pausescreen.SetActive(false);

    }

    private void Awake(){
        MobileAds.Initialize(initStatus => { });
        interstitialID = "ca-app-pub-7961161801463155/9683207308";
    }

     void Start()
    {
    	PedirInterstitial();
    	pausescreen.SetActive(false);
        
    }
}
