using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
	private float largo;
	public GameObject[] obstaculos;
	private GameObject actual;
    // Start is called before the first frame update
    void Start()
    {
        largo = this.GetComponent<Renderer>().bounds.size.x;
        float adicion = largo * 0.15f;
        largo = largo * 0.7f;
        int cantidad = Random.Range(1, 4);
        float espacios = largo / cantidad;
        float posicion_inicialX = this.transform.position.x - (this.GetComponent<Renderer>().bounds.size.x/2);
        float posicion_inicialY = (this.GetComponent<Renderer>().bounds.size.y/2);
        for(int i = 0; i < cantidad; i++){
        	int posicion = Random.Range(0, obstaculos.Length);
        	float alto = obstaculos[posicion].GetComponent<Renderer>().bounds.size.y/2;
        	float posX = Random.Range(espacios*i, espacios * (i+1));
        	posX += posicion_inicialX;
        	float posY = posicion_inicialY + alto + this.transform.position.y;
        	Vector3 pos =  new Vector3(posX + adicion, posY, this.transform.position.z);
        	actual =  Instantiate(obstaculos[posicion], pos, obstaculos[posicion].transform.rotation);
        	actual.transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
