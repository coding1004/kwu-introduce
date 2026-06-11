using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    // 효과음
    [SerializeField] private AudioSource bgmSource;

    private int design;
    private int dev;
    private int plan;

    private int resultNum = 0;
    private string uniName = "";
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Image resultImage;

    [SerializeField] private Sprite[] resultSprite;


    void Awake()
    {
        bgmSource.loop = true;
        bgmSource.Play();
    }

    void Start()
    {
        design = ScoreManagerScript.Instance.designScore;
        dev = ScoreManagerScript.Instance.devScore;
        plan = ScoreManagerScript.Instance.planScore;

        CalculateResult();
        SetUI();
    }

    private void CalculateResult()
    {
        int avg = (design + dev + plan) / 3;

        // 1. 겜콘 조교 우니
        if (design >= 90 && dev >= 90 && plan >= 90)
        {
            resultNum = 1;
        }

        // 2. 5학년 우니
        else if (avg < 10)
        {
            resultNum = 2;
        }

        // 3. QA 우니
        else if (plan >= 60 && dev >= 60 && Mathf.Abs(plan - dev) <= 15)
        {
            resultNum = 7;
        }

        // 4. UI 디자이너 우니
        else if (design > dev && design > plan && design >= plan * 1.5f)
        {
            resultNum = 3;
        }

        // 5. 사운드 디자이너 우니
        else if (design >= 60 && dev >= 60 && Mathf.Abs(design - dev) <= 15)
        {
            resultNum = 4;
        }

        // 6. 개발자 우니
        else if (dev > design && dev > plan)
        {
            resultNum = 5;
        }

        // 7. 기획자 우니
        else if (plan > design && plan > dev)
        {
            resultNum = 6;
        }

        // 기본
        else
        {
            resultNum = 0;
        }
    }

    private void SetUI()
    {
        switch (resultNum)
        {
            case 0:
                uniName = "우니";
                resultImage.sprite = resultSprite[0];
                break;

            case 1:
                uniName = "겜콘 조교 우니";
                resultImage.sprite = resultSprite[1];
                break;

            case 2:
                uniName = "5학년 우니";
                resultImage.sprite = resultSprite[2];
                break;

            case 3:
                uniName = "UI 디자이너 우니";
                resultImage.sprite = resultSprite[3];
                break;

            case 4:
                uniName = "사운드 디자이너 우니";
                resultImage.sprite = resultSprite[4];
                break;

            case 5:
                uniName = "개발자 우니";
                resultImage.sprite = resultSprite[5];
                break;

            case 6:
                uniName = "기획자 우니";
                resultImage.sprite = resultSprite[6];
                break;

            case 7:
                uniName = "QA 우니";
                resultImage.sprite = resultSprite[7];
                break;

            default:
                uniName = "우니";
                resultImage.sprite = resultSprite[0];
                break;
        }

        resultText.text = $"'{uniName}' 입니다!";
    }

    // StartScene 이동 버튼
    public void OnStartSceneBtn()
    {
        SceneManager.LoadScene("StartScene");
    }
}
