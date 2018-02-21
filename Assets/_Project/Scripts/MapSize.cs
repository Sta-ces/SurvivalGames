using UnityEngine;

public class MapSize : MonoBehaviour {

    [Range(3f, 20f)]
    public float m_Size = 5f;
    public string m_ChildLayer;


    private void Start()
    {
        GenerateMap("Wall_North", new Vector3(m_Size, 1, 1), new Vector3(0, .5f, m_Size *.5f));
        GenerateMap("Wall_South", new Vector3(m_Size, 1, 1), new Vector3(0, .5f, -m_Size * .5f));
        GenerateMap("Wall_East", new Vector3(1, 1, m_Size), new Vector3(-m_Size * .5f, .5f, 0));
        GenerateMap("Wall_West", new Vector3(1, 1, m_Size), new Vector3(m_Size * .5f, .5f, 0));
    }


    private void GenerateMap(string _nameWall, Vector3 _scale, Vector3 _position)
    {
        GameObject wall = new GameObject(_nameWall);
        wall.transform.parent = transform;
        wall.transform.position = _position;
        wall.transform.localScale = _scale;
        wall.AddComponent<BoxCollider>();
        wall.layer = LayerMask.NameToLayer(m_ChildLayer);
    }
}
