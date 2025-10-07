using UnityEngine;
using UnityEngine.InputSystem;

public class NoteRemover : MonoBehaviour
{
    // The key we need to press to make the note dissapear.
    [SerializeField] InputAction noteKey;

    Score score;
    private void Start()
    {
        // We need to enable the note manually, fun times if you forget!
        noteKey.Enable();
        score = FindAnyObjectByType<Score>();
    }

    void Update()
    {
        if(noteKey.WasPressedThisFrame())
        {
            DestoryNearbyNotes();
        }
    }

    void DestoryNearbyNotes()
    {
        // This will give us an array (list) of 'note' objects in our scene
        Note[] notes = Object.FindObjectsByType<Note>(FindObjectsSortMode.None);


        bool hasRemovedAnyNote = false;
        foreach (Note note in notes)
        {
            // Get distance to us and the note
            float distance = Vector2.Distance(note.transform.position, transform.position);

            if (distance < 1)
            {
                hasRemovedAnyNote = true;
                Object.Destroy(note.gameObject);
                score.AddScore(1000);
            }
        }

        // If we have NOT remove any notes, 
        if(!hasRemovedAnyNote)
        {
            score.RemoveScore(100);
        }
    }
}
