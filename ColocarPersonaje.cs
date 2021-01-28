using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarPersonaje : MonoBehaviour
{
	public GameObject[] personajes;

    // Start is called before the first frame update
    void Start()
    {
       	int posicion = PlayerPrefs.GetInt("Personajeactual", 0);
       	Instantiate(personajes[posicion], this.transform.position, personajes[posicion].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
