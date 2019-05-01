using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : Singleton<GameOverUI>
{
    public GameObject GameOverGameObject;
    public Text GameOverText;
    public void GameOver(string message){
        this.GameOverText.text = message;
        GameOverGameObject.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
