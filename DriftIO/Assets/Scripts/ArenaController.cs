using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArenaController : MonoBehaviour
{
    public List<Transform> ArenaParts;

    public float ringTimer;
    public float partTimer;
    public int startNumber;

    void Start()
    {
        ArenaParts = new List<Transform>();
        foreach(Transform t in transform)
        {
            t.gameObject.AddComponent<MeshCollider>();
            ArenaParts.Add(t);
        }
        ArenaParts = ArenaParts.OrderBy(t => t.name).ToList();
        StartCoroutine(RingTimer());
    }

    private IEnumerator RingTimer()
    {
        float timer = 0;

        while(timer < ringTimer)
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        while (ArenaParts[0].name.Contains(startNumber.ToString("000")))
        {
            timer = 0;
            while (timer < partTimer)
            {
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            Collapse();
        }

        startNumber++;
        if(startNumber < 30)
        {
            StartCoroutine(RingTimer());
        }
    }

    void Update()
    {
        
    }

    private void Collapse()
    {
        ArenaParts[0].gameObject.AddComponent<ArenaPartController>();
        ArenaParts.RemoveAt(0);
    }
}
