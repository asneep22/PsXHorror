using NaughtyAttributes;
using UnityEngine;

public class Path : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        if (transform.childCount == 0)
            return;

    }

    public PathPoint[] GetPathPoints()
    {
        return GetComponentsInChildren<PathPoint>();
    }

    [Button]
    public void CreatePoint()
    {
        GameObject path_point = new GameObject();
        path_point.AddComponent<PathPoint>();
        path_point.transform.position = transform.childCount == 0 ? transform.position : transform.GetChild(transform.childCount - 1).transform.position;
        path_point.transform.SetParent(transform);

        if (transform.childCount > 1)
            transform.GetChild(transform.childCount - 2).GetComponent<PathPoint>().NextPathPoint = path_point.GetComponent<PathPoint>();
    }

    [Button]
    public void CreateEndPoint()
    {
        if (transform.childCount < 1)
            throw new System.Exception("You can't create end path point. Please, create path point before");

        GameObject path_point = new GameObject();
        path_point.AddComponent<EndPathPoint>();
        path_point.transform.position = transform.childCount == 0 ? transform.position : transform.GetChild(transform.childCount - 1).transform.position;
        path_point.transform.SetParent(transform);

       transform.GetChild(transform.childCount - 2).GetComponent<PathPoint>().NextPathPoint = path_point.GetComponent<PathPoint>();
    }
}
