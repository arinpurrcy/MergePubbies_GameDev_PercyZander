using UnityEngine;

//<summary> This script is used for the merging of Pubbies! - Zander :3 </summary>
public class MergeLogic : MonoBehaviour
{
    //Big to Small Pubby (0 = Biggest, 9 = Smallest)
    private string[] pubbyTags = { "Wolf", "Samo", "Rott", "Husky", "Golden", "Beagle", "Shiba", "Dasch", "Pom", "Malt" };
    private float[] pubbyRadius = { 2.5f, 2.2f, 1.85f, 1.55f, 1.25f, 1.1f, .82f, .65f, .48f, .32f };
    public Sprite[] pubbySprites;
    private int currentPubbyIndex;

    private void Start()
    {
        currentPubbyIndex = 9; //Will eventually be random
        UpdatePubbyInformation();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(gameObject.tag)) //Makes sure tags match
        {
            if (gameObject.GetInstanceID() > collision.gameObject.GetInstanceID()) //This makes sure the method is only called once for each collision
            {
                Destroy(collision.gameObject); //Destroys the other Pubby
                UpgradePubby();
            }
        }
    }

    private void UpgradePubby()
    {
        currentPubbyIndex--;
        if(currentPubbyIndex < 0)
        {
            Destroy(gameObject);
        }
        UpdatePubbyInformation();
    }

    private void UpdatePubbyInformation()
    {
        tag = pubbyTags[currentPubbyIndex];
        gameObject.GetComponent<CircleCollider2D>().radius = pubbyRadius[currentPubbyIndex];
        gameObject.GetComponent<SpriteRenderer>().sprite = pubbySprites[currentPubbyIndex];
    }
}