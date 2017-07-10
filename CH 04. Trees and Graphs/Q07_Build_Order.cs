using System;
using System.Collections.Generic;
using lib_ctci;

namespace CH_04._Trees_and_Graphs
{
    public class Q07_Build_Order
    {
        public string[] GetOrder(Q07_Graph graph)
        {
            List<Q07_Project> projectsByOrder = new List<Q07_Project>();

            AddNonDependent(projectsByOrder, graph.Graph);

            int toBeProcessed = 0;
            while (toBeProcessed < graph.Graph.Count)
            {
                if (projectsByOrder.Count <= toBeProcessed)
                {
                    return null;
                }

                Q07_Project current = projectsByOrder[toBeProcessed];

                foreach (Q07_Project project in current.Connections)
                {
                    project.DecrementDependencies();
                }

                AddNonDependent(projectsByOrder, current.Connections);

                toBeProcessed++;
            }

            string[] result = new string[projectsByOrder.Count];
            for (int i = 0; i < projectsByOrder.Count; i++)
            {
                result[i] = projectsByOrder[i].Name;
            }

            return result;
        }

        protected void AddNonDependent (List<Q07_Project> projectsByOrder, List<Q07_Project> projects)
        {
            foreach (Q07_Project project in projects)
            {
                if (project.Dependencies == 0)
                {
                    projectsByOrder.Add(project);
                }
            }
        }
    }

    public class Q07_Project
    {
        protected string name;
        protected List<Q07_Project> connections = new List<Q07_Project>();
        protected int dependencies = 0;

        public Q07_Project(string name)
        {
            this.name = name;
        }

        public void AddConnection(Q07_Project project)
        {
            connections.Add(project);
            project.IncrementDependencies();
        }

        public void IncrementDependencies()
        {
            dependencies++;
        }

        public void DecrementDependencies()
        {
            dependencies--;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Dependencies
        {
            get
            {
                return dependencies;
            }
        }

        public List<Q07_Project> Connections
        {
            get
            {
                return connections;
            }
        }
    }

    public class Q07_Graph
    {
        protected List<Q07_Project> graph = new List<Q07_Project>();

        public void AddConnectionsByName(string parentName, string childName)
        {
            Q07_Project childProject = GetOrCreateByName(childName);
            Q07_Project parentProject = GetOrCreateByName(parentName);

            parentProject.AddConnection(childProject);
        }

        public Q07_Project GetOrCreateByName(string name)
        {
            foreach (Q07_Project current in graph)
            {
                if (current.Name == name)
                {
                    return current;
                }
            }

            Q07_Project project = new Q07_Project(name);
            graph.Add(project);

            return project;
        }

        public List<Q07_Project> Graph
        {
            get
            {
                return graph;
            }
        }
    }
}