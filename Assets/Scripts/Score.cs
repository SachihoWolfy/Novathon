using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour {

	public Transform player;
	public Transform end;
	public TMP_Text scoreText;
	private int progress;
	
	// Update is called once per frame
	void Update () {
		progress = ((int)((player.position.z / end.position.z) * 100));
		scoreText.text = progress.ToString("0") + "%";
	}
}
