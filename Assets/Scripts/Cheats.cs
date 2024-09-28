using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
	private static Cheats instance;

	private string[] cheatCode;
	[SerializeField]
	private int index;
	public static bool isSlease;

	private void Awake()
	{
		DontDestroyOnLoad(this);

		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	void Start()
	{
		// Code is "slease", user needs to input this in the right order
		cheatCode = new string[] { "s", "l", "e", "a", "s", "e" };
		index = 0;
	}

	void Update()
	{
		if (Input.anyKeyDown && !isSlease)
		{
			if (Input.GetKeyDown(cheatCode[index]))
			{
				index++;
			}
			else
			{
				index = 0;
			}
		}

		// If index reaches the length of the cheatCode string, 
		// the entire code was correctly entered
		if (index == cheatCode.Length)
		{
			// Unlock Slease mode
			isSlease = true;
		}
	}
}
