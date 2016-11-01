using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

namespace Assets.Project.Scripts
{
    public class Generate : MonoBehaviour
    {
        const string ArtFolder = "Art/";
        readonly List<GameObject> _artObjectsList = new List<GameObject>();

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                TakeScreenShot();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                GenerateCubeArt();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                ClearArt();
            }
        }

        void ClearArt()
        {
            foreach (var o in _artObjectsList)
            {
                Destroy(o);
            }
            _artObjectsList.Clear();
        }

        void TakeScreenShot()
        {
            Application.CaptureScreenshot(ArtFolder + DateTime.Now.Ticks + ".jpg", 2);
        }

        void GenerateCubeArt()
        {
            const int n = 10000;
            const float spread = n/25f;
            
            for (int i = 0; i < n; i++)
            {
                var go = CreateCube(spread, 10);
                go.transform.parent = transform;
                _artObjectsList.Add(go);
            }
        }

        GameObject CreateCube(float spread, float scale)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Random.insideUnitSphere * spread;
            cube.transform.rotation = Random.rotation;
            cube.transform.localScale = Vector3.one*scale;
            var rend = cube.GetComponent<Renderer>();
            rend.material.color = Random.ColorHSV(0, 1);
            rend.receiveShadows = false;
            rend.shadowCastingMode = ShadowCastingMode.Off;
            cube.GetComponent<Collider>().enabled = false;
            return cube;
        }
    }
}
