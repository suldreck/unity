﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class iBoton : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        vector = new int[4];
    }
    public Image[] imagenes1;
    public Image[] imagenes0;
    // Update is called once per frame
    void Update()
    {

    }
    public int[] vector;
    public int total;
    public void fAleatorio()
    {
        

        for (int i=0; i < vector.Length; i++)
        {
            vector[i] = Random.Range(1, 4);//1-3
            Debug.Log("el valor es:_" + vector[i]);
        }
    }
}