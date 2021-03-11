using UnityEngine;
using System.Collections;

public class Volver : MonoBehaviour
{

    float tiempo;
    void Start()
    {
        tiempo = 3;
    }

    void Update()
    {
         tiempo = tiempo - Time.deltaTime;
        if (tiempo < 0)

            Application.LoadLevel("juego");

    }

 
}
