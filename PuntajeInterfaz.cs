using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeInterfaz : MonoBehaviour
{
	public GameObject texto;
    // Start is called before the first frame update

	public void Ocultar(){
		gameObject.SetActive(false);
	}

    public void Mostrar(){
    	int punt = PlayerPrefs.GetInt("TotalScore");
        texto.GetComponent<UnityEngine.UI.Text>().text = punt.ToString();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
