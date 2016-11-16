using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    int maxHealth =12;
    int currentHealth;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	    if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "enemy")
        {
            currentHealth -= col.gameObject.GetComponent<Enemy>().damage;
        }
    }
}
