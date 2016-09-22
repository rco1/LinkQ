<Query Kind="Statements">
  <Connection>
    <ID>cef92e1b-6169-4e53-ba73-7111739ad484</ID>
    <Persist>true</Persist>
    <Server>RANDELL\SQL2014</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

var EmployeeReqSkill = 
	(from x in Skills
	where RequiresTicket = true
	select {x.EmployeeSkills.Count()})
EmployeeReqSkill.Dump()