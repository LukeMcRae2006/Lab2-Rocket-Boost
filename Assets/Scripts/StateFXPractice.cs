using UnityEngine;

public class StateFXPractice : MonoBehaviour
{
    [SerializeField] ParticleSystem practiceFX;
    [SerializeField] private Color changeToColor;
    bool effectActive = false;
    void Update()
    {
        RespondToDebugKeys();


    }
    void RespondToDebugKeys()
    {
        // P: start the effect only if it is not already active
        // R: reset the practice state and stop the particles
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateEffect();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetEffect();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeColor();
        }

    }
    void ActivateEffect()
    {
        // set the state
        // play the particles
        // print a useful Console message
        if (effectActive == false)
        {
            effectActive = true;
            practiceFX.Play();
        }
        Debug.Log("Trying to activate, effect status: " + effectActive);
    }
    void ResetEffect()
    {
        // reset the state
        // stop the particles
        // print a useful Console message
        if (effectActive == true)
        {
            effectActive = false;
            practiceFX.Stop();
        }
        Debug.Log("Trying to reset, effect status: " + effectActive);
    }

    void ChangeColor()
    {
        var mainModule = practiceFX.main;
        mainModule.startColor = changeToColor;
        Debug.Log("Changing color to: " + changeToColor);
    }
}
