using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("I am friendly!");
            break;
            case "Finish":
                Debug.Log("You win!");
                NextLevel();
            break;  
            default:
                Debug.Log("You crashed!");
                ReloadLevel();
            break;
       }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);   
    }
}
