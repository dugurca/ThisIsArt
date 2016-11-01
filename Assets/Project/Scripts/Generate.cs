using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Project.Scripts
{
    public class Generate : MonoBehaviour
    {
        const string ArtFolder = "Art/";
        void Start ()
        {
            GenerateCubeArt();
        }

        void GenerateCubeArt()
        {
            const int n = 10000;
            const float spread = n/25f;
            var lst = new List<GameObject>();
            for (int i = 0; i < n; i++)
            {
                lst.Add(CreateCube(spread, 10));
            }
            Application.CaptureScreenshot(ArtFolder + DateTime.Now.Ticks + ".png", 4);

            return;
            foreach (var go in lst)
            {
                Destroy(go);
            }
        }

        GameObject CreateCube(float spread, float scale)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Random.insideUnitSphere * spread;
            cube.transform.rotation = Random.rotation;
            cube.transform.localScale = Vector3.one*scale;
            cube.GetComponent<Renderer>().material.color = Random.ColorHSV(0, 1);
            return cube;
        }
    }
}
