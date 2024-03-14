using UnityEngine;

public class RaycastController : MonoBehaviour
{
    void Update()
    {
        // Überprüfe, ob die linke Maustaste geklickt wurde
        if (Input.GetMouseButtonDown(0))
        {
            // Erstelle einen Ray von der Kameraposition zur Mausposition
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Führe den Raycast aus
            if (Physics.Raycast(ray, out hit))
            {
                // Ändere die Farbe des getroffenen Objekts zu einer zufälligen Farbe
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = new Color(Random.value, Random.value, Random.value);
                }

                // Schreibe den Namen und die Position des Objekts in die Konsole
                Debug.Log($"Objektname: {hit.collider.gameObject.name}, Position: {hit.transform.position}");

                // Visualisiere den Ray im Editor
                Debug.DrawLine(ray.origin, hit.point, Color.red, 100f);
            }
        }
    }
}
