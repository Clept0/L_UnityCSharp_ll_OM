// Unity C# Script: Refactoring Exercise for YAGNI and KISS Principles
//
// AUFGABENSTELLUNG:
// Dieses Script demonstriert unnötig komplexe und überladene Ansätze zur Lösung einfacher Probleme,
// die mit dem Bewegen eines Spielobjekts in einer Spielszene verbunden sind. Ihre Aufgabe ist es,
// den Code gemäß den YAGNI- und KISS-Prinzipien zu refaktorisieren. Entfernen Sie überflüssige
// Komplexitäten und optimieren Sie den Code, um die gleiche Funktionalität mit einfacheren und
// direkteren Methoden zu erreichen.
//
// HINWEISE:
// - Beachten Sie die Verwendung von Designmustern, die nicht erforderlich sind.
// - Achten Sie auf Methoden, die mehr tun, als sie sollen.
// - Vereinfachen Sie die Logik, wo immer es möglich ist.
// - Vermeiden Sie die Verwendung unnötiger Variablen und Schleifen.
// - Arbeiten Sie mit einem Duplicat dieses Scripts im goodCode-Folder und belassen Sie dieses
//   im orig.Zustand im badCode-Folder.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexMovement_good : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToPosition(new Vector3(0, 0, 10));
        }
    }

    private void MoveToPosition(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
    }
}
