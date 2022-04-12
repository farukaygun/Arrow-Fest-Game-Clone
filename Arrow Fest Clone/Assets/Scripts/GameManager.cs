using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[SerializeField] private GameObject arrows;
	[SerializeField] private GameObject finish;
	[SerializeField] private TMP_Text textWin;

	public bool isGameWin = false;

	private void Awake()
	{
		instance = this;
	}

	private void Update()
	{
		if (arrows.transform.childCount <= 0)
			GameOver();

		if (isGameWin)
			Win();
	}

	private void GameOver()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void Win()
	{
		Time.timeScale = 0f;
		textWin.gameObject.SetActive(true);
	}
}
