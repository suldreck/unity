using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class iBoton : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        vector = new int[4];
    }
    public Sprite[] imagenes0;
    public bool dadoPulsado = false;//estado estado del dado que activara luego las acciones derivadas 
    public void turnoSiguenteJugador()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        dadoPulsado = false;
    }
    public int[] vector;
    public int total;
    public int valorDado { get; set; }

    public void fAleatorio()
    {
        
        valorDado = Random.Range(0, imagenes0.Length);
        Debug.Log("el valor del dado es: " + valorDado);
        this.transform.GetChild(0).GetComponent<Image>().sprite = imagenes0[valorDado];
        this.dadoPulsado = true;//hemos tirado el dado

       /* for (int i=0; i < vector.Length; i++)
        {
            vector[i] = Random.Range(0, 2);//1-3
            Debug.Log("el valor es:_" + vector[i]);
            if(vector[i]==0)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite=imagenes0[ Random.Range (0, imagenes0.Length)];
            }
            else
            {
                Debug.Log("la longitud de imagenes1 es: " + imagenes0.LongLength);
                Debug.Log("la longitud de imagenes1 es: " + imagenes1.LongLength);
                transform.GetChild(i).GetComponent<Image>().sprite = imagenes1[Random.Range(0, imagenes1.Length)];
            }
        }*/
    }
}
