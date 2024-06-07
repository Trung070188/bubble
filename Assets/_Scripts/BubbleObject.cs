
using Unity.VisualScripting;
using UnityEngine;

public class BubbleObject : MonoBehaviour, ICollision
{
   public GameObject Particle;
   public bool isClick = false;
   public int BubbleId;

   public void InitParticle()
   {
    
     for(int i = 0 ; i < 4 ; i++)
     {
        GameObject particle = Instantiate(Particle, transform.position, Quaternion.identity);
        particle.GetComponent<ParticleObject>().direction(i);
     }

   }
   public void HandleCollision(Transform obj)
   {
     Debug.Log("id : " + BubbleId);
   }

}
