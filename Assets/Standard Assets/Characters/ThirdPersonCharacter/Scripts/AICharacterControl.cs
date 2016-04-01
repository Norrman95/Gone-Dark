using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;
                                    // target to aim for

            

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            agent.enabled = false;
            agent.updateRotation = false;
            agent.updatePosition = true;


            
            
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            //if (GameObject.Find("Player").GetComponent<playermovement>().spotted)
            //tanken är att den ska kolla om spotted blir true inne i playermovement scriptet
            //Denna raycasten nedanför är bara fiendens synfält

            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, fwd, 10))
            {
                agent.enabled = true;
                print("he saw ya");

            }


            //if (agent.remainingDistance > agent.stoppingDistance)
            //    character.Move(agent.desiredVelocity, false, false);
            //else
            //    character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
