using UnityEngine;
using System.Collections;


public class MoverCuadrado : MonoBehaviour {
	
	float caidas;
	bool caminoEquivocado;
	float Tiempo;
	Camino x;
	float pasos;
	bool sw = true;
	bool gV=false;
	
	void Start()
	{

        caminoEquivocado = false;
		caidas = 0;
	
		GameObject.Find("Inicio").GetComponent<Camino>().setEsCamino(true);
		GameObject.Find("Inicio").GetComponent<MeshRenderer>().material.color=Color.blue;

     
		int cam = Random.Range(1,8);
        
		switch(cam)
		{
		case 1:
			pasos = 12;
			for (int i=1;i<=36;i++)
			{ string cad=i.ToString();
				if (i!=4 && i<=13 )
					GameObject.Find(cad).GetComponent<Camino>().setEsCamino(true);
				else
					GameObject.Find(cad).GetComponent<Camino>().setEsCamino(false);
			}
				break;
		case 2:
			pasos = 10;
			for (int i=1;i<=36;i++)
			{ string cad=i.ToString();
				if (i!=4 && i<=15 && i!=10 && i!=11 && i!=12 && i!=13) 
					GameObject.Find(cad).GetComponent<Camino>().setEsCamino(true);
				else
					GameObject.Find(cad).GetComponent<Camino>().setEsCamino(false);
			}
			break;
		case 3:
			pasos = 13;
			for (int i=1;i<=36;i++)
			{ string cad=i.ToString();
				if (i!=4 && i<=20  && i!=8 && i!=9 && i!=10 && i!=11 && i!=12 && i!=13 && i!=14 && i!=15 && i!=16) 
					GameObject.Find(cad).GetComponent<Camino>().setEsCamino(true);
				else
					GameObject.Find(cad).GetComponent<Camino>().setEsCamino(false);
			}
			break;
		case 4:
			pasos = 10;
            for (int i = 1; i <= 36; i++)
            {
                string cad = i.ToString();
                if ((i != 4  && i <=7) || (i>=17 && i<=20))
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(true);
                else
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(false);
            }
			break;
		case 5:
			pasos = 10;
            for (int i = 1; i <= 36; i++)
            {
                string cad = i.ToString();
                if ((i != 3 && i <= 4) || (i >= 21 && i <= 27))
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(true);
                else
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(false);
            }
			break;
		case 6:
			pasos = 12;
            for (int i = 1; i <= 36; i++)
            {
                string cad = i.ToString();
                if ((i != 3 && i <= 4) || (i >= 21 && i <= 23) || (i >= 26 && i <= 31))
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(true);
                else
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(false);
            }
			break;
		case 7:
			pasos = 10;
            for (int i = 1; i <= 36; i++)
            {
                string cad = i.ToString();
                if ((i != 3 && i <= 4) || (i >= 21 && i <= 23) || (i >= 29 && i <= 32))
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(true);
                else
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(false);
            }

			break;
		case 8:
            for (int i = 1; i <= 36; i++)
            {
                string cad = i.ToString();
                if ((i != 3 && i <= 4) || (i >= 21 && i <= 23) || (i >= 29 && i <= 30) || (i >= 33 && i <= 36))
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(true);
                else
                    GameObject.Find(cad).GetComponent<Camino>().setEsCamino(false);
            }
			break;
		
		default:
				break;
		}
	   	Tiempo = 2;
	}
	
	void Update () {
		
		
		Tiempo = Tiempo - Time.deltaTime;
		if (Tiempo < 0)
		{	
			if (sw)
			{
				sw = false;
				for (int i=1;i<=36;i++)
				{
					string cad=i.ToString();

					GameObject.Find(cad).GetComponent<MeshRenderer>().material.color=Color.gray;
			
				}

			}

       
			if(!gV )
			{
           
				if (Input.GetKeyDown(KeyCode.UpArrow))
				{
					transform.rotation = Quaternion.LookRotation(Vector3.forward);
					transform.Translate(Vector3.right , Space.World);
				}
				
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					transform.rotation = Quaternion.LookRotation(Vector3.right);
					transform.Translate(Vector3.back , Space.World);
				}
				
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					transform.rotation = Quaternion.LookRotation(Vector3.back);
					transform.Translate(Vector3.forward , Space.World);
				}
			}
			
		}
		else
		{
            

			for (int i=1;i<=36;i++)
			{
				string cad=i.ToString();
				
				if(GameObject.Find(cad).GetComponent<Camino>().getEsCamino())
				{
					GameObject.Find(cad).GetComponent<MeshRenderer>().material.color = Color.green;
				}
				else{
					
					GameObject.Find(cad).GetComponent<MeshRenderer>().material.color = Color.red;
				}
				
			}

	
		}
		
		
		
		
		
	}
	
	
	void OnTriggerEnter(Collider otro)
	{
		
		GameObject detectado = otro.gameObject;
	


        if (detectado.name == "Cube" )
        {
            detectado.GetComponent<MeshRenderer>().material.color = Color.green;

        }
		if (detectado.name == "Plane" && caidas<3 ) {
			
			caidas++;
	    	transform.position = new Vector3 (-31f, 6.8f, 1);
			
			
		}
		if (caidas == 3  ) {

            Perdiste();
		}
		
		else{

            Estado(detectado);
		}
		
	}

    void Estado(GameObject detectado)
    {
        x = detectado.GetComponent<Camino>();

        if (x.getEsCamino())
        {
            detectado.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            caminoEquivocado = true;
            detectado.GetComponent<MeshRenderer>().material.color = Color.red;

        }
    }


    public void Perdiste()
    {
        GetComponent<MeshRenderer>().material.color = Color.cyan;
        gV = true;
        transform.position = new Vector3(-31f, 6.8f, 1);
        Application.LoadLevel("perdiste");

    }
	
}
