// Unity C# Script: Clean Code Basics Exercise
//
// AUFGABENSTELLUNG:
// Dieses Script enthält mehrere Verstöße gegen Clean Code Prinzipien. Ihre Aufgabe ist es,
// den Code so zu refaktorisieren, dass er den Grundlagen von Clean Code entspricht. Achten
// Sie dabei auf die Benennung, die Strukturierung des Codes und die allgemeine Lesbarkeit.
//
// HINWEISE:
// - Benutzen Sie aussagekräftige und eindeutige Namen für Variablen und Methoden.
// - Verwenden Sie CamelCase für lokale Variablen und Methodennamen, PascalCase für öffentliche 
//   Variablen und Methoden.
// - Vermeiden Sie Abkürzungen in Namen, es sei denn, sie sind allgemein verständlich.
// - Benutzen Sie Booleans mit Präfixen wie 'is', 'has', 'can', um die Lesbarkeit zu verbessern.
// - Organisieren Sie Ihren Code logisch und sorgen Sie für eine klare Struktur.
//
// BAD CODE:

using UnityEngine;

public class codeExample_good : MonoBehaviour
{
    public float Speed = 10f;



    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveToLeft();
        }
    }

    private void MoveToLeft()
    {
        Vector3 positionToMove = transform.position + Vector3.left * Speed * Time.deltaTime;
        transform.position = positionToMove;  
    }
}
