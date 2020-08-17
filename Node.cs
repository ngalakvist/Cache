namespace Cache
{
  public class Node
  {
		public Node prev;
		public Node next;
		public string[] results;
		public string query;

		public Node(string q, string[] res)
		{
			results = res;
			query = q;
		}
	}
}