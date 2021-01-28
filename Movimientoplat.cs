using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientoplat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	Time.timeScale = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float velocidad = PlayerPrefs.GetFloat("Speed", -0.05f);
        this.transform.position += new Vector3(velocidad, 0, 0);
        if(this.transform.position.x <= -20f){
        	Destroy(gameObject);
        }
    }
}
