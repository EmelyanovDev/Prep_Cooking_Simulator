using UnityEngine;

namespace Client
{
    public class ClientsDestroyer : MonoBehaviour
    {
        private ClientsPool _clientsPool;

        private void Awake() => _clientsPool = ClientsPool.Instance;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out ClientMovement clientMovement))
                _clientsPool.DeactivateClient(clientMovement);
        }
    }
}