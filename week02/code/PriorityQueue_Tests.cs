using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add one item to the queue and then dequeue it
    // Expected Result: Returns the item that was added
    // Defect(s) Found: None. Test passes.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Add multiple items to the queue and then dequeue them in order of priority
    // Expected Result: Item with the highest priority is returned first, followed by the next highest, and so on
    // Defect(s) Found: Dequeue returns wrong item. Loop condition stops before last element: 
    // "for (int index = 1; index < _queue.Count - 1; index++)" should be 
    // "for (int index = 1; index < _queue.Count; index++)"
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 3);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Throws an InvalidOperationException
    // Defect(s) Found: None. Test passes.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Add items, dequeue one, verify it was removed, add more, dequeue again
    // Expected Result: Dequeue removes items from queue, second dequeue gets next highest priority
    // Defect(s) Found: Two bugs found:
    // 1. Item is never removed from queue: missing "_queue.RemoveAt(highPriorityIndex);"
    // 2. Loop condition issue: "index < _queue.Count - 1" stops before last
    public void TestPriorityQueue_ItemActuallyRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 10);
    
        var first = priorityQueue.Dequeue();
        Assert.AreEqual("B", first);
    
        var second = priorityQueue.Dequeue();
        Assert.AreEqual("A", second);
    }
}