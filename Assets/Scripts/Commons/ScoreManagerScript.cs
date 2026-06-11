using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    public static ScoreManagerScript Instance;

    public int designScore;
    public int devScore;
    public int planScore;

    public bool colorGameClear;
    public bool runningGameClear;
    public bool catchGameClear;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AutoCreate()
    {
        if (Instance == null)
        {
            GameObject obj = new GameObject("GameScoreSystems");
            obj.AddComponent<ScoreManagerScript>();
        }
    }

    public void ResetScores()
    {
        designScore = 0;
        devScore = 0;
        planScore = 0;

        colorGameClear = false;
        runningGameClear = false;
        catchGameClear = false;
    }
}