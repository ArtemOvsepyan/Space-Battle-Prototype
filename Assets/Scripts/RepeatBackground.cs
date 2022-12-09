using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private readonly float boxColliderRemain = 50;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.y - boxColliderRemain;
    }

    // Update is called once per frame
    void Update()
    {
        RepeatLevel();
    }
    private void RepeatLevel()
    {
        if (transform.position.y < startPos.y - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
