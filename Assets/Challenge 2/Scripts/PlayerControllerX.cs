using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    // This variable is used to control the time interval between dog spawn, also coroutine slot (instead of Invoke I use coroutine)
    private float spawnDelay = 0.77f;
    private float nextSpawn;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            nextSpawn = Time.time + spawnDelay;
        }
    }
}
