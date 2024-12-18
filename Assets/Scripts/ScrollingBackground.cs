using UnityEngine;
using UnityEngine.Tilemaps;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f; // Velocidad de desplazamiento
    private Tilemap tilemap;
    private Vector3Int tilemapSize;
    private Vector3 offset;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapSize = tilemap.size; // Obtener el tamaño del Tilemap
        offset = new Vector3(tilemapSize.x * tilemap.cellSize.x, 0, 0); // Calcular el desplazamiento inicial
    }

    void Update()
    {
        // Desplazar el fondo a la izquierda
        transform.position -= new Vector3(scrollSpeed * Time.deltaTime, 0, 0);

        // Reiniciar la posición del fondo cuando salga de la vista
        if (transform.position.x <= -offset.x)
        {
            transform.position += offset;
        }
    }
}
