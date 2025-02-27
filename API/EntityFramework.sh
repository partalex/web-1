# Create a migrarion
dotnet ef migrations add MigrationName --project Server --startup-project Server

# Update Database
dotnet ef database update --project Server --startup-project Server

# Delete All Migrations
rm -r Server/Migrations
dotnet ef database update 0 --project Server --startup-project Server

# Reverse to a previous migration
dotnet ef database update MigrationName --project Server --startup-project Server
