using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] GameObject[] typeOfAttackers;

    bool spawn = true;
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
        StopSpawning();
    }

    public void StopSpawning()
    {
        spawn = false;
    }
    private void SpawnAttacker()
    {
        Spawn(typeOfAttackers[Random.Range(0,typeOfAttackers.Length)]);
    }

    private void Spawn(GameObject myAttacker)
    {
        GameObject newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity) as GameObject;
        newAttacker.transform.parent = transform;
    }
}
