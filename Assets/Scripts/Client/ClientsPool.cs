using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class ClientsPool : MonoBehaviour
    {
        [SerializeField] private ClientMovement[] clientTemplates;
        [SerializeField] private int startClientsCount;

        private List<ClientMovement> _unActivatedClients = new List<ClientMovement>();

        private static ClientsPool _instance;

        public static ClientsPool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<ClientsPool>();
                return _instance;
            }
        }

        private void Awake()
        {
            for (int i = 0; i < startClientsCount; i++)
            {
                CreateClient(Vector3.zero);
            }
        }

        private void CreateClient(Vector3 position)
        {
            var randomClient = clientTemplates[Random.Range(0, clientTemplates.Length)];
            var client = Instantiate(randomClient, position, Quaternion.identity);
            
            client.gameObject.SetActive(false);
            _unActivatedClients.Add(client);
        }

        public void ActivateClient(Vector3 position)
        {
            if (_unActivatedClients.Count == 0)
            {
                CreateClient(position);
            }

            var client = _unActivatedClients[0];
            client.Activating(position);
            _unActivatedClients.Remove(client);
        }

        public void DeactivateClient(ClientMovement client)
        {
            client.gameObject.SetActive(false);
            _unActivatedClients.Add(client);
        }
    }
}