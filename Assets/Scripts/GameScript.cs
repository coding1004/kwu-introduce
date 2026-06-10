using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public void OnCloseBtn()
    {
        SceneManager.LoadScene("StartScene");
    }

    // 디자인 게임
    public void OnColorSceneBtn()
    {
        SceneManager.LoadScene("ColorScene");
    }

    // 사과 게임
    public void OnAppleSceneBtn()
    {
        SceneManager.LoadScene("CatchGameScene");
    }

    // 러닝 게임
    public void OnRunSceneBtn()
    {
        SceneManager.LoadScene("RunningGameScene");
    }
}
