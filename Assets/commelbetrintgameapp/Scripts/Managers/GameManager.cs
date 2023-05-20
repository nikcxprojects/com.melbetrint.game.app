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

    private static Ball ball;
    private static Level level;

    private static Sprite goldSprite;

    private void Awake()
    {
        goldSprite = Resources.Load<Sprite>("goldSprite");
    }

    public static void Move()
    {
        id++;

        var steps = level.sequence.ToCharArray();
        var trueDir = steps[id].ToString() == ball.direction;
        if (trueDir)
        {
            level.transform.GetChild(id).GetComponent<SpriteRenderer>().sprite = goldSprite;

            ball.transform.SetParent(level.transform.GetChild(id));
            ball.transform.localPosition = Vector3.up * 0.6f;

            if(id == steps.Length- 1)
            {
                UIManager.Instance.GameOver(true);
                CompletedLevelCount++;
            }
        }
        else
        {
            UIManager.Instance.GameOver(false);
            if (SettingsManager.VibraEnbled)
            {
                Handheld.Vibrate();
            }
        }
    }

    public static void Initalize(Ball _ball, Level _level)
    {
        id = 0;

        ball = _ball;
        level = _level;

        level.transform.GetChild(id).GetComponent<SpriteRenderer>().sprite = goldSprite;

        ball.transform.SetParent(level.transform.GetChild(id));
        ball.transform.localPosition = Vector3.up * 0.6f;
    }
}
