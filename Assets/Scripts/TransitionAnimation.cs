using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void PlayTransition()
    {
        // get the animator from self
        //Animator animation = GetComponent<Animator>();

        // start its trigger
        //animation.SetTrigger("transition");
    }

    public void DeleteSelf()
    {
        Destroy(this.gameObject);
    }

    
}
