using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private readonly float topBound = 26;
    private readonly float lowerBound = 9;
    private readonly float sideBound = 16;
   
    // Update is called once per frame
    void Update()
    {
        DestroyExcess();
    }
    private void DestroyExcess()
    {
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > sideBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -sideBound)
        {
            Destroy(gameObject);
        }
    }
}
