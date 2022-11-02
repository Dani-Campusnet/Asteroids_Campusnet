using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{       
    
        public TextMeshProUGUI tiempo;
        public TextMeshProUGUI puntuacion;
        public TextMeshProUGUI vidas;
        public GameObject gameover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo.text = Time.time.ToString("00.00");
        puntuacion.text = gameManager.instance.puntuacion.ToString("00000000");
        vidas.text = gameManager.instance.vidas.ToString("Vidas: "+gameManager.instance.vidas);
        if(gameManager.instance.vidas <=0){

            gameover.SetActive(true);
        }
    }
}
