using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelmanager : MonoBehaviour
{
	public GameObject[] imagenes;
	public GameObject[] botones;
	public GameObject datos;
	public GameObject letrero;
	private int posi;

	void OnEnable(){
		letrero.SetActive(false);
		CambiarImagen(PlayerPrefs.GetInt("MundoActual", 0));
	}

	public void Seleccionar(){
		PlayerPrefs.SetInt("MundoActual", posi);
	}

	public void Derecha(){
		posi += 1;
		if(posi < imagenes.Length){
			CambiarImagen(posi);
		}else{
			posi -= 1;
		}
	}

	public void Izquierda(){
		posi -= 1;
		if(posi >= 0){
			CambiarImagen(posi);
		}else{
			posi += 1;
		}
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

	public void Comprar(){
		int precio;
		int.TryParse(imagenes[posi].tag, out precio);
		print(precio);
		PlayerPrefs.SetInt("MundoAcom", posi);
		datos.SendMessage("ComprarMundo", precio);
		if(PlayerPrefs.GetInt("Sepudo", 0) == 1){
			buttons(1);
		}else{
			letrero.SetActive(true);
		}
	}

	public void quitarLetrero(){
		letrero.SetActive(false);
	}

	public void CambiarImagen(int posicion){
		posi = posicion;
		for(int i = 0; i < imagenes.Length; i++){
			if(i == posicion){
				imagenes[i].SetActive(true);
				if(PlayerPrefs.GetInt("MundoActual", 0) == posicion){
					buttons(0);
				}else{
					datos.SendMessage("Mundodispo", i);
					if(PlayerPrefs.GetInt("Dispo", 0) == 1){
						buttons(1);
					}else{
						buttons(2);
					}
				}
			}else{
				imagenes[i].SetActive(false);
			}
		}
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
