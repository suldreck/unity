using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class iBoton : MonoBehaviour {
    public int[] vector;
    public int total;
    public manejadorDeEstados dado;
    // Use this for initialization
    void Start()
    {
        dado= GameObject.FindObjectOfType<manejadorDeEstados>();
        vector = new int[4];
        dado.valorDado = 0;
}
    public Sprite[] imagenes0;
    //public bool dadoPulsado = false;//estado estado del dado que activara luego las acciones derivadas 
    //public int valorDado;
    public void turnoSiguenteJugador()
    {
        dado.dadoPulsado = false;
    }
    public string prueba = "";
    // Update is called once per frame
    void Update()
    {
        //dadoPulsado = false;//no se que hace aqui
    }
    
   
    

    public void fAleatorio()
    {
         dado.valorDado = Random.Range(0, imagenes0.Length);
       
        this.transform.GetChild(0).GetComponent<Image>().sprite = imagenes0[dado.valorDado];
        this.dado.dadoPulsado = true;//hemos tirado el dado

     
    }
}
