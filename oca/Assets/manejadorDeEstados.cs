using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manejadorDeEstados : MonoBehaviour {
    public bool dadoPulsado = false;//estado estado del dado que activara luego las acciones derivadas 
    public int valorDado;
    public bool fichaTocada = false;
    public bool animacion = false;
    public void nuevoTurno()
    {
        dadoPulsado =  false;
        fichaTocada =  false;
        animacion = false; 
        //nuevo jugador
    }
    //public enum Estados {reposo,esperando_click,EnAnimacion,Efecto_de_casilla};
    //public Estados estadoActual;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
