using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelgenerator : MonoBehaviour
{
	public GameObject[] plataformas;
	public GameObject inicio;
	private int tamanoArr;
	private GameObject ultimo;
    // Start is called before the first frame update
    void Start()
    {
    	//Random.InitState(1);
    	Vector3 adicion = new Vector3(0,0,0);
        tamanoArr = plataformas.Length;
        float variacion = 0;
        int objeto = 0;
        Vector3 posicion = new Vector3(0,0,0);
        float variacionY = 0.0f;
        for(int i = 0; i < 5; i++){
        	ultimo = Instantiate(plataformas[objeto], inicio.transform.position + adicion, plataformas[objeto].transform.rotation);
			posicion = inicio.transform.position + adicion;
			float valorActual = plataformas[objeto].GetComponent<Renderer>().bounds.size.x / 2;
			objeto = Random.Range(1, tamanoArr);

        	variacion += Random.Range(1f, 2f) + (plataformas[objeto].GetComponent<Renderer>().bounds.size.x / 2) + valorActual;
        	variacionY += Random.Range(-1.5f, 1.5f);
        	adicion = new Vector3(variacion, variacionY,0);
        }
        inicio.transform.position = posicion;
    }

    // Update is called once per frame
    void Update()
    {
        
        float posicionX = (ultimo.GetComponent<Renderer>().bounds.size.x / 2) + ultimo.transform.position.x;
        if(posicionX <= inicio.transform.position.x){
        	float variacionY = Random.Range(-1.5f, 1.5f);
        	int objeto = Random.Range(1, tamanoArr);
        	float variacion = Random.Range(1f, 2f);
        	float valorActual = plataformas[objeto].GetComponent<Renderer>().bounds.size.x / 2;
        	Vector3 adicion = new Vector3(variacion + valorActual,variacionY,0);
        	ultimo = Instantiate(plataformas[objeto], inicio.transform.position + adicion, plataformas[objeto].transform.rotation);
        	inicio.transform.position += new Vector3(0,variacionY, 0);
        }
    }
}
