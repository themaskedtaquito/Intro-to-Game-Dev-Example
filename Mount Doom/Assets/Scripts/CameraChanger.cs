using UnityEngine;
using System.Collections;

public class CameraChanger : MonoBehaviour {
    public GameObject[] cams;
    int currentCam = 0;
	// Use this for initialization
	void Start () {
        ActivateCam(currentCam);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //move to the next camera
            currentCam += 1;
            if (currentCam == cams.Length)
            {
                currentCam = 0;
            }
            ActivateCam(currentCam);
        }
    }

    public void ActivateCam(int camIndex)
    {

        DeactivateAllCams();

        //activate camindex cam
        cams[camIndex].SetActive(true);

    }

    public void DeactivateAllCams()
    {
        //deactivate all cameras
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].SetActive(false);
        }
    }
}
