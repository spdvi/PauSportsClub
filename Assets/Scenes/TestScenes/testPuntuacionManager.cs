using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class testPuntuacionManager : MonoBehaviour
{
    
    public PuntuacionManager puntuacionManager;
    
    
    public TMP_InputField turno;
    public TMP_InputField bolos_tirados;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void clickingButton()
    {
        int turno_actual = int.Parse(turno.text);
        int bolos = int.Parse(bolos_tirados.text);
        puntuacionManager.setTirada(turno_actual, bolos);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
