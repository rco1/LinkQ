<Query Kind="Statements">
  <Connection>
    <ID>6c99ccee-4727-4072-90e6-da8e0a9c1ea1</ID>
    <Persist>true</Persist>
    <Server>RANDELL\SQL2014</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var maxbills = (from x in Waiters
				where x.Bills.Count == ((from y in Waiters select y.Bills.Count()).Max())
				select new{Name = x.FirstName + " " + x.LastName, BillNumber = x.Bills.Count()});
				
maxbills.Dump();
//var maxbills = (from y in Waiters select y.Bills.Count()).Max();

//create a data set wich contains the summary bills by waiter
var WaiterBill = (from x in Waiters
					orderby x.LastName,x.FirstName
					select new {Name = x.LastName + " " + x.FirstName,
								BillInfo = (from y in Bills
											where y.BillItems.Count() > 0
											select new {BillID = y.BillID,
														BillDate  = y.BillDate,
														TableID = y.TableID,
														Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)})}
														);
WaiterBill.Dump();