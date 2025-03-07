using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float crashRestartDelay = 0.6f;
    [SerializeField] ParticleSystem bumpEffect;
    [SerializeField] AudioClip crashSfx;

    bool hasCrashed = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Ground.ToString()) && !hasCrashed)
        {
            Debug.Log("Ouch!!! The Player bumped his head into the ground!");
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            bumpEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSfx);
            Invoke(nameof(ReloadFirstScene), crashRestartDelay);
        }
        else
        {
            Debug.Log("The player bumped into something!");
        }
    }

    void ReloadFirstScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<PlayerController>().EnableControls();
        hasCrashed = false;
    }
}