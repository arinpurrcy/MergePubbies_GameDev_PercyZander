using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//<Summary> This script is used for the fake loading screen before the actual gameplay
public class LoadingScreen : MonoBehaviour
{
    private ServiceHub serviceHub;

    private float randomLoadTime;

    public GameObject readyScreen;
    public GameObject goScreen;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;

        randomLoadTime = Random.Range(3, 5);

        StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        yield return new WaitForSeconds(randomLoadTime);
        readyScreen.SetActive(true);
        serviceHub.AudioManager.PlayIntrolude();
        yield return new WaitForSeconds(1.5f);
        goScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }
}