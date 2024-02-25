using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Scene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
