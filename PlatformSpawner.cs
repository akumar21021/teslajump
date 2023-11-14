using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject platformSpawnTrigger;
    [SerializeField] float y;
     [SerializeField] float x;
    [SerializeField] int spawnCount;

    public static PlatformSpawner Instance;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        PlatformSpawn();



    }
        public void PlatformSpawn()
        {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(platform, new Vector3(Random.Range(-x,x),y),Quaternion.identity);
            y +=2.5f;

            if (i == spawnCount)
            {

            Instantiate(platformSpawnTrigger, new Vector3(Random.Range(0, y),y),Quaternion.identity);

            }
        }

        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
