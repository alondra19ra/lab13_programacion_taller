using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Vectorio : MonoBehaviour
{
    [Header("General Settings")]
    public float TimeToDestroy = 0.1f;
    public bool chaseTarget = false;

    [Header("Line Settings")]
    public float lineWidth = 0.1f;
    public Color lineColor = Color.white;

    private LineRenderer lineRenderer;
    private Vector3? startPosition;
    private Vector3? endPosition;
    private float timer;
    private bool active;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.textureMode = LineTextureMode.Stretch;
        lineRenderer.sortingOrder = -1;
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        timer = 0f;
        active = true;
    }

    void Update()
    {
        if (!active) return;

        timer += Time.deltaTime;
        if (timer >= TimeToDestroy)
        {
            Hide();
        }
    }

    public void Set(Vector3 start, Vector3 end, Color color, float timeToDestroy = 0.1f, float width = 0.1f)
    {
        startPosition = start;
        endPosition = end;
        lineColor = color;
        lineWidth = width;
        TimeToDestroy = timeToDestroy;

        ApplyLineSettings();
        DrawLine(startPosition.Value, endPosition.Value);
        gameObject.SetActive(true);
    }

    public void SetCircle(Vector3 center, float radius, Color color, float timeToDestroy = 0.1f, int segments = 50, float width = 0.05f)
    {
        lineColor = color;
        lineWidth = width;
        TimeToDestroy = timeToDestroy;

        ApplyLineSettings();
        DrawCircle(center, radius, segments);
        gameObject.SetActive(true);
    }

    private void ApplyLineSettings()
    {
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    private void DrawLine(Vector3 start, Vector3 end)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.loop = false;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

    private void DrawCircle(Vector3 center, float radius, int segments)
    {
        lineRenderer.positionCount = segments + 1;
        lineRenderer.loop = true;

        for (int i = 0; i <= segments; i++)
        {
            float angle = Mathf.Deg2Rad * (360f / segments) * i;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            lineRenderer.SetPosition(i, center + new Vector3(x, y, 0f));
        }
    }

    private void Hide()
    {
        active = false;
        gameObject.SetActive(false);
    }
}
