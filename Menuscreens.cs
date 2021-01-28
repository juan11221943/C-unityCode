using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscreens : MonoBehaviour
{
	public GameObject[] Menu;
	private int Nivel = 0;

 	public void IniciarNivel(){
 		Nivel = PlayerPrefs.GetInt("MundoActual", 0) + 1;
 		string nombre = "Nivel" + Nivel.ToString();
 		CambiarScreen(2);
 		SceneManager.LoadScene(nombre);
 	}

	public void CambiarScreen(int posicion){
		for(int i = 0; i < Menu.Length; i++){
			if(i == posicion){
				Menu[i].SetActive(true);
			}else{
				Menu[i].SetActive(false);
			}
		}
	}

    void Start()
    {
    	Time.timeScale = 1;
        CambiarScreen(0);
        Nivel = PlayerPrefs.GetInt("NivelActual", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
