using System.Collections;
using UnityEngine;

//<Summary> This script is used for any temporary UI elements. - Zander :3 <Summary>
public class TutorialText : MonoBehaviour
{
    public float deletionTime;

    private void Start()
    {
        StartCoroutine(StartDeletionTime());
    }

    IEnumerator StartDeletionTime()
    {
        yield return new WaitForSeconds(deletionTime);
        Destroy(gameObject);
    }
}