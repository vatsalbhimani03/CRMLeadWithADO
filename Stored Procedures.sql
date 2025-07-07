-- Get lead data stored procedure
create procedure dummyGetAllLeads as
begin 
select * from dummyCRMLeads
end
-- fetch data
exec dummyGetAllLeads




exec dummyCreateLeads 5, '8/12/23', 'Rob', 'Rob@yahoo.com', '9123123413', 'Web' , 'Open', '8/12/23'

exec dummyGetAllLeads
-- Create Leads
create procedure dummyCreateLeads 
@Id int,
@LeadDate datetime,
@Name varchar(50),
@EmailAddress varchar(50),
@Mobile varchar(10), 
@LeadSource varchar(50), 
@LeadStatus varchar(10),
@NextFollowUpDate datetime
as
begin 
	INSERT INTO dummyCRMLeads(Id, LeadDate, Name ,EmailAddress, Mobile, LeadSource ,LeadStatus, NextFollowUpDate)
	VALUES (@Id, @LeadDate, @Name, @EmailAddress, @Mobile, @LeadSource, @LeadStatus, @NextFollowUpDate) 
end

-- deleting procedure
drop procedure dummyCreateLeads


