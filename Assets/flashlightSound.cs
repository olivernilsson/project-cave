using UnityEngine;
using System.Collections;

public class flashlightSound : MonoBehaviour {
    public AudioClip otherClip;
    public AudioSource ad;
    GameObject test;
    bool o;

    // Use this for initialization
    void Start () {
        AudioSource ad = GetComponent<AudioSource>();
        test = GameObject.FindWithTag("MainCamera");

    }
	
	// Update is called once per frame
	void Update () {

         o = test.GetComponent<pickUpFlashlight>().pickedUp;

        print(o);

        if (Input.GetKeyDown(KeyCode.F))
            {
            if (test.GetComponent<pickUpFlashlight>().carrying == true)
            {
                ad.Play();
            }
            }
        }

    

   
}
