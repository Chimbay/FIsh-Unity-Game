using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;


public class Ocean : MonoBehaviour
{
    // Make an object of Fish
    Fish fish;
    // Store all the fishes in the ocean from reference
    public List<GameObject> fishInOcean;

    // Stores the prefab of fishes
    [SerializeField] private GameObject normalFish;
    [SerializeField] private GameObject burningFish;
    [SerializeField] private GameObject explodingFish;

    // Store the position of a mouse click
    private Vector3 mousePos;
    // Store the position of the mouse click relative to the world
    private Vector3 worldPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Call spawn function
            spawnFishAtClickLocation();
        }
    }

    // Function that spawns the fish where you click
    void spawnFishAtClickLocation()
    {
        // Hold the game object of the new fish
        GameObject newFish;
        // Hold a random integer
        int random = Random.Range(1, 4);
        UnityEngine.Debug.Log("Random integer: " + random);

        mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Get a random fish
        switch (random)
        {
            case 1:
                newFish = Instantiate<GameObject>(normalFish);
                newFish.transform.position = worldPos;
                break;
            case 2:
                newFish = Instantiate<GameObject>(explodingFish);
                newFish.transform.position = worldPos;
                break;
            case 3:
                newFish = Instantiate<GameObject>(burningFish);
                newFish.transform.position = worldPos;
                break;
            default:
                newFish = Instantiate<GameObject>(normalFish);
                break;
        }

        fishInOcean.Add(newFish);
    }
}
