using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	private float Xinicial;
	private bool iniciar = false;
	private float Yinicial;
	private GameObject overscreen;

	private void terminado(){
		overscreen.SetActive(true);
    	Time.timeScale = 0;
    	 PlayerPrefs.SetFloat("Speed", 0);
         PlayerPrefs.SetFloat("Score", 0);
         /*if(!guardo){
              GameData data = new GameData(0, 0, 0);
              print(data.score);
              data.Prueba();
              guardo = true;
          }*/
	}
	void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "plataforma"){
        	iniciar = false;
        	Yinicial = this.transform.position.y;
        }
    }
	void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "plataforma"){
        	iniciar = true;
        	
        }
        	
    }
    // Start is called before the first frame update
    void Start()
    {
        Xinicial = this.transform.position.x;
        Yinicial = this.transform.position.y;
        overscreen = GameObject.FindWithTag("over");
        overscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    	if(iniciar){
    		if(Yinicial - 4 >= this.transform.position.y){
    			terminado();
    			
    		}
    	}
        if(Xinicial - 1 >= this.transform.position.x){
        	terminado();
        }
    }
}
