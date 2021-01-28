using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicmenu : MonoBehaviour
{

	public AudioSource Menutheme;
    // Start is called before the first frame update
    void Start()
    {
        float musica = PlayerPrefs.GetFloat("VolumenMusica", 1.0f);
        Menutheme.Play(0);
        Menutheme.volume = musica;
    }

    // Update is called once per frame
    void Update()
    {
        float musica = PlayerPrefs.GetFloat("VolumenMusica", 1.0f);
 		Menutheme.volume = musica;
    }
}
