using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAuto : MonoBehaviour {
    public float speed = 7000f;
    public List<GameObject> Goal = new List<GameObject>();
    public GameObject Ball;
    List<Vector3> GoalXYZ = new List<Vector3>();
    Vector3 BallXYZ;
    int key = 0;
    public float countStepPerFrame = 0;
    public List<Vector3> Step = new List<Vector3>();
    MoveAuto() {
        Ball = new GameObject();
        BallXYZ = new Vector3();
    }

    public void Move(int key) {
        //transform.position += Step[key];
        transform.position = Vector3.MoveTowards(transform.position, GoalXYZ[key], speed * Time.deltaTime * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start() {
        GoalXYZ.Add(transform.position);
        for (int i = 0; i < Goal.Count; i++) {
            GoalXYZ.Add(Goal[i].transform.position);
        }
        //Step.Add((GoalXYZ[0] - transform.position) / speed);
        //for (int i = 1; i < GoalXYZ.Count; i++) {
        //    Step.Add((GoalXYZ[i] - GoalXYZ[i - 1]) / speed);
        //}
    }
    bool CheckGoal(Vector3 check, Vector3 Goals)
    {
        if (check == Goals) return false;
        else return true;
    }
    // Update is called once per frame
    void Update() {
        Move(key);
        if (transform.position == GoalXYZ[key]) key += 1;
        if (key > 4) key = 0;
    }
}
