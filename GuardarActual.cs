using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarActual : MonoBehaviour
{

	public GameObject guardado;
	private bool fin = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetFloat("Score") == 0 && !fin){
        	fin = true;
        	guardado.SendMessage("Guardar");
        }
    }
}
