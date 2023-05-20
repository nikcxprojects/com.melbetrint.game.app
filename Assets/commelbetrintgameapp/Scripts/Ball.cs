using UnityEngine;

public class Ball : MonoBehaviour
{
    private AudioSource Source { get; set; }

    private Transform Pivot { get; set; }

    public string direction;

    private void Awake()
    {
        Pivot = transform.GetChild(0);
        Source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(RotatePivot), 0.0f, 1.0f);
    }

    private void OnDestroy()
    {
        CancelInvoke(nameof(RotatePivot));
    }

    private void RotatePivot()
    {
        var rv = Random.Range(1, 4);

        Pivot.Rotate(90 * rv * Vector3.back);
        switch(Mathf.RoundToInt(Pivot.eulerAngles.z))
        {
            case 310: direction = "r"; break;
            case 220: direction = "d"; break;
            case 130: direction = "l"; break;
            case 40: direction = "u"; break;
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (SettingsManager.SoundsEnabled)
            {
                if (Source.isPlaying)
                {
                    Source.Stop();
                }

                Source.Play();
            }

            GameManager.Move();
        }
    }
}
