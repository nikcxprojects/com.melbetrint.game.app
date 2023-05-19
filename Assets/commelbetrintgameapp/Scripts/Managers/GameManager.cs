using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int CompletedLevelCount
    {
        get
        {
            return PlayerPrefs.GetInt("completedLevel", 0);
        }

        set
        {
            PlayerPrefs.SetInt("completedLevel", value);
            PlayerPrefs.Save();
        }
    }

    private static int id;

    private static Transform ball;
    private static Transform levelRoot;

    public static void Move()
    {
        ball.SetParent(levelRoot.GetChild(++id));
        ball.localPosition = Vector3.up * 0.6f;
    }

    public static void Initalize(Transform _ball, Transform _leveRoot)
    {
        id = 0;

        ball = _ball;
        levelRoot = _leveRoot;

        ball.SetParent(levelRoot.GetChild(id));
        ball.localPosition = Vector3.up * 0.6f;
    }
}
