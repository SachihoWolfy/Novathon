using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrazeObserver : Subject
{
    private PlayerCollision pc;
    private MusicManager mm;
    public bool _isGrazing;

    public float grazeDistance;

    private void Start()
    {
        pc = FindObjectOfType<PlayerCollision>();
        mm = FindObjectOfType<MusicManager>();
    }
    private void OnEnable()
    {
        if(!mm) mm = FindObjectOfType<MusicManager>();
        if (mm) Attach(mm);
    }
    private void OnDisable()
    {
        if (!mm) mm = FindObjectOfType<MusicManager>();
        if (mm) Detach(mm);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Sphere", System.StringComparison.CurrentCultureIgnoreCase) && !other.isTrigger)
        {
            _isGrazing = true;
            pc.grazing = _isGrazing;
            grazeDistance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Attempting to Notify of Graze!");
            NotifyObservers();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Sphere", System.StringComparison.CurrentCultureIgnoreCase) && !_isGrazing && !other.isTrigger)
        {
            _isGrazing = true;
            pc.grazing = _isGrazing;
            NotifyObservers();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Sphere", System.StringComparison.CurrentCultureIgnoreCase) && _isGrazing && !other.isTrigger)
        {
            _isGrazing = false;
            pc.grazing = _isGrazing;
            NotifyObservers();
        }
    }
}
