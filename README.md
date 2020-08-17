# Cache
LRU Cache for a Single System
System Requirements
When designing the cache, we know we'll need to support two primary functions:

1) Efficient lookups given a key.
2) Expiration of old data so that it can be replaced with new data.

• A linked list would allow easy purging of old data, by moving "fresh" items to the front. We could implement
it to remove the last element of the linked list when the list exceeds a certain size.

• A hash table allows efficient lookups of data, but it wouldn't ordinarily allow easy data purging.

In addition, we must also handle updating or clearing the cache when the results for a query change.
Because some queries are very common and may permanently reside in the cache, we cannot just wait for
the cache to naturally expire
