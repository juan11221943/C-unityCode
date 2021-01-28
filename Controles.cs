using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controles : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private float posicionY;
	private GameObject jugador;
	private bool Existe = false;

	public void OnPointerDown (PointerEventData eventData) 
	{
		posicionY = eventData.position.y;
	}

	public void OnPointerUp (PointerEventData eventData) 
	{
		if(posicionY < eventData.position.y){
			if(Existe){
				jugador.SendMessage("Salto");
			}
		}else if(posicionY > eventData.position.y){
			if(Existe){
				jugador.SendMessage("deslizar");
			}
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
        if(jugador != null){
        	Existe = true;
        }else{
        	Existe = false;
        }
        }
    }
}
