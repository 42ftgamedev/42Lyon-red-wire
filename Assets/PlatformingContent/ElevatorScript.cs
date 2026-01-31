using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform finish;

    bool touched = false;
    Vector3 p;
    Transform _currentTarget;
    float _speed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float DistanceToEnd = Vector3.Distance(transform.position, finish.position);
        float DistanceToStart = Vector3.Distance(transform.position, start.position);

        if (touched == true)
        {
            _currentTarget = finish;
        }
        else if (touched == false)
        {
            _currentTarget = start;
        }
        if (touched == true || DistanceToStart != 0f)
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        touched = true;
        if (other.tag == "Character")
        {
            other.transform.parent = this.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        touched = false;
        if (other.tag == "Character")
        {
            other.transform.parent = null;
        }
    }
}
