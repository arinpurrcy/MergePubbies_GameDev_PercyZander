using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//<summary> This script is used for the Game Over Trigger! - Zander :3 </summary>
public class GameOverTrigger : MonoBehaviour
{
    private bool isTriggerStay;
    public int currentCountDown = 0;
    public int maxCountDown = 5;

    public GameObject floor;

    private ServiceHub serviceHub;

    private void Start()
    {
        isTriggerStay = false;
        serviceHub = ServiceHub.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggerStay = true;
        StartCoroutine(CheckTrigger());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggerStay = false;
        currentCountDown = 0;
    }

    IEnumerator CheckTrigger()
    {
        while (isTriggerStay)
        {
            yield return new WaitForSeconds(1f);
            if(isTriggerStay) currentCountDown++;
            if (currentCountDown >= maxCountDown)
            {
                floor.SetActive(false);
                serviceHub.Spawner.GameOver();
                yield break;
            }
            if (!isTriggerStay) currentCountDown = 0;
        }
    }
}