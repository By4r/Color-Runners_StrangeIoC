using System.Linq;
using Runtime.Data.ValueObject;
using strange.extensions.command.impl;
using UnityEngine;

namespace Runtime.Controller.PlayerControllers
{
    public class ForceBallsToPoolCommand : Command
    {
        [Inject] public Transform manager { get; set; }
        [Inject] public PlayerForceData ForceData { get; set; }

        private readonly string _collectable = "Collectable";


        public override void Execute()
        {
            var transform1 = manager.transform;
            var position1 = transform1.position;
            var forcePos = new Vector3(position1.x, position1.y - 1f, position1.z + .9f);

            var collider = Physics.OverlapSphere(forcePos, 1.7f);

            var collectableColliderList = collider.Where(col => col.CompareTag(_collectable)).ToList();

            foreach (var col in collectableColliderList)
            {
                if (col.GetComponent<Rigidbody>() == null) continue;
                var rb = col.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0, ForceData.ForwardForceCounter.x, ForceData.ForwardForceCounter.y),
                    ForceMode.Impulse);
            }

            collectableColliderList.Clear();
        }
    }
}