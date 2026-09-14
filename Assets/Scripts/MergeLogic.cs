using UnityEngine;

//<summary> This script is used for the merging of Pubbies! - Zander :3 </summary>
public class MergeLogic : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(gameObject.tag))
        {
            
        }
    }
}