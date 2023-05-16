using UnityEngine;

public class Ball : MonoBehaviour
{
    private AudioSource Source { get; set; }

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
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
