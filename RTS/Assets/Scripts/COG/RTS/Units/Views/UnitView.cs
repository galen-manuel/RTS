using UnityEngine;
using UnityEngine.AI;

namespace COG.RTS.Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class UnitView : MonoBehaviour, IDamageable
    {
        public Unit UnitData;

        protected NavMeshAgent _agent;
        protected Transform _transform;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            _agent.updateRotation = false;
            _agent.speed = UnitData.MovementSpeed.Value;
        }

        public void TakeDamage(string pSource, float pAmount, DamageType pDamageType)
        {
            throw new System.NotImplementedException();
        }

        public virtual void SetPosition(Vector3 targetPosition)
        {
            _agent.SetDestination(targetPosition);
        }
    }
}
