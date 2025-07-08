-- Get lead data stored procedure
create procedure dummyGetAllLeads as
begin 
select * from dummyCRMLeads
end
-- fetch data
exec dummyGetAllLeads




exec dummyCreateLeads 7, '8/12/23', 'Rob', 'Rob@yahoo.com', '9123123413', 'Web' , 'Open', '8/12/23'

exec dummyGetAllLeads


-- Create Leads
Alter procedure dummyCreateLeads 
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



-- getting data procedure
create procedure dummyGetLeads 
@Id int
as
begin 
	select Id , LeadDate, Name , EmailAddress, Mobile, LeadSource, LeadStatus, NextFollowUpDate 
	from dummyCRMLeads where Id = @Id
end

exec dummyGetLeads 9

-- updating data procedure
create procedure dummyUpdateLeads 
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
	UPDATE dummyCRMLeads SET 
		LeadDate = @LeadDate, 
		Name =@Name,
		EmailAddress = @EmailAddress, 
		Mobile = @Mobile, 
		LeadSource = @LeadSource,
		LeadStatus = @LeadStatus, 
		NextFollowUpDate = @NextFollowUpDate
	Where Id = @Id
end


-- Deleting the data

create procedure dummyDeleteLeads
@Id int
AS
BEGIN
	DELETE FROM dummyCRMLeads where Id = @Id
END

exec dummyDeleteLeads 9
exec dummyDeleteLeads 10
exec dummyGetAllLeads