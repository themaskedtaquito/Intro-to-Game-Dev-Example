using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Transform target;
    public int damage = 3;

    public float moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 direction = target.position - transform.position;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction),.2f);
        transform.position += direction.normalized*Time.deltaTime*moveSpeed;
	}
}
