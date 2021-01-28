using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colocarmuestras : MonoBehaviour
{
	public GameObject[] personajes;
	public GameObject[] botones;
	public GameObject[] screens;
	public GameObject disponible;
	public GameObject letrero;
	private GameObject aux;
	private int posicion;
    // Start is called before the first frame update

    public void actual(){
    	letrero.SetActive(false);
        posicion = PlayerPrefs.GetInt("Personajeactual", 0);
        Destroy(aux);
       	aux = Instantiate(personajes[posicion], this.transform.position, personajes[posicion].transform.rotation);
       	habili();
       	buttons(0);
    }

	private void buttons(int pos){
		for(int i = 0; i < 3; i++){
			if(pos == i){
				botones[i].SetActive(true);
			}else{
				botones[i].SetActive(false);
			}
		}
	}

	private void habili(){
		for(int i = 0; i < 10; i++){
			if(i == posicion){
				screens[i].SetActive(true);
			}else{
				screens[i].SetActive(false);
			}
		}
	}

	public void Seleccionar(){
		disponible.SendMessage("Seleccion", posicion);
		buttons(0);
	}

	public void Comprar(){
		int precio;
		int.TryParse(screens[posicion].tag, out precio);
		print(precio);
		PlayerPrefs.SetInt("PersoCom", posicion);
		disponible.SendMessage("Compra", precio);
		if(PlayerPrefs.GetInt("Compra", 1) == 0){
			print("No se pudo");
			letrero.SetActive(true);
		}else{
			buttons(1);
			print("Compraexitosa");
		}
	}

	public void quitar(){
		letrero.SetActive(false);
	}

	public void siguiente(){
		if(posicion < 9){
			posicion += 1;
			Destroy(aux);
			habili();
       		aux = Instantiate(personajes[posicion], this.transform.position, personajes[posicion].transform.rotation);
       		disponible.SendMessage("personajeDispo", posicion);
       		if(posicion == PlayerPrefs.GetInt("Personajeactual", 0)){
       			buttons(0);
       		}else if(PlayerPrefs.GetInt("disponible") == 1){
       			buttons(1);
       		}else{
       			buttons(2);
       		}
		}
	}

	public void Anterior(){
		if(posicion > 0){
			posicion -= 1;
			Destroy(aux);
			habili();
       		aux = Instantiate(personajes[posicion], this.transform.position, personajes[posicion].transform.rotation);
       		if(posicion == PlayerPrefs.GetInt("Personajeactual", 0)){
       			buttons(0);
       		}else if(PlayerPrefs.GetInt("disponible") == 1){
       			buttons(1);
       		}else{
       			buttons(2);
       		}
		}
	}

    void Start()
    {
    	/*letrero.SetActive(false);
        posicion = PlayerPrefs.GetInt("Personajeactual", 0);
       	aux = Instantiate(personajes[posicion], this.transform.position, personajes[posicion].transform.rotation);
       	habili();
       	buttons(0);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
