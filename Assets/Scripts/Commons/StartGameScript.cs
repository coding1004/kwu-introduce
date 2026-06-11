using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    // MainScene 이동 버튼
    public void OnMainSceneBtn()
    {
        ScoreManagerScript.Instance.ResetScores();

        SceneManager.LoadScene("MainScene");
    }
}
