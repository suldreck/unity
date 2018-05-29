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
    public bool botonSw = false;
    public Casilla casillaInicio;
    public Casilla casillaActual;
    public Casilla[] camino;
    public int caminoIndice;
    public Casilla casillaFinal;
    bool sw = false;


    public Vector3 posicionObj;
    Vector3 velocidad = Vector3.zero;
    float camaraLenta = 0.2f;
    float distanciaFichas = 20f;
    float extraAltura ;

    Vector3 altura ;
    // Update is called once per frame
    void Update()
    {
        extraAltura = ((this.transform.localScale.y + casillaInicio.transform.localScale.y) / 2) - 5;
        altura = new Vector3(0, extraAltura, 0);
        //Debug.Log( " update fuera if caminoIndice " + caminoIndice+" longitud: "+ camino.Length);
        float distancia = Vector3.Distance(this.transform.position, posicionObj);
        Debug.Log("distancia fichas" + distancia);
        if (botonSw == true)
        {

            if (distancia < distanciaFichas)
            {
                if (camino != null)

                {

                    if (caminoIndice < camino.Length)
                    {

                        DameUnaNuevaPosicionObj(camino[caminoIndice].transform.position);

                        caminoIndice++;
                    }
                    else//añadido para q me permita la teleportacion
                    {
                        botonSw = false;
                    }
                }

            }
          


            this.transform.position = Vector3.SmoothDamp(this.transform.position, posicionObj + altura, ref velocidad, camaraLenta);
        }
        else
        {

            if (this.casillaActual != null && this.casillaActual.tag != "Untagged")
            {
                Debug.Log(" " + this.casillaFinal.tag);
                switch (this.casillaActual.tag)
                {
                    case "oca":
                        Debug.Log(this.casillaFinal.tag);
                        break;
                    case "puente":
                        Debug.Log(this.casillaFinal.tag);
                        salto(2);
                        break;
                    case "carcel":
                        Debug.Log(this.casillaFinal.tag);
                        break;


                    default:
                        break;
                }
            }
            else
            {
                Debug.Log("no tiene tag");
            }
        }
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
    void salto(int espacios)
    {
        ruta(espacios);
        //this.transform.position = Vector3.SmoothDamp(this.transform.position, posicionObj , ref velocidad, camaraLenta);
        this.transform.position = casillaFinal.transform.position;
        this.transform.position = this.transform.position + Vector3.up * extraAltura;
    }
    void OnMouseUp()
    {
        botonSw = true;
        tirada();

        //salto(); 
      

    }
}
