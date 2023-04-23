@echo off
set descricao=%desc
dotnet ef migrations add %desc --project .\BlazingTrails.Api\ -o .\Persistence\Data\Migrations\