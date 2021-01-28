using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muestras : MonoBehaviour
{
	public Animator animacion;

	void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "plataforma"){
        		animacion.Play("IDLE", 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
