
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
   public void SetBubble()
   {
    switch(BubbleId)
      {
        case 1: 
            GameObject bubble1 = Instantiate(LevelConverter.instance.bubble2, transform.position, Quaternion.identity);
            bubble1.GetComponent<BubbleObject>().BubbleId = 2;
            Destroy(gameObject);
            break;
        case 2: 
            GameObject bubble2 = Instantiate(LevelConverter.instance.bubble3, transform.position, Quaternion.identity);
            bubble2.GetComponent<BubbleObject>().BubbleId = 3;

            Destroy(gameObject);
            break;
        case 3: 
            GameObject bubble3 = Instantiate(LevelConverter.instance.bubble4, transform.position, Quaternion.identity);
            bubble3.GetComponent<BubbleObject>().BubbleId = 4;
            Destroy(gameObject);
            break;
        default:
           return;
      }
   }
   public void HandleCollision(Transform obj)
   {
       
      switch(BubbleId)
      {
        case 1: 
            GameObject bubble1 = Instantiate(LevelConverter.instance.bubble2, transform.position, Quaternion.identity);
            Destroy(gameObject);
            break;
        case 2: 
            GameObject bubble2 = Instantiate(LevelConverter.instance.bubble3, transform.position, Quaternion.identity);
            Destroy(gameObject);
            break;
        case 3: 
            GameObject bubble3 = Instantiate(LevelConverter.instance.bubble4, transform.position, Quaternion.identity);
            Destroy(gameObject);
            break;
        case 4: 
            InitParticle();
            Destroy(gameObject);
            break;
        default:
           return;

      }
   }

}
