using UnityEngine;
using System.Collections;

public class Camino : MonoBehaviour {
	
	public bool estado;
	public void setEsCamino(bool x)
	{
		estado = x;
	}
	public bool getEsCamino()
	{
		return estado;
		
	}
	
	void Start () {
        GetComponent<MeshRenderer>().material.color = Color.gray;

		
}
	
	
	void Update () {
		
	}
    void OnTriggerEnter(Collider otro)
    {
        if (!estado)
        {
            otro.gameObject.GetComponent<MoverCuadrado>().Perdiste(); 
        }
    }

}


