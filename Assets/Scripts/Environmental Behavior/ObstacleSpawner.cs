using UnityEngine;

/*
 * use this script on player
*/

public class ObstacleSpawner : MonoBehaviour
{
    //x coordinate of the gameObject the furthest away from the player
    private float furthestRightPosition;

    #region Properties
    //use only one object and apply texture in script
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Sprite[] obstacleTextures;

    [SerializeField] private float minObstacleDistance;
    [SerializeField] private float maxObstacleDistance;
    [SerializeField] private float obstacleToPlayerDistance;
    [SerializeField] private float startingDistance;
    #endregion

    private bool firstObstacle = true;
    void Update()
    {
        if (furthestRightPosition - transform.position.x < obstacleToPlayerDistance)
        {
            spawnObstacle(Random.Range(0, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y));
        }
    }

    private void spawnObstacle(float spawnHeight)
    {
        //randomize distance between obstacles
        float xSpawnPos = transform.position.x + Random.Range(minObstacleDistance, maxObstacleDistance);
        if (firstObstacle)
        {
            xSpawnPos += startingDistance;
            firstObstacle = false;
        }

        //randomize rotation
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));  

        GameObject newObstacle = Instantiate(obstacle, new Vector2(xSpawnPos, spawnHeight), rotation);
        furthestRightPosition = xSpawnPos;

        //apply random texture
        newObstacle.GetComponent<SpriteRenderer>().sprite = obstacleTextures[Random.Range(0, obstacleTextures.Length)];

    }
}
