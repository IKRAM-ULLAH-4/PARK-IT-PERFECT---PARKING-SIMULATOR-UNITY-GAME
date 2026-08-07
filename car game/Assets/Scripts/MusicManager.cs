using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager: MonoBehaviour
{
    [Header("Playlist")]
    public AudioClip[] songs;

    private AudioSource audioSource;
    private int currentSong = 0;
    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (songs.Length == 0)
        {
            Debug.LogWarning("No songs assigned!");
            enabled = false;
            return;
        }

        audioSource.clip = songs[currentSong];
        audioSource.loop = false;
        audioSource.Play();
    }

    void Update()
    {
        // R = Next Song
        if (Input.GetKeyDown(KeyCode.R))
        {
            NextSong();
        }

        // T = Play / Pause
        if (Input.GetKeyDown(KeyCode.T))
        {
            TogglePlayPause();
        }

        // Automatically play the next song when the current one finishes
        if (!audioSource.isPlaying && !isPaused)
        {
            NextSong();
        }
    }

    public void NextSong()
    {
        currentSong++;

        // Loop back to the first song
        if (currentSong >= songs.Length)
        {
            currentSong = 0;
        }

        audioSource.Stop();
        audioSource.clip = songs[currentSong];
        audioSource.Play();

        isPaused = false;
    }

    public void TogglePlayPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            isPaused = true;
        }
        else
        {
            audioSource.UnPause();
            isPaused = false;
        }
    }
}