using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarSimulacion()
    {
        SceneManager.LoadScene(1);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
