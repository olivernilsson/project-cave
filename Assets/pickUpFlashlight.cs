using UnityEngine;
using System.Collections;

public class pickUpFlashlight : MonoBehaviour
{

    GameObject mainCamera;
    public bool pickedUp = true;
    GameObject carriedObject;
    public float distance;
    public float smooth;
    public bool carrying = false;
    public bool on = false;
    Vector3 fl;
   

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        GetComponent<Light>().intensity = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            carry(carriedObject);
            toggleFlashLight();
          
        }
        else
        {
            pickup();
        }
    }

    // void rotateObject()
    // {
    //     carriedObject.transform.Rotate(5, 10, 15);
    //  }

    void carry(GameObject o)
    {
   
        //o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * 4 / 10, Time.deltaTime * smooth);
        o.transform.position = mainCamera.transform.position+mainCamera.transform.forward * 4/10+mainCamera.transform.right * 4/10+mainCamera.transform.up * -3/10;
        o.transform.rotation = mainCamera.transform.rotation;
        //o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        //o.transform.rotation = Quaternion.identity;

      
    }


    void pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Flashlight p = hit.collider.GetComponent<Flashlight>();
                if (p != null)
                {
                    ;

                    carrying = true;
                    carriedObject = p.gameObject;
                    //p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;


                   
                }


            }
        }
    }

    void toggleFlashLight() {


        if (Input.GetKeyDown(KeyCode.F))
            on = !on;
        if (on)
        {
            GetComponent<Light>().intensity = 2;
            
        }
        else if (!on)
        {
            GetComponent<Light>().intensity = 0;
            
        }
    }
}