using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAutoMove : MonoBehaviour
{
    public List<Transform> Goal = new List<Transform>();
   
    public float Speed = 100f;
    public float RolationSpeed = 100f;
    public GameObject Ball;
    int key = 0;
    // Start is called before the first frame update
    void Move(int key)
    {
        transform.position = Vector3.MoveTowards(transform.position, Goal[key].position, Speed * Time.deltaTime * Time.deltaTime);
    }
    void Rolate()
    {
        Ball.transform.Rotate(new Vector3(1, 1, 1)*RolationSpeed);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rolate();
        Move(key);
        //if (Vector3.Distance(transform.position, GoalXYZ[key]) <= 0.01)
        //{
        //    tran
        //    if sform.position = GoalXYZ[key++];(key < Goal.Count - 1)
        //    {
        //        key = 0;
        //    }
        //}
        if (transform.position == Goal[key].position) { key++; }
        if (key > 3) key = 0;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Goal[key].position);
    }
}
