using UnityEngine;


/*
 *  Please note that code is not perfect, and has obvious flaws for the sake of simplicity.
 */
public class NoteSpawner : MonoBehaviour
{
    [SerializeField] float notesPerMinute;
    [SerializeField] float travelTime = 3f;

    private AudioSource audioSource;
    private float songTimer = -3f;
    private bool songStarted = false;
    private int lastSpawnedBeat = -1;

    /* Start adding workshop variable things here */

    [SerializeField] TextAsset beatmap;
    string[] lines;
    [SerializeField] GameObject[] prefabs;

    /* Variable finish */

    void Start()
    {
        // Get the audio source from the object
        audioSource = GetComponent<AudioSource>();

        // Preload the audio data to avoid lagspike
        audioSource.clip.LoadAudioData();

        // TODO: Split the text asset into seperate lines
        string fullText = beatmap.text;

        // Now we just have to split it
        lines = fullText.Split('\n');
    }

    void Update()
    {
        // Add the time passed to our timer
        songTimer += Time.deltaTime;

        // If we are ready to start the song, start the song
        if (!songStarted && songTimer >= 0f)
        {
            audioSource.Play();
            songStarted = true;
        }

        // Calculate what notes we need after travel time has passed (So what notes we need in 3 seconds)
        float spawnTime = songTimer + travelTime;

        // Calculate the correct beat we would be on
        int currentBeat = Mathf.FloorToInt(spawnTime * (notesPerMinute / 60f));

        // Check if we started a new beat
        if (currentBeat != lastSpawnedBeat)
        {
            // Update what we concider the last beat
            lastSpawnedBeat = currentBeat;

            // TODO: Instantiate the correct object
            string line = lines[currentBeat];
            Debug.Log(line);

            for (int index = 0; index < 4; index++)
            {
                char c = line[index];
                if(c == 'X')
                {
                    GameObject.Instantiate(prefabs[index]);
                }
            }
        }
    }
}
