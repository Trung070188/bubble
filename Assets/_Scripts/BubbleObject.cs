
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
        GameObject particle = Instantiate(Particle, transform.position, Quaternion.identity, GameCtr.instance.ParticleParent);
        particle.GetComponent<ParticleObject>().direction(i);
     }
     Destroy(gameObject);
   }
   public void SetBubble()
   {
    switch(BubbleId)
      {
        case 1: 
            GameObject bubble1 = Instantiate(GameCtr.instance.bubble2, transform.position, Quaternion.identity, GameCtr.instance.BubbleParent);
            bubble1.GetComponent<BubbleObject>().BubbleId = 2;
            Destroy(gameObject);
            break;
        case 2: 
            GameObject bubble2 = Instantiate(GameCtr.instance.bubble3, transform.position, Quaternion.identity, GameCtr.instance.BubbleParent);
            bubble2.GetComponent<BubbleObject>().BubbleId = 3;

            Destroy(gameObject);
            break;
        case 3: 
            GameObject bubble3 = Instantiate(GameCtr.instance.bubble4, transform.position, Quaternion.identity, GameCtr.instance.BubbleParent);
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
            GameObject bubble1 = Instantiate(GameCtr.instance.bubble2, transform.position, Quaternion.identity, GameCtr.instance.BubbleParent);
            Destroy(gameObject);
            break;
        case 2: 
            GameObject bubble2 = Instantiate(GameCtr.instance.bubble3, transform.position, Quaternion.identity, GameCtr.instance.BubbleParent);
            Destroy(gameObject);
            break;
        case 3: 
            GameObject bubble3 = Instantiate(GameCtr.instance.bubble4, transform.position, Quaternion.identity, GameCtr.instance.BubbleParent);
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
