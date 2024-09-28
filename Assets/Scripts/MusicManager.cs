using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Observer
{
    private static MusicManager musicManagerInstance;
    private PlayerCollision pc;
    private GrazeObserver grazeObserver;
    private Score score;
    public AudioSource main;
    public AudioSource grazer;
    public AudioSource progressor;
    public AudioSource dier;

    public bool isDying = false;
    public bool isProgress = false;
    public bool isGrazing = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        main.Stop();
        grazer.Stop();
        progressor.Stop();
        dier.Stop();

        main.Play();
        grazer.Play();
        progressor.Play();
        dier.Play();
    }
    public override void Notify(Subject subject)
    {
        if (!pc && !grazeObserver && !score) { Debug.Log("not Pc or mm");  pc = subject.GetComponent<PlayerCollision>(); grazeObserver = subject.GetComponent<GrazeObserver>(); score = FindObjectOfType<Score>(); }
        if (pc)
        {
            Debug.Log("Notified!");
            isDying = pc.dying;
            isGrazing = pc.grazing;
        }
        if (grazeObserver)
        {
            Debug.Log("Notified!");
            isGrazing = grazeObserver._isGrazing;
        }
        if (score)
        {
            Debug.Log("Score Notif!");
            isProgress = score.isProgress;
        }
        if (isGrazing) { PlayGraze(); } else { StopGraze(); }
        if (isProgress) { PlayProgress(); } else { StopProgress(); }
        if (isDying) { PlayDie(); } else { StopDie(); }
    }
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(50, 50, 100, 200));
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Observer Observations");
        GUILayout.EndHorizontal();
        if (isGrazing)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Grazing~");
            GUILayout.EndHorizontal();
        }
        if (isProgress)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("The Sound of Progress");
            GUILayout.EndHorizontal();
        }
        if (isDying)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Like Dying? Observers do too!");
            GUILayout.EndHorizontal();
        }
        if (Cheats.isSlease)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Slease...");
            GUILayout.EndHorizontal();
        }
        GUILayout.EndArea();
    }

    private void PlayGraze()
    {
        grazer.volume = main.volume;
    }
    private void StopGraze()
    {
        grazer.volume = 0f;
    }
    private void PlayProgress()
    {
        progressor.volume = main.volume;
    }
    private void StopProgress()
    {
        progressor.volume = 0f;
    }
    private void PlayDie()
    {
        dier.volume = main.volume;
        main.mute = true;
        grazer.mute = true;
        progressor.mute = true;
    }
    private void StopDie()
    {
        dier.volume = 0f;
        main.mute = false;
        grazer.mute = false;
        progressor.mute = false;
    }
}
