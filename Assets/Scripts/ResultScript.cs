using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    // StartScene 이동 버튼
    public void OnStartSceneBtn()
    {
        SceneManager.LoadScene("StartScene");
    }
}
