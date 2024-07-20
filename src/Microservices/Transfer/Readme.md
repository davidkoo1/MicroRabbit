EF migration
 - **Add:** Add-Migration "InitialCreate" -Context TransferDbContext -Project MicroRabbit.Transfer.Api -StartupProject MicroRabbit.Transfer.Api
 - **Update:**  update-database -Context TransferDbContext -Project MicroRabbit.Transfer.Api -StartupProject MicroRabbit.Transfer.Api
	- 
	- 
1. Select MicroRabbit.[Name].Api
2. Run
3. ConsolePackeg > Select [Name]DbContext Solution(Data/Infrastructure)
	Ex: MicroRabbit.Banking.Infrastructure
4. Add-Migration "Initial[Name]" -Context [Name]DbContext
	Ex: Add-Migration "InitialTransferDb" -Context TransferDbContext
5. update-database -Context [Name]DbContext
	Ex: Update-Database -Context TransferDbContext