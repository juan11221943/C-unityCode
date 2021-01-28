using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Rotarpersonaje : MonoBehaviour, IDragHandler
{
	private GameObject jugador;
	private bool Existe = false;
	private float inicial;

	 public void OnBeginDrag(PointerEventData data)
    {
        //Debug.Log("OnBeginDrag: " + data.position.x);
        inicial = data.position.x;
    }

	 public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
        	if(inicial < data.position.x){
        		print("Derecha");
        		jugador.transform.Rotate(0, -8, 0);
        	}else if(inicial > data.position.x){
        		print("Izquierda");
        		jugador.transform.Rotate(0, 8, 0);
        	}
        	inicial = data.position.x;
           	//Debug.Log("Dragging:" + data.position.x);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindWithTag("Jugador");
        if(jugador != null){
        	Existe = true;
        }else{
        	Existe = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    	if(!Existe){
    	        jugador = GameObject.FindWithTag("Jugador");
    	    }
        if(jugador != null){
        	Existe = true;
        }else{
        	Existe = false;
        }
    }
}
