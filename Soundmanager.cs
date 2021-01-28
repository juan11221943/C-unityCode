using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
	public GameObject Sound;
	public GameObject Mute;
	/*float musica = PlayerPrefs.GetFloat("VolumenMusica", 1.0f);
    	efecto = PlayerPrefs.GetFloat("VolumenEfecto", 1.0f);
    	*/
    public void cambiar(){
    	float sonido = PlayerPrefs.GetFloat("VolumenMusica", 1.0f);
    	if(sonido >= 1.0f){
    		PlayerPrefs.SetFloat("VolumenEfecto", 0);
    		PlayerPrefs.SetFloat("VolumenMusica", 0);
    		Sound.SetActive(false);
    		Mute.SetActive(true);
    	}else{
    		PlayerPrefs.SetFloat("VolumenEfecto", 1.0f);
    		PlayerPrefs.SetFloat("VolumenMusica", 1.0f);
    		Sound.SetActive(true);
    		Mute.SetActive(false);
    	}
    }
    // Start is called before the first frame update
    void Start()
    {
        float sonido = PlayerPrefs.GetFloat("VolumenMusica", 1.0f);
        if(sonido >= 1.0f){
    		Sound.SetActive(true);
    		Mute.SetActive(false);
    	}else{
    		Sound.SetActive(false);
    		Mute.SetActive(true);
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
