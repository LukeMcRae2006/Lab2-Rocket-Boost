using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip finishAudio;

    [SerializeField] private MovementScript player;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("I am friendly!");
                break;
            case "Finish":
                Debug.Log("You win!");
                audioSource.PlayOneShot(finishAudio);
                Invoke("NextLevel", 2f);
                break;
            default:
                Debug.Log("You crashed!");
                player.DestroyPlayer();
                Invoke("ReloadLevel", 1f);
                break;
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }
}
