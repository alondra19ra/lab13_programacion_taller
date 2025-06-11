using System;
using System.Collections.Generic;
using UnityEngine;

public  class DrawVectors  :MonoBehaviour
{
    public static DrawVectors Instance { get; private set; }

    [Header("Settings")]
    public Vectorio vectorPrefab;
    public Transform container;
    public int poolSize = 20;

    private readonly List<Vectorio> vectorPool = new();
    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // Inicializar pool
        for (int i = 0; i < poolSize; i++)
        {
            Vectorio v = Instantiate(vectorPrefab, container);
            v.gameObject.SetActive(false);
            vectorPool.Add(v);
        }
    }

    private Vectorio GetAvailableVectorio()
    {
        for (int i = 0; i < poolSize; i++)
        {
            currentIndex = (currentIndex + 1) % poolSize;
            if (!vectorPool[currentIndex].gameObject.activeSelf)
                return vectorPool[currentIndex];
        }

        // Si todos están ocupados, forzar reutilización del más antiguo
        return vectorPool[currentIndex];
    }

    public void Draw(Vector3 start, Vector3 end, Color color, float duration = 0.1f, float width = 0.1f)
    {
        var vector = GetAvailableVectorio();
        vector.gameObject.SetActive(true);
        vector.Set(start, end, color, duration, width);
    }

    public void DrawDirection(Vector3 origin, Vector3 direction, Color color, float duration = 0.1f, float width = 0.1f)
    {
        var vector = GetAvailableVectorio();
        vector.gameObject.SetActive(true);
        vector.Set(origin, origin + direction, color, duration, width);
    }

    public void DrawCircle(Vector3 center, float radius, Color color, float duration = 0.1f, int segments = 50, float width = 0.05f)
    {
        var vector = GetAvailableVectorio();
        vector.gameObject.SetActive(true);
        vector.SetCircle(center, radius, color, duration, segments, width);
    }

}
