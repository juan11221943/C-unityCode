using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
   	public GameObject[] plataformas;
	public GameObject inicio;
	private GameObject ultimo;
    // Start is called before the first frame update
    void Start()
    {
    	//Random.InitState(1);
    	Vector3 adicion = new Vector3(0,0,0);
        Vector3 posicion = new Vector3(0,0,0);
        float variacion = 0.0f;
        for(int i = 0; i < 3; i++){
        	ultimo = Instantiate(plataformas[0], inicio.transform.position + adicion, plataformas[0].transform.rotation);
			posicion = inicio.transform.position + adicion;
			float valorActual = plataformas[0].GetComponent<Renderer>().bounds.size.x / 2;
        	variacion += (plataformas[0].GetComponent<Renderer>().bounds.size.x / 2) + valorActual;
        	adicion = new Vector3(variacion, 0,0);
        }
        inicio.transform.position = posicion;
    }

    // Update is called once per frame
    void Update()
    {
        
        float posicionX = (ultimo.GetComponent<Renderer>().bounds.size.x / 2) + ultimo.transform.position.x;
        if(posicionX <= inicio.transform.position.x){
        	float valorActual = plataformas[0].GetComponent<Renderer>().bounds.size.x / 2;
        	Vector3 adicion = new Vector3(valorActual,0,0);
        	ultimo = Instantiate(plataformas[0], inicio.transform.position + adicion, plataformas[0].transform.rotation);
        	//inicio.transform.position += new Vector3(0,variacionY, 0);
        }
    }
}
