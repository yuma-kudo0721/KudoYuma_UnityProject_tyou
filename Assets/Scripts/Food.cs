using UnityEngine;

public class Food : MonoBehaviour
{

    public FoodType foodType; 
    

    void OnTriggerEnter(Collider other)
    {
        
        Player player = other.GetComponent<Player>(); 

        if (player != null)
        {
            
            player.PickUpFood(foodType); 

            
            Destroy(gameObject); 
        }
    }
}
