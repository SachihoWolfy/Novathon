using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleaseMode : MonoBehaviour
{
    private void Awake()
    {
        if (!Cheats.isSlease && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        if (!gameObject.activeSelf && Cheats.isSlease)
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeSelf && Cheats.isSlease)
        {
            gameObject.SetActive(true);
        }
    }
}
