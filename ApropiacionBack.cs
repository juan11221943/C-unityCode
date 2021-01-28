using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApropiacionBack : MonoBehaviour
{
	private GameObject[] fondos;
    // Start is called before the first frame update
    void Start()
    {
        if (fondos == null)
            fondos = GameObject.FindGameObjectsWithTag("Fondo");

        foreach (GameObject fondo in fondos)
        {
            fondo.transform.SetParent(this.transform);
        }
    }

}
