using UnityEngine;

//<summary> This script will spawn the next pubby on the Slope. - Zander :3 </summary>
public class NextPubbyLogic : MonoBehaviour
{
    private ServiceHub serviceHub;

    private int currentPubbyIndex;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;

        currentPubbyIndex = serviceHub.Spawner.nextPubby;

        //Update Pubby Information
        gameObject.GetComponent<CircleCollider2D>().radius = serviceHub.MergeLogic.pubbyRadius[currentPubbyIndex];
        gameObject.GetComponent<SpriteRenderer>().sprite = serviceHub.MergeLogic.pubbySprites[currentPubbyIndex]; //Pubby on Slope will not show that it's evil
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = currentPubbyIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); //The spawner will enable a GameObject with a trigger for a split second, destroying the current Pubby on the Slope
    }
}