using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public Vector3 direction;
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction;
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
