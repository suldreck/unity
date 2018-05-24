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
      
        Debug.Log(" ****posicion***" + this.transform.position);//para borrar
        //int espaciosParaMover = dado.valorDado;
        int espaciosParaMover = 2;//solo para testear
        Casilla casillaFinal = casillaActual;
       // Debug.Log("la casilla siguiente " + casillaFinal.transform.position);// si es nullo
        for (int i = 0; i < espaciosParaMover; i++)
        {
            //Debug.Log("dentro del for");//se q entro en el for
            if (casillaFinal == null)
            {//*********recordar que cuando llegue a la 63, no tiene q ir a la casilla de inicio sino hacia atras.
                casillaFinal = casillaInicio;
                Debug.Log("casilla final es nula");// si es nullo
            }
            else
            {
                casillaFinal = casillaFinal.siguiente[0];//como si fuera un iterador
                                                         //creo q no necesita ser un array,
                                                  // por q solo puede ir a una casilla
               // Debug.Log("la casilla siguiente "+ casillaFinal.transform.name);// si es nullo
            }
        }
        if (casillaFinal == null)
        {
            return;
        }

        
        this.transform.position = casillaFinal.transform.position;//revisar por q no entiendo
        Debug.Log(" ---->posicion cambio<-----" + this.transform.position);

        casillaActual = casillaFinal;
    }
}
