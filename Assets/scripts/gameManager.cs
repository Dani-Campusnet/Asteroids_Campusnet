using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public int vidas = 3;
    public int puntuacion = 0;
    private void Awake()
    { 
    
    instance= this;
    
    }


}
