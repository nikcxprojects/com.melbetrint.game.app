using UnityEngine.UI;
using UnityEngine;

public class LevelBtn : MonoBehaviour
{
    private Button Btn { get; set; }
    private Image Img { get; set; }

    [SerializeField] Sprite on;
    [SerializeField] Sprite off;

    private void Awake()
    {
        Btn = GetComponent<Button>();
        Img = GetComponent<Image>();
    }

    private void OnEnable()
    {
        var intercat = transform.GetSiblingIndex() <= GameManager.CompletedLevelCount;

        Btn.interactable = intercat;
        Img.sprite = intercat ? on : off;
    }
}
