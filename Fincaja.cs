using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fincaja : MonoBehaviour
{
	public Rigidbody caras;
	private GameObject monedas;

	public void Destruir()
    {
        for(int i = 0; i < 3; i++)
    		{
    			Rigidbody instantiatedProjectile = Instantiate(caras, this.transform.position,transform.rotation)as Rigidbody;
    		    Destroy(instantiatedProjectile.gameObject, 3);
    		    instantiatedProjectile.velocity = this.transform.up * 5f;
    		}
    	monedas = GameObject.FindWithTag("Monedas");
    	monedas.SendMessage("añadir");
    } 
    
}
