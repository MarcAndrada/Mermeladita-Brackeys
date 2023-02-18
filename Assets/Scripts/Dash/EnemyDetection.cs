using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {
    [SerializeField] private GameObject[] enemies;

    private void Awake() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void FixedUpdate() {
        FindClosestEnemy();
    }

    void FindClosestEnemy() {
        float distanceToNearestEnemy = Mathf.Infinity;
        GameObject nearestEnemy = null;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 mouseInWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        foreach (GameObject currentEnemy in enemies) {
            float dist = (currentEnemy.transform.position - mouseInWorldPos).sqrMagnitude;

            if (dist < distanceToNearestEnemy) {
                distanceToNearestEnemy = dist;
                nearestEnemy = currentEnemy;
            }
        }
        Debug.DrawLine(mouseInWorldPos, nearestEnemy.transform.position);
    }
}
