using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider), typeof(NavMeshModifierVolume))]
public class NavMeshCostModifierSpeedReductionZone : MonoBehaviour
{
    private NavMeshModifierVolume Volume;

    private void Awake()
    {
        Volume = GetComponent<NavMeshModifierVolume>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent Agent))
        {
            if (Volume.AffectsAgentType(Agent.agentTypeID))
            {
                float CostModifier = NavMesh.GetAreaCost(Volume.area);

                Agent.speed /= CostModifier;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent Agent))
        {
            if (Volume.AffectsAgentType(Agent.agentTypeID))
            {
                float CostModifier = NavMesh.GetAreaCost(Volume.area);

                Agent.speed *= CostModifier;
            }
        }
    }
}
