using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesceneMove : MonoBehaviour
{
    public static bool isMain = true;
    FollowCamera followCamara;
    private void Awake()
    {
        followCamara = GetComponent<FollowCamera>();
    }
    public void BackMain()
    {
        isMain = true;
        SceneManager.LoadScene("Main");
        Score.Instance.Scorereset();
    }
    public void miniGameScene()
    {
        isMain = false;
        SceneManager.LoadScene("miniGame");
        Score.Instance.Scorereset();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score.Instance.Scorereset();
    }
    public bool Ismain()
    {
        return isMain;
    }
   
}
