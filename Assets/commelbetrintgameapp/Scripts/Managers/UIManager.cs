using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Networking.UnityWebRequest;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    private GameObject _gameRef;

    [Space(10)]
    [SerializeField] GameObject menu;
    [SerializeField] GameObject levels;
    [SerializeField] GameObject game;
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;


    private void Start()
    {
        OpenMenu();
    }

    public void OpenLevels()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }

    public void StartGame()
    {
        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>("level");

        _gameRef = Instantiate(_prefab, _parent);

        levels.SetActive(false);

        win.SetActive(false);
        lose.SetActive(false);

        game.SetActive(true);
    }

    public void OpenMenu()
    {
        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        game.SetActive(false);
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
