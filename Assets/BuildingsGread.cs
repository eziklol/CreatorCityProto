using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BuildingsGread : MonoBehaviour
{
    public Vector2Int GreadSize = new Vector2Int(10, 10);

    private Building[,] grid;
    public Building thisBuilding;
    [SerializeField] private GameObject resource;
    
    

    private Camera mainCamera;
    private void Awake()
    {
        grid = new Building[GreadSize.x, GreadSize.y];
        mainCamera = Camera.main;
        
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        
        if (thisBuilding != null)
        {
            Destroy(thisBuilding.gameObject);
        }
        if (
            (resource.GetComponent<Resourse>().derevo >= buildingPrefab.GetComponent<Building>().resourseForest) &&
            (resource.GetComponent<Resourse>().kamen >= buildingPrefab.GetComponent<Building>().resourseStone)
            )
        {
            thisBuilding = Instantiate(buildingPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
            if (thisBuilding != null)
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                    {



                    var groundPlane = new Plane(Vector3.up, Vector3.zero);
                    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);


                    if (groundPlane.Raycast(ray, out float position))
                    {
                        Vector3 worldPosition = ray.GetPoint(position);

                        int x = Mathf.RoundToInt(worldPosition.x);
                        int y = Mathf.RoundToInt(worldPosition.z);

                        bool available = true;

                        if (x < 0 || x > (GreadSize.x - thisBuilding.Size.x)) { available = false; }
                        if (y < 0 || y > (GreadSize.y - thisBuilding.Size.y)) { available = false; }

                        if (available && IsPlaceTaken(x, y)) available = false;

                        thisBuilding.transform.position = new Vector3(x, 0, y);
                        thisBuilding.SetTransparent(available);

                        if (available && Input.GetMouseButtonDown(0))
                        {
                            resource.GetComponent<Resourse>().derevo -= thisBuilding.GetComponent<Building>().resourseForest;
                            resource.GetComponent<Resourse>().kamen -= thisBuilding.GetComponent<Building>().resourseStone;
                            PlaceFlyingBuilding(x, y);
                        }

                    }
                
            }
        }
    }


    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < thisBuilding.Size.x; x++)
        {
            for (int y = 0; y < thisBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }



    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < thisBuilding.Size.x; x++)
        {
            for (int y = 0; y < thisBuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = thisBuilding;
            }
        }
        thisBuilding.SetNormal();
        thisBuilding = null;
    }
    public void OnDrawGizmosSelected()
    {
        for (int x = 0; x < GreadSize.x; x++)
        {
            for (int y = 0; y < GreadSize.y; y++)
            {
                Gizmos.color = new Color(0.33f, 0f, 0.66f, 0.7f);
                Gizmos.DrawCube( new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
            }
        }
    }
}
