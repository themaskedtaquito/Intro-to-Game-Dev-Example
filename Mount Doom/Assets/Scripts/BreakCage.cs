using UnityEngine;
using System.Collections;

public class BreakCage : MonoBehaviour {
    public GameObject goodGuy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "break")
        {
            goodGuy.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
