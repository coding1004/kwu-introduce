using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Button[] gameButtons;
    [SerializeField] private TextMeshProUGUI[] buttonTexts;
    [SerializeField] private Image[] stampImages;
    [SerializeField] private Slider[] scoreSliders;

    [SerializeField] private GameObject[] gamePanel;
    [SerializeField] private GameObject clearPopupPanel;

    [SerializeField] private AudioSource bgmSource;


    void Awake()
    {
        if (bgmSource != null)
        {
            bgmSource.loop = true;
            bgmSource.Play();
        }

        foreach (var panel in gamePanel)
        {
            panel.SetActive(false);
        }
        clearPopupPanel.SetActive(false);
    }

    void Start()
    {
        RefreshGameState();
        RefreshScoreSliders();
    }

    private bool SafeScore(out ScoreManagerScript sm)
    {
        sm = ScoreManagerScript.Instance;
        if (sm == null)
        {
            Debug.LogError("ScoreManager가 생성되지 않았습니다.");
            return false;
        }
        return true;
    }

    private void SetButtonState(int index, bool isClear)
    {
        // 버튼 활성/비활성
        gameButtons[index].interactable = !isClear;
        stampImages[index].gameObject.SetActive(isClear);

        // 텍스트 색 변경
        buttonTexts[index].color = isClear
            ? new Color32(178, 47, 87, 255)  // #B22F57 (완료)
            : Color.white;                  // 미완료
    }

    private void RefreshGameState()
    {
        if (!SafeScore(out var sm)) return;

        SetButtonState(0, sm.colorGameClear);
        SetButtonState(1, sm.catchGameClear);
        SetButtonState(2, sm.runningGameClear);

        if (sm.colorGameClear && sm.catchGameClear && sm.runningGameClear)
        {
            ClearAllGame();
        }
    }

    private void RefreshScoreSliders()
    {
        if (ScoreManagerScript.Instance == null)
            return;

        float[] scores =
        {
            ScoreManagerScript.Instance.designScore,
            ScoreManagerScript.Instance.devScore,
            ScoreManagerScript.Instance.planScore
        };

        float total = 0;

        foreach (float score in scores)
        {
            total += score;
        }

        if (total <= 0)
        {
            foreach (var slider in scoreSliders)
            {
                slider.value = 0;
            }
            return;
        }
        
        for (int i = 0; i < Mathf.Min(scoreSliders.Length, scores.Length); i++)
        {
            scoreSliders[i].value = scores[i] / total;
        }
    }

    public void OnStartSceneBtn() => SceneManager.LoadScene("StartScene");
    public void OnColorSceneBtn() => SceneManager.LoadScene("ColorScene");
    public void OnCatchGameSceneBtn() => SceneManager.LoadScene("CatchGameScene");
    public void OnRunSceneBtn() => SceneManager.LoadScene("RunningGameScene");

    public void OnGamePanel1Btn()
    {
        if (ScoreManagerScript.Instance?.colorGameClear == true) return;
        OpenPanel(0);
    }

    public void OnGamePanel2Btn()
    {
        if (ScoreManagerScript.Instance?.catchGameClear == true) return;
        OpenPanel(1);
    }

    public void OnGamePanel3Btn()
    {
        if (ScoreManagerScript.Instance?.runningGameClear == true) return;
        OpenPanel(2);
    }

    private void OpenPanel(int index)
    {
        foreach (var panel in gamePanel)
        {
            panel.SetActive(false);
        }

        gamePanel[index].SetActive(true);
    }

    private void ClearAllGame()
    {
        if (bgmSource != null)
            bgmSource.Stop();

        clearPopupPanel.SetActive(true);
    }

    public void OnResultSceneBtn()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
