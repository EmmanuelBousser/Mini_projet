using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterBehaviour : MonoBehaviour {

    public GameObject Arrival;
    public string NameToReact = "Camera (eye)";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Teleporter TRigger:" + other.gameObject.name);
        if (other.gameObject.name == NameToReact && Arrival!=null)
        {
            // récupérer le CameraRig HTC
            GameObject cameraRig = getCameraRigContainer(other.gameObject);
            GameObject start = gameObject;


            cameraRig.transform.position = cameraRig.transform.position + (Arrival.transform.position - start.transform.position);
        }
    }

    private GameObject getCameraRigContainer(GameObject go)
    {
        int i = 0;
        GameObject temp = go;
        while(temp.transform.name != "[CameraRig]" && i < 5)
        {
            temp = temp.transform.parent.gameObject;
            i++;
        }
        return temp;
    }
}
