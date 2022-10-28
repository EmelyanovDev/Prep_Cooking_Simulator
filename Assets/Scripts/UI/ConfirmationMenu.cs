using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ConfirmationMenu : MonoBehaviour
    {
        private Money _money;

        private void Awake()
        {
            _money = Money.Instance;
        }

        public void Confirmation()
        {
            _money.ResetMoney();
            string activeScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(activeScene);
        }

        public void Rejection()
        {
            gameObject.SetActive(false);
        }
    }
}