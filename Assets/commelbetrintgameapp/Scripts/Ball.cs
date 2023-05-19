using UnityEngine;

public class Ball : MonoBehaviour
{
    private AudioSource Source { get; set; }

    private Transform Pivot { get; set; }

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
        Pivot.Rotate(Vector3.back * 90);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameManager.Move();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(SettingsManager.VibraEnbled)
        {
            Handheld.Vibrate();
        }

        if (SettingsManager.SoundsEnabled)
        {
            if(Source.isPlaying)
            {
                Source.Stop();
            }

            Source.Play();
        }
    }
}
