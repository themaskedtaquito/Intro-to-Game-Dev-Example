using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public Bullet bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        bullet.direction = transform.forward;
        Instantiate(bullet, transform.position + transform.forward,transform.rotation);
        
    }
}
