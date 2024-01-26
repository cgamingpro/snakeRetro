
using UnityEngine;

public class FoodS : MonoBehaviour
{
 public BoxCollider2D gridarea;
 public void RespawanFood()
 {
    Bounds bounds = gridarea.bounds;
    float x = Random.Range(bounds.min.x,bounds.max.x);
    float y = Random.Range(bounds.min.y,bounds.max.y);
    transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0f);
 }
 void Start()
 {
    RespawanFood();
 }
 void OnTriggerEnter2D(Collider2D other)
 {
   if(other.tag == "Player")
   {
      RespawanFood();
   }  
 }
}
