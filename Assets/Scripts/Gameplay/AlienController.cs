using UnityEngine;

public class AlienController : MonoBehaviour
{
    public float time; 
    public GameObject projectile;// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time % time < Time.deltaTime)
       {
           Instantiate(projectile, transform.position, projectile.transform.rotation);
       }
    }
}
