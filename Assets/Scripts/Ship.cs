using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Take a reference of component
    private Ocean fishInScene;
    // Current fish being targeted;
    private GameObject target;
    // Current direction being impulsed towards to
    private Vector3 direction;
    // Get the component of the RigidBody for impulse
    private Rigidbody2D rb;
    // Get the component of the HUD
    private HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        fishInScene = Camera.main.GetComponent<Ocean>();
        rb = GetComponent<Rigidbody2D>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnMouseDown is called when the user has pressed the mouse button while over the Collider.
    IEnumerator OnMouseDown()
    {
        while (fishInScene.fishInOcean.Count != 0)
        {
            // Function that propels the ship to the nearest fish
            findNearestFish();

            // Wait until boat stops
            yield return new WaitUntil(() => rb.velocity.magnitude < 0.1f);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // A check to make sure its actually hitting the right target 
        if(other.gameObject == target)
        {
            // Get the reference of Fish
            Fish fishTarget = target.GetComponent<Fish>();

            // Good capture, stores the point to the hud to present
            hud.AddPoints(fishTarget.PointValue);
            Debug.Log("Points being added: " + fishTarget.PointValue);

            // Destroy fish
            fishTarget.destroyFish();

            // If they touch, remove the target fish from the list
            fishInScene.fishInOcean.Remove(other.gameObject);

            // Set the velocity to 0;
            rb.velocity = Vector2.zero;
            Debug.Log("bang!");
        }
    }

    // Function that finds the nearest fish relative to the ship
    void findNearestFish()
    {
        // Start with the first element in fishList
        target = fishInScene.fishInOcean.First();
        // Start with the distance of the first fish
        float nearestDistance = Vector3.Distance(transform.position, target.transform.position);

        foreach (GameObject fish in fishInScene.fishInOcean)
        {
            // Store the comparing distance of the other fish
            float comparingDistance = Vector3.Distance(transform.position, fish.transform.position);
            // Compare distances
            if(comparingDistance < nearestDistance)
            {
                // Set the nearestDistance
                nearestDistance = comparingDistance;
                // Set new target
                target = fish;
            }
        }

        // Get direction
        direction = (target.transform.position - transform.position).normalized;
        // Blast off
        rb.AddForce(direction * 5f, ForceMode2D.Impulse);
    }
}