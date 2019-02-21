using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class rockfallTrigger : MonoBehaviour {

    GameObject[] rocks;
    GameObject camera;
    GameObject camera2;
    AudioSource audio;
    float timeLeft = 1.8f;
    bool timerStart = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (timerStart == true) {

            timeLeft -= Time.deltaTime;
        }

	}

    void OnTriggerEnter(Collider other) {


        audio = GetComponent<AudioSource>();
        audio.Play();
        rocks = GameObject.FindGameObjectsWithTag("fallingrock");

        for (int i = 0; i < 10; i++)
        {
            rocks[i].GetComponent<Rigidbody>().isKinematic = false;
            

        }

        
        timerStart = true;

        if (timeLeft < 0)
        {
            camera = GameObject.FindWithTag("MainCamera");
            camera.GetComponent<Camera>().enabled = false;
            camera = GameObject.FindWithTag("blackscreen");
            camera.GetComponent<Camera>().enabled = true;
            camera2 = GameObject.FindWithTag("test");
            camera2.GetComponent<AudioSource>().enabled = false;
        }
    }
}
