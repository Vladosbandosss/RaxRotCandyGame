using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] candies;
    float maxXpos = 7f;
    float minXpos = -7f;

    public static CandySpawner instanse;
    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
        }
    }
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnCandie()
    {
        int randomCandy = Random.Range(0, candies.Length);
        float randomX = Random.Range(minXpos, maxXpos);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(candies[randomCandy], randomPos, Quaternion.identity);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnCandie();
            yield return new WaitForSeconds(2f);
        }
    }
    public void StartSpawning()
    {
        StartCoroutine(nameof(SpawnCandies));
    }
    public void StopSpawning()
    {
        StopCoroutine(nameof(SpawnCandies));
    }
}
