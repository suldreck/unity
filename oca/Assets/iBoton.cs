using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class iBoton : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        vector = new int[4];
        valorDado = 0;
}
    public Sprite[] imagenes0;
    public bool dadoPulsado = false;//estado estado del dado que activara luego las acciones derivadas 
    public int valorDado;
    public void turnoSiguenteJugador()
    {

    }
    public string prueba = "";
    // Update is called once per frame
    void Update()
    {
        dadoPulsado = false;
    }
    public int[] vector;
    public int total;
   
    

    public void fAleatorio()
    {
         valorDado = Random.Range(0, imagenes0.Length);
        Debug.Log("el valor del dado es: " + valorDado);
        this.transform.GetChild(0).GetComponent<Image>().sprite = imagenes0[valorDado];
        this.dadoPulsado = true;//hemos tirado el dado

     
    }
}
