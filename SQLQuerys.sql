use Circus

alter trigger TG_Age_Animal
on Animals
for insert, update
as
	declare @Id int, @Age int, @Date date
	select @Date = Birthday, @Id = Id from Animals
	where id = (select Id from inserted)
	set @Age = DATEDIFF(yy, @Date, GetDate())

	update Animals
	set Age = @Age
	where Id = @Id
go

alter trigger TG_Actor_Insert
on Users
for insert
as
	declare @Id int, @IdRole int
	select @Id = Id, @IdRole = IdRole from Users
	where id = (select Id from inserted)
	if @IdRole = 2
	begin
		insert Actor values
		(@Id, 1, 0)
	end
go

alter trigger TG_Actor_Delete
on Users
for delete
as
	declare @Id int
	select @Id = Id from deleted

	delete Actor
	where Id = @Id

alter trigger TG_QuantityEvent
on ScheduleEvent
for insert, update, delete
as
	declare @IdEmp int, @Quan int, @SQL_Command nchar(10)	  
 	IF NOT EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)  
 	 	SET @SQL_Command = 'DELETE' 
	if @SQL_Command = 'DELETE'
	begin
		select @IdEmp = IdEmployee from deleted
	end
	else
	begin
		select @IdEmp = IdEmployee from inserted
	end

	select @Quan = isnull(count(Id), 0) from ScheduleEvent
	group by IdEmployee
	having IdEmployee = @IdEmp

	update Actor
	set QuantityEvent = @Quan
	where Id = @IdEmp
	
	if @Quan >= 5
	begin
		update Actor
		set IdStatus = 3
	end
	else if @Quan >= 3
	begin
		update Actor
		set IdStatus = 2
	end
	else
	begin
		update Actor
		set IdStatus = 1
	end
go

create trigger TG_Promoter
on ScheduleEvent
for insert
as
	declare @IdComp int
	select @IdComp = IdPromoter from inserted

	if @IdComp = 1
	begin
		update ScheduleEvent
		set Prepayment = 0
		where IdPromoter = @IdComp
	end
go

create trigger TG_Profit
on ScheduleEvent
for insert
as
	declare @Prepayment money, 
			@Expenses money, 
			@TicketsProfit money, 
			@Profit money
	select @Prepayment = Prepayment, @Expenses = Expenses,
		@TicketsProfit = TicketsProfit from inserted
	set @Profit = @Prepayment - @Expenses + @TicketsProfit
	update ScheduleEvent
	set Profit = @Profit
	where Id = (select Id from inserted)
go