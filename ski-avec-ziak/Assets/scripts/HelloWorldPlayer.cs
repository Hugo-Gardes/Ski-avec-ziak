using Unity.Netcode;
using UnityEngine;

namespace HelloWorld
{
    public class HelloWorldPlayer : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Move();
            }
        }

        public void Move()
        {
            if (NetworkManager.Singleton.IsServer)
            {
                if (Input.GetKey(KeyCode.Z)) {
                    transform.Translate(Vector3.forward * 5f * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S)) {
                    transform.Translate(Vector3.back * 5f * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.Q)) {
                    transform.Translate(Vector3.left * 5f * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.D)) {
                    transform.Translate(Vector3.right * 5f * Time.deltaTime);
                }
            }
            else
            {
                SubmitPositionRequestServerRpc();
            }
        }

        [ServerRpc]
        void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = GetRandomPositionOnPlane();
        }

        static Vector3 GetRandomPositionOnPlane()
        {
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        }

        void Update()
        {
            transform.position = Position.Value;
        }
    }
}