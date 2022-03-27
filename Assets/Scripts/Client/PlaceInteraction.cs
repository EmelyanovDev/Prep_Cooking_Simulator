using Interactions;
using Items;
using UnityEngine;

namespace Client
{
    [RequireComponent(typeof(ClientsPlaceEvaluation))]
    [RequireComponent(typeof(ClientsPlaceOrdering))]
    public class PlaceInteraction : MonoBehaviour, IPutItem
    {
        [SerializeField] private Transform clientsPlace;
        [SerializeField] private Transform placePoint;
        
        private ClientsPlaceEvaluation _clientsEvaluation;
        private ClientsPlaceOrdering _clientsOrdering;
        private ClientMovement _client;
        private Item _placedItem;
        private bool _isReserved;

        public bool IsReserved => _isReserved;
        public Transform PlacePoint => placePoint;

        private void Awake()
        {
            _clientsEvaluation = GetComponent<ClientsPlaceEvaluation>();
            _clientsOrdering = GetComponent<ClientsPlaceOrdering>();
        }
        
        private void OnEnable()
        {
            _clientsEvaluation.FreeUpSpace += FreeUpPlace;
        }

        private void OnDisable()
        {
            _clientsEvaluation.FreeUpSpace -= FreeUpPlace;
        }

        public void CreateNewOrder()
        {
            _clientsOrdering.CreateNewOrder();
        }

        public void SetReserved(bool condition)
        {
            _isReserved = condition;
        }

        public Vector3 PutItem(Item item)
        {
            _placedItem = item;
            StartCoroutine(_clientsEvaluation.TryEvaluateOrder(_placedItem));

            return placePoint.position;
        }
        
        public bool CanPutItem()
        {
            return _placedItem == null && _clientsEvaluation.RecipeIsCreated;
        }
        
        public Vector3 TakePlace(ClientMovement client)
        {
            _client = client;
            
            return clientsPlace.position;
        }
        
        private void FreeUpPlace()
        {
            _isReserved = false;
            _placedItem = null;
            _client.FreeUpPlace();
            _client = null;
        }
    }
}
