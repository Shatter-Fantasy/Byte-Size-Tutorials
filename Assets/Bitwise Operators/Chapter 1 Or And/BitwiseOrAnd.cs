using UnityEngine;

namespace SF.Bitwise
{
    public class BitwiseOrAnd : MonoBehaviour
    {
        public LayerMask PlatformMask;


        public void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Target Layer Mask: " + PlatformMask.value); 
            Debug.Log(1 << collision.gameObject.layer);
            Debug.Log("Collided Object Layer: " + collision.gameObject.layer);

            /* Default Layer is at bit 0
             * Unity Layer Mask uses 0 per layer bit to say exclude and 1 to include.
             * So if the layermask has only Default as the selected layer the Layermask value is 1.
             * So you have to left shift a byte by the value of 1 by the numbered layer the game object is on.
             * Default Layer value is 0 in Unity. Shifting the number one by the value of zero keeps it still. 
             * So after bit shifting the one can now be compared against the layermask using the & operator. 
             * If the & operator returns a number that is not one aka one of the bits matched the layer of the game object is in
             * the layermask and we can return true.
             */


            if( (PlatformMask & (1 << collision.gameObject.layer)) != 0)
            {
                Debug.Log("<color=green> The collision was on a layer in the platform mask.</color>"); 
            }
            else
                Debug.Log("<color=red> The collision was not on a layer in the platform mask.</color>");
        }
    }
}