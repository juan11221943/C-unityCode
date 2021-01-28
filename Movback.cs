using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float velocidad = -0.01f;
        this.transform.position += new Vector3(velocidad, 0, 0);
        if(this.transform.position.x <= -100f){
        	Destroy(gameObject);
        }
    }
}
