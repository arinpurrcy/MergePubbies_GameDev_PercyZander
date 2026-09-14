using UnityEngine;

//<summary> This script is used for the merging of Pubbies! - Zander :3 </summary>
public class MergeLogic : MonoBehaviour
{
    private ServiceHub serviceHub;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(gameObject.tag)) //Makes sure tags match
        {
            if (gameObject.GetInstanceID() > collision.gameObject.GetInstanceID()) //This makes sure the method is only called once for each collision
            {
                Destroy(collision.gameObject); //Destroys the other Pubby
                gameObject.GetComponent<CircleCollider2D>().enabled = false; //Disables the collider so it doesn't interfere with the new Pubby
                
            }
        }
    }
}