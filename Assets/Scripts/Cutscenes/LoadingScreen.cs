using System.Collections;
using TMPro;
using UnityEngine;

//<Summary> This script is used for the fake loading screen before the actual gameplay
public class LoadingScreen : MonoBehaviour
{
    private ServiceHub serviceHub;

    private float randomLoadTime;

    public GameObject readyScreen;
    public GameObject goScreen;

    public GameObject gamePlay;
    public GameObject loadingScreen;

    public TextMeshProUGUI tipDisplay;
    public string[] tips;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;

        randomLoadTime = Random.Range(3, 5);

        tipDisplay.text = $"Tip: {tips[Random.Range(0, tips.Length)]}";

        StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        yield return new WaitForSeconds(randomLoadTime);
        readyScreen.SetActive(true);
        serviceHub.AudioManager.PlayIntrolude();
        yield return new WaitForSeconds(1.6f);
        goScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        serviceHub.AudioManager.PlayGameplay();
        gamePlay.SetActive(true);
        loadingScreen.SetActive(false);
    }
}