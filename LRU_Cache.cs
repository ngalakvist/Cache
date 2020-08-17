using System;
using System.Collections.Generic;

namespace Cache
{
	internal class LRU_Cache
	{

		public static int MAX_SIZE = 10;
		public Node head;
		public Node tail;
		public new Dictionary<string, Node> map;
		public int size = 0;

		public LRU_Cache()
		{
			map = new Dictionary<string, Node>();
		}
		public void moveToFront(Node node)
		{
			if (node == head)
			{
				return;
			}
			removeFromLinkedList(node);
			node.next = head;
			if (head != null)
			{
				head.prev = node;
			}
			head = node;
			size++;

			if (tail == null)
			{
				tail = node;
			}
		}

		public void moveToFront(String query)
		{
			Node node;
			map.TryGetValue(query, out node);
			moveToFront(node);
		}

		public void removeFromLinkedList(Node node)
		{
			if (node == null)
			{
				return;
			}

			if (node.next != null || node.prev != null)
			{
				size--;
			}

			Node prev = node.prev;
			if (prev != null)
			{
				prev.next = node.next;
			}

			Node next = node.next;
			if (next != null)
			{
				next.prev = prev;
			}

			if (node == head)
			{
				head = next;
			}

			if (node == tail)
			{
				tail = prev;
			}

			node.next = null;
			node.prev = null;
		}

		public string[] getResults(string query)
		{
			if (map.ContainsKey(query))
			{
				Node node;
				map.TryGetValue(query, out node);
				moveToFront(node);
				return node.results;
			}
			return null;
		}

		public void insertResults(string query, string[] results)
		{
			if (map.ContainsKey(query))
			{
				Node nodeGetCurrent;
				map.TryGetValue(query, out nodeGetCurrent);
				nodeGetCurrent.results = results;
				moveToFront(nodeGetCurrent);
				return;
			}

			Node newNode = new Node(query, results);
			moveToFront(newNode);
			map.Add(query, newNode);

			if (size > MAX_SIZE)
			{
				map.Remove(tail.query);
				removeFromLinkedList(tail);
			}
		}
	}
}