using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities
    // Expected Result: Dequeue returns items in descending priority order
    // Defect(s) Found: Original code did not remove items and had incorrect priority comparison
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 7);
        pq.Enqueue("D", 5);

        // Expected order: C (7), A (5), D (5), B (2)
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Original code did not handle empty queue correctly in all cases
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Expected InvalidOperationException not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority
    // Expected Result: First inserted item with highest priority dequeued first (FIFO)
    // Defect(s) Found: Original code used >= and picked last item instead of first
    public void TestPriorityQueue_FifoWithSamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 3);
        pq.Enqueue("Y", 5);
        pq.Enqueue("Z", 5); // Same priority as Y
        pq.Enqueue("W", 1);

        // Y should come out before Z because they have same priority
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("W", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue and Dequeue only one item
    // Expected Result: Item is returned and queue is empty afterwards
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Solo", 10);

        // Dequeue the only item
        Assert.AreEqual("Solo", pq.Dequeue());

        // Queue should now be empty — Dequeue should throw
        try
        {
            pq.Dequeue();
            Assert.Fail("Expected InvalidOperationException not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
