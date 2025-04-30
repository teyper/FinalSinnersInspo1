using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CutToScene2 : MonoBehaviour
{
    public PlayableDirector director;
    public string nextScene = "Scene 2";

    private void Start()
    {
        if (director != null)
        {
            director.stopped += OnTimelineStopped;
        }
    }

    private void OnTimelineStopped(PlayableDirector d)
    {
        SceneManager.LoadScene(nextScene);
    }
}
