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
}
