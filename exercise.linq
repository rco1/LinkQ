<Query Kind="Statements">
  <Connection>
    <ID>cef92e1b-6169-4e53-ba73-7111739ad484</ID>
    <Persist>true</Persist>
    <Server>RANDELL\SQL2014</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

//Question 1
//Show all skills requiring a ticket and which employees have those skills. 
//Include all the data as seen in the following image. 
var Question1 = 
from x in Skills
where x.RequiresTicket == true
select new {Description = x.Description, 
Item = (from y in EmployeeSkills
where y.SkillID == x.SkillID
orderby y.YearsOfExperience descending
select new {Name = y.Employee.FirstName + ' ' + y.Employee.LastName ,
			Level = y.Level,
			YearsExperience = y.YearsOfExperience}
)
};
Question1.Dump();

//Question 2
//List all skills, alphabetically, showing only the description of the skill. 
var Question2 = 
from x in Skills
orderby x.Description ascending
select new { Description = x.Description};
Question2.Dump();

//Question 3
//List all the skills for which we do not have any qualfied employees. 
var Question3 = 
from x in Skills
orderby x.Description ascending
where x.EmployeeSkills.Count() == 0
select new { Description = x.Description};
Question3.Dump();

//Question 4
//From the shifts scheduled for NAIT's placement contract, show the number
//of employees needed for each day (ordered by day-of-week). Bonus: display
//the name of the day of week (first day being Monday). 
var Question4 = 
from x in Shifts
select new { Days = x.DayOfWeek , EmployeeNeeded = 
(
	
)