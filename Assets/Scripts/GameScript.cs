using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject[] gamePanels;

    void Start() {
        foreach (var gamePanel in gamePanels)
        {
            gamePanel.SetActive(false);
        }
    }

    // MainScene 이동 버튼
    public void OnMainSceneBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    // ColorScene 이동 버튼 - 디자인 게임
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

    public void OnCloseBtn()
    {
        foreach (var gamePanel in gamePanels)
        {
            gamePanel.SetActive(false);
        }
    }

    public void OnGamePanel1Btn()
    {
        foreach (var gamePanel in gamePanels)
        {
            gamePanel.SetActive(false);
        }
        gamePanels[0].SetActive(true);
    }

    public void OnGamePanel2Btn()
    {
        foreach (var gamePanel in gamePanels)
        {
            gamePanel.SetActive(false);
        }
        gamePanels[1].SetActive(true);
    }

    public void OnGamePanel3Btn()
    {
        foreach (var gamePanel in gamePanels)
        {
            gamePanel.SetActive(false);
        }
        gamePanels[2].SetActive(true);
    }

    public void OnGamePanel4Btn()
    {
        foreach (var gamePanel in gamePanels)
        {
            gamePanel.SetActive(false);
        }
        gamePanels[3].SetActive(true);
    }
}
