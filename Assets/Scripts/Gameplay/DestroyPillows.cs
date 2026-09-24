using UnityEngine;

//<Summary> This script is used for destroying the pillows when they drop, but could be used for anything that needs to be destroyed by Lava. - Zander :3 <Summary>
public class DestroyPillows : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava")) Destroy(gameObject);
    }
}