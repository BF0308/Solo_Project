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
        SceneManager.UnloadSceneAsync("miniGame");
        EnableScene();
    }
    public void miniGameScene()
    {
        isMain = false;
        SceneManager.LoadScene("miniGame", LoadSceneMode.Additive);
        DisableScene();
    }
    public void DisableScene()
    {
        Scene targetScene = SceneManager.GetSceneByName("Main");


        foreach (GameObject go in targetScene.GetRootGameObjects())
        {
            go.SetActive(false); // 상태는 그대로 유지됨!
        }

    }

    public void EnableScene()
    {
        Scene targetScene = SceneManager.GetSceneByName("Main");


        foreach (GameObject go in targetScene.GetRootGameObjects())
        {
            go.SetActive(true); // 다시 활성화
        }

    }
    public void RestartButton()
    {
        SceneManager.LoadScene("miniGame");
    }
    public bool Ismain()
    {
        return isMain;
    }
}
