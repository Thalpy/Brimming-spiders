using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshgen : MonoBehaviour
{

    Mesh mesh;
    public Material material;

    Vector3[] Vertices;
    Vector3[] Normals;
    Vector2[] newUV;
    int[] Triangles;

    int xSize = 200;
    int zSize = 200;
    float xExtents;
    float zExtents;



    // Start is called before the first frame update
    void Start()
    {



        xExtents = xSize / 2;
        zExtents = zSize / 2;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = material;

        MakeShape();


        mesh.vertices = Vertices;
        mesh.uv = newUV;
        
        mesh.triangles = Triangles;
        mesh.RecalculateNormals();



    }

    // Update is called once per frame
    
    void MakeShape()
    {
        Vertices = new Vector3[(xSize + 1) * (zSize + 1)];


        
        for (int i = 0,z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                Vertices[i] = new Vector3(x - xExtents, Gety(x - xExtents, z - zExtents), z - zExtents); //Gety(x - xExtents, z - zExtents)
                i++;
            }

        }



        newUV = new Vector2[(xSize + 1) * (zSize + 1)];
               
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                newUV[i] = new Vector3(x - xExtents, z - zExtents);
                i++;
            }

        }



       

        Triangles = new int[xSize * zSize * 6];
        int verts = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                Triangles[tris + 0] = verts + 0;
                Triangles[tris + 1] = verts + xSize + 1;
                Triangles[tris + 2] = verts + 1;
                Triangles[tris + 3] = verts + 1;
                Triangles[tris + 4] = verts + xSize + 1;
                Triangles[tris + 5] = verts + xSize + 2;
                verts++;
                tris += 6;
            }
            verts++;
        }
    }


    public float zstart = -110;
    public float zend = -90;
    public float xstart = -4;
    public float xend = 4;
    public float entrancefadefactor = 100;
    float entrancefade;
    public float y0scale = 10;



    float Gety(float x, float z)
    {
        float y = 1;

        entrancefade = x * x - (xstart + xend) * x + xstart * xend + z * z - (zstart + zend) * z + zstart * zend;

        entrancefade = Mathf.Clamp(entrancefade, 0, entrancefadefactor)/ entrancefadefactor;

        y = Mathf.Sin(y0scale*(x + Mathf.Sin(z)));


        y *= entrancefade;


        








        return (y);
    }


    void Update()
    {

        Random.InitState(1234);

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                Vertices[i] = new Vector3(x - xExtents, Gety(x - xExtents, z - zExtents), z - zExtents); //Gety(x - xExtents, z - zExtents)
                i++;
            }

        }

        mesh.vertices = Vertices;
        mesh.RecalculateNormals();



    }



}
