using UnityEngine;
using System.Collections;

public class Morir : MonoBehaviour {

	// Use this for initialization
	float t;
	void Start () {
		t = 2;
	}
	
	// Update is called once per frame
	void Update () {
		t = t - Time.deltaTime;
		if(t<0)
		{
			t = 2;
			Destroy (gameObject);
		}	
	}
}
