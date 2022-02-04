using Ordering;
using UnityEngine;

namespace Client
{
    [RequireComponent(typeof(ClientsPlaceEvaluation))]
    public class ClientsPlaceOrdering : MonoBehaviour
    {
        private ClientsPlaceEvaluation _clientsEvaluation;
        private OrdersGenerator _ordersGenerator;

        private void Awake()
        {
            _clientsEvaluation = GetComponent<ClientsPlaceEvaluation>();
            _ordersGenerator = OrdersGenerator.Instance;
        }

        public void CreateNewOrder()
        {
            _clientsEvaluation.SetNewOrder(_ordersGenerator.CreateNewOrder());
        }
    }
}
