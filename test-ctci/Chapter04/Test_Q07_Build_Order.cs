using System;
using System.Collections.Generic;
using Xunit;
using CH_04._Trees_and_Graphs;
using lib_ctci;

namespace test_ctci
{
    public class Test_Chapter04_Q7_Build_Order
    {
        private Q07_Build_Order buildOrder = new Q07_Build_Order();

        [Fact]
        public void BuildOrder()
        {
            Q07_Graph graph1 = new Q07_Graph();

            graph1.GetOrCreateByName("a");
            graph1.GetOrCreateByName("b");
            graph1.GetOrCreateByName("c");
            graph1.GetOrCreateByName("d");
            graph1.GetOrCreateByName("e");
            graph1.GetOrCreateByName("f");

            graph1.AddConnectionsByName("a", "d");
            graph1.AddConnectionsByName("f", "b");
            graph1.AddConnectionsByName("b", "d");
            graph1.AddConnectionsByName("f", "a");
            graph1.AddConnectionsByName("d", "c");

            Assert.Equal(new string[]{"e", "f", "b", "a", "d", "c"}, buildOrder.GetOrder(graph1));

            Q07_Graph graph2 = new Q07_Graph();

            graph2.GetOrCreateByName("a");
            graph2.GetOrCreateByName("b");
            graph2.GetOrCreateByName("c");
            graph2.GetOrCreateByName("d");
            graph2.GetOrCreateByName("e");
            graph2.GetOrCreateByName("f");

            graph2.AddConnectionsByName("a", "d");
            graph2.AddConnectionsByName("f", "b");
            graph2.AddConnectionsByName("c", "d");
            graph2.AddConnectionsByName("d", "e");
            graph2.AddConnectionsByName("b", "d");
            graph2.AddConnectionsByName("f", "a");
            graph2.AddConnectionsByName("f", "c");

            Assert.Equal(new string[]{"f", "b", "a", "c", "d", "e"}, buildOrder.GetOrder(graph2));

            Q07_Graph graph3 = new Q07_Graph();

            graph3.GetOrCreateByName("a");
            graph3.GetOrCreateByName("b");
            graph3.GetOrCreateByName("c");
            graph3.GetOrCreateByName("d");
            graph3.GetOrCreateByName("e");
            graph3.GetOrCreateByName("f");

            graph3.AddConnectionsByName("a", "d");
            graph3.AddConnectionsByName("f", "b");
            graph3.AddConnectionsByName("c", "d");
            graph3.AddConnectionsByName("d", "e");
            graph3.AddConnectionsByName("b", "d");
            graph3.AddConnectionsByName("f", "a");
            graph3.AddConnectionsByName("f", "c");
            graph3.AddConnectionsByName("d", "b");

            Assert.Null(buildOrder.GetOrder(graph3));
        }
    }
}