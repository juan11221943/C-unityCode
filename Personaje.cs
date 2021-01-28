using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
	public Rigidbody jugador;
	public float fuerza = 0.0f;
	public Animator animacion;
	private bool saltando = false;
	private bool cayendo = false;
	private bool deslizando = false;
	private float contadorDes = 0.0f;
	private float efecto;
	public AudioSource salto;
	public AudioSource slide;
	public AudioSource caja;
	public AudioSource cancion1;
	public AudioSource cancion2;

	void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "plataforma"){
        	if(deslizando){
        		animacion.Play("Slide", 0);
        	}else{
	        	animacion.Play("RUN", 0);
	        	}
	        saltando = false;
	    	cayendo = false;
        }
        if(collision.gameObject.tag == "Caja"){
        	if(deslizando){
        		caja.volume = efecto;
        		caja.Play(0);
        		collision.gameObject.SendMessage("Destruir");
        		Destroy(collision.gameObject);	      
        	}  	
        }
        
    }

	void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "plataforma"){
        	if(!saltando){
        		animacion.Play("Falling", 0);
        	}
        	cayendo = true;
        }
    }

	public void Salto(){
		if(!saltando && !cayendo){
			if(deslizando == true){
				deslizando = false;
			}
			salto.volume = efecto;
			salto.Play(0);
			animacion.Play("Jump", 0);
			jugador.AddForce(jugador.transform.up * fuerza);
			saltando = true;
		}
	}

	public void deslizar(){
		deslizando = true;
		contadorDes = 0.6f;
		slide.volume = efecto;
		slide.Play(0);
		if(saltando || cayendo){
			jugador.AddForce(jugador.transform.up * -fuerza * 1.3f);
		}else{
			animacion.Play("Slide", 0);
		}
	}
    // Start is called before the first frame update
    void Start()
    {
    	animacion.Play("Falling", 0);
    	float musica = PlayerPrefs.GetFloat("VolumenMusica", 1.0f);
    	efecto = PlayerPrefs.GetFloat("VolumenEfecto", 1.0f);
    	int cual = Random.Range(0, 2);
    	if(cual == 1){
    		cancion1.Play(0);
    		cancion1.volume = musica;
    	}else{
    		cancion2.Play(0); 
    		cancion2.volume = musica;
    	}
    }

    // Update is called once per frame
    void Update()
    {
        if(deslizando){
        	contadorDes -=  Time.deltaTime;
        	if(contadorDes <= 0 && !cayendo){
	        	animacion.Play("RUN", 0);
	        	deslizando = false;
	        }
        }
        
    }
}
