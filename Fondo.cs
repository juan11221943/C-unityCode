using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
	public GameObject[] fondos;
	private GameObject ultimo;
	private float posicionX = 0;
    // Start is called before the first frame update
    void Start()
    {
    	
     	for(int i = 0; i < 10; i++){
            ultimo = Instantiate(fondos[0], this.transform.position + new Vector3(posicionX,0,0), fondos[0].transform.rotation);
            ultimo.transform.SetParent(this.transform);
            posicionX += fondos[0].GetComponent<Renderer>().bounds.size.x / 2;
            //posicion = Random.Range(0, plataformas.Length);
            posicionX += fondos[0].GetComponent<Renderer>().bounds.size.x / 2;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if(posicionX >= ultimo.transform.position.x){
        	float posicionaux = posicionX;
        	posicionX = ultimo.transform.position.x;
        	posicionX += fondos[0].GetComponent<Renderer>().bounds.size.x / 2;
        	posicionX += fondos[0].GetComponent<Renderer>().bounds.size.x / 2;
        	ultimo = Instantiate(fondos[0], this.transform.position + new Vector3(posicionX,0,0), fondos[0].transform.rotation);
            ultimo.transform.SetParent(this.transform);
            posicionX = posicionaux;
        }
    }
}
