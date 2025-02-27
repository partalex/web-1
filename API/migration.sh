#!/bin/bash

# File containing the last migration number
MIGRATION_FILE="migration.txt"

# Read the last migration number
if [ -f "$MIGRATION_FILE" ]; then
    LAST_MIGRATION=$(cat "$MIGRATION_FILE")
else
    echo "Migration file not found!"
    exit 1
fi

# Increment the migration number
NEW_MIGRATION=$((LAST_MIGRATION + 1))

# Create a new migration
dotnet ef migrations add "Migration$NEW_MIGRATION" --project . --startup-project .

# Update the database
dotnet ef database update --project . --startup-project .

# Save the new migration number to the file
echo "$NEW_MIGRATION" > "$MIGRATION_FILE"

echo "Migration $NEW_MIGRATION created and database updated."