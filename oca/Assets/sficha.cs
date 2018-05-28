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
    public Casilla [] camino;
    public int caminoIndice;




    public Vector3 posicionObj;
    Vector3 velocidad = Vector3.zero;
    float camaraLenta = 1f;
    float distanciaFichas = 20f;

    // Update is called once per frame
    void Update()
    {
        float extraAltura = ((this.transform.localScale.y + casillaInicio.transform.localScale.y) / 2) - 5;

        Vector3 altura = new Vector3(0, extraAltura, 0);
        //Debug.Log( " update fuera if caminoIndice " + caminoIndice+" longitud: "+ camino.Length);
        float distancia = Vector3.Distance(this.transform.position, posicionObj);
        Debug.Log("distancia:  " + distancia);
       if (distancia>distanciaFichas)
        {           


            this.transform.position = Vector3.SmoothDamp(this.transform.position, posicionObj + altura, ref velocidad, camaraLenta);
        }
        else
        {
        //seguir el camino con la ficha
         if (  camino !=null      )
       // while (camino != null && caminoIndice < camino.Length)
        {
                Debug.Log("entra en el if de camino null");
                if (caminoIndice < camino.Length)
                {
                    Debug.Log("longitud del camino " + camino.Length + " caminoIndice " + caminoIndice);
                    DameUnaNuevaPosicionObj(camino[caminoIndice].transform.position);
                    //Debug.Log("camino  " + camino[caminoIndice].ToString());
                    //Debug.Log("posicion objeto " + this.transform.position.x);
                    //Debug.Log("posicion nueva " + posicionObj.x);         

                    caminoIndice++;
                }
        }
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
        camino = new Casilla[espaciosParaMover];
        if (espaciosParaMover == 0)
        {
            return;
        }

        //    // Debug.Log("la casilla siguiente " + casillaFinal.transform.position);// si es nullo
        for (int i = 0; i < espaciosParaMover; i++)
        {
          
            if (casillaFinal == null)
            {//*********recordar que cuando llegue a la 63, no tiene q ir a la casilla de inicio sino hacia atras.
                casillaFinal = casillaInicio;

            }
            else
            {
                if (casillaFinal.siguiente == null || casillaFinal.siguiente.Length == 0)
                {
                    Debug.Log("fin de la lista¿retornara?");

                    return;
                }/*
                //id del juegador
                else if(casillaFinal.siguiente.length > 1)
                {
                      casillaFinal = casillaFinal.siguiente[0];
                }
                else
                {
                      casillaFinal = casillaFinal.siguiente[0];
                }


                */
                casillaFinal = casillaFinal.siguiente[0];//como si fuera un iterador
                                                         //creo q no necesita ser un array,
                                                         // por q solo puede ir a una casilla

            }
            camino[i] = casillaFinal;//camino q seguira la ficha
        }
        if (casillaFinal == null)
        {
            return;
        }
        else
        {
            
            // this.transform.position = casillaFinal.transform.position;//revisar por q no entiend
            //Debug.Log(this.transform.position);
           
            //DameUnaNuevaPosicionObj(casillaFinal.transform.position);

            //Debug.Log(this.transform.position);
            caminoIndice = 0;
            casillaActual = casillaFinal;
        }

    
    }
}
