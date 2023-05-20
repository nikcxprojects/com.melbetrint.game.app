using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Networking.UnityWebRequest;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    private int currentLevel;
    private GameObject _gameRef;

    [Space(10)]
    [SerializeField] GameObject menu;
    [SerializeField] GameObject levels;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;

    [Space(10)]
    [SerializeField] GameObject nextBtn;


    private void Start()
    {
        OpenMenu();
    }

    public void OpenLevels()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }

    public void OpenLevel(int levelID)
    {
        currentLevel = levelID;

        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>($"levels/{levelID}");

        _gameRef = Instantiate(_prefab, _parent);
        var ball = Instantiate(Resources.Load<Ball>("ball"), _parent);

        GameManager.Initalize(ball, _gameRef.GetComponent<Level>());

        levels.SetActive(false);

        win.SetActive(false);
        lose.SetActive(false);

        game.SetActive(true);
    }

    public void TryAgain()
    {
        OpenLevel(currentLevel);
    }

    public void NextLevel()
    {
        currentLevel++;
        OpenLevel(currentLevel);
    }

    public void SetPause(bool IsPause)
    {
        pause.SetActive(IsPause);
    }

    public void OpenMenu()
    {
        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        game.SetActive(false);
        pause.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        levels.SetActive(false);

        menu.SetActive(true);
    }

    public void GameOver(bool IsWin)
    {
        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        nextBtn.SetActive(currentLevel < 8);

        if(IsWin)
        {
            win.SetActive(true);
        }
        else
        {
            lose.SetActive(true);
        }

        game.SetActive(false);
    }
}
