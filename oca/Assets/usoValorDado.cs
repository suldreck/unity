using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class usoValorDado : MonoBehaviour {

	// Use this for initialization
	void Start () {

        tirada = GameObject.FindObjectOfType<iBoton>();
    }
    
    iBoton tirada;
    // Update is called once per frame
    void Update () {
        GetComponent<Text>().text = "="+tirada;
        
	}
}
