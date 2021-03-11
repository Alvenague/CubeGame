using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject Prototipo1;
    public GameObject Prototipo2;
 float frecuencia=0.2f;
	float t;
    bool sw;
	void Start () {
		t = frecuencia;
        sw = false;
	}
	
		void Update () {

            if (sw)
            {
                t = t - Time.deltaTime;
                if (t < 0)
                {
                    t = frecuencia;
                    Instantiate(Prototipo1, transform.position, transform.rotation);
                    Instantiate(Prototipo2, transform.position, transform.rotation);
                }
            }
		
	}

        void OnTriggerEnter(Collider otro)
        {
            if (otro.tag == "Player")
            {
                sw = true;
              
            }
        }
}
