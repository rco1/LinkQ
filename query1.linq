<Query Kind="Statements">
  <Connection>
    <ID>91ce79fc-fb43-43c3-99f6-7b5434a09636</ID>
    <Persist>true</Persist>
    <Server>RANDELL\SQL2014</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//sample for entity subset
//sample of entity avigation from child to parent
//remider that cod is c# and thus appropriate methods can be used .equals
from x in Customers
where x.SupportRepIdEmployee.FirstName.Equals("Jane") && x.SupportRepIdEmployee.LastName.Equals("Peacock")
select new{
		Name = x.LastName + ' ' + x.FirstName,
		City = x.City,
		State = x.State,
		Phone = x.Phone,
		Email = x.Email
		};
//use agregrate
//count() count the number of instances of the collection references
//Sum totals a specific firld thus will likely need to use a deligate
from x in Albums
orderby x.Title ascending
where x.Tracks.Count() > 0
select new {Title = x.Title,
			TrackCount = x.Tracks.Count(),
			TotalPrice = x.Tracks.Sum(y => y.UnitPrice)
			}
			
			
from x in Albums
orderby x.Title ascending
where x.Tracks.Count() > 0
select new {AlbumTitle = x.Title,
			TrackCount = x.Tracks.Count(),
			TotalPrice = x.Tracks.Sum(y => y.UnitPrice),
			AverageTime = x.Tracks.Average(y =>y.Milliseconds/1000)};
			
			
from x in MediaTypes.Take(1)
orderby x.Tracks.Count() descending
select new {MediaType = x.Name,TractCount = x.Tracks.Count()};

//when you need to use multiple step to solve the problem 
//switch your choice to either statemnt or program
//the results of each queries will now be saved in a variable.
//the variable can be use in future queries.
var maxcount = (from x in MediaTypes select x.Tracks.Count()).Max();

var popularmediatype = (from x in MediaTypes
						where x.Tracks.Count() == maxcount
						select new{Type = x.Name ,
									TCount = x.Tracks.Count()});
popularmediatype.Dump();
// to display the context of a variable in a linq pad 
//use the method .Dump
//can this set of statements be done as one complete query.
//the answer i possibly, and in this case yes
from x in MediaTypes
where x.Tracks.Count() = (from y in MediaTypes
						select y.Tracks.Count()).Max()
select new {MediaType = x.Name}

//using the method syntax to determin he count value for the where expression
//this demonstrated that queries can be constructed using both query syntax abd method syntax