<Query Kind="Expression">
  <Connection>
    <ID>6c99ccee-4727-4072-90e6-da8e0a9c1ea1</ID>
    <Persist>true</Persist>
    <Server>RANDELL\SQL2014</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//this is a multi column group 
//grouping data placed in a local temp dataset for further processing
//.key allows you to have acess to the values to your group keys
//if you have multitle group columns they must be in an annomyouse data type
//to create a DTO tye collection you can use .ToList on a temp dataset
//you can have a custom anonymus data colection by using a nested query

//step A
from food in Items
    group food by new {food.MenuCategoryID, food.CurrentPrice}  into tempdataset
	//step B DTO style dataset
	select new{
				MenuCategoryID = tempdataset.Key.MenuCategoryID,
				CurrentPrice = tempdataset.Key.CurrentPrice,
				FoodItems = from x in tempdataset
							select new{ItemID = x.ItemID,
										FoodDescription = x.Description,
										TimeServed = x.BillItems.Count()}
				}