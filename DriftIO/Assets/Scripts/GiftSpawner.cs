using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    public GameObject GiftPrefab;
    public float spawnTime;
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, spawnTime);
    }
    
    private void Spawn()
    {
        GameObject gift = Instantiate(GiftPrefab);
        float radius = Random.Range(0f, 8f);
        float radian = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        gift.transform.position = new Vector3(radius * Mathf.Sin(radian), 20, radius * Mathf.Cos(radian));
    }
}
