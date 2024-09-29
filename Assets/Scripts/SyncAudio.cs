using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncAudio : MonoBehaviour
{
    public AudioSource master;
    public AudioSource[] slaves;

    private void Start()
    {
        StartCoroutine(SyncSources());
    }
    private IEnumerator SyncSources()
    {
        while (true)
        {
            foreach (var slave in slaves)
            {
                slave.time = master.time;
                Debug.Log("Synced: " + slave.name);
                yield return null;
            }
        }
    }
}
