using UnityEngine;

//<Summary> This script is used for the loading Pubby in the loading screen. - Zander :3 <Summary>
public class SpinPubby : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector2(15,30) * Time.deltaTime); //This looks extremely funny so I'm keeping it
    }
}