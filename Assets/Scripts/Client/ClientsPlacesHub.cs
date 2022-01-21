using System.Linq;
using UnityEngine;

namespace Client
{
    public class ClientsPlacesHub : MonoBehaviour
    {
        [SerializeField] private Transform exitPoint;
        
        private ClientsPlace[] _clientsPlaces;
        
        private static ClientsPlacesHub _instance;

        public static ClientsPlacesHub Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<ClientsPlacesHub>();
                return _instance;
            }
        }

        private void Awake() => _clientsPlaces = FindObjectsOfType<ClientsPlace>();

        public bool HasEmptyPlace() => _clientsPlaces.Any(clientsPlace => !clientsPlace.IsReserved);

        public ClientsPlace GetEmptyPlace()
        {
            foreach (var clientsPlace in _clientsPlaces)
            {
                if (clientsPlace.IsReserved) continue;
                
                clientsPlace.SetReserved(true);
                return clientsPlace;
            }

            return null;
        }
        
        public Transform GetExitPoint() => exitPoint;
    }
}
