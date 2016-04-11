    using UnityEngine;
using System;

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
        public static float Sight_Width;
        public static float Sight_Range;


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            agent.enabled = false;
            agent.updateRotation = false;
            agent.updatePosition = true;


            Sight_Range = 25;
            Sight_Width = 90;


        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            // if (GameObject.Find("Player").GetComponent<playermovement>().spotted)
            //tanken är att den ska kolla om spotted blir true inne i playermovement scriptet
            //Denna raycasten nedanför är bara fiendens synfält

            //Vector3 fwd = transform.TransformDirection(Vector3.forward);
            //if (Physics.Raycast(transform.position, fwd, 10))
            //{
            //    agent.enabled = true;
            //    print("he saw ya");

            //}


            if (CanSeePlayer() == true)
            {
                agent.enabled = true;
                //print("he saw ya");
            }
        }

        bool CanSeePlayer()
        {
            Vector3 startVec = transform.position;
            Vector3 startVecFwd = transform.forward;

            RaycastHit hit;
            Vector3 rayDirection = target.transform.position - startVec;
            Debug.DrawRay(transform.position, rayDirection);

            if ((Vector3.Angle(rayDirection, startVecFwd)) < 360 && (Vector3.Distance(startVec, target.transform.position) <= 5))
            {
                return true;
            }

            if ((Vector3.Angle(rayDirection, startVecFwd)) < Sight_Width && (Vector3.Distance(startVec, target.transform.position) <= Sight_Range))
                if (Physics.Raycast(startVec, rayDirection, out hit, 100f))
                {
                    if (hit.transform.tag == "Player")
                        return true;
                    else
                        return false;
                }
            return false;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
