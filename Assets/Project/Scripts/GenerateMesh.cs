using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Project.Scripts
{
    public class GenerateMesh : MonoBehaviour
    {
        public Material Mat;

        void Start()
        {
            const int n = 15000;

            gameObject.AddComponent<MeshRenderer>();
            gameObject.AddComponent<MeshFilter>();
            var gom = gameObject.GetComponent<MeshFilter>();
            gom.mesh.vertices = GetRandVertices(n, 500);
            gom.mesh.triangles = GetOrdList(n).ToArray();
            gameObject.GetComponent<Renderer>().material = Mat;
        }

        private List<int> GetOrdList(int n)
        {
            var lst = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                if (i % 3 == 0) lst.Add(0);
                else lst.Add(i);
            }
            return lst;
        }

        private Vector3[] GetRandVertices(int n, int mult)
        {
            var arr = new Vector3[n];
            arr[0] = Vector3.zero;
            for (int i = 1; i < n; i++)
            {
                arr[i] = GetRandVertex(mult);
            }
            return arr;
        }

        private Vector3 GetRandVertex(float mult)
        {
            return Random.insideUnitSphere*mult;
        }
    }
}