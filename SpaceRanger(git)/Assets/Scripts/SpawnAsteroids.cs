using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    [SerializeField]
    private GameObject[] AsteroidPrefabs;
    public GameObject explosion;
    public GameObject next;
    public float endTimer = 60.0f;
    int counter;
    int curr;

    // Start is called before the first frame update
    void Start()
    {
        counter = (int)endTimer - 1;
    }

    // Update is called once per frame
    void Update()
    {
        endTimer -= Time.deltaTime;
        curr = (int)endTimer;
        if(curr == counter)
        {
            InternalAsteroids(20);
            ExternalAsteroids(20);

            counter = curr - 1;
        }
        Debug.Log(curr);

        if(curr == 50)
        {
            var nextLevel = (GameObject)Instantiate(next , new Vector3(0, 0, this.transform.position.z), Quaternion.identity);
        }

        if(curr < 0)
        {
            Debug.Log("Game Over!");
        }
    }

    void InternalAsteroids(int amount)
    {
        for (int i=0; i < amount; i++) 
        {
            Debug.Log("InternalAsteroid Called...");
            var pos = new Vector3(Random.Range(-50, 50), Random.Range(-40, 40), this.transform.position.z);
            var chosenAsteroid = AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)];
            var asteroid = (GameObject)Instantiate(chosenAsteroid , pos, Random.rotation);
            asteroid.gameObject.transform.localScale += new Vector3(Random.Range(0, 4), Random.Range(0, 4), Random.Range(0, 4));

            Destroy(asteroid, 12.0f);
        }
    }

    void ExternalAsteroids(int amount)
    {
        Debug.Log("ExternalAsteroid Called...");
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Destroy(this);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

}
