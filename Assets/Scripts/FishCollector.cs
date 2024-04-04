using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;


public class FishCollector : MonoBehaviour
{
    // Store a single list of fishies
    public List<GameObject> fishies = new List<GameObject>();

    // Store the prefab: fish
    [SerializeField] private GameObject fish;

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
            mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            GameObject newFish = Instantiate<GameObject>(fish);
            newFish.transform.position = worldPos;
            fishies.Add(newFish);
        }
    }
}
