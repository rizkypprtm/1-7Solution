# 1-7Solution


1> 
- The code is checking nested null conditions to make sure the application.application.protected, and application.protected.shieldLastRun 
  are not null before returning application.protected.shieldLastRun.
- The protected variable make ambigous call with modifier protected, so coulb be better to rename it(protecteds)

2>
- Hardcdoed Values: The values for Path and Name are hardcoded . it might be better to pass them as parameters to the method.
- Return Type: The method returns the ApplicationInfo,i think it might be lack of information about it's method. Ensure that this class accurately represents the required information and is properly documented for its purpose, i rename it to (ApplicationInfoNo2 class and     GetApplicationInfoNo2 method)

3>
- Encapsulation method on Os property as private make better control for  modification.

4>
- The sample code seems to be an example of a memory leak scenario where objects are keep added to a list without ever removing it,
  that object make memory consumption over time. To improve it and prevent memory leaks,make sure that unnecessary references to objects are not kept.
  in provided solution i use "myList = null"

5>
- is sample code current implementation, every EventSubscriber subscribes to the MyEvent event of the EventPublisher. but, these subscribers are never unsubscribed, which can lead to memory leaks over time.

6>
- in sample code implementation, it has no mechanism to remove the TreeNode objects once they are added to the tree. I
- Creating or addi large number of nodes in each iteration of the loop can decrease performance, especially if the tree becomes very large.

7>
The sample code doesn't have an error handling for where a key is not found in the cache (Get method). 

