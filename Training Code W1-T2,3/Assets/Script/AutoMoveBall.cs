using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveBall : MonoBehaviour
{
    ////{ public GameObject oball;
    ////    public GameObject cot1;
    ////    public GameObject cot2;
    ////    public GameObject cot3;
    ////    public GameObject cot4;
    ////    public Transform dichuyen;
    ////    public Vector3 toadoball;
    ////    public Vector3 toadocot1;
    ////    public Vector3 toadocot2;
    ////    public Vector3 toadocot3;
    ////    public Vector3 toadocot4;
    ////    //public int[] tocota = { 1, 2,3,4 };
    ////    void Dilai1()
    ////    {
    ////        transform.position = transform.position + (toadocot1 - transform.position) / 300;
    ////    }

    ////    void Dilai(Vector3 toadocot)
    ////    {
    ////        transform.position = transform.position + (toadocot - transform.position) / 300;
    ////    }

    ////    // Start is called before the first frame update
    ////    void Start()
    ////    {
    ////        toadoball=oball.transform.position;
    ////        toadocot1 = cot1.transform.position;
    ////        toadocot2 = cot2.transform.position;
    ////        toadocot3 = cot3.transform.position;
    ////        toadocot4 = cot4.transform.position;
    ////    }
    ////    // Update is called once per frame
    ////    void Update()
    ////    {/*
    ////      * 
    ////        transform.LookAt(dichuyen);
    ////        Dilai1();
    ////        Dilai2();
    ////        Dilai3();
    ////        Dilai4();
    ////        Dilai5();
    ////        */
    ////        //if (transform.position == toadocot) { break; }
    ////        bool flag1, flag2, flag3, flag4;
    ////        if (transform.position == toadoball)
    ////        {
    ////            for (int i = 0; i < 1000; i++)
    ////            {if(transform.position == toadocot1) { break; }
    ////                Dilai(toadocot1);
    ////            }
    ////        }
    ////        if (transform.position == toadocot1)
    ////        {
    ////            for (int i = 0; i < 1000; i++)
    ////            {
    ////                if (transform.position == toadocot2) { break; }
    ////                Dilai(toadocot2);
    ////            }
    ////        }
    ////        if (transform.position == toadocot2)
    ////        {
    ////            for (int i = 0; i < 1000; i++)
    ////            {
    ////                if (transform.position == toadocot3) { break; }
    ////                Dilai(toadocot3);
    ////            }
    ////        }
    ////        if (transform.position == toadocot3)
    ////        {
    ////            for (int i = 0; i < 1000; i++)
    ////            {
    ////                if (transform.position == toadocot4) { break; }
    ////                Dilai(toadocot4);
    ////            }
    ////        }
    ////        if (transform.position == toadocot4)
    ////        {
    ////            for (int i = 0; i < 1000; i++)
    ////            {
    ////                if (transform.position == toadocot1) { break; }
    ////                Dilai(toadocot1);
    ////            }
    ////        }

    ////    }


    ////    }

    //using System.Collections;
    //using System.Collections.Generic;
    //using UnityEngine;

    //public class AutoMoveBall : MonoBehaviour {
    //    public GameObject oball;
    //    public GameObject[] destinaion;
    //    public Vector3 initBallXYZ;
    //    public Vector3[] destinationXYZ;
    //    int key = 0;

    //    //AutoMoveBall() {
    //    //    oball = new GameObject();
    //    //    destinaion = new GameObject[0];
    //    //    initBallXYZ = new Vector3();
    //    //    destinationXYZ = new Vector3[0];
    //    //}
    //    //AutoMoveBall(GameObject oball, GameObject[] destination, Vector3 initBallXYZ, Vector3[] destinationXYZ) {
    //    //    this.oball = oball;
    //    //    this.destinaion = destination;
    //    //    this.initBallXYZ = initBallXYZ;
    //    //    this.destinationXYZ = destinationXYZ;
    //    //}

    //    public void Move(Vector3 destination) {
    //        transform.position = transform.position + (destination - transform.position) / 300;
    //    }

    //    private void Start() {
    //        //AutoMoveBall autoMoveBall = new AutoMoveBall();
    //        //float X = 0, Y = 0, Z = 0;
    //        //initBallXYZ = new Vector3(X, Y, Z);
    //        int numberOfDestination = 4;
    //        destinaion = new GameObject[numberOfDestination];
    //        //for (int i = 0; i < numberOfDestination; i++)
    //        //{
    //        //    destinaion[i].transform.position = new Vector3(X++, Y++, Z++);
    //        //}
    //        destinationXYZ = new Vector3[numberOfDestination];
    //        for (int i = 0; i < numberOfDestination; i++)
    //        {
    //            destinationXYZ[i] = destinaion[i].transform.position;
    //        }
    //    }
    //    //private void Start(GameObject oball, GameObject[] destination, Vector3 initBallXYZ, Vector3[] destinationXYZ)
    //    //{
    //    //    AutoMoveBall autoMoveBall = new AutoMoveBall(oball, destination, initBallXYZ, destinationXYZ);
    //    //}

    //    bool CheckDestination(Vector3 check, Vector3 destinationXYZ) {
    //        if (check == destinationXYZ) return true;
    //        else return false;
    //    }

    //    private void Update() {
    //        if (CheckDestination(transform.position, destinationXYZ[key])) key++;
    //        Move(destinationXYZ[key]);
    //    }


    //}
    public List<Transform> waypoint = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f;
    private int lastWayPointIndex;

    public float speed;
    private float rotationSpeed = 2.2f;
    private void Start()
    {
        targetWaypoint = waypoint[targetWaypointIndex];
        lastWayPointIndex = waypoint.Count - 1;
    }
    // Update is called once per frame
    void Update()
    {

        float movement = speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWayPoint(distance);
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movement);

        float rotationStep = rotationSpeed * Time.deltaTime;
        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);
    }

    void CheckDistanceToWayPoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWayPoint();
        }
    }

    void UpdateTargetWayPoint()
    {
        if (targetWaypointIndex > lastWayPointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoint[targetWaypointIndex];
    }

    //implement_gizmos
    private void OnDrawGizmos()
    {
        for (int i = 0; i <= waypoint.Count; i++)
        {
            if (i < waypoint.Count - 1)
            {
                if (waypoint.Count > 0)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawLine(waypoint[i].position, waypoint[i + 1].position);
                }
            }
        }
    }
}