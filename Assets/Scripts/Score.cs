using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : Subject {

	public Transform player;
	public Transform end;
	public TMP_Text scoreText;
	private MusicManager mm;
	private int progress;
	public bool isProgress;

	private void Start()
	{
		mm = FindObjectOfType<MusicManager>();
	}
	private void OnEnable()
	{
		if (!mm) mm = FindObjectOfType<MusicManager>();
		if (mm) Attach(mm);
	}
	private void OnDisable()
	{
		if (!mm) mm = FindObjectOfType<MusicManager>();
		if (mm) Detach(mm);
	}

	// Update is called once per frame
	void Update () {
		progress = ((int)((player.position.z / end.position.z) * 100));
		scoreText.text = progress.ToString("0") + "%";

		if(isProgress && progress < 42)
        {
			ToggleProgress();
        }
		if (!isProgress && progress > 42)
		{
			ToggleProgress();
		}
	}

	private void ToggleProgress()
    {
		isProgress = !isProgress;
		NotifyObservers();
    }
}
