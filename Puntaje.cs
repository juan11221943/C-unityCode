using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
	public GameObject titulo;
	public GameObject Moneda;
    public GameObject Alto;
	private float puntuacion;
	private int texto;
	private float contador;
	private int cada;
    private bool letrero = false;

	private void cambiar(){
		texto = (int)puntuacion;
		PlayerPrefs.SetInt("TotalScore", texto);
		this.GetComponent<UnityEngine.UI.Text>().text = texto.ToString();
	}
    // Start is called before the first frame update
    void Start()
    {
    	titulo.SetActive(false);
        Alto.SetActive(false);
        PlayerPrefs.SetInt("Nuevo", 0);
    	PlayerPrefs.SetFloat("Speed", -0.05f);
    	PlayerPrefs.SetFloat("Score", 0.2f);
    	PlayerPrefs.SetInt("Moneda", 0);
        puntuacion = PlayerPrefs.GetFloat("Score");
        contador = 100;
        cada = 3500;
        cambiar();
    }
    
    void Update(){
    	if(PlayerPrefs.GetFloat("Score") == 0){
    		titulo.SetActive(true);
    		titulo.GetComponent<UnityEngine.UI.Text>().text = texto.ToString();
    		int aux = PlayerPrefs.GetInt("Moneda");
    		Moneda.GetComponent<UnityEngine.UI.Text>().text = aux.ToString();
    	}
        if(PlayerPrefs.GetInt("Nuevo") == 1 && !letrero){
            Alto.SetActive(true);
            letrero = true;
            Alto.SendMessage("Mostrar");
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
    	
        puntuacion += PlayerPrefs.GetFloat("Score");
        cambiar();
        if(texto >= cada){
        	int aux = PlayerPrefs.GetInt("Moneda");
        	aux += 1;
        	cada += 1000;
        	PlayerPrefs.SetInt("Moneda", aux);
        }
        if(puntuacion >= contador){
        	float velocidad = PlayerPrefs.GetFloat("Speed");
        	velocidad += -0.00125f;
        	PlayerPrefs.SetFloat("Speed", velocidad);
        	contador += 100;
        }
    }
}
