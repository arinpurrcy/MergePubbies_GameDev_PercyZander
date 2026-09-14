using UnityEngine;

//<summary> This script is used for the merging of Pubbies! - Zander :3 </summary>
public class MergeLogic : MonoBehaviour
{
    //Big to Small Pubby (0 = Biggest, 9 = Smallest)
    private string[] pubbyTags = { "Wolf", "Samo", "Rott", "Husky", "Golden", "Beagle", "Shiba", "Dasch", "Pom", "Malt" };
    private float[] pubbyRadius = { 2.5f, 2.2f, 1.85f, 1.55f, 1.25f, 1.1f, .82f, .65f, .48f, .32f };
    private int[] pubbyScore = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
    public Sprite[] pubbySprites;
    private int currentPubbyIndex;

    private ServiceHub serviceHub;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;

        currentPubbyIndex = serviceHub.Spawner.currentPubby; //Will eventually be random
        UpdatePubbyInformation();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(gameObject.tag)) //Makes sure tags match
        {
            if (gameObject.GetInstanceID() > collision.gameObject.GetInstanceID()) //This makes sure the method is only called once for each collision
            {
                Destroy(collision.gameObject); //Destroys the other Pubby
                serviceHub.GameManager.AddScore(pubbyScore[currentPubbyIndex]);
                UpgradePubby();
            }
        }
    }

    private void UpgradePubby()
    {
        currentPubbyIndex--;
        if(currentPubbyIndex < 0) Destroy(gameObject);
        else UpdatePubbyInformation();
    }

    private void UpdatePubbyInformation()
    {
        tag = pubbyTags[currentPubbyIndex];
        gameObject.GetComponent<CircleCollider2D>().radius = pubbyRadius[currentPubbyIndex];
        gameObject.GetComponent<SpriteRenderer>().sprite = pubbySprites[currentPubbyIndex];
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = currentPubbyIndex;
    }
}