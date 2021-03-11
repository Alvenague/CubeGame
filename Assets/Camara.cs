using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {


    Vector3 dif;
    public GameObject Heroe;
	void Start () {
        Heroe = GameObject.Find("Jugador");
     dif= Heroe.transform.position - transform.position;

	}
	
	
	void Update () {
        transform.position = Heroe.transform.position - dif;
        transform.LookAt(Heroe.transform.position);
	}
}
