<Query Kind="Expression">
  <Connection>
    <ID>91ce79fc-fb43-43c3-99f6-7b5434a09636</ID>
    <Persist>true</Persist>
    <Server>RANDELL\SQL2014</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in Albums
select new {Title = x.Title,TrackCount = x.Tracks.TrackId.count()}