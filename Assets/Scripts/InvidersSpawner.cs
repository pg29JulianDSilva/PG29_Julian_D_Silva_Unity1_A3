using System.Collections;
using UnityEngine;

public class InvidersSpawner : MonoBehaviour
{

    //For the Invider ships spawner

    [Header("Spawn Data")]
    [SerializeField] private float _spawnTimeMin = 0.5f;
    [SerializeField] private float _spawnTimeMax = 3f;

    [Header("Spawn Prefab")]
    [SerializeField] private GameObject _InvidersPrefab;

    //It start the corutine to spawn
    void Start()
    {
        StartCoroutine(spawnCoroutine());
    }

    private IEnumerator spawnCoroutine()
    {
        while (true)
        {
            SpawnInvider();
            yield return new WaitForSeconds(GetRandomSpawnDelay());
        }
    }

    //spawn the invider each x time isnide the spawner at a random X position
    private void SpawnInvider()
    {
        Vector3 startPos = GetRandomPointInSpawnArea();

        GameObject invader = Instantiate(_InvidersPrefab, startPos, Quaternion.identity);
    }

    private Vector3 GetRandomPointInSpawnArea()
    {
        float posInitX = Random.Range((-1 * (transform.localScale.x / 2)), transform.localScale.x / 2);
        return new Vector3(posInitX, transform.position.y, transform.position.z);
    }

    //This is the spawner delay
    private float GetRandomSpawnDelay()
    {
        return Random.Range(_spawnTimeMin, _spawnTimeMax);
    }

}
