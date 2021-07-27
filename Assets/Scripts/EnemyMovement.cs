using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent Agent;
    [SerializeField]
    private Transform Player;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void GoToTarget()
    {
        Agent.SetDestination(Player.position);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(25, 25, 300, 50), "Move Enemy To Target"))
        {
            GoToTarget();
        }
    }
}
