# Cache
LRU Cache for a Single System
System Requirements
When designing the cache, we know we'll need to support two primary functions:

Efficient lookups given a key.
Expiration of old data so that it can be replaced with new data.

In addition, we must also handle updating or clearing the cache when the results for a query change.
Because some queries are very common and may permanently reside in the cache, we cannot just wait for
the cache to naturally expire
