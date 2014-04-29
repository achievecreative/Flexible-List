Flexible-List
=============

A property editor for umbraco 7.0.2 +

I have used this in one of project. Have two buildin providers:

1. Member Groups Selector - List all member groups
2. Children Node Selector - List all children of current node


Create more list provider
=============

1. Create a new class that inherit from __DatasourceProvider__ class
2. Give provide a unique name
3. Overwrite Query(int currentNodeId, string propertyAlias) method

> 1. currentNodeId - The current node id
2. propertyAlias - The property alias name


