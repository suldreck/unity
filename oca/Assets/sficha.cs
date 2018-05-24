using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sficha : MonoBehaviour {

	// Use this for initialization
	void Start () {
        dado = GameObject.FindObjectOfType<iBoton>();

    }
     iBoton  dado;
    public Casilla casillaInicio;
    Casilla casillaActual;
	// Update is called once per frame
	void Update () {
        
    }
     void OnMouseUp()
    {//ToDo,  asegurrse de que objeto ui, se esta pulsando, en este caso
     //deberia ser la ficha solamente.
     
       
        int espaciosParaMover = dado.valorDado;
        //Debug.Log("valor dado:  " + espaciosParaMover);
        //Casilla casillaFinal = casillaActual;
        //float extraAltura = (this.transform.localScale.y) / 2;
     
       
       
        
    //    // Debug.Log("la casilla siguiente " + casillaFinal.transform.position);// si es nullo
    //    for (int i = 0; i < espaciosParaMover; i++)
    //    {
    //        //Debug.Log("dentro del for");//se q entro en el for
    //        if (casillaFinal == null)
    //        {//*********recordar que cuando llegue a la 63, no tiene q ir a la casilla de inicio sino hacia atras.
    //            casillaFinal = casillaInicio;
               
    //        }
    //        else
    //        {
    //            casillaFinal = casillaFinal.siguiente[0];//como si fuera un iterador
    //                                                     //creo q no necesita ser un array,
    //                                              // por q solo puede ir a una casilla
              
    //        }
    //    }
    //    if (casillaFinal == null)
    //    {
    //        return;
    //    }

        
    //    this.transform.position = casillaFinal.transform.position;//revisar por q no entiend
    //    this.transform.position = this.transform.position + Vector3.up * extraAltura;//se modifica aqui con vector3.up
    //    casillaActual = casillaFinal;
    }
}
