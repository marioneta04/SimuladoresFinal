using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SimuladorPan : MonoBehaviour
{
    public RecetaPan[] recetas;
    public RecetaPan recetaActual;

    [Header("UI")]
    public TMP_Dropdown dropdownReceta;

    public TMP_InputField inputHarina;
    public TMP_InputField inputAgua;

    public Slider sliderAmasado;
    public Slider sliderFermentacion;
    public Slider sliderTemperatura;
    public Slider sliderCoccion;

    public TMP_Text textoCalidad;
    public TMP_Text textoResultado;

    public TextMeshProUGUI hidratacionIdealText;
    public TextMeshProUGUI amasadoIdealText;
    public TextMeshProUGUI fermentacionIdealText;
    public TextMeshProUGUI temperaturaIdealText;
    public TextMeshProUGUI coccionIdealText;

    void Start()
    {
        recetaActual = recetas[0];
        MostrarRecetaIdeal(recetaActual);
    }

    public void CambiarReceta(int index)
    {
        Debug.Log("Cambio de receta: " + index);
        recetaActual = recetas[index];

        MostrarRecetaIdeal(recetaActual);
    }

    void MostrarRecetaIdeal(RecetaPan receta)
    {
        hidratacionIdealText.text = "Hidratación: " + receta.hidratacionIdeal + "%";
        amasadoIdealText.text = "Amasado: " + receta.amasadoIdeal + " min";
        fermentacionIdealText.text = "Fermentación: " + receta.fermentacionIdeal + " min";
        temperaturaIdealText.text = "Temperatura: " + receta.temperaturaIdeal + " °C";
        coccionIdealText.text = "Cocción: " + receta.coccionIdeal + " min";
    }
    public void CalcularResultado()
    {
        float harina = float.Parse(inputHarina.text);
        float agua = float.Parse(inputAgua.text);

        float amasado = sliderAmasado.value;
        float fermentacion = sliderFermentacion.value;
        float temperatura = sliderTemperatura.value;
        float coccion = sliderCoccion.value;

        float hidratacion = (agua / harina) * 100f;

        float errorHidratacion = Mathf.Abs(hidratacion - recetaActual.hidratacionIdeal);
        float errorAmasado = Mathf.Abs(amasado - recetaActual.amasadoIdeal);
        float errorFermentacion = Mathf.Abs(fermentacion - recetaActual.fermentacionIdeal);
        float errorTemperatura = Mathf.Abs(temperatura - recetaActual.temperaturaIdeal);
        float errorCoccion = Mathf.Abs(coccion - recetaActual.coccionIdeal);

        float errorTotal = errorHidratacion + errorAmasado + errorFermentacion + errorTemperatura + errorCoccion;

        float calidad = Mathf.Clamp(100 - errorTotal, 0, 100);

        string resultado = "";

        if (hidratacion < recetaActual.hidratacionIdeal - 5)
            resultado += "Falta agua en la masa\n";

        else if (hidratacion > recetaActual.hidratacionIdeal + 5)
            resultado += "Exceso de agua en la masa\n";


        if (amasado < recetaActual.amasadoIdeal - 2)
            resultado += "Falta amasado\n";

        else if (amasado > recetaActual.amasadoIdeal + 2)
            resultado += "Demasiado amasado\n";


        if (fermentacion < recetaActual.fermentacionIdeal - 5)
            resultado += "Fermentación insuficiente\n";

        else if (fermentacion > recetaActual.fermentacionIdeal + 5)
            resultado += "Fermentación excesiva\n";


        if (temperatura < recetaActual.temperaturaIdeal - 15)
            resultado += "Temperatura del horno demasiado baja\n";

        else if (temperatura > recetaActual.temperaturaIdeal + 15)
            resultado += "Temperatura del horno demasiado alta\n";


        if (coccion < recetaActual.coccionIdeal - 3)
            resultado += "Falta tiempo de cocción\n";

        else if (coccion > recetaActual.coccionIdeal + 3)
            resultado += "Exceso de cocción\n";

        if (resultado == "")
        {
            if (calidad > 90)
                resultado = "Pan perfecto";
            else if (calidad > 70)
                resultado = "Buen pan";
            else if (calidad > 50)
                resultado = "Pan aceptable";
            else
                resultado = "Pan mediocre";
        }

        PlayerPrefs.SetFloat("CalidadPan", calidad);
        PlayerPrefs.SetString("ResultadoPan", resultado);

        SceneManager.LoadScene(2);
    }
}
