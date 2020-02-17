# Interview

Interview solution
------------------

This is my implementation of the repository implementation. 

I have kept it simple for the first iteration and would love the opportunity to discuss the requirements further and enhance the solution through another cycle of development and testing which is in line with the needs of the cutomer.

Points to note:
1. A Storable entity has been defined as a passenger class containing an Id acting as the primary key and a string containing the passenger's name. This can be enhanced to cater for for categories of passengers as part of an inheritance heirachy depending on the requirements.
2. The data access code is curently in the Repository implementation to keep the first iteration simple. The data access layer can be abstracted out into a separate interface (e.g. IModel containing functions such as Add, Remove, FindById) that can be implementated for different types of data stores and injected into the Repository class.
3. More work is required to optimise the handling of a large data store. Abstracting out the data access layer will help in achieving this by encapsulating the data operations into a separate class allowing different strategies for searching and sorting to be implemented.
4. Making the operations asynchronous would make any applications using the repository more responsive and as such there is a need to create async data access operations.


