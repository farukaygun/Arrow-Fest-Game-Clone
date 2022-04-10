using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject arrows;

    private void Update() {
        if (arrows.transform.childCount <= 0)
            GameOver();
    }

    private void GameOver() {
        SceneManager.LoadScene(0);        
    }
}
