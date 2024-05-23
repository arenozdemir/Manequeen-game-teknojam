using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHall1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //SceneManager.LoadScene("Scene0", LoadSceneMode.Single);
        //first loading screen then open the scene
        SceneManager.LoadScene("Scene0", LoadSceneMode.Single);
        
    }
}
