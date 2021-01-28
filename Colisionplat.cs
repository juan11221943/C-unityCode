using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisionplat : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "plataforma"){
        	Destroy(collision.gameObject);
        	print("destruido");
        }
    }
    /*private void OnTriggerEnter(Collider collision)
    {
    	if(collision.gameObject.tag == "plataforma"){
        	Destroy(collision.gameObject);
        	print("destruido");
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
