<Query Kind="Program">
  <Connection>
    <ID>6c99ccee-4727-4072-90e6-da8e0a9c1ea1</ID>
    <Persist>true</Persist>
    <Server>RANDELL\SQL2014</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
//a list of bill counts for all waiters
//this query will create a flat dataset
//the columns are native types(ie int, string,.....)
//one is not concerning with repeated data in a column
//instead of using an aonymus datatype
//we wish to use a definied class definition
	var maxbillcount = (from x in Waiters
					select x.Bills.Count()).Max();
					
	var BestWaiter = from x in Waiters
				where x.Bills.Count() == maxbillcount
				select new WaiterBillCounts{
					Name = x.FirstName + " " + x.LastName,
					TCount = x.Bills.Count()
				};
	BestWaiter.Dump();
	
	var paramMonth = 4;
	var paramYear = 2014;
	var waiterbills = from x in Waiters
						where x.FirstName.Contains("a")
						orderby x.LastName, x.FirstName
						select new WaiterBills{
								Name = x.LastName + ", " + x.FirstName,
								TotalBillCount = x.Bills.Count(),
								BillInfo = (from y in x.Bills
											where y.BillItems.Count() > 0
											&& y.BillDate.Month == DateTime.Today.Month - paramMonth
											&& y.BillDate.Year == paramYear
											select new BillItemSummary{
												BillID = y.BillID,
												BillDate = y.BillDate,
												TableID = y.TableID,
												Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
														}
											).ToList()
									};
	waiterbills.Dump();
				
}

// Define other methods and classes here
//an example of a poco class (flat)
public class WaiterBillCounts
{
	//what ever recieving field on your query in your select
	//appears as a property in this class
	public string Name{get;set;}
	public int TCount{get;set;}
}

public class BillItemSummary
{
	public int BillID {get;set;}
	public DateTime BillDate {get;set;}
	public int? TableID {get;set;}
	public decimal Total {get;set;}
}

//An example of a DTO Class (structured)

public class WaiterBills
{
	public string Name{get;set;}
	public int TotalBillCount{get;set;}
	public List<BillItemSummary> BillInfo {get;set;}
}
