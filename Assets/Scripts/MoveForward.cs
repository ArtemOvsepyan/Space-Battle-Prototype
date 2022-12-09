using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 10;    

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);        
    }


}
