using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public Enemy basicEnemy;
    public Enemy toughEnemy;
    public GameObject player;

    public Transform[] spawnPoints;
	// Use this for initialization
	void Start () {

        InvokeRepeating("Spawn", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        float rand = Random.Range(0.0f, 1.0f);
        if(rand < .2f)
        {
            Instantiate(toughEnemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
        else
        {
            Instantiate(basicEnemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }
}
