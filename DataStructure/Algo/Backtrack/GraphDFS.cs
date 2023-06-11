using System.Collections.ObjectModel;

namespace DataStructure.Algo.Backtrack;
/// <summary>
/// 图的深度优先遍历
/// </summary>
public class GraphDFS
{
    public interface Graph
    {
        int getE();
        int getV();
        bool hasEdge(int v, int w);
        Collection<int> adj(int v);

        int degree(int v);

    }
    
    public List<int> dfs(Graph g)
    {
        List<int> res = new List<int>();
        bool[] visited = new bool[g.getV()];
        for (int i = 0; i < g.getV(); i++)
        {
            if (!visited[i])
            {
                dfs(g,i,res,visited);
            }
        }

        return res;
    }

    //递归遍历
    private void dfs(Graph graph, int v, List<int> res, bool[] visited)
    {
        res.Add(v);
        visited[v] = true;
        foreach (var i in graph.adj(v))
        {//树最多两个相邻的顶点,但图呢有很多个相邻的定点，所以需要循环遍历
            if (!visited[i])
            {
                dfs(graph, i, res, visited);
            }
        }
    }
}