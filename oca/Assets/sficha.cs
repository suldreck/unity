using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sficha : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        dado = GameObject.FindObjectOfType<iBoton>();
        posicionObj = this.transform.position;

    }
    iBoton dado;

    public Casilla casillaInicio;
    Casilla casillaActual;
    public Casilla[] camino;
    public int caminoIndice;
    public Casilla casillaFinal;
    bool sw = false;


    public Vector3 posicionObj;
    Vector3 velocidad = Vector3.zero;
    float camaraLenta = 0.2f;
    float distanciaFichas = 20f;

    // Update is called once per frame
    void Update()
    {
        float extraAltura = ((this.transform.localScale.y + casillaInicio.transform.localScale.y) / 2) - 5;

        Vector3 altura = new Vector3(0, extraAltura, 0);
        //Debug.Log( " update fuera if caminoIndice " + caminoIndice+" longitud: "+ camino.Length);
        float distancia = Vector3.Distance(this.transform.position, posicionObj);
      
        if (distancia < distanciaFichas)
        {
            if (camino != null)

            {
              
                if (caminoIndice < camino.Length)
                {
                   
                    DameUnaNuevaPosicionObj(camino[caminoIndice].transform.position);

                    caminoIndice++;
                }
            }

        }


        this.transform.position = Vector3.SmoothDamp(this.transform.position, posicionObj + altura, ref velocidad, camaraLenta);
    }

    void DameUnaNuevaPosicionObj(Vector3 pos)
    {
        posicionObj = pos;
        velocidad = Vector3.zero;
    }

    void tirada()
    {
        


        int espaciosParaMover = dado.valorDado + 1;
        // Debug.Log("valor dado:  " + espaciosParaMover);
        casillaFinal = casillaActual;
        camino = new Casilla[espaciosParaMover];
        ruta(espaciosParaMover);
    }

    void ruta(int espaciosParaMover)
    {
        camino = new Casilla[espaciosParaMover];


        bool atrasSw = false;
        if (espaciosParaMover == 0)
        {
            return;
        }

        //    // Debug.Log("la casilla siguiente " + casillaFinal.transform.position);// si es nullo
        for (int i = 0; i < espaciosParaMover; i++)
        {

            if (casillaFinal == null && sw == false)
            {//*********recordar que cuando llegue a la 63, no tiene q ir a la casilla de inicio sino hacia atras.
                casillaFinal = casillaInicio;
                sw = true;

            }
            else
            {

                int longitud = casillaFinal.siguiente.Length;
                if (casillaFinal.siguiente[0] == null || atrasSw == true)
                {
                    casillaFinal = casillaFinal.atras[0];
                    atrasSw = true;
                }
                else
                {
                    casillaFinal = casillaFinal.siguiente[0];//como si fuera un iterador
                                                             //creo q no necesita ser un array,
                                                             // por q solo puede ir a una casilla
                }
            }
            camino[i] = casillaFinal;//camino q seguira la ficha
        }
        if (casillaFinal == null)
        {
            return;
        }
        else
        {


            caminoIndice = 0;
            casillaActual = casillaFinal;

        }
    }

    void casillasEspeciales()
    {

    }
    void OnMouseUp()
    {
        tirada();


    }
}
