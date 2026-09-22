using System.Collections;
using UnityEngine;

//<summary> This script is used for the Game Over Trigger! - Zander :3 </summary>
public class GameOverTrigger : MonoBehaviour
{
    private SpriteRenderer sr;

    private bool isTriggerStay;
    public int currentCountDown = 0;
    public int maxCountDown = 5;

    public GameObject floor;
    public GameObject frontFloorSprite;
    public float fadeOutTime;

    private ServiceHub serviceHub;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        isTriggerStay = false;
        serviceHub = ServiceHub.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggerStay = true;
        StartCoroutine(CheckTrigger());
        sr.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggerStay = false;
        currentCountDown = 0;
        sr.enabled = false;
    }

    IEnumerator CheckTrigger()
    {
        while (isTriggerStay)
        {
            yield return new WaitForSeconds(1f);
            if(isTriggerStay) currentCountDown++;
            if (currentCountDown >= maxCountDown)
            {
                StartCoroutine(FadeImage());
                floor.SetActive(false);
                Camera.main.GetComponent<Animator>().enabled = true;
                serviceHub.GameManager.GameOver();
                serviceHub.Spawner.GameOver();
                yield break;
            }
            if (!isTriggerStay) currentCountDown = 0;
        }
    }

    IEnumerator FadeImage()
    {
        float alpha = 1f;

        while(alpha > 0f)
        {
            yield return new WaitForSeconds(fadeOutTime);

            alpha -= .1f;

            frontFloorSprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }
        frontFloorSprite.SetActive(false);
    }
}