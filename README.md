Order Management API

This API can be used to Manage orders for the logged in user.

The API has following end points

1. GET/api/Order/getOrders/{userid}
Param : {userId} 

This End point fetches all the orders for the logged in user.

2. POST/api/Order

request example {id:guid,name:string,description:string,userId,guid}
adds the record to the orders table .

3. PUT/api/Order/id
request example {id:guid,name:string,description:string,userId,guid}
updates the record to the orders table .

4. DELETE/api/Order/id/userId
  request example {id:guid,name:string,description:string,userId,guid}
deletes the record from order table.

Technology Stack : 
.Net Core Web API
Entity Framework core

Dependencies :
Mapster.
