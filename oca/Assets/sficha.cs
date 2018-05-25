using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sficha : MonoBehaviour {

	// Use this for initialization
	void Start () {
        dado = GameObject.FindObjectOfType<iBoton>();
        posicionObj = this.transform.position;
    }
    iBoton  dado;

    public Casilla casillaInicio;
    Casilla casillaActual;
    
    Vector3 posicionObj;
    Vector3 velocidad = Vector3.zero;
    float camaraLenta = 1f;
    // Update is called once per frame
    void Update()
    {
        

        if (this.transform.position != posicionObj)
        {   
            Debug.Log("valor de y" + casillaInicio.transform.localScale.y);
            float extraAltura = ((this.transform.localScale.y + casillaInicio.transform.localScale.y) / 2) -5;
            Debug.Log("valor de y local" + this.transform.localScale.y);
            Vector3 altura= new Vector3(0, extraAltura, 0);
            this.transform.position = Vector3.SmoothDamp(this.transform.position , posicionObj+altura , ref velocidad, camaraLenta);
        }

    }
    void DameUnaNuevaPosicionObj(Vector3 pos)
    {
        posicionObj = pos;
        velocidad = Vector3.zero;
    }
     void OnMouseUp()
    {//ToDo,  asegurrse de que objeto ui, se esta pulsando, en este caso
     //deberia ser la ficha solamente.
     
       
        int espaciosParaMover = dado.valorDado+1;
       // Debug.Log("valor dado:  " + espaciosParaMover);
        Casilla casillaFinal = casillaActual;
       

        //    // Debug.Log("la casilla siguiente " + casillaFinal.transform.position);// si es nullo
        for (int i = 0; i < espaciosParaMover; i++)
        {
            Debug.Log("dentro del for");//se q entro en el for
            if (casillaFinal == null)
            {//*********recordar que cuando llegue a la 63, no tiene q ir a la casilla de inicio sino hacia atras.
                casillaFinal = casillaInicio;

            }
            else
            {
                casillaFinal = casillaFinal.siguiente[0];//como si fuera un iterador
                                                         //creo q no necesita ser un array,
                                                         // por q solo puede ir a una casilla

            }
        }
        if (casillaFinal == null)
        {
            return;
        }
        else
        {
            
            // this.transform.position = casillaFinal.transform.position;//revisar por q no entiend
            //Debug.Log(this.transform.position);
           
            DameUnaNuevaPosicionObj(casillaFinal.transform.position);
 
            //Debug.Log(this.transform.position);
          
            casillaActual = casillaFinal;
        }

    
    }
}
