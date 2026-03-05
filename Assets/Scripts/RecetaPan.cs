using UnityEngine;
[CreateAssetMenu(fileName = "NuevaReceta", menuName = "Panaderia/Receta")]
public class RecetaPan : ScriptableObject
{
    public string nombre;

    public float hidratacionIdeal;

    public float amasadoIdeal;
    public float fermentacionIdeal;

    public float temperaturaIdeal;
    public float coccionIdeal;
}
