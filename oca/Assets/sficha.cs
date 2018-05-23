using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sficha : MonoBehaviour {

	// Use this for initialization
	void Start () {
        dado = GameObject.FindObjectOfType<iBoton>();
	}
    iBoton dado;
    public Casilla casillaInicio;
    Casilla casillaActual;
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseUp()
    {//ToDo,  asegurrse de que objeto ui, se esta pulsando, en este caso
        //deberia ser la ficha solamente.
        Debug.Log("click");
        int espaciosParaMover = dado.valorDado;
        Casilla casillaFinal = casillaActual;
        for (int i = 0; i < espaciosParaMover; i++)
        {
            if (casillaActual == null)
            {
                casillaFinal = casillaActual;
            }
            else
            {
                casillaFinal = casillaActual.siguiente[0];//como si fuera un iterador
            }
        }
       
       
    }
}
