using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils
{
    /// <summary>
    /// class for draw one line in game view
    /// </summary>
    public class LineDrawer
    {
        private LineRenderer _lineRenderer;
        private float _lineSize;
        private bool _initialized;

        public LineDrawer()
        {
            Init();
        }

        public void Init(float lineSize = 0.05f)
        {
            if (_initialized) return;
            
            var lineObj = new GameObject("LineObj");
            _lineRenderer = lineObj.AddComponent<LineRenderer>();

            _lineRenderer.material = new Material(Shader.Find("Hidden/Internal-Colored"));

            _lineSize = lineSize;
            _initialized = true;
        }

        //Draws lines through the provided vertices
        public void DrawLineInGameView(Vector3 start, Vector3 end, Color color)
        {

            //Set color
            _lineRenderer.startColor = color;
            _lineRenderer.endColor = color;

            //Set width
            _lineRenderer.startWidth = _lineSize;
            _lineRenderer.endWidth = _lineSize;

            //Set line count which is 2
            _lineRenderer.positionCount = 2;

            //Set the position of both two lines
            _lineRenderer.SetPosition(0, start);
            _lineRenderer.SetPosition(1, end);
        }

        public void Destroy()
        {
            if (_lineRenderer != null)
            {
                Object.Destroy(_lineRenderer.gameObject);
            }
        }
    }
}