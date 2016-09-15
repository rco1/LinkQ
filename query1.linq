<Query Kind="Expression">
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
			AverageTime = x.Tracks.Average(y =>y.Milliseconds/1000)}